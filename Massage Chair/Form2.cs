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
        string localpath;

        private int listMaxCount = 0;
        private int listCurrentCount = 0;

        private int uiFindFirstIndex = 0;
        private int uiFindLastIndex = 0;
        private int uiFindIndexLength = 0;

        enum optOperate
        {
            ADD,
            REMOVE,
        };

        private delegate void drawRichTextBox();
        drawRichTextBox updateRichTextBox;

        #region massae option
        public enum optMassageType 
        { 
            MASSAGE_TYPE_KNEAD, 
            MASSAGE_TYPE_KNEAD_R, 
            MASSAGE_TYPE_TAP, 
            MASSAGE_TYPE_MIX, 
            MASSAGE_TYPE_PRESS,
            MASSAGE_TYPE_SOFT_TAP,
            MASSAGE_TYPE_SWING,
            MASSAGE_TYPE_SWING_TAP,
            MASSAGE_TYPE_SWING_SOFT_TAP,
            MASSAGE_TYPE_KNEAD_SOFT_TAP,
            MASSAGE_TYPE_MAX,
        };
        public enum optMassageWalkLoc
        {
            WALK_LOCATE_PARK,
            WALK_LOCATE_TOP,
            WALK_LOCATE_HEAD_BACK,
            WALK_LOCATE_NECK_POSITION,
            WALK_LOCATE_NECK_MIDDLE,
            WALK_LOCATE_SHOULDER,
            WALK_SHOULDER_WAIST_1_10,
            WALK_SHOULDER_WAIST_2_10,
            WALK_SHOULDER_WAIST_3_10,
            WALK_SHOULDER_WAIST_4_10,
            WALK_SHOULDER_WAIST_5_10,
            WALK_SHOULDER_WAIST_6_10,
            WALK_SHOULDER_WAIST_7_10,
            WALK_SHOULDER_WAIST_8_10,
            WALK_SHOULDER_WAIST_9_10,
            WALK_LOCATE_WAIST,
            WALK_LOCATE_HIP_HIGH,
            WALK_LOCATE_HIP_LOW
        };
        public enum optMassagePower 
        { 
            MOTOR_POWER_0,
            MOTOR_POWER_1,
            MOTOR_POWER_2,
            MOTOR_POWER_3,
            MOTOR_POWER_4,
            MOTOR_POWER_5,
            MOTOR_POWER_6,
            MOTOR_POWER_7,
            MOTOR_POWER_8,
            MOTOR_POWER_9,
            MOTOR_POWER_10,
            MOTOR_POWER_MAX
        };
        public enum optMassageWidth
        {
            STATE_KNEAD_DONTCARE,
            STATE_KNEAD_IDLE = 0,           /*0*/
            STATE_KNEAD_CLOCK_RUN,
            STATE_KNEAD_UNCLOCK_RUN,
            STATE_KNEAD_STOP_AT_MIN,
            STATE_KNEAD_STOP_AT_MID,

            STATE_KNEAD_STOP_AT_MAX,        /*5*/
            STATE_KNEAD_UNSTOP_AT_MIN,
            STATE_KNEAD_UNSTOP_AT_MID,
            STATE_KNEAD_UNSTOP_AT_MAX,

            STATE_KNEAD_SWING_MIN,
            STATE_KNEAD_SWING_MID,          /*10*/
            STATE_KNEAD_SWING_MAX,

            STATE_KNEAD_QS_MIN_CW,
            STATE_KNEAD_QS_MID_CW,
            STATE_KNEAD_QS_MAX_CW,

            STATE_KNEAD_QS_MIN_CCW,         /*15*/
            STATE_KNEAD_QS_MID_CCW,
            STATE_KNEAD_QS_MAX_CCW,

            STATE_KNEAD_ENC_R1A,            //knead range 5 ~30, CCW
            STATE_KNEAD_ENC_R1B,            //knead range 20 ~30, CCW
            STATE_KNEAD_ENC_R1C,            //knead range 40 ~55, CCW
            STATE_KNEAD_ENC_R1D,            //knead range 5 ~60, ccw

            STATE_KNEAD_ENC_R2A,            //knead range 5 ~30, CW
            STATE_KNEAD_ENC_R2B,            //knead range 20 ~30, CW
            STATE_KNEAD_ENC_R2C,            //knead range 40 ~55, CW
            STATE_KNEAD_ENC_R2D,            //knead range 5 ~60, cw

            STATE_KNEAD_MAX,
        };
        public enum optMassageXdLoc 
        {
            XD_STEP_0,                      /*0*/
            XD_STEP_1,
            XD_STEP_2,
            XD_STEP_3,
            XD_STEP_4,

            XD_STEP_5,                      /*5*/

            XD_STEP_MAX,
        }
        public enum optMassageXdRepeat
        {
            MASSAGE_XD_SECTION_0_1,
            MASSAGE_XD_SECTION_0_2,
            MASSAGE_XD_SECTION_0_3,
            MASSAGE_XD_SECTION_0_4,
            MASSAGE_XD_SECTION_0_5,

            MASSAGE_XD_SECTION_1_0,
            MASSAGE_XD_SECTION_1_2,
            MASSAGE_XD_SECTION_1_3,
            MASSAGE_XD_SECTION_1_4,
            MASSAGE_XD_SECTION_1_5,

            MASSAGE_XD_SECTION_2_0,
            MASSAGE_XD_SECTION_2_1,
            MASSAGE_XD_SECTION_2_3,
            MASSAGE_XD_SECTION_2_4,
            MASSAGE_XD_SECTION_2_5,

            MASSAGE_XD_SECTION_3_0,
            MASSAGE_XD_SECTION_3_1,
            MASSAGE_XD_SECTION_3_2,
            MASSAGE_XD_SECTION_3_4,
            MASSAGE_XD_SECTION_3_5,

            MASSAGE_XD_SECTION_4_0,
            MASSAGE_XD_SECTION_4_1,
            MASSAGE_XD_SECTION_4_2,
            MASSAGE_XD_SECTION_4_3,
            MASSAGE_XD_SECTION_4_5,

            MASSAGE_XD_SECTION_5_0,
            MASSAGE_XD_SECTION_5_1,
            MASSAGE_XD_SECTION_5_2,
            MASSAGE_XD_SECTION_5_3,
            MASSAGE_XD_SECTION_5_4,

            MASSAGE_XD_SECTION_MAX
        }

        public enum optMassageXdAdj
        {
            XD_AD_STEP_1,                   /*0*/
            XD_AD_STEP_2,
            XD_AD_STEP_3,

            XD_AD_STEP_MAX,
        }

        public enum optMassageInterwork
        {
            INTERWORK_AIR_SHOULDER,
            INTERWORK_AIR_HIP_RELEASE,
            INTERWORK_AIR_SEAT_BACK,
            INTERWORK_AIR_SEAT_NOT_SHOULDER,
            INTERWORK_AIR_AUTOCARE,

            INTERWORK_MAX
        }
        #endregion


        public struct MassageMap
        {
            static public byte count = 11;
            public optMassageType massageType;
            public optMassageWalkLoc walkHoldTime;
            public optMassagePower walkSpeed;
            public optMassageWidth width;
            public optMassagePower tDuty;  //tap
            public optMassagePower kDuty;  //knead
            public optMassageXdLoc xdHoldTime;
            public optMassagePower xdDuty;
            public optMassageXdRepeat xdRepeat;
            public optMassageXdAdj XdAdj;
            public optMassageInterwork interwork;

            public MassageMap
            (optMassageType _type, optMassageWalkLoc _whold, optMassagePower _wduty, optMassageWidth _width, optMassagePower _tduty,
                optMassagePower _kduty, optMassageXdLoc _xhold, optMassagePower _xdDuty, optMassageXdRepeat _repeat, optMassageXdAdj _xdAdj, optMassageInterwork _inwork)
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
                XdAdj = _xdAdj;
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
            localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            massageList.Add(new MassageMap((optMassageType)cbType.SelectedItem, (optMassageWalkLoc)cbWalkLoc.SelectedItem, (optMassagePower)cbWalkSpd.SelectedItem, 
                (optMassageWidth)cbWidth.SelectedItem,(optMassagePower)cbTapSpd.SelectedItem, (optMassagePower)cbKneadSpd.SelectedItem, 
                (optMassageXdLoc)cbXdLoc.SelectedItem, (optMassagePower)cbXdSpd.SelectedItem, (optMassageXdRepeat)cbXdRepeat.SelectedItem, optMassageXdAdj.XD_AD_STEP_MAX,
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

#if false
#region 마사지타입 변환
        private optMassageType funcMassageType(string type)
        {
            optMassageType retType = optMassageType.KNEAD;

            switch (type)
            {
                case "KNEAD":
                    retType = optMassageType.KNEAD;
                    break;
                case "KNEAD_R":
                    retType = optMassageType.KNEAD_R;
                    break;
                case "TAP":
                    retType = optMassageType.TAP;
                    break;
                case "MIX":
                    retType = optMassageType.MIX;
                    break;
                case "PRESS":
                    retType = optMassageType.PRESS;
                    break;
                case "SOFT_TAP":
                    retType = optMassageType.SOFT_TAP;
                    break;
                case "SWING":
                    retType = optMassageType.SWING;
                    break;
                case "SWING_TAP":
                    retType = optMassageType.SWING_TAP;
                    break;
                case "SWING_SOFT_TAP":
                    retType = optMassageType.SWING_SOFT_TAP;
                    break;
                case "KNEAD_SOFT_TAP":
                    retType = optMassageType.KNEAD_SOFT_TAP;
                    break;
                default:
                    break;
            }
            return retType;
        }
#endregion
#region 모듈위치 변환
        private optMassageWalkLoc funcModuleLocation(string type)
        {
            optMassageWalkLoc retType = optMassageWalkLoc.HEAD_BACK;

            switch (type)
            {
                case "PARK":
                    retType = optMassageWalkLoc.PARK;
                    break;
                case "TOP":
                    retType = optMassageWalkLoc.TOP;
                    break;
                case "HEAD_BACK":
                    retType = optMassageWalkLoc.HEAD_BACK;
                    break;
                case "NECK":
                    retType = optMassageWalkLoc.NECK;
                    break;
                case "NECK_MID":
                    retType = optMassageWalkLoc.NECK_MID;
                    break;
                case "SHOULDER":
                    retType = optMassageWalkLoc.SHOULDER;
                    break;
                case "SW_1_10":
                    retType = optMassageWalkLoc.SW_1_10;
                    break;
                case "SW_2_10":
                    retType = optMassageWalkLoc.SW_2_10;
                    break;
                case "SW_3_10":
                    retType = optMassageWalkLoc.SW_3_10;
                    break;
                case "SW_4_10":
                    retType = optMassageWalkLoc.SW_4_10;
                    break;
                case "SW_5_10":
                    retType = optMassageWalkLoc.SW_5_10;
                    break;
                case "SW_6_10":
                    retType = optMassageWalkLoc.SW_6_10;
                    break;
                case "SW_7_10":
                    retType = optMassageWalkLoc.SW_7_10;
                    break;
                case "SW_8_10":
                    retType = optMassageWalkLoc.SW_8_10;
                    break;
                case "SW_9_10":
                    retType = optMassageWalkLoc.SW_9_10;
                    break;
                case "WAIST":
                    retType = optMassageWalkLoc.WAIST;
                    break;
                case "HIP_H":
                    retType = optMassageWalkLoc.HIP_H;
                    break;
                case "HIP_L":
                    retType = optMassageWalkLoc.HIP_L;
                    break;
                default:
                    break;
            }
            return retType;
        }
#endregion
#endif
        public static class EnumUtil<T>
        {
            public static T Parse(string s)
            {
                return (T)Enum.Parse(typeof(T), s);
            }
        }

        public optMassageType GetTypeFromString(string type)
        {
            optMassageType c = EnumUtil<optMassageType>.Parse(type);

            return c;
        }

        public optMassageWalkLoc GetLocationFromString(string location)
        {
            optMassageWalkLoc c = EnumUtil<optMassageWalkLoc>.Parse(location);

            return c;
        }

        public optMassagePower GetPowerFromString(string power)
        {
            optMassagePower c = EnumUtil<optMassagePower>.Parse(power);

            return c;
        }

        public optMassageWidth GetWidthFromString(string width)
        {
            optMassageWidth c = EnumUtil<optMassageWidth>.Parse(width);

            return c;
        }

        public optMassageXdLoc GetXdLocationFromString(string location)
        {
            optMassageXdLoc c = EnumUtil<optMassageXdLoc>.Parse(location);

            return c;
        }

        public optMassageXdRepeat GetXdRepeatFromString(string repeat)
        {
            optMassageXdRepeat c = EnumUtil<optMassageXdRepeat>.Parse(repeat);

            return c;
        }

        public optMassageXdAdj GetXdAdjFromString(string xdAdj)
        {
            optMassageXdAdj c = EnumUtil<optMassageXdAdj>.Parse(xdAdj);

            return c;
        }

        public optMassageInterwork GetInterworkFromString(string interwork)
        {
            optMassageInterwork c = EnumUtil<optMassageInterwork>.Parse(interwork);

            return c;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            //text 파일 경로 지정
            //string folder = localpath + @"\VSoutput";
            //string folder = @"C:\Users\luisf\Desktop\VSoutput";

            //text 파일명 지정
            //string textFile = folder + @"\output.txt";

            //파일 선택
            string file_path = null;
            masageFileOpen.InitialDirectory = "C:\\";

            if(masageFileOpen.ShowDialog() == DialogResult.OK)
            {
                file_path = masageFileOpen.FileName;

                //선택된파일 읽기
                try
                {
                    FileStream fileStream = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

                    //파일 내용을 불러와 message에 넣기
                    string message = streamReader.ReadToEnd();
                    streamReader.Close();
                    fileStream.Close();

                    //message 내용을 구분자로 분류하여, massageLoadList에 넣기
                    message = message.Trim();

                    string[] deLimiterChars = new string[] { "{", "}", "\n", ","," ","((","<<4","|",")" };
                    //string[] deLimiterChars = new string[] { "{", "}", "\n", ",", " ", };
                    string[] messagedeLimit = message.Split(deLimiterChars, StringSplitOptions.RemoveEmptyEntries);

                    massageList.Clear();

                    int rowMax = messagedeLimit.Count() / MassageMap.count;

                    richTextBox1.Clear();

                    for (int i = 0; i < rowMax; i++)
                    {

                        int colIndex = i * MassageMap.count;
                        massageList.Add(new MassageMap(GetTypeFromString(messagedeLimit[colIndex + 0]), GetLocationFromString(messagedeLimit[colIndex + 1]),
                                                           GetPowerFromString(messagedeLimit[colIndex + 2]), GetWidthFromString(messagedeLimit[colIndex + 3]),
                                                            GetPowerFromString(messagedeLimit[colIndex + 4]), GetPowerFromString(messagedeLimit[colIndex + 5]),
                                                            GetXdLocationFromString(messagedeLimit[colIndex + 6]), GetPowerFromString(messagedeLimit[colIndex + 7]),
                                                            GetXdRepeatFromString(messagedeLimit[colIndex + 8]), GetXdAdjFromString(messagedeLimit[colIndex + 9]),
                                                            GetInterworkFromString(messagedeLimit[colIndex + 10])));

                        //richTextBox1.Text += messagedeLimit.Count().ToString() + Environment.NewLine;
                        updateRichTextBox = drawAddRichTextContents;
                        updateRichTextBox();
                    }
                }
                catch
                {
                    MessageBox.Show("파일이 없습니다");
                }
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
            richTextBox1.Text += "((" + massageList[listNum].tDuty + "<<4) | " + massageList[listNum].kDuty + ")," + String.Empty.PadRight(4, ' ');
            //richTextBox1.Text += massageList[listNum].kDuty + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].xdHoldTime + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].xdDuty + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].xdRepeat + String.Empty.PadRight(4, ' ') + ",";
            richTextBox1.Text += massageList[listNum].XdAdj + String.Empty.PadRight(4, ' ') + ",";
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
            //text 파일 저장할 폴더 지정(바탕화면 soutput)
            string folder = localpath + @"\VSoutput";

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

                    foreach (var s in byteSendData)
                    {
                        sum += s;
                    }

                    sum = (byte)(sum & 0xff);
                    byteSendData[15] = sum;

                    //하이라이트 취소
                    uiFindFirstIndex = richTextBox1.Text.IndexOf("{");
                    uiFindLastIndex = richTextBox1.Text.LastIndexOf("}");
                    uiFindIndexLength = uiFindLastIndex - uiFindFirstIndex + 1;

                    richTextBox1.Select(uiFindFirstIndex, uiFindIndexLength);
                    richTextBox1.SelectionBackColor = Form2.DefaultBackColor;

                    //전송할 마사지맵 하이라이트
                    uiFindFirstIndex = richTextBox1.Text.IndexOf("{");
                    uiFindLastIndex = richTextBox1.Text.IndexOf("}");
                    uiFindIndexLength = uiFindLastIndex - uiFindFirstIndex + 1;

                    richTextBox1.BackColor = Form2.DefaultBackColor;

                    if (listCurrentCount == 0)
                    {
                        richTextBox1.Select(uiFindFirstIndex, uiFindIndexLength);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        for (int iCount = 0; iCount < listCurrentCount; iCount++)
                        {
                            uiFindFirstIndex = richTextBox1.Text.IndexOf("{", uiFindFirstIndex + 1);
                        }

                        for (int iCount = 0; iCount < listCurrentCount; iCount++)
                        {
                            uiFindLastIndex = richTextBox1.Text.IndexOf("}", uiFindLastIndex + 1);
                        }

                        richTextBox1.Select(uiFindFirstIndex, uiFindIndexLength);
                        richTextBox1.SelectionBackColor = Color.Yellow;

                    }

                    //해당 마사지맵 전송
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
