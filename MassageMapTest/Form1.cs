using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassageMapTest
{
    public struct MassageMap
    {
        public string massageType;
        public string walkHoldTime;
        public string walkSpeed;
        public string width;
        //public string tapKneadDuty;  //tap<<4 | knead
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
            //tapKneadDuty = _duty;
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
                                    ,"LOCATE_WAIST", "LOCATE_HIP_HIGH", "LOCATE_HIP_LOW"};
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

            string[] comboXdHold = { "XD_STEP_0", "XD_STEP_1", "XD_STEP_2", "XD_STEP_3", "XD_STEP_4", "XD_STEP_5"};
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

        private void drawRichTextBod()
        {
            richTextBox1.Clear();

            for (int listnum = 0; listnum < massageList.Count; listnum++)
            {
                richTextBox1.Text += massageList[listnum].massageType + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].walkHoldTime + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].walkSpeed + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].width + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].tDuty + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].kDuty + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].xdHoldTime + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].xdRepeat + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].xdAdj + String.Empty.PadRight(4, ' ');
                richTextBox1.Text += massageList[listnum].interwork + String.Empty.PadRight(4, ' ');

                richTextBox1.Text += Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            massageList.Add(new MassageMap(comboBox1.Text.ToString(), comboBox2.Text.ToString(), comboBox3.Text.ToString(), comboBox4.Text.ToString(), comboBox5.Text.ToString(),
                comboBox6.Text.ToString(), comboBox7.Text.ToString(), comboBox8.Text.ToString(), comboBox9.Text.ToString(), "XD_AD_STEP_MAX", comboBox10.Text.ToString()));

            drawRichTextBod();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (massageList.Count == 0)
            {
                return;
            }

            massageList.RemoveAt(massageList.Count - 1);

            drawRichTextBod();
        }
    }
}
