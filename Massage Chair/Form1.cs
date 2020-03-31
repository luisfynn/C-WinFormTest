using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Massage_Chair
{
    public partial class Form1 : Form
    {
        protected SerialPort gPort;
       // private bool gPortStart;
        //private bool gStartTimer;
        protected SerialPort GPort { get; set; }

        public bool GPortStart { get; set; }
        public bool GStartTimer { get; set; }

        private List<Byte> gSerialRecv;
        byte[] gSendData;
        private bool gSendBusy;

        /// <summary>
        /// 생성자(constructor)
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 사용자가 프로그램 실행시 호출되는 함수 
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            btnOpen.Text = "connect".ToString();
            GPortStart = false;
            GStartTimer = false;

            gSerialRecv = new List<Byte>();
            gSendData = new byte[35];
            gSendBusy = false;

            ComboBr.Text = "115200";
            ComboDb.Text = "8";

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                ComboParity.Items.Add(s);
            }
            ComboParity.SelectedIndex = 0;
            ComboSb.Text = "1";

            rBtnHexa.Checked = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                 switch(GPortStart)
                {
                    case false:
                        if (gPort == null)
                        {
                            gPort = new SerialPort();
                            gPort.DataReceived += new SerialDataReceivedEventHandler(gPort_DataReceived);
                            gPort.PortName = cboPortName.SelectedItem.ToString();
                            gPort.BaudRate = Convert.ToInt32(ComboBr.Text.ToString());
                            gPort.DataBits = Convert.ToInt32(ComboDb.Text.ToString()) ;
                            gPort.Parity = (Parity)ComboParity.SelectedIndex;
                            gPort.StopBits = (StopBits)ComboSb.SelectedIndex;

                            gPort.ReadTimeout = (int)2000;
                            gPort.WriteTimeout = (int)2000;

                            gPort.Open();
                        }

                        if (gPort.IsOpen)
                        {
                            GPortStart = true;
                            btnOpen.Text = "disconnect";
                            cboPortName.Enabled = false;
                            ComboBr.Enabled = false;
                            ComboDb.Enabled = false;
                            ComboParity.Enabled = false;
                            ComboSb.Enabled = false;

                            gRecvTimer.Start();
                            MessageBox.Show("시리얼 포트를 연결했습니다.");

                            MassageMap.Enabled = true;
                        }
                        else
                        {
                            MassageMap.Enabled = false;
                        }
                        break;
                    case true:
                        GPortStart = false;

                        try
                        {
                            if (gPort.IsOpen)
                            {
                                btnOpen.Text = "connect";
                                cboPortName.Enabled = true;
                                ComboBr.Enabled = true;
                                ComboDb.Enabled = true;
                                ComboParity.Enabled = true;
                                ComboSb.Enabled = true;
                                gRecvTimer.Stop();

                                gPort.DiscardInBuffer();
                                gPort.Dispose();
                                gPort.Close();
                                gPort = null;
                            }
                            /*
                            if (null != gPort)
                            {
                                if (gPort.IsOpen)
                                {
                                    gPort.DiscardInBuffer();
                                    gPort.Dispose();
                                    gPort.Close();
                                    gPort = null;
                                }
                            }
                            */
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    
                        break;
                    default:
                        break;

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string str2hex(string strData)
        {
            string resultHex = string.Empty;
            byte[] arr_byteStr = Encoding.Default.GetBytes(strData);
 
            foreach (byte byteStr in arr_byteStr)
                resultHex += string.Format("{0:X2}", byteStr);
 
            return resultHex;
        }

        private void MorRecvDataTimer_Tick(object sender, EventArgs e)
        {
            // 분석할 데이터가 5개 이하면 return
            if (gSerialRecv.Count < 5) return;

            // STX 확인
            if (gSerialRecv[0] != 0x24)
            {
                //Strings = String.Format("[ERR] STX fail.");
                gSerialRecv.Clear();
                return;
            }

            // 수신 데이터 길이 확인
            Int32 len = gSerialRecv[4];

            if (len + 6 > gSerialRecv.Count)
            {
                return;
            }

            // CheckSum 확인
            Int32 checkSum = 0;
            StringBuilder msg = new StringBuilder();

            for (int i = 0; i < len - 1; i++)
            {
                msg.Append((Char)gSerialRecv[i]);
                checkSum += gSerialRecv[i];
            }

            if ((Byte)(checkSum & 0xFF) != gSerialRecv[len + 5])
            {
                //Strings = String.Format("[ERR] CheckSum fail.");
                gSerialRecv.Clear();
                return;
            }

            // 텍스트박스에 데이터 출력
#if false
            //Strings = String.Format("[RECV] {0}", msg.ToString());
            //txtRec.Text += msg.ToString() + Environment.NewLine;
            //Int32 numVal = Int32.Parse(msg.ToString());
            txtRec.Text += str2hex(msg.ToString());
            //Int16.Parse(checkSum.ToString());
            Int16 numVal = Int16.Parse(checkSum.ToString());
            txtRec.Text += numVal.ToString("X");
            //txtRec.Text += str2hex(Int16.Parse(checkSum.ToString()).ToString());
            txtRec.Text += Environment.NewLine;
            //txtRec.Text += numVal.ToString();
#endif
            if (rBtnChar.Checked)
            {
                txtRec.Text += msg.ToString();
                txtRec.Text += Environment.NewLine;
            }
            else
            {
                txtRec.Text += str2hex(msg.ToString());
                Int16 numVal = Int16.Parse(checkSum.ToString());
                txtRec.Text += numVal.ToString("X");
                txtRec.Text += Environment.NewLine;
            }

            // ACK 전송
            gSendBusy = true;
            /*
            gSendData[0] = Convert.ToByte("24".ToString(), 16);
            gSendData[1] = Convert.ToByte("41".ToString(), 16);
            gSendData[2] = Convert.ToByte("52".ToString(), 16);
            gSendData[3] = Convert.ToByte("03".ToString(), 16);
            gSendData[4] = Convert.ToByte("1d".ToString(), 16);

            gSendData[5] = Convert.ToByte(gSerialRecv[5].ToString(), 16);
            gSendData[6] = Convert.ToByte(gSerialRecv[6].ToString(), 16);
            gSendData[7] = Convert.ToByte(gSerialRecv[7].ToString(), 16);
            gSendData[8] = Convert.ToByte("0", 16);

            try
            {
                if (true == rBtnHexa.Checked)
                {
                    byte checksum = 0;

                    foreach (var s in gSendData)
                    {
                        checksum += gSendData[s];
                    }
                    gSendData[8] = checksum;

                    gPort.Write(gSendData, 0, 9);
                }
                else
                {
                    MessageBox.Show("공사중입니다.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
            gSendBusy = false;
            // 분석한 데이터를 리스트에서 삭제
            gSerialRecv.RemoveRange(0, len + 4);
        }

        private void gPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            for (int i = 0; i < gPort.BytesToRead; i++)
            {
                gSerialRecv.Add((Byte)gPort.ReadByte());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != gPort)
            {
                if (gPort.IsOpen)
                {
                    gPort.Close();
                    gPort.Dispose();
                    gPort = null;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (null != gPort)
            {
                if (gPort.IsOpen)
                {
                    gSendTimer.Stop();
                    gPort.Close();
                    gPort.Dispose();
                    gPort = null;
                }
            }
        }

        //수신 텍스트박스에 기록된 내용 삭제
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRec.Clear();
        }

        //set parity
        private void ComboParity_MouseClick(object sender, MouseEventArgs e)
        {
            ComboParity.Items.Clear();      //clear combobox list

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                ComboParity.Items.Add(s);
            }
        }

        //set stopbits
        private void ComboSb_MouseClick(object sender, MouseEventArgs e)
        {
            ComboSb.Items.Clear();      //clear combobox list

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                ComboSb.Items.Add(s);
            }
        }

        private void cboPortName_MouseClick(object sender, MouseEventArgs e)
        {
            cboPortName.Items.Clear();      //clear combobox list

            foreach (string comport in SerialPort.GetPortNames())
            {
                cboPortName.Items.Add(comport);
            }
        }

        //timer start
        private void Button1_Click(object sender, EventArgs e)
        {
            if(gPort != null && gPort.IsOpen)
            //if (gPort.IsOpen)
            {
                if (GStartTimer == false)
                {
                    GStartTimer = true;
                    button1.Text = "send".ToString();
                    gSendTimer.Start();
                    gRecvTimer.Start();
                }
                else
                {
                    GStartTimer = false;
                    button1.Text = "stop".ToString();
                    gSendTimer.Stop();
                    gRecvTimer.Stop();
                }
            }
            else
            {
                MessageBox.Show("시리얼포트가 연결되지 않았습니다.");
            }
        }

        //send data to remocon every time is elasped
        private void gSendTimer_Tick(object sender, EventArgs e)
        {
            if (gPort.IsOpen == false || gPort == null)
            {
                gSendTimer.Stop();
                MessageBox.Show("시리얼 연결이 끊겼습니다.");
                return;
            }
            if (gSendBusy == true) return;

            //byte[] byteSendData = new byte[35];

            int iSendCount = 35;

            try
            {
                if (true == rBtnHexa.Checked)
                {
                    byte checksum = 0;
                    byte count = 0;

                    foreach (var s in gSendData)
                    {
                        gSendData[0] = Convert.ToByte("24".ToString(), 16);
                        gSendData[1] = Convert.ToByte("41".ToString(), 16);
                        gSendData[2] = Convert.ToByte("52".ToString(), 16);
                        gSendData[3] = Convert.ToByte("02".ToString(), 16);
                        gSendData[4] = Convert.ToByte("1d".ToString(), 16);

                        gSendData[5] = Convert.ToByte(textBox1.Text.ToString(), 16);
                        gSendData[6] = Convert.ToByte(textBox2.Text.ToString(), 16);
                        gSendData[7] = Convert.ToByte(textBox3.Text.ToString(), 16);
                        gSendData[8] = Convert.ToByte(textBox4.Text.ToString(), 16);
                        gSendData[9] = Convert.ToByte(textBox5.Text.ToString(), 16);

                        gSendData[10] = Convert.ToByte(textBox6.Text.ToString(), 16);
                        gSendData[11] = Convert.ToByte(textBox7.Text.ToString(), 16);
                        gSendData[12] = Convert.ToByte(textBox8.Text.ToString(), 16);
                        gSendData[13] = Convert.ToByte(textBox9.Text.ToString(), 16);
                        gSendData[14] = Convert.ToByte(textBox10.Text.ToString(), 16);

                        gSendData[15] = Convert.ToByte(textBox11.Text.ToString(), 16);
                        gSendData[16] = Convert.ToByte(textBox12.Text.ToString(), 16);
                        gSendData[17] = Convert.ToByte(textBox13.Text.ToString(), 16);
                        gSendData[18] = Convert.ToByte(textBox14.Text.ToString(), 16);
                        gSendData[19] = Convert.ToByte(textBox15.Text.ToString(), 16);

                        gSendData[20] = Convert.ToByte(textBox16.Text.ToString(), 16);
                        gSendData[21] = Convert.ToByte(textBox17.Text.ToString(), 16);
                        gSendData[22] = Convert.ToByte(textBox18.Text.ToString(), 16);
                        gSendData[23] = Convert.ToByte(textBox19.Text.ToString(), 16);
                        gSendData[24] = Convert.ToByte(textBox20.Text.ToString(), 16);

                        gSendData[25] = Convert.ToByte(textBox21.Text.ToString(), 16);
                        gSendData[26] = Convert.ToByte(textBox22.Text.ToString(), 16);
                        gSendData[27] = Convert.ToByte(textBox23.Text.ToString(), 16);
                        gSendData[28] = Convert.ToByte(textBox24.Text.ToString(), 16);
                        gSendData[29] = Convert.ToByte(textBox25.Text.ToString(), 16);

                        gSendData[30] = Convert.ToByte(textBox26.Text.ToString(), 16);
                        gSendData[31] = Convert.ToByte(textBox27.Text.ToString(), 16);
                        gSendData[32] = Convert.ToByte(textBox28.Text.ToString(), 16);
                        gSendData[33] = Convert.ToByte(textBox29.Text.ToString(), 16);
                        gSendData[34] = 0;

                        checksum += s;
                        count++;
                    }
                    gSendData[34] = checksum;

                    gPort.Write(gSendData, 0, iSendCount);
                }
                else
                {
                    gPort.Write(gSendData, 0, iSendCount);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gRecvTimer_Tick(object sender, EventArgs e)
        {
            MorRecvDataTimer_Tick(sender, e);
        }

        private void MassageMap_Click(object sender, EventArgs e)
        {
            if (gPort.IsOpen == true)
            {
                Form2 massageMapBox = new Form2();
                massageMapBox.Form2Port1 = gPort;
                massageMapBox.ShowDialog();
            }
            else
            {
                MessageBox.Show("serial port가 연결되지 않았습니다");
            }
        }

        private void btUartTest_Click(object sender, EventArgs e)
        {
            if (gPort.IsOpen == true)
            {
                Form3 uartTestBox = new Form3();
                uartTestBox.Form3Port1 = gPort;
                uartTestBox.ShowDialog();
            }
            else
            {
                MessageBox.Show("serial port가 연결되지 않았습니다");
            }
        }
    }
}
