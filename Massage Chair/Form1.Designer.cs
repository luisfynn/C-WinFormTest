namespace Massage_Chair
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbComPort = new System.Windows.Forms.Label();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cboPortName = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.gBox = new System.Windows.Forms.GroupBox();
            this.rBtnHexa = new System.Windows.Forms.RadioButton();
            this.rBtnChar = new System.Windows.Forms.RadioButton();
            this.lbDataBit = new System.Windows.Forms.Label();
            this.lbParity = new System.Windows.Forms.Label();
            this.lbStopBit = new System.Windows.Forms.Label();
            this.lbSendMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBr = new System.Windows.Forms.ComboBox();
            this.ComboDb = new System.Windows.Forms.ComboBox();
            this.ComboParity = new System.Windows.Forms.ComboBox();
            this.ComboSb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gSendTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.gRecvTimer = new System.Windows.Forms.Timer(this.components);
            this.MassageMap = new System.Windows.Forms.Button();
            this.btUartTest = new System.Windows.Forms.Button();
            this.gBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbComPort
            // 
            this.lbComPort.AutoSize = true;
            this.lbComPort.Location = new System.Drawing.Point(34, 15);
            this.lbComPort.Name = "lbComPort";
            this.lbComPort.Size = new System.Drawing.Size(59, 12);
            this.lbComPort.TabIndex = 2;
            this.lbComPort.Text = "COM port";
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Location = new System.Drawing.Point(34, 47);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(59, 12);
            this.lbBaudRate.TabIndex = 3;
            this.lbBaudRate.Text = "Baud rate";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(242, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(120, 28);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Connect";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cboPortName
            // 
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.Location = new System.Drawing.Point(99, 12);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.Size = new System.Drawing.Size(121, 20);
            this.cboPortName.TabIndex = 6;
            this.cboPortName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboPortName_MouseClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(242, 47);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 30);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Message Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtRec
            // 
            this.txtRec.Location = new System.Drawing.Point(36, 363);
            this.txtRec.Multiline = true;
            this.txtRec.Name = "txtRec";
            this.txtRec.ReadOnly = true;
            this.txtRec.Size = new System.Drawing.Size(903, 198);
            this.txtRec.TabIndex = 9;
            // 
            // gBox
            // 
            this.gBox.Controls.Add(this.rBtnHexa);
            this.gBox.Controls.Add(this.rBtnChar);
            this.gBox.Location = new System.Drawing.Point(242, 83);
            this.gBox.Name = "gBox";
            this.gBox.Size = new System.Drawing.Size(103, 84);
            this.gBox.TabIndex = 12;
            this.gBox.TabStop = false;
            this.gBox.Text = "DATA TYPE";
            // 
            // rBtnHexa
            // 
            this.rBtnHexa.AutoSize = true;
            this.rBtnHexa.Location = new System.Drawing.Point(6, 58);
            this.rBtnHexa.Name = "rBtnHexa";
            this.rBtnHexa.Size = new System.Drawing.Size(55, 16);
            this.rBtnHexa.TabIndex = 14;
            this.rBtnHexa.TabStop = true;
            this.rBtnHexa.Text = "HEXA";
            this.rBtnHexa.UseVisualStyleBackColor = true;
            // 
            // rBtnChar
            // 
            this.rBtnChar.AutoSize = true;
            this.rBtnChar.Location = new System.Drawing.Point(6, 36);
            this.rBtnChar.Name = "rBtnChar";
            this.rBtnChar.Size = new System.Drawing.Size(59, 16);
            this.rBtnChar.TabIndex = 13;
            this.rBtnChar.TabStop = true;
            this.rBtnChar.Text = "문자열";
            this.rBtnChar.UseVisualStyleBackColor = true;
            // 
            // lbDataBit
            // 
            this.lbDataBit.AutoSize = true;
            this.lbDataBit.Location = new System.Drawing.Point(34, 71);
            this.lbDataBit.Name = "lbDataBit";
            this.lbDataBit.Size = new System.Drawing.Size(47, 12);
            this.lbDataBit.TabIndex = 14;
            this.lbDataBit.Text = "Data bit";
            // 
            // lbParity
            // 
            this.lbParity.AutoSize = true;
            this.lbParity.Location = new System.Drawing.Point(34, 96);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(37, 12);
            this.lbParity.TabIndex = 15;
            this.lbParity.Text = "Parity";
            // 
            // lbStopBit
            // 
            this.lbStopBit.AutoSize = true;
            this.lbStopBit.Location = new System.Drawing.Point(34, 122);
            this.lbStopBit.Name = "lbStopBit";
            this.lbStopBit.Size = new System.Drawing.Size(47, 12);
            this.lbStopBit.TabIndex = 16;
            this.lbStopBit.Text = "Stop bit";
            // 
            // lbSendMessage
            // 
            this.lbSendMessage.AutoSize = true;
            this.lbSendMessage.Location = new System.Drawing.Point(34, 168);
            this.lbSendMessage.Name = "lbSendMessage";
            this.lbSendMessage.Size = new System.Drawing.Size(91, 12);
            this.lbSendMessage.TabIndex = 20;
            this.lbSendMessage.Text = "Send message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Receive message";
            // 
            // ComboBr
            // 
            this.ComboBr.FormattingEnabled = true;
            this.ComboBr.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.ComboBr.Location = new System.Drawing.Point(99, 42);
            this.ComboBr.Name = "ComboBr";
            this.ComboBr.Size = new System.Drawing.Size(121, 20);
            this.ComboBr.TabIndex = 22;
            // 
            // ComboDb
            // 
            this.ComboDb.FormattingEnabled = true;
            this.ComboDb.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.ComboDb.Location = new System.Drawing.Point(99, 68);
            this.ComboDb.Name = "ComboDb";
            this.ComboDb.Size = new System.Drawing.Size(121, 20);
            this.ComboDb.TabIndex = 23;
            // 
            // ComboParity
            // 
            this.ComboParity.FormattingEnabled = true;
            this.ComboParity.Location = new System.Drawing.Point(99, 93);
            this.ComboParity.Name = "ComboParity";
            this.ComboParity.Size = new System.Drawing.Size(121, 20);
            this.ComboParity.TabIndex = 24;
            this.ComboParity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboParity_MouseClick);
            // 
            // ComboSb
            // 
            this.ComboSb.FormattingEnabled = true;
            this.ComboSb.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.ComboSb.Location = new System.Drawing.Point(99, 119);
            this.ComboSb.Name = "ComboSb";
            this.ComboSb.Size = new System.Drawing.Size(121, 20);
            this.ComboSb.TabIndex = 25;
            this.ComboSb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboSb_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 26;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gSendTimer
            // 
            this.gSendTimer.Interval = 200;
            this.gSendTimer.Tick += new System.EventHandler(this.gSendTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 60;
            this.label5.Text = "6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 59;
            this.label6.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 58;
            this.label7.Text = "4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(458, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "9";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(415, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 62;
            this.label9.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 61;
            this.label10.Text = "7";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(815, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 70;
            this.label11.Text = "16";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(764, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 69;
            this.label12.Text = "15";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(711, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 68;
            this.label13.Text = "14";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(662, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 67;
            this.label14.Text = "13";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(614, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 66;
            this.label15.Text = "12";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(558, 197);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 65;
            this.label16.Text = "11";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(510, 197);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 64;
            this.label17.Text = "10";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(361, 254);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 77;
            this.label18.Text = "23";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(304, 254);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 76;
            this.label19.Text = "22";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(248, 254);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 75;
            this.label20.Text = "21";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(209, 254);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 12);
            this.label21.TabIndex = 74;
            this.label21.Text = "20";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(158, 254);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 12);
            this.label22.TabIndex = 73;
            this.label22.Text = "19";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(97, 254);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 72;
            this.label23.Text = "18";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(49, 254);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 71;
            this.label24.Text = "17";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(614, 254);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 12);
            this.label27.TabIndex = 82;
            this.label27.Text = "28";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(558, 254);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 81;
            this.label28.Text = "27";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(510, 254);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 12);
            this.label29.TabIndex = 80;
            this.label29.Text = "26";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(458, 254);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 12);
            this.label30.TabIndex = 79;
            this.label30.Text = "25";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(409, 254);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 12);
            this.label31.TabIndex = 78;
            this.label31.Text = "24";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(662, 254);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 12);
            this.label26.TabIndex = 83;
            this.label26.Text = "29";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 212);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 21);
            this.textBox1.TabIndex = 84;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 212);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 21);
            this.textBox2.TabIndex = 85;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(139, 212);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(45, 21);
            this.textBox3.TabIndex = 86;
            this.textBox3.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(190, 212);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(45, 21);
            this.textBox4.TabIndex = 87;
            this.textBox4.Text = "0";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(241, 212);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(45, 21);
            this.textBox5.TabIndex = 88;
            this.textBox5.Text = "0";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(292, 212);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(45, 21);
            this.textBox6.TabIndex = 89;
            this.textBox6.Text = "0";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(343, 212);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(45, 21);
            this.textBox7.TabIndex = 90;
            this.textBox7.Text = "0";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(394, 212);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(45, 21);
            this.textBox8.TabIndex = 91;
            this.textBox8.Text = "0";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(445, 212);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(45, 21);
            this.textBox9.TabIndex = 92;
            this.textBox9.Text = "0";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(496, 212);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(45, 21);
            this.textBox10.TabIndex = 93;
            this.textBox10.Text = "0";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(547, 212);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(45, 21);
            this.textBox11.TabIndex = 94;
            this.textBox11.Text = "0";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(598, 212);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(45, 21);
            this.textBox12.TabIndex = 95;
            this.textBox12.Text = "0";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(649, 212);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(45, 21);
            this.textBox13.TabIndex = 96;
            this.textBox13.Text = "0";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(700, 212);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(45, 21);
            this.textBox14.TabIndex = 97;
            this.textBox14.Text = "0";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(751, 212);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(45, 21);
            this.textBox15.TabIndex = 98;
            this.textBox15.Text = "0";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(802, 212);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(45, 21);
            this.textBox16.TabIndex = 99;
            this.textBox16.Text = "0";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(36, 269);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(45, 21);
            this.textBox17.TabIndex = 100;
            this.textBox17.Text = "0";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(87, 269);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(45, 21);
            this.textBox18.TabIndex = 101;
            this.textBox18.Text = "0";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(139, 269);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(45, 21);
            this.textBox19.TabIndex = 102;
            this.textBox19.Text = "0";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(190, 269);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(45, 21);
            this.textBox20.TabIndex = 103;
            this.textBox20.Text = "0";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(241, 269);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(45, 21);
            this.textBox21.TabIndex = 104;
            this.textBox21.Text = "0";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(292, 269);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(45, 21);
            this.textBox22.TabIndex = 105;
            this.textBox22.Text = "0";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(343, 269);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(45, 21);
            this.textBox23.TabIndex = 106;
            this.textBox23.Text = "0";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(394, 269);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(45, 21);
            this.textBox24.TabIndex = 107;
            this.textBox24.Text = "0";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(445, 269);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(45, 21);
            this.textBox25.TabIndex = 108;
            this.textBox25.Text = "0";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(496, 269);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(45, 21);
            this.textBox26.TabIndex = 109;
            this.textBox26.Text = "0";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(547, 269);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(45, 21);
            this.textBox27.TabIndex = 110;
            this.textBox27.Text = "0";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(598, 269);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(45, 21);
            this.textBox28.TabIndex = 111;
            this.textBox28.Text = "0";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(649, 269);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(45, 21);
            this.textBox29.TabIndex = 112;
            this.textBox29.Text = "0";
            // 
            // gRecvTimer
            // 
            this.gRecvTimer.Interval = 50;
            this.gRecvTimer.Tick += new System.EventHandler(this.gRecvTimer_Tick);
            // 
            // MassageMap
            // 
            this.MassageMap.Enabled = false;
            this.MassageMap.Location = new System.Drawing.Point(608, 11);
            this.MassageMap.Name = "MassageMap";
            this.MassageMap.Size = new System.Drawing.Size(120, 28);
            this.MassageMap.TabIndex = 113;
            this.MassageMap.Text = "MassageMap";
            this.MassageMap.UseVisualStyleBackColor = true;
            this.MassageMap.Click += new System.EventHandler(this.MassageMap_Click);
            // 
            // btUartTest
            // 
            this.btUartTest.Enabled = false;
            this.btUartTest.Location = new System.Drawing.Point(608, 45);
            this.btUartTest.Name = "btUartTest";
            this.btUartTest.Size = new System.Drawing.Size(120, 28);
            this.btUartTest.TabIndex = 114;
            this.btUartTest.Text = "Uart test";
            this.btUartTest.UseVisualStyleBackColor = true;
            this.btUartTest.Click += new System.EventHandler(this.btUartTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(951, 573);
            this.Controls.Add(this.btUartTest);
            this.Controls.Add(this.MassageMap);
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ComboSb);
            this.Controls.Add(this.ComboParity);
            this.Controls.Add(this.ComboDb);
            this.Controls.Add(this.ComboBr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSendMessage);
            this.Controls.Add(this.lbStopBit);
            this.Controls.Add(this.lbParity);
            this.Controls.Add(this.lbDataBit);
            this.Controls.Add(this.txtRec);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cboPortName);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lbBaudRate);
            this.Controls.Add(this.lbComPort);
            this.Controls.Add(this.gBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial program";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBox.ResumeLayout(false);
            this.gBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbComPort;
        private System.Windows.Forms.Label lbBaudRate;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cboPortName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtRec;
        private System.Windows.Forms.GroupBox gBox;
        private System.Windows.Forms.RadioButton rBtnHexa;
        private System.Windows.Forms.RadioButton rBtnChar;
        private System.Windows.Forms.Label lbDataBit;
        private System.Windows.Forms.Label lbParity;
        private System.Windows.Forms.Label lbStopBit;
        private System.Windows.Forms.Label lbSendMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBr;
        private System.Windows.Forms.ComboBox ComboDb;
        private System.Windows.Forms.ComboBox ComboParity;
        private System.Windows.Forms.ComboBox ComboSb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer gSendTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.Timer gRecvTimer;
        private System.Windows.Forms.Button MassageMap;
        private System.Windows.Forms.Button btUartTest;
    }
}

