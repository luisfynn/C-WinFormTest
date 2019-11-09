using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using System.IO.Ports;

namespace Massage_Chair
{
    public partial class Form1 : Form
    {
        private SerialPort _Port;

        bool SendStart = false;
        bool ParseStart = false;

        /// <summary>
        /// 시리얼포트 컨트롤 객체
        /// </summary>
        private SerialPort Port
        {
            get
            {
                if (_Port == null)
                {
                    _Port = new SerialPort();
                    _Port.PortName = "COM1";
                    _Port.BaudRate = 9600;
                    _Port.DataBits = 8;
                    _Port.Parity = Parity.None;
                    _Port.Handshake = Handshake.None;
                    _Port.StopBits = StopBits.One;
                    _Port.DataReceived += Port_DataReceived;
                }
                return _Port;
            }
        }

        /// <summary>
        /// 시리얼포트 상태 및 컨트롤 제어
        /// </summary>
        private Boolean IsOpen
        {
            get { return Port.IsOpen; }
            set
            {
                if (value)
                {
                    Strings = "연결 됨";
                    //SendStart = true;
                    //btConnectControl.Text = "연결 끊기";
                    //tbRecvMessage.Enabled = true;
                    //tbSendMessage.Enabled = true;
                    //btSendMessage.Enabled = true;
                    //gbSettings.Enabled = false;
                }
                else
                {
                    Strings = "연결 해제됨";
                    //SendStart = false;
                    //btConnectControl.Text = "연결";
                    //tbRecvMessage.Enabled = false;
                    //tbSendMessage.Enabled = false;
                    //btSendMessage.Enabled = false;
                    //gbSettings.Enabled = true;
                }
            }
        }

        //private SerialPort gPort;
        //private bool gStartTimer;
        //protected SerialPort GPort { get; set; }
        //public bool GPortStart { get; set; }

        private List<Byte> gSerialRecv;
        byte[] gSendData;
        private bool gSendBusy;

        /* 로그 제어 */
        private StringBuilder _Strings;
        /// <summary>
        /// 로그 객체
        /// </summary>
        private String Strings
        {
            set
            {
                if (_Strings == null)
                    _Strings = new StringBuilder(1024);
                // 로그 길이가 1024자가 되면 이전 로그 삭제
                if (_Strings.Length >= (1024 - value.Length))
                    _Strings.Clear();
                // 로그 추가 및 화면 표시
                _Strings.AppendLine(value);
                txtRec.Text = _Strings.ToString();
            }
        }

        /// <summary>
        /// 생성자(constructor)
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// WinForm Load
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;

            btnOpen.Text = "connect".ToString();
            //GPortStart = false;
            //gStartTimer = false;

            gSerialRecv = new List<Byte>(40);
            //Strings = new String();
            gSendData = new byte[35];
            gSendBusy = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!Port.IsOpen)
            {
                // 현재 시리얼이 연결된 상태가 아니면 연결
                Port.PortName = cboPortName.SelectedItem.ToString();
                Port.BaudRate = Convert.ToInt32(ComboBr.SelectedItem);
                Port.DataBits = 8;
                Port.Parity = Parity.None;
                Port.StopBits = StopBits.One;
                Port.Handshake = Handshake.None;

                try
                {
                    // 연결
                    Port.Open();
                    btnOpen.Text = "연결됨";
                    gRecvTimer.Start();
                }
                catch (Exception ex) { Strings = String.Format("[ERR] {0}", ex.Message); }
            }
            else
            {
                // 현재 시리얼이 연결 상태이면 연결 해제
                Port.Close();
                btnOpen.Text = "연결해제됨";
                gRecvTimer.Stop();
            }

