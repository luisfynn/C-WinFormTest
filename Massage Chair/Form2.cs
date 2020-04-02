using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Massage_Chair
{
    public partial class Form2 : Form
    {
        private SerialPort Form2Port;
        public SerialPort Form2Port1 { get => Form2Port; set => Form2Port = value; }

        public bool bIsPowerOpen;

        private int listMaxCount = 0;
        private int listCurrentCount = 0;

        enum optOperate
        {
            ADD,
            REMOVE,
        };

        private delegate void drawRichTextBox();
        drawRichTextBox updateRichTextBox;

        #region massae option
        public enum optMassageType { KNEAD, KNEAD_R, TAP, MIX, PRESS, SOFT_TAP, SWING, SWING_TAP, SWING_SOFT_TAP, KNEAD_SOFT_TAP };
        public enum optMassageWalkLoc
        {
            PARK, TOP, HEAD_BACK, NECK, NECK_MID, SHOULDER, SW_1_10, SW_2_10, SW_3_10, SW_4_10, SW_5_10, SW_6_10, SW_7_10, SW_8_10, SW_9_10,
            WAIST, HIP_H, HIP_L
        };
        public enum optMassagePower { POWER_0, POWER_1, POWER_2, POWER_3, POWER_4, POWER_5 };
        public enum optMassageWidth
        {
            DONTCARE, CLOCK_RUN, UNCLOCK_RUN, STOP_AT_MIN, STOP_AT_MID, STOP_AT_MAX, UNSTOP_AT_MIN, UNSTOP_AT_MID, UNSTOP_AT_MAX,
            SWING_MIN, SWING_MID, SWING_MAX, QS_MIN_CW, QS_MID_CW, QS_MAX_CW, QS_MIN_CCW, QS_MID_CCW, QS_MAX_CCW, ENC_R1A, ENC_R1B, ENC_R1C, ENC_R1D, ENC_R2A, ENC_R2B,
            ENC_R2C, ENC_R2D,
        };
        public enum optMassageXdLoc { STEP0, STEP1, STEP2, STEP3, STEP4, STEP5 }
        public enum optMassageXdRepeat
        {
            SEC_NONE, SEC_0_1, SEC_0_2, SEC_0_3, SEC_0_4, SEC_0_5, SEC_1_0, SEC_1_2, SEC_1_3, SEC_1_4, SEC_1_5, SEC_2_0, SEC_2_1, SEC_2_3, SEC_2_4, SEC_2_5,
            SEC_3_0, SEC_3_1, SEC_3_2, SEC_3_4, SEC_3_5, SEC_4_0, SEC_4_1, SEC_4_2, SEC_4_3, SEC_4_5, SEC_5_0, SEC_5_1, SEC_5_2, SEC_5_3, SEC_5_4,
        }
        public enum optMassageInterwork
        {
            NONE, SHOULDER, HIP_RELEASE, SEAT_BACK, SEAT_NOT_SHOULDER, AUTOCARE,
        }
        #endregion


        public struct MassageMap
        {
            static public byte count = 10;
            public optMassageType massageType;
            public optMassageWalkLoc walkHoldTime;
            public optMassagePower walkSpeed;
            public optMassageWidth width;
            public optMassagePower tDuty;  //tap
            public optMassagePower kDuty;  //knead
            public optMassageXdLoc xdHoldTime;
            public optMassagePower xdDuty;
            public optMassageXdRepeat xdRepeat;
            public optMassageInterwork interwork;

            public MassageMap
            (optMassageType _type, optMassageWalkLoc _whold, optMassagePower _wduty, optMassageWidth _width, optMassagePower _tduty,
                optMassagePower _kduty, optMassageXdLoc _xhold, optMassagePower _xdDuty, optMassageXdRepeat _repeat, optMassageInterwork _inwork)
            {
                massageType = _type;
                walkHoldTime = _whold;
                walkSpeed = _wduty;
                width = _width;
                tDuty = _tduty;
                kDuty = _kduty;
                xdHoldTime = _xhold;
                xdDuty = _xdDuty;
                xdRepeat = _repeat;
                interwork = _inwork;
            }
        }

        public List<MassageMap> massageList;
        public List<MassageMap> massageLoadList;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            massageList = new List<MassageMap>();

            #region SetComboBox
            cbType.DataSource = Enum.GetValues(typeof(optMassageType));
            cbWalkLoc.DataSource = Enum.GetValues(typeof(optMassageWalkLoc));
            cbWalkSpd.DataSource = Enum.GetValues(typeof(optMassagePower));
            cbWidth.DataSource = Enum.GetValues(typeof(optMassageWidth));
            cbTapSpd.DataSource = Enum.GetValues(typeof(optMassagePower));
            cbKneadSpd.DataSource = Enum.GetValues(typeof(optMassagePower));
            cbXdLoc.DataSource = Enum.GetValues(typeof(optMassageXdLoc));
            cbXdSpd.DataSource = Enum.GetValues(typeof(optMassagePower));
            cbXdRepeat.DataSource = Enum.GetValues(typeof(optMassageXdRepeat));
            cbInterWork.DataSource = Enum.GetValues(typeof(optMassageInterwork));
            #endregion 

            bIsPowerOpen = false;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            massageList.Add(new MassageMap((optMassageType)cbType.SelectedItem, (optMassageWalkLoc)cbWalkLoc.SelectedItem, (optMassagePower)cbWalkSpd.SelectedItem, 
                (optMassageWidth)cbWidth.SelectedItem,(optMassagePower)cbTapSpd.SelectedItem, (optMassagePower)cbKneadSpd.SelectedItem, 
                (optMassageXdLoc)cbXdLoc.SelectedItem, (optMassagePower)cbXdSpd.SelectedItem, (optMassageXdRepeat)cbXdRepeat.SelectedItem,
                (optMassageInterwork)cbInterWork.SelectedItem));

            updateRichTextBox = drawAddRichTextContents;
            updateRichTextBox();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (massageList.Count == 0)
            {
                return;
            }
            massageList.RemoveAt(massageList.Count - 1);

            updateRichTextBox = drawRemoveRichTextContents;
            updateRichTextBox();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //Text file로 저장
            WriteTextFile(richTextBox1.Text);
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            //text 파일 경로 지정
            string folder = Application.StartupPath + @"\VSoutput";

            //text 파일명 지정
            string textFile = folder + @"\output.txt";

            //파일 오픈
            try
            {
                FileStream fileStream = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

                //파일 내용을 불러와 message에 넣기
                string message = streamReader.ReadToEnd();
                streamReader.Close();
                fileStream.Close();

                //message 내용을 구분자로 분류하여, massageLoadList에 넣기
                message = message.Trim();

                string[] deLimiterChars = new string[] { "{", "}", "\n", "," };
                string[] messagedeLimit = message.Split(deLimiterChars, StringSplitOptions.RemoveEmptyEntries);

                massageLoadList = new List<MassageMap>();

#region underconstruction..
#if false
                int rowMax = messagedeLimit.Count() / MassageMap.count;

                for (int i = 0; i < rowMax; i++)
                {
                    int colIndex = i * MassageMap.count;
                    massageLoadList.Add(new MassageMap(messagedeLimit[colIndex + 0], messagedeLimit[colIndex + 1], messagedeLimit[colIndex + 2], messagedeLimit[colIndex + 3],
                                                        messagedeLimit[colIndex + 4], messagedeLimit[colIndex + 5], messagedeLimit[colIndex + 6], messagedeLimit[colIndex + 7],
                                                        messagedeLimit[colIndex + 8], messagedeLimit[colIndex + 9], messagedeLimit[colIndex + 10]));
                }

                richTextBox1.Text = messagedeLimit.Count().ToString() + Environment.NewLine;

                for (int i = 0; i < massageLoadList.Count; i++)
                {
                    richTextBox1.Text += massageLoadList[i].massageType;
                    richTextBox1.Text += massageLoadList[i].walkHoldTime;
                    richTextBox1.Text += massageLoadList[i].walkSpeed;
                    richTextBox1.Text += massageLoadList[i].width;
                    richTextBox1.Text += massageLoadList[i].tDuty;
                    richTextBox1.Text += massageLoadList[i].kDuty;
                    richTextBox1.Text += massageLoadList[i].xdHoldTime;
                    richTextBox1.Text += massageLoadList[i].xdDuty;
                    richTextBox1.Text += massageLoadList[i].xdRepeat;
                    richTextBox1.Text += massageLoadList[i].xdAdj;
                    richTextBox1.Text += massageLoadList[i].interwork;
                    richTextBox1.Text += Environment.NewLine;
                }
#endif
#endregion
            }
            catch
            {
                MessageBox.Show("파일이 없습니다");
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            //최종 확인
            var result = MessageBox.Show("기록된 마사지맵을 초기화하시겠습니까?", "CAPTION", MessageBoxButtons.OKCancel);

            //사용자가 ok누를 경우 기록삭제
            if (result == DialogResult.OK)
            {
                richTextBox1.Clear();
                massageList.Clear();
                //MessageBox.Show($"{massageList.Count()}");
            }
        }

        private void drawAddRichTextContents()
        {
            int listNum = massageList.Count;

            if (listNum < 1) return;
            listNum = listNum - 1;

            richTextBox1.Text += "{";
            richTextBox1.Text += massageList[listNum].massageType + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].walkHoldTime + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].walkSpeed + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].width + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].tDuty + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].kDuty + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].xdHoldTime + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].xdDuty + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].xdRepeat + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].interwork + String.Empty.PadRight(4, ' ');
            richTextBox1.Text += "},";

            richTextBox1.Text += Environment.NewLine;
        }

        private void drawRemoveRichTextContents()
        {
            int startCnt = richTextBox1.Text.LastIndexOf("{");
            int stopCnt = richTextBox1.Text.LastIndexOf("}") + 1;       //richtextbox의 newline도 삭제하기 위함
            int lineLength = stopCnt - startCnt + 1;

            richTextBox1.Text = richTextBox1.Text.Remove(startCnt, lineLength);
        }

        private void WriteTextFile(string text)
        {
            //text 파일 저장할 폴더 지정
            string folder = Application.StartupPath + @"\VSoutput";

            //폴더가 없을 경우 생성
            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists) dirInfo.Create();

            //text 파일명 지정
            string textFile = folder + @"\output.txt";

            //파일 오픈
            FileStream fileStream = new FileStream(textFile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream, System.Text.Encoding.Default);

            //파일에 내용 입력 및 파일 닫기
            streamWriter.WriteLine(text);
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }

        private byte ConvertUint16ToHex(UInt16 value)
        {
            UInt16 rxValue = value;
            string strHex = Convert.ToString(rxValue);
            return Convert.ToByte(strHex, 16);
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 0;
                    int iDataCount = 0;
#region 전원커맨드 전송 테스트
                    //The REX power on command
                    iSendCount = 8;

                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("BC".ToString(), 16);
#endregion

                    listMaxCount = massageList.Count;
                    iDataCount = byteSendData.Length - 6;
                    iSendCount = byteSendData.Length;

                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("c0".ToString(), 16);
                    byteSendData[4] = Convert.ToByte(iDataCount.ToString(), 10);

                    byteSendData[5] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].massageType);
                    byteSendData[6] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].walkHoldTime);
                    byteSendData[7] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].walkSpeed);
                    byteSendData[8] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].width);
                    byteSendData[9] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].tDuty);

                    byteSendData[10] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].kDuty);
                    byteSendData[11] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].xdHoldTime);
                    byteSendData[12] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].xdDuty);
                    byteSendData[13] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].xdRepeat);
                    byteSendData[14] = ConvertUint16ToHex((UInt16)massageList[listCurrentCount].interwork);

                    byte sum = 0;

                    foreach(var s in byteSendData)
                    {
                        sum += s;
                    }

                    sum = (byte)(sum & 0xff);
                    byteSendData[15] = sum;

                    Form2Port1.Write(byteSendData, 0, iSendCount);

                    listCurrentCount++;
                    if (listCurrentCount >= listMaxCount)
                    {
                        listCurrentCount = 0;
                    }
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }    
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btPower_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    switch (bIsPowerOpen)
                    {
                        case false:
                            bIsPowerOpen = true;
                            btPower.Text = "전원 켜짐";

                            #region 전원 켬
                            //The REX power on command
                            byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                            byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                            byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                            byteSendData[3] = Convert.ToByte("01".ToString(), 16);
                            byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                            byteSendData[5] = Convert.ToByte("01".ToString(), 16);
                            byteSendData[6] = Convert.ToByte("01".ToString(), 16);
                            byteSendData[7] = Convert.ToByte("BC".ToString(), 16);
                            #endregion
                            break;
                        default:
                            bIsPowerOpen = false;
                            btPower.Text = "전원 꺼짐";

                            #region 전원 끔
                            //The REX power off command
                            byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                            byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                            byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                            byteSendData[3] = Convert.ToByte("01".ToString(), 16);
                            byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                            byteSendData[5] = Convert.ToByte("01".ToString(), 16);
                            byteSendData[6] = Convert.ToByte("00".ToString(), 16);
                            byteSendData[7] = Convert.ToByte("BB".ToString(), 16);
                            #endregion
                            break;
                    }
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btBodyScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    #region 체형인식 완료 커맨드
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("C2".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("00".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("7C".ToString(), 16);
                    #endregion

                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btWalkUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    #region 모듈 위로 올림
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("22".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("DD".ToString(), 16);
                    #endregion
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btWalkDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    #region 모듈 아래로 내림
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("22".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("DE".ToString(), 16);
                    #endregion
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btWalkHold_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    #region 모듈 멈춤
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("22".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("FF".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("DB".ToString(), 16);
                    #endregion
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btKneadRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    #region 주무름 동작
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("C3".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("00".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("7D".ToString(), 16);
                    #endregion
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btKneadStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 8;

                    #region 주무름 동작
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("C3".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("02".ToString(), 16);
                    byteSendData[5] = Convert.ToByte("00".ToString(), 16);
                    byteSendData[6] = Convert.ToByte("00".ToString(), 16);
                    byteSendData[7] = Convert.ToByte("7C".ToString(), 16);
                    #endregion
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btMainAir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 10;
                    byte byteCheckSum = 0;
                    int mainAIrDataLength = tbMainAir.Text.Length; 

                    #region 메인 에어 제어
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("C4".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("04".ToString(), 16);

                    switch (mainAIrDataLength)
                    {
                        case 2:
                            byteSendData[5] = Convert.ToByte("00", 16);
                            byteSendData[6] = Convert.ToByte("00", 16);
                            byteSendData[7] = Convert.ToByte("00", 16);
                            byteSendData[8] = Convert.ToByte(tbMainAir.Text.Substring(0, 2), 16);
                            break;
                        case 4:
                            byteSendData[5] = Convert.ToByte("00", 16);
                            byteSendData[6] = Convert.ToByte("00", 16);
                            byteSendData[7] = Convert.ToByte(tbMainAir.Text.Substring(0, 2), 16);
                            byteSendData[8] = Convert.ToByte(tbMainAir.Text.Substring(2, 2), 16);
                            break;
                        case 6:
                            byteSendData[5] = Convert.ToByte("00", 16);
                            byteSendData[6] = Convert.ToByte(tbMainAir.Text.Substring(0, 2), 16);
                            byteSendData[7] = Convert.ToByte(tbMainAir.Text.Substring(2, 2), 16);
                            byteSendData[8] = Convert.ToByte(tbMainAir.Text.Substring(4, 2), 16);
                            break;
                        case 8:
                            byteSendData[5] = Convert.ToByte(tbMainAir.Text.Substring(0, 2), 16);
                            byteSendData[6] = Convert.ToByte(tbMainAir.Text.Substring(2, 2), 16);
                            byteSendData[7] = Convert.ToByte(tbMainAir.Text.Substring(4, 2), 16);
                            byteSendData[8] = Convert.ToByte(tbMainAir.Text.Substring(6, 2), 16);
                            break;
                        default:
                            break;
                    }

                    for (byte i = 0; i < iSendCount - 1; i++)
                    {
                        byteCheckSum += byteSendData[i];
                        byteCheckSum &= 0xff;
                    }
                    byteSendData[9] = byteCheckSum;

                    #endregion
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }

        private void btLegAir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form2Port1.IsOpen)
                {
                    byte[] byteSendData = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
                    int iSendCount = 7;
                    byte byteCheckSum = 0;

                    #region 주무름 동작
                    byteSendData[0] = Convert.ToByte("24".ToString(), 16);
                    byteSendData[1] = Convert.ToByte("52".ToString(), 16);
                    byteSendData[2] = Convert.ToByte("41".ToString(), 16);
                    byteSendData[3] = Convert.ToByte("C5".ToString(), 16);
                    byteSendData[4] = Convert.ToByte("01".ToString(), 16);
                    byteSendData[5] = Convert.ToByte(tbLegAir.Text.ToString(), 16);
                    #endregion
                    for (byte i = 0; i < iSendCount - 1; i++)
                    {
                        byteCheckSum += byteSendData[i];
                        byteCheckSum &= 0xff;
                    }
                    byteSendData[6] = byteCheckSum;
                    Form2Port1.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    MessageBox.Show("시리얼포트가 열리지 않았습니다");
                }
            }
            catch
            {
                MessageBox.Show("시리얼전송시 문제가 발생하였습니다");
            }
            finally
            {
                //reserve
            }
        }
    }
}
