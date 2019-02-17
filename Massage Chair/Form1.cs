using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

namespace Massage_Chair
{
    public partial class Form1 : Form
    {
        private SerialPort gPort;
        //protected SerialPort GPort { get => gPort; set => gPort = value; }
        protected SerialPort GPort { get; set; }
        public bool GPortStart { get; set; }

        protected struct LegControlStruct
        {
            //private bool gLegStart;
            //private bool gCalfStart;
            //private bool gSoleStart;
            public bool GLegStart { get; set; }
            public bool GCalfStart { get; set; }
            public bool GSoleStart { get; set; }
        }

        protected LegControlStruct gLegCtl;

        public Form1()          //Constructor
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            gLegCtl.GLegStart = false;
            gLegCtl.GCalfStart = false;
            gLegCtl.GSoleStart = false;

            tBoxLegCtl.Text = "stop".ToString();
            tBoxCalfCtl.Text = "stop".ToString();
            tBoxSoleCtl.Text = "stop".ToString();
            tBoxAirCtl.Text = "stop".ToString();

           // btnOpen.Enabled = true;
            btnOpen.Text = "Disconnect".ToString();
            GPortStart = false;
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
                            gPort.Parity = (Parity)ComboParity.SelectedItem;
                            gPort.StopBits = (StopBits)ComboSb.SelectedItem;

                            gPort.ReadTimeout = (int)500;
                            gPort.WriteTimeout = (int)500;
                            gPort.Open();
                        }

                        if (gPort.IsOpen)
                        {
                            //btnOpen.Enabled = false;
                            GPortStart = true;
                            MessageBox.Show("시리얼 포트를 연결했습니다.");
                        }
                        else
                        {
                            //btnOpen.Enabled = true; 
                            //gPort.Close();
                            //gPort.Dispose();
                            //gPort = null;
                            //MessageBox.Show("시리얼 포트를 연결에 실패하였습니다..");
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

                            //btnOpen.Enabled = true;
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

        private void gPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int intRecSize = GPort.BytesToRead;
            string strRecData;

            if (intRecSize != 0)
            {
                strRecData = "";
                byte[] buff = new byte[intRecSize];

                GPort.Read(buff, 0, intRecSize);

                for (int iTemp = 0; iTemp < intRecSize; iTemp++)
                {
                    if (rBtnHexa.Checked)
                    {
                        strRecData += buff[iTemp].ToString("X2") + " ";
                    }
                    else
                    {
                        strRecData += Convert.ToChar(buff[iTemp]);
                    }
                }
                txtRec.Text += strRecData;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != GPort)
            {
                if (GPort.IsOpen)
                {
                    GPort.Close();
                    GPort.Dispose();
                    GPort = null;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (null != GPort)
            {
                if (GPort.IsOpen)
                {
                    GPort.Close();
                    GPort.Dispose();
                    GPort = null;
                }
            }

            //btnOpen.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRec.Clear();
            txtSend.Clear();
        }

        private void btnLegLength_Click(object sender, EventArgs e)
        {
            byte[] byteSendData = new byte[100];
            string bSendData;

            try
            {
#if false
                int iSendCount = 0;
                if (true == chkSndHexa.Checked)
                {
                    foreach (string s in txtSend.Text.Split(' '))
                    {
                        if (s != null && s != "")
                        {
                            byteSendData[iSendCount++] = Convert.ToByte(s, 16);
                        }
                    }
                sPort.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    sPort.Write(txtSend.Text);
                }
#endif
                gLegCtl.GLegStart = !gLegCtl.GLegStart;
        
                if (gLegCtl.GLegStart)
                {
                    bSendData = "leg lengh 1 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    GPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxLegCtl.Text = "move".ToString();
                }
                else
                {
                    bSendData = "leg lengh 0 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    GPort.Write(byteSendData, 0, byteSendData.Length);


                    tBoxLegCtl.Text = "stop".ToString();
                }             
            }
            catch (System.Exception ex)
            {
                gLegCtl.GLegStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
        }

        private void btnCalf_Click(object sender, EventArgs e)
        {
            byte[] byteSendData = new byte[100];
            string bSendData;

            try
            {
                gLegCtl.GCalfStart = !gLegCtl.GCalfStart;

                if (gLegCtl.GCalfStart)
                {
                    bSendData = "calf lengh 1 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    GPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxCalfCtl.Text = "move".ToString();
                }
                else
                {
                    bSendData = "calf lengh 0 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    GPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxCalfCtl.Text = "stop".ToString();
                }
            }
            catch (System.Exception ex)
            {
                gLegCtl.GCalfStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
        }

        private void btnSole_Click(object sender, EventArgs e)
        {
            byte[] byteSendData = new byte[100];
            string bSendData;

            try
            {
                gLegCtl.GSoleStart = !gLegCtl.GSoleStart;

                if (gLegCtl.GSoleStart)
                {
                    bSendData = "Sole lengh 1 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    GPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxSoleCtl.Text = "move".ToString();
                }
                else
                {
                    bSendData = "Sole lengh 0 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    GPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxSoleCtl.Text = "stop".ToString();
                }
            }
            catch (System.Exception ex)
            {
                gLegCtl.GSoleStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
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
            ComboParity.Items.Clear();      //clear combobox list

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                ComboParity.Items.Add(s);
            }
        }

        private void cboPortName_MouseClick(object sender, MouseEventArgs e)
        {
            //cboPortName.BeginUpdate();
            cboPortName.Items.Clear();      //clear combobox list

            foreach (string comport in SerialPort.GetPortNames())
            {
                cboPortName.Items.Add(comport);
            }
           // cboPortName.EndUpdate();
        }
    }
}