            // 상태 변경
            IsOpen = Port.IsOpen;
            /*
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
                            gPort.BaudRate = Convert.ToInt32(ComboBr.SelectedItem);
                            gPort.DataBits = Convert.ToInt32(ComboDb.SelectedItem) ;
                            gPort.Parity = (Parity)ComboParity.SelectedItem;
                            gPort.StopBits = (StopBits)ComboSb.SelectedItem;

                            gPort.ReadTimeout = (int)500;
                            gPort.WriteTimeout = (int)500;
                            gPort.Open();
                        }

                        if (gPort.IsOpen)
                        {
                            GPortStart = true;
                            MessageBox.Show("시리얼 포트를 연결했습니다.");
                        }
                        else
                        {
                        }
                        break;
                    case true:
                        GPortStart = false;

                        try
                        {
                            if (null != GPort)
                            {
                                if (gPort.IsOpen)
                                {
                                    gPort.DiscardInBuffer();
                                    gPort.Dispose();
                                    gPort.Close();
                                    gPort = null;
                                }
                            }
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
            */
        }

        private void MorRecvDataTimer_Tick(object sender, EventArgs e)
        {
#if false
            // 분석할 데이터가 5개 이하면 return
            if (gSerialRecv.Count < 5) return;
            if (ParseStart == true) return;

            // STX 확인
            if (gSerialRecv[0] != 36)
            {
                Strings = String.Format("[ERR] STX fail.");
                gSerialRecv.Clear();
                return;
            }
            else
            {
                ParseStart = true;
            }

            // 길이 확인
            Byte len = (Byte)(gSerialRecv[4] + 6);
            //if (len + 6 != gSerialRecv.Count) return;
           
            // CheckSum 확인
            Byte checkSum = 0;

            int capacity = 255;
            StringBuilder msg = new StringBuilder(capacity);
   
            for (Byte i = 0; i < len - 1; i++)
            {
                msg.Append(gSerialRecv[i].ToString());
                checkSum += gSerialRecv[i];
            }

            if ((Byte)(checkSum & 0xFF) != gSerialRecv[len - 1])
            {
                Strings = String.Format("[ERR] CheckSum fail.");
                gSerialRecv.Clear();
                return;
            }

            // 데이터 출력
            //Strings = String.Format("[RECV] {0}", msg.ToString());

            // ACK 전송
            gSendBusy = true;
            gSendData[0] = Convert.ToByte(0x24.ToString(), 16);
            gSendData[1] = Convert.ToByte(0x41.ToString(), 16);
            gSendData[2] = Convert.ToByte(0x52.ToString(), 16);
            gSendData[3] = Convert.ToByte(0x03.ToString(), 16);
            gSendData[4] = Convert.ToByte(0x1d.ToString(), 16);

            gSendData[5] = Convert.ToByte(gSerialRecv[5].ToString(), 10);
            gSendData[6] = Convert.ToByte(gSerialRecv[6].ToString(), 10);
            gSendData[7] = Convert.ToByte(gSerialRecv[7].ToString(), 10);
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

                    Port.Write(gSendData, 0, 9);
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
            gSendBusy = false;
            // 분석한 데이터 삭제
            gSerialRecv.RemoveRange(0, len + 6);
#endif
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(SerialReceived));
            /*
            // Receive 버퍼 뒤에 수신 받은 데이터 채우기
            String msg = Port.ReadExisting();           // Byte 변환에 문제 있음
            if (!String.IsNullOrEmpty(msg))
                // Port.Encoding은 Port 생성시에 설정된 Encoding(UTF-8. line38 참조)
                RecvDataList.AddRange(Port.Encoding.GetBytes(msg));
            */
        }

        private void SerialReceived(object s, EventArgs e)
        {
            gSerialRecv.Add((Byte)Port.ReadByte());

            // STX 확인
            if (gSerialRecv[0] != 36)
            {
                //Strings = String.Format("[ERR] STX fail.");
                gSerialRecv.Clear();
                return;
            }
            else
            {
                //ParseStart = true;
            }

            // 분석할 데이터가 5개 이하면 return
            if (gSerialRecv.Count < 5) return;

            // 길이 확인
            Byte len = (Byte)(gSerialRecv[4] + 6);

            if (len != gSerialRecv.Count) return;

            // CheckSum 확인
            Byte checkSum = 0;

            int capacity = 255;
            StringBuilder msg = new StringBuilder(capacity);

            for (Byte i = 0; i < len - 1; i++)
            {
                msg.Append(gSerialRecv[i].ToString());
                checkSum += gSerialRecv[i];
            }

            if ((Byte)(checkSum & 0xFF) != gSerialRecv[len - 1])
            {
                Strings = String.Format("[ERR] CheckSum fail.");
                gSerialRecv.Clear();
                return;
            }

            // 데이터 출력
            Strings = String.Format("[RECV] {0}", msg.ToString());

#if true
            // ACK 전송
            gSendBusy = true;
            gSendData[0] = Convert.ToByte(0x24.ToString(), 16);
            gSendData[1] = Convert.ToByte(0x41.ToString(), 16);
            gSendData[2] = Convert.ToByte(0x52.ToString(), 16);
            gSendData[3] = Convert.ToByte(0x03.ToString(), 16);
            gSendData[4] = Convert.ToByte(0x1d.ToString(), 16);

            gSendData[5] = Convert.ToByte(gSerialRecv[5].ToString(), 10);
            gSendData[6] = Convert.ToByte(gSerialRecv[6].ToString(), 10);
            gSendData[7] = Convert.ToByte(gSerialRecv[7].ToString(), 10);
            gSendData[8] = Convert.ToByte("0", 16);

            try
            {
                if (true == rBtnHexa.Checked)
                {
                    byte checksum = 0;

                    for(byte count = 0; count < 8; count++)
                    {
                        checksum += gSendData[count];
                    }
                    gSendData[8] = checksum;

                    Port.Write(gSendData, 0, 9);
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
            gSendBusy = false;
#endif
            // 분석한 데이터 삭제
            gSerialRecv.RemoveRange(0, len);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != Port)
            {
                if (Port.IsOpen)
                {
                    Port.Close();
                    Port.Dispose();
                    //GPort = null;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (null != Port)
            {
                if (Port.IsOpen)
                {
                    Port.Close();
                    Port.Dispose();
                    //Port = null;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRec.Clear();
        }

        //set parity
        /*
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
            ComboParity.Items.Clear();      //clear combobox list

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                ComboParity.Items.Add(s);
            }
        }
        */

        private void cboPortName_MouseClick(object sender, MouseEventArgs e)
        {
            cboPortName.Items.Clear();      //clear combobox list

            foreach (string comport in SerialPort.GetPortNames())
            {
                cboPortName.Items.Add(comport);
            }
        }

        //timer start
        private void button1_Click(object sender, EventArgs e)
        {
            if(Port != null && Port.IsOpen)
            {
                if (SendStart == false)
                {
                    SendStart = true;
                    button1.Text = "전송 중".ToString();
                    gSendTimer.Start();
                }
                else
                {
                    SendStart = false;
                    button1.Text = "전송 중지됨".ToString();
                    gSendTimer.Stop();
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
            if (gSendBusy == true) return;

            byte[] byteSendData = new byte[35];

            int iSendCount = 35;

            try
            {
                if (true == rBtnHexa.Checked)
                {
                    byte checksum = 0;

                    for(byte len = 0; len < 34; len++)
                    {
                        checksum += gSendData[len];
                    }
                    gSendData[34] = checksum;

                    Port.Write(gSendData, 0, iSendCount);
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
        }

        private void gRecvTimer_Tick(object sender, EventArgs e)
        {
            gSendData[0] = Convert.ToByte(24.ToString(), 16);
            gSendData[1] = Convert.ToByte(41.ToString(), 16);
            gSendData[2] = Convert.ToByte(52.ToString(), 16);
            gSendData[3] = Convert.ToByte(02.ToString(), 16);
            gSendData[4] = Convert.ToByte(1D.ToString(), 16);

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

            //MorRecvDataTimer_Tick(sender, e);
        }
    }
}
