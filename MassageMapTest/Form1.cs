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
using System.Runtime.InteropServices;

namespace MassageMapTest
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MassageMap
    {
        static public byte count = 11;
        public string massageType;
        public string walkHoldTime;
        public string walkSpeed;
        public string width;
        public string tDuty;  //tap
        public string kDuty;  //knead
        public string xdHoldTime;
        public string xdDuty;
        public string xdRepeat;
        public string xdAdj;
        public string interwork;

        public MassageMap(string _type, string _whold, string _wduty, string _width, string _tduty, string _kduty, string _xhold, string _xdDuty, string _repeat, string _adj, string _inwork)
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
            xdAdj = _adj;
            interwork = _inwork;
        }
    }

    public partial class Form1 : Form
    {
        public List<MassageMap> massageList;
        public List<MassageMap> massageLoadList;

        public Form1()
        {
            InitializeComponent();

            massageList = new List<MassageMap>();

#if false
            string[] massageType = { "MASSAGE_TYPE_KNEAD", "MASSAGE_TYPE_KNEAD_R", "MASSAGE_TYPE_TAP", "MASSAGE_TYPE_MIX", "MASSAGE_TYPE_PRESS"
                                    ,"MASSAGE_TYPE_SOFT_TAP", "MASSAGE_TYPE_SWING", "MASSAGE_TYPE_SWING_TAP", "MASSAGE_TYPE_SWING_SOFT_TAP", "MASSAGE_TYPE_KNEAD_SOFT_TAP"  };
#endif
            string[] comboMassageType = { "KNEAD", "KNEAD_R", "TAP", "MIX", "PRESS"
                                    ,"SOFT_TAP", "SWING", "SWING_TAP", "SWING_SOFT_TAP", "KNEAD_SOFT_TAP"  };
            comboBox1.Items.AddRange(comboMassageType);

#if false
            string[] comboWalkLocation = { "WALK_LOCATE_PARK", "WALK_LOCATE_TOP", "WALK_LOCATE_HEAD_BACK", "WALK_LOCATE_NECK_POSITION", "WALK_LOCATE_NECK_MIDDLE"
                                    ,"WALK_LOCATE_SHOULDER", "WALK_SHOULDER_WAIST_1_10", "WALK_SHOULDER_WAIST_2_10", "WALK_SHOULDER_WAIST_3_10", "WALK_SHOULDER_WAIST_4_10"
                                    ,"WALK_SHOULDER_WAIST_5_10", "WALK_SHOULDER_WAIST_6_10", "WALK_SHOULDER_WAIST_7_10", "WALK_SHOULDER_WAIST_8_10", "WALK_SHOULDER_WAIST_9_10"
                                    ,"WALK_LOCATE_WAIST", "WALK_LOCATE_HIP_HIGH", "WALK_LOCATE_HIP_LOW"};
#endif
            string[] comboWalkLocation = { "PARK", "TOP", "HEAD_BACK", "NECK_POSITION", "NECK_MIDDLE"
                                    ,"SHOULDER", "SHOULDER_WAIST_1_10", "SHOULDER_WAIST_2_10", "SHOULDER_WAIST_3_10", "SHOULDER_WAIST_4_10"
                                    ,"SHOULDER_WAIST_5_10", "SHOULDER_WAIST_6_10", "SHOULDER_WAIST_7_10", "SHOULDER_WAIST_8_10", "HOULDER_WAIST_9_10"
                                    ,"LOCATE_WAIST", "LOCATE_HIP_HIGH", "LOCATE_HIP_LOW", "TIME_10S | TIME_MASK_FLAG"};
        
            comboBox2.Items.AddRange(comboWalkLocation);

            string[] comboWalkDuty = { "MOTOR_POWER_0", "MOTOR_POWER_1", "MOTOR_POWER_2", "MOTOR_POWER_3", "MOTOR_POWER_4", "MOTOR_POWER_5"};
            comboBox3.Items.AddRange(comboWalkDuty);

#if false
            string[] comboWidth = { "STATE_KNEAD_IDLE", "STATE_KNEAD_CLOCK_RUN", "STATE_KNEAD_UNCLOCK_RUN", "STATE_KNEAD_STOP_AT_MIN", "STATE_KNEAD_STOP_AT_MID", "STATE_KNEAD_STOP_AT_MAX",
                                    "STATE_KNEAD_UNSTOP_AT_MIN", "STATE_KNEAD_UNSTOP_AT_MID", "STATE_KNEAD_UNSTOP_AT_MAX", "STATE_KNEAD_SWING_MIN", "STATE_KNEAD_SWING_MID", "STATE_KNEAD_SWING_MAX"
                                    "STATE_KNEAD_QS_MIN_CW", "STATE_KNEAD_QS_MIN_CCW"};
#endif
            string[] comboWidth = { "IDLE", "CLOCK_RUN", "UNCLOCK_RUN", "STOP_AT_MIN", "STOP_AT_MID", "STOP_AT_MAX",
                                    "UNSTOP_AT_MIN", "UNSTOP_AT_MID", "UNSTOP_AT_MAX", "SWING_MIN", "SWING_MID", "SWING_MAX",
                                    "QS_MIN_CW", "QS_MIN_CCW"};
            comboBox4.Items.AddRange(comboWidth);

            comboBox5.Items.AddRange(comboWalkDuty);
            comboBox6.Items.AddRange(comboWalkDuty);

            string[] comboXdHold = { "XD_STEP_0", "XD_STEP_1", "XD_STEP_2", "XD_STEP_3", "XD_STEP_4", "XD_STEP_5", "TIME_10S | TIME_MASK_FLAG" };
            comboBox7.Items.AddRange(comboXdHold);
            comboBox8.Items.AddRange(comboWalkDuty);

#if false
            string[] comboXdRepeat = { "MASSAGE_XD_SECTION_0_1", "MASSAGE_XD_SECTION_0_2", "MASSAGE_XD_SECTION_0_3", "MASSAGE_XD_SECTION_0_4", "MASSAGE_XD_SECTION_0_5"
                                        ,"MASSAGE_XD_SECTION_1_0", "MASSAGE_XD_SECTION_1_2", "MASSAGE_XD_SECTION_1_3", "MASSAGE_XD_SECTION_1_4", "MASSAGE_XD_SECTION_1_5"
                                        ,"MASSAGE_XD_SECTION_2_0", "MASSAGE_XD_SECTION_2_1", "MASSAGE_XD_SECTION_2_3", "MASSAGE_XD_SECTION_2_4", "MASSAGE_XD_SECTION_2_5"
                                        ,"MASSAGE_XD_SECTION_3_0", "MASSAGE_XD_SECTION_3_1", "MASSAGE_XD_SECTION_3_2", "MASSAGE_XD_SECTION_3_4", "MASSAGE_XD_SECTION_3_5"
                                        ,"MASSAGE_XD_SECTION_4_0", "MASSAGE_XD_SECTION_4_1", "MASSAGE_XD_SECTION_4_2", "MASSAGE_XD_SECTION_4_3", "MASSAGE_XD_SECTION_4_5"
                                        ,"MASSAGE_XD_SECTION_5_0", "MASSAGE_XD_SECTION_5_1", "MASSAGE_XD_SECTION_5_2", "MASSAGE_XD_SECTION_5_3", "MASSAGE_XD_SECTION_5_4"};
#endif
            string[] comboXdRepeat = { "SECTION_0_1", "SECTION_0_2", "SECTION_0_3", "SECTION_0_4", "SECTION_0_5"
                                      ,"SECTION_1_0", "SECTION_1_2", "SECTION_1_3", "SECTION_1_4", "SECTION_1_5"
                                      ,"SECTION_2_0", "SECTION_2_1", "SECTION_2_3", "SECTION_2_4", "SECTION_2_5"
                                      ,"SECTION_3_0", "SECTION_3_1", "SECTION_3_2", "SECTION_3_4", "SECTION_3_5"
                                      ,"SECTION_4_0", "SECTION_4_1", "SECTION_4_2", "SECTION_4_3", "SECTION_4_5"
                                      ,"SECTION_5_0", "SECTION_5_1", "SECTION_5_2", "SECTION_5_3", "SECTION_5_4"};

            comboBox9.Items.AddRange(comboXdRepeat);

            string[] comboInterWork = { "INTERWORK_AIR_HIP", "INTERWORK_AIR_SHOULDER", "INTERWORK_AIR_HIP_RELEASE", "INTERWORK_AIR_SEAT_BACK", "INTERWORK_AIR_SEAT_NOT_SHOULDER"
                                      ,"INTERWORK_LEG_DOWN", "INTERWORK_BRAIN_ALL_ARM", "INTERWORK_BRAIN_RIGHT_ARM", "INTERWORK_BRAIN_LEFT_ARM", "INTERWORK_BRAIN_SHOULDER_FOOT_HEEL"
                                      ,"INTERWORK_BRAIN_FOOT_HEEL_LEG_SHOULDER", "INTERWORK_BRAIN_WAIST_SHOULDER_6S", "INTERWORK_BRAIN_WAIST_SHOULDER_5S", "INTERWORK_BRAIN_ALL_DISABLE"};

            comboBox10.Items.AddRange(comboInterWork);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                comboBox1.Text = comboBox1.SelectedIndex.ToString();
            }
        }

        private void drawRichTextContents()
        {
            richTextBox1.Clear();

            for (int listnum = 0; listnum < massageList.Count; listnum++)
            {
                richTextBox1.Text += "{";
                richTextBox1.Text += massageList[listnum].massageType + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].walkHoldTime + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].walkSpeed + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].width + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].tDuty + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].kDuty + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].xdHoldTime + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].xdDuty + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].xdRepeat + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].xdAdj + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += massageList[listnum].interwork + String.Empty.PadRight(4, ' ') + ",";
                richTextBox1.Text += "}";

                richTextBox1.Text += Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            massageList.Add(new MassageMap(comboBox1.Text.ToString(), comboBox2.Text.ToString(), comboBox3.Text.ToString(), comboBox4.Text.ToString(), comboBox5.Text.ToString(),
                comboBox6.Text.ToString(), comboBox7.Text.ToString(), comboBox8.Text.ToString(), comboBox9.Text.ToString(), "XD_AD_STEP_MAX", comboBox10.Text.ToString()));

            drawRichTextContents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (massageList.Count == 0)
            {
                return;
            }

            massageList.RemoveAt(massageList.Count - 1);

            drawRichTextContents();
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

        private void FileLoad_Click(object sender, EventArgs e)
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

                string[] deLimiterChars = new string[] { "{", "}","\n","," };
                string[] messagedeLimit = message.Split(deLimiterChars, StringSplitOptions.RemoveEmptyEntries);

                massageLoadList = new List<MassageMap>();

                int rowMax = messagedeLimit.Count() / MassageMap.count;

                for (int i = 0; i < rowMax; i++)
                {
                    int colIndex = i * MassageMap.count;
                    massageLoadList.Add(new MassageMap(messagedeLimit[colIndex + 0], messagedeLimit[colIndex + 1], messagedeLimit[colIndex + 2], messagedeLimit[colIndex + 3], 
                                                        messagedeLimit[colIndex + 4],messagedeLimit[colIndex + 5], messagedeLimit[colIndex + 6], messagedeLimit[colIndex + 7], 
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
            }
            catch
            {
                MessageBox.Show("파일이 없습니다");
            }
        }

        private void FIleSave_Click(object sender, EventArgs e)
        {
            //Text file로 저장
            WriteTextFile(richTextBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}
