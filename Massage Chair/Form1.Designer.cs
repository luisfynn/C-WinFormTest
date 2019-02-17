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
            this.btnLegLength = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBoxAirCtl = new System.Windows.Forms.TextBox();
            this.tBoxSoleCtl = new System.Windows.Forms.TextBox();
            this.tBoxCalfCtl = new System.Windows.Forms.TextBox();
            this.tBoxLegCtl = new System.Windows.Forms.TextBox();
            this.btnAir = new System.Windows.Forms.Button();
            this.btnSole = new System.Windows.Forms.Button();
            this.btnCalf = new System.Windows.Forms.Button();
            this.lbComPort = new System.Windows.Forms.Label();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cboPortName = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.gBox = new System.Windows.Forms.GroupBox();
            this.rBtnHexa = new System.Windows.Forms.RadioButton();
            this.rBtnChar = new System.Windows.Forms.RadioButton();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.lbDataBit = new System.Windows.Forms.Label();
            this.lbParity = new System.Windows.Forms.Label();
            this.lbStopBit = new System.Windows.Forms.Label();
            this.lbSendMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBr = new System.Windows.Forms.ComboBox();
            this.ComboDb = new System.Windows.Forms.ComboBox();
            this.ComboParity = new System.Windows.Forms.ComboBox();
            this.ComboSb = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.gBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLegLength
            // 
            this.btnLegLength.Location = new System.Drawing.Point(6, 20);
            this.btnLegLength.Name = "btnLegLength";
            this.btnLegLength.Size = new System.Drawing.Size(116, 23);
            this.btnLegLength.TabIndex = 0;
            this.btnLegLength.Text = "LegLengthMotor";
            this.btnLegLength.UseVisualStyleBackColor = true;
            this.btnLegLength.Click += new System.EventHandler(this.btnLegLength_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxAirCtl);
            this.groupBox1.Controls.Add(this.tBoxSoleCtl);
            this.groupBox1.Controls.Add(this.tBoxCalfCtl);
            this.groupBox1.Controls.Add(this.tBoxLegCtl);
            this.groupBox1.Controls.Add(this.btnAir);
            this.groupBox1.Controls.Add(this.btnSole);
            this.groupBox1.Controls.Add(this.btnCalf);
            this.groupBox1.Controls.Add(this.btnLegLength);
            this.groupBox1.Location = new System.Drawing.Point(514, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LegMassage Block";
            // 
            // tBoxAirCtl
            // 
            this.tBoxAirCtl.Location = new System.Drawing.Point(128, 109);
            this.tBoxAirCtl.Name = "tBoxAirCtl";
            this.tBoxAirCtl.ReadOnly = true;
            this.tBoxAirCtl.Size = new System.Drawing.Size(66, 21);
            this.tBoxAirCtl.TabIndex = 25;
            // 
            // tBoxSoleCtl
            // 
            this.tBoxSoleCtl.Location = new System.Drawing.Point(128, 80);
            this.tBoxSoleCtl.Name = "tBoxSoleCtl";
            this.tBoxSoleCtl.ReadOnly = true;
            this.tBoxSoleCtl.Size = new System.Drawing.Size(66, 21);
            this.tBoxSoleCtl.TabIndex = 24;
            // 
            // tBoxCalfCtl
            // 
            this.tBoxCalfCtl.Location = new System.Drawing.Point(128, 51);
            this.tBoxCalfCtl.Name = "tBoxCalfCtl";
            this.tBoxCalfCtl.ReadOnly = true;
            this.tBoxCalfCtl.Size = new System.Drawing.Size(66, 21);
            this.tBoxCalfCtl.TabIndex = 23;
            // 
            // tBoxLegCtl
            // 
            this.tBoxLegCtl.Location = new System.Drawing.Point(128, 20);
            this.tBoxLegCtl.Name = "tBoxLegCtl";
            this.tBoxLegCtl.ReadOnly = true;
            this.tBoxLegCtl.Size = new System.Drawing.Size(66, 21);
            this.tBoxLegCtl.TabIndex = 22;
            // 
            // btnAir
            // 
            this.btnAir.Location = new System.Drawing.Point(6, 107);
            this.btnAir.Name = "btnAir";
            this.btnAir.Size = new System.Drawing.Size(116, 23);
            this.btnAir.TabIndex = 3;
            this.btnAir.Text = "Air pocket";
            this.btnAir.UseVisualStyleBackColor = true;
            // 
            // btnSole
            // 
            this.btnSole.Location = new System.Drawing.Point(6, 78);
            this.btnSole.Name = "btnSole";
            this.btnSole.Size = new System.Drawing.Size(116, 23);
            this.btnSole.TabIndex = 2;
            this.btnSole.Text = "SoleMotor";
            this.btnSole.UseVisualStyleBackColor = true;
            this.btnSole.Click += new System.EventHandler(this.btnSole_Click);
            // 
            // btnCalf
            // 
            this.btnCalf.Location = new System.Drawing.Point(6, 49);
            this.btnCalf.Name = "btnCalf";
            this.btnCalf.Size = new System.Drawing.Size(116, 23);
            this.btnCalf.TabIndex = 1;
            this.btnCalf.Text = "CalfMotor";
            this.btnCalf.UseVisualStyleBackColor = true;
            this.btnCalf.Click += new System.EventHandler(this.btnCalf_Click);
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
            this.btnOpen.Location = new System.Drawing.Point(242, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(96, 23);
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
            this.btnClear.Location = new System.Drawing.Point(520, 206);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Message Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtRec
            // 
            this.txtRec.Location = new System.Drawing.Point(36, 249);
            this.txtRec.Multiline = true;
            this.txtRec.Name = "txtRec";
            this.txtRec.ReadOnly = true;
            this.txtRec.Size = new System.Drawing.Size(453, 118);
            this.txtRec.TabIndex = 9;
            // 
            // gBox
            // 
            this.gBox.Controls.Add(this.rBtnHexa);
            this.gBox.Controls.Add(this.rBtnChar);
            this.gBox.Location = new System.Drawing.Point(520, 283);
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
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(36, 181);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ReadOnly = true;
            this.txtSend.Size = new System.Drawing.Size(453, 37);
            this.txtSend.TabIndex = 13;
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
            this.lbSendMessage.Location = new System.Drawing.Point(34, 166);
            this.lbSendMessage.Name = "lbSendMessage";
            this.lbSendMessage.Size = new System.Drawing.Size(91, 12);
            this.lbSendMessage.TabIndex = 20;
            this.lbSendMessage.Text = "Send message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 234);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 430);
            this.Controls.Add(this.ComboSb);
            this.Controls.Add(this.ComboParity);
            this.Controls.Add(this.ComboDb);
            this.Controls.Add(this.ComboBr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSendMessage);
            this.Controls.Add(this.lbStopBit);
            this.Controls.Add(this.lbParity);
            this.Controls.Add(this.lbDataBit);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtRec);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cboPortName);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lbBaudRate);
            this.Controls.Add(this.lbComPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Serial Test Program V0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBox.ResumeLayout(false);
            this.gBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLegLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSole;
        private System.Windows.Forms.Button btnCalf;
        private System.Windows.Forms.Label lbComPort;
        private System.Windows.Forms.Label lbBaudRate;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cboPortName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtRec;
        private System.Windows.Forms.GroupBox gBox;
        private System.Windows.Forms.RadioButton rBtnHexa;
        private System.Windows.Forms.RadioButton rBtnChar;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label lbDataBit;
        private System.Windows.Forms.Label lbParity;
        private System.Windows.Forms.Label lbStopBit;
        private System.Windows.Forms.Label lbSendMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAir;
        private System.Windows.Forms.TextBox tBoxAirCtl;
        private System.Windows.Forms.TextBox tBoxSoleCtl;
        private System.Windows.Forms.TextBox tBoxCalfCtl;
        private System.Windows.Forms.TextBox tBoxLegCtl;
        private System.Windows.Forms.ComboBox ComboBr;
        private System.Windows.Forms.ComboBox ComboDb;
        private System.Windows.Forms.ComboBox ComboParity;
        private System.Windows.Forms.ComboBox ComboSb;
    }
}

