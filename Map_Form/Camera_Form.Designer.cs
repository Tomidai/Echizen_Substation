namespace Map_Form {
    partial class Camera_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label3 = new System.Windows.Forms.Label();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.label4 = new System.Windows.Forms.Label();
            this.webBrowser4 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cam001_left = new System.Windows.Forms.Label();
            this.cam001_right = new System.Windows.Forms.Label();
            this.cam001_down = new System.Windows.Forms.Label();
            this.cam002_down = new System.Windows.Forms.Label();
            this.cam002_right = new System.Windows.Forms.Label();
            this.cam002_left = new System.Windows.Forms.Label();
            this.cam003_down = new System.Windows.Forms.Label();
            this.cam003_right = new System.Windows.Forms.Label();
            this.cam003_left = new System.Windows.Forms.Label();
            this.cam004_down = new System.Windows.Forms.Label();
            this.cam004_right = new System.Windows.Forms.Label();
            this.cam004_left = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_cnt_LU = new System.Windows.Forms.Label();
            this.btn_cnt_UP = new System.Windows.Forms.Label();
            this.btn_cnt_RU = new System.Windows.Forms.Label();
            this.btn_cnt_ZU = new System.Windows.Forms.Label();
            this.btn_cnt_ZO = new System.Windows.Forms.Label();
            this.btn_cnt_LF = new System.Windows.Forms.Label();
            this.btn_cnt_AF = new System.Windows.Forms.Label();
            this.btn_cnt_RI = new System.Windows.Forms.Label();
            this.btn_cnt_FU = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_cnt_FD = new System.Windows.Forms.Label();
            this.btn_cnt_LD = new System.Windows.Forms.Label();
            this.btn_cnt_DW = new System.Windows.Forms.Label();
            this.btn_cnt_RD = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_preReg = new System.Windows.Forms.Label();
            this.btn_preNameChange = new System.Windows.Forms.Label();
            this.btn_pre008 = new System.Windows.Forms.Label();
            this.btn_pre007 = new System.Windows.Forms.Label();
            this.btn_pre006 = new System.Windows.Forms.Label();
            this.btn_pre005 = new System.Windows.Forms.Label();
            this.btn_pre004 = new System.Windows.Forms.Label();
            this.btn_pre003 = new System.Windows.Forms.Label();
            this.btn_pre002 = new System.Windows.Forms.Label();
            this.btn_pre001 = new System.Windows.Forms.Label();
            this.btn_rec = new System.Windows.Forms.Label();
            this.btn_map = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Font = new System.Drawing.Font("HGPｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.treeView1.Location = new System.Drawing.Point(5, 85);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 379);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(216, 58);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(840, 472);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("https://www.yahoo.co.jp/", System.UriKind.Absolute);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(229, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "CAM001";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(1071, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(816, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "CAM002";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(1059, 61);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(840, 472);
            this.webBrowser2.TabIndex = 3;
            this.webBrowser2.Url = new System.Uri("https://www.yahoo.co.jp/", System.UriKind.Absolute);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(1071, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(816, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "CAM003";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // webBrowser3
            // 
            this.webBrowser3.Location = new System.Drawing.Point(1059, 552);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.ScrollBarsEnabled = false;
            this.webBrowser3.Size = new System.Drawing.Size(840, 472);
            this.webBrowser3.TabIndex = 7;
            this.webBrowser3.Url = new System.Uri("https://www.yahoo.co.jp/", System.UriKind.Absolute);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(229, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(816, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "CAM004";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            this.label4.DoubleClick += new System.EventHandler(this.label4_DoubleClick);
            // 
            // webBrowser4
            // 
            this.webBrowser4.Location = new System.Drawing.Point(216, 557);
            this.webBrowser4.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser4.Name = "webBrowser4";
            this.webBrowser4.ScrollBarsEnabled = false;
            this.webBrowser4.Size = new System.Drawing.Size(840, 472);
            this.webBrowser4.TabIndex = 5;
            this.webBrowser4.Url = new System.Uri("https://www.yahoo.co.jp/", System.UriKind.Absolute);
            this.webBrowser4.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser4_DocumentCompleted);
            // 
            // cam001_left
            // 
            this.cam001_left.Location = new System.Drawing.Point(216, 50);
            this.cam001_left.Name = "cam001_left";
            this.cam001_left.Size = new System.Drawing.Size(15, 481);
            this.cam001_left.TabIndex = 27;
            // 
            // cam001_right
            // 
            this.cam001_right.Location = new System.Drawing.Point(1041, 50);
            this.cam001_right.Name = "cam001_right";
            this.cam001_right.Size = new System.Drawing.Size(15, 481);
            this.cam001_right.TabIndex = 28;
            // 
            // cam001_down
            // 
            this.cam001_down.Location = new System.Drawing.Point(216, 522);
            this.cam001_down.Name = "cam001_down";
            this.cam001_down.Size = new System.Drawing.Size(840, 15);
            this.cam001_down.TabIndex = 29;
            // 
            // cam002_down
            // 
            this.cam002_down.Location = new System.Drawing.Point(1059, 519);
            this.cam002_down.Name = "cam002_down";
            this.cam002_down.Size = new System.Drawing.Size(840, 15);
            this.cam002_down.TabIndex = 32;
            // 
            // cam002_right
            // 
            this.cam002_right.Location = new System.Drawing.Point(1884, 47);
            this.cam002_right.Name = "cam002_right";
            this.cam002_right.Size = new System.Drawing.Size(15, 481);
            this.cam002_right.TabIndex = 31;
            // 
            // cam002_left
            // 
            this.cam002_left.Location = new System.Drawing.Point(1059, 47);
            this.cam002_left.Name = "cam002_left";
            this.cam002_left.Size = new System.Drawing.Size(15, 481);
            this.cam002_left.TabIndex = 30;
            // 
            // cam003_down
            // 
            this.cam003_down.Location = new System.Drawing.Point(216, 1015);
            this.cam003_down.Name = "cam003_down";
            this.cam003_down.Size = new System.Drawing.Size(840, 15);
            this.cam003_down.TabIndex = 35;
            // 
            // cam003_right
            // 
            this.cam003_right.Location = new System.Drawing.Point(1041, 543);
            this.cam003_right.Name = "cam003_right";
            this.cam003_right.Size = new System.Drawing.Size(15, 481);
            this.cam003_right.TabIndex = 34;
            // 
            // cam003_left
            // 
            this.cam003_left.Location = new System.Drawing.Point(216, 543);
            this.cam003_left.Name = "cam003_left";
            this.cam003_left.Size = new System.Drawing.Size(15, 481);
            this.cam003_left.TabIndex = 33;
            // 
            // cam004_down
            // 
            this.cam004_down.Location = new System.Drawing.Point(1059, 1011);
            this.cam004_down.Name = "cam004_down";
            this.cam004_down.Size = new System.Drawing.Size(840, 15);
            this.cam004_down.TabIndex = 38;
            // 
            // cam004_right
            // 
            this.cam004_right.Location = new System.Drawing.Point(1884, 539);
            this.cam004_right.Name = "cam004_right";
            this.cam004_right.Size = new System.Drawing.Size(15, 481);
            this.cam004_right.TabIndex = 37;
            // 
            // cam004_left
            // 
            this.cam004_left.Location = new System.Drawing.Point(1059, 539);
            this.cam004_left.Name = "cam004_left";
            this.cam004_left.Size = new System.Drawing.Size(15, 481);
            this.cam004_left.TabIndex = 36;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trackBar1.Location = new System.Drawing.Point(4, 140);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(190, 25);
            this.trackBar1.TabIndex = 39;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btn_cnt_LU);
            this.groupBox1.Controls.Add(this.btn_cnt_UP);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.btn_cnt_RU);
            this.groupBox1.Controls.Add(this.btn_cnt_ZU);
            this.groupBox1.Controls.Add(this.btn_cnt_ZO);
            this.groupBox1.Controls.Add(this.btn_cnt_LF);
            this.groupBox1.Controls.Add(this.btn_cnt_AF);
            this.groupBox1.Controls.Add(this.btn_cnt_RI);
            this.groupBox1.Controls.Add(this.btn_cnt_FU);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btn_cnt_FD);
            this.groupBox1.Controls.Add(this.btn_cnt_LD);
            this.groupBox1.Controls.Add(this.btn_cnt_DW);
            this.groupBox1.Controls.Add(this.btn_cnt_RD);
            this.groupBox1.Location = new System.Drawing.Point(5, 510);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 171);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Image = global::Map_Form.Properties.Resources.cont_b011;
            this.label9.Location = new System.Drawing.Point(136, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 30);
            this.label9.TabIndex = 13;
            // 
            // btn_cnt_LU
            // 
            this.btn_cnt_LU.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_LU.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_LU.Image = global::Map_Form.Properties.Resources.cont_b001;
            this.btn_cnt_LU.Location = new System.Drawing.Point(3, 15);
            this.btn_cnt_LU.Name = "btn_cnt_LU";
            this.btn_cnt_LU.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_LU.TabIndex = 9;
            this.btn_cnt_LU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_LU_MouseDown);
            this.btn_cnt_LU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_LU_MouseUp);
            // 
            // btn_cnt_UP
            // 
            this.btn_cnt_UP.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_UP.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_UP.Image = global::Map_Form.Properties.Resources.cont_b002;
            this.btn_cnt_UP.Location = new System.Drawing.Point(35, 15);
            this.btn_cnt_UP.Name = "btn_cnt_UP";
            this.btn_cnt_UP.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_UP.TabIndex = 10;
            this.btn_cnt_UP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_UP_MouseDown);
            this.btn_cnt_UP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_UP_MouseUp);
            // 
            // btn_cnt_RU
            // 
            this.btn_cnt_RU.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_RU.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_RU.Image = global::Map_Form.Properties.Resources.cont_b003;
            this.btn_cnt_RU.Location = new System.Drawing.Point(67, 15);
            this.btn_cnt_RU.Name = "btn_cnt_RU";
            this.btn_cnt_RU.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_RU.TabIndex = 11;
            this.btn_cnt_RU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_RU_MouseDown);
            this.btn_cnt_RU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_RU_MouseUp);
            // 
            // btn_cnt_ZU
            // 
            this.btn_cnt_ZU.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_ZU.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_ZU.Image = global::Map_Form.Properties.Resources.cont_b012;
            this.btn_cnt_ZU.Location = new System.Drawing.Point(104, 15);
            this.btn_cnt_ZU.Name = "btn_cnt_ZU";
            this.btn_cnt_ZU.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_ZU.TabIndex = 12;
            this.btn_cnt_ZU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_ZU_MouseDown);
            this.btn_cnt_ZU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_ZU_MouseUp);
            // 
            // btn_cnt_ZO
            // 
            this.btn_cnt_ZO.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_ZO.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_ZO.Image = global::Map_Form.Properties.Resources.cont_b013;
            this.btn_cnt_ZO.Location = new System.Drawing.Point(168, 15);
            this.btn_cnt_ZO.Name = "btn_cnt_ZO";
            this.btn_cnt_ZO.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_ZO.TabIndex = 14;
            this.btn_cnt_ZO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_ZO_MouseDown);
            this.btn_cnt_ZO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_ZO_MouseUp);
            // 
            // btn_cnt_LF
            // 
            this.btn_cnt_LF.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_LF.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_LF.Image = global::Map_Form.Properties.Resources.cont_b004;
            this.btn_cnt_LF.Location = new System.Drawing.Point(3, 50);
            this.btn_cnt_LF.Name = "btn_cnt_LF";
            this.btn_cnt_LF.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_LF.TabIndex = 15;
            this.btn_cnt_LF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_LF_MouseDown);
            this.btn_cnt_LF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_LF_MouseUp);
            // 
            // btn_cnt_AF
            // 
            this.btn_cnt_AF.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_AF.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_AF.Image = global::Map_Form.Properties.Resources.cont_b005;
            this.btn_cnt_AF.Location = new System.Drawing.Point(35, 50);
            this.btn_cnt_AF.Name = "btn_cnt_AF";
            this.btn_cnt_AF.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_AF.TabIndex = 16;
            this.btn_cnt_AF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_AF_MouseDown);
            this.btn_cnt_AF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_AF_MouseUp);
            // 
            // btn_cnt_RI
            // 
            this.btn_cnt_RI.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_RI.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_RI.Image = global::Map_Form.Properties.Resources.cont_b006;
            this.btn_cnt_RI.Location = new System.Drawing.Point(67, 50);
            this.btn_cnt_RI.Name = "btn_cnt_RI";
            this.btn_cnt_RI.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_RI.TabIndex = 17;
            this.btn_cnt_RI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_RI_MouseDown);
            this.btn_cnt_RI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_RI_MouseUp);
            // 
            // btn_cnt_FU
            // 
            this.btn_cnt_FU.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_FU.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_FU.Image = global::Map_Form.Properties.Resources.cont_b012;
            this.btn_cnt_FU.Location = new System.Drawing.Point(104, 50);
            this.btn_cnt_FU.Name = "btn_cnt_FU";
            this.btn_cnt_FU.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_FU.TabIndex = 18;
            this.btn_cnt_FU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_FU_MouseDown);
            this.btn_cnt_FU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_FU_MouseUp);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Image = global::Map_Form.Properties.Resources.cont_b010;
            this.label12.Location = new System.Drawing.Point(136, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 30);
            this.label12.TabIndex = 19;
            // 
            // btn_cnt_FD
            // 
            this.btn_cnt_FD.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_FD.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_FD.Image = global::Map_Form.Properties.Resources.cont_b013;
            this.btn_cnt_FD.Location = new System.Drawing.Point(168, 50);
            this.btn_cnt_FD.Name = "btn_cnt_FD";
            this.btn_cnt_FD.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_FD.TabIndex = 20;
            this.btn_cnt_FD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_FD_MouseDown);
            this.btn_cnt_FD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_FD_MouseUp);
            // 
            // btn_cnt_LD
            // 
            this.btn_cnt_LD.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_LD.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_LD.Image = global::Map_Form.Properties.Resources.cont_b007;
            this.btn_cnt_LD.Location = new System.Drawing.Point(3, 83);
            this.btn_cnt_LD.Name = "btn_cnt_LD";
            this.btn_cnt_LD.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_LD.TabIndex = 21;
            this.btn_cnt_LD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_LD_MouseDown);
            this.btn_cnt_LD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_LD_MouseUp);
            // 
            // btn_cnt_DW
            // 
            this.btn_cnt_DW.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_DW.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_DW.Image = global::Map_Form.Properties.Resources.cont_b008;
            this.btn_cnt_DW.Location = new System.Drawing.Point(35, 83);
            this.btn_cnt_DW.Name = "btn_cnt_DW";
            this.btn_cnt_DW.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_DW.TabIndex = 22;
            this.btn_cnt_DW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_DW_MouseDown);
            this.btn_cnt_DW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_DW_MouseUp);
            // 
            // btn_cnt_RD
            // 
            this.btn_cnt_RD.BackColor = System.Drawing.Color.Transparent;
            this.btn_cnt_RD.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cnt_RD.Image = global::Map_Form.Properties.Resources.cont_b009;
            this.btn_cnt_RD.Location = new System.Drawing.Point(67, 83);
            this.btn_cnt_RD.Name = "btn_cnt_RD";
            this.btn_cnt_RD.Size = new System.Drawing.Size(30, 30);
            this.btn_cnt_RD.TabIndex = 23;
            this.btn_cnt_RD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_RD_MouseDown);
            this.btn_cnt_RD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cnt_RD_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btn_preReg);
            this.groupBox2.Controls.Add(this.btn_preNameChange);
            this.groupBox2.Controls.Add(this.btn_pre008);
            this.groupBox2.Controls.Add(this.btn_pre007);
            this.groupBox2.Controls.Add(this.btn_pre006);
            this.groupBox2.Controls.Add(this.btn_pre005);
            this.groupBox2.Controls.Add(this.btn_pre004);
            this.groupBox2.Controls.Add(this.btn_pre003);
            this.groupBox2.Controls.Add(this.btn_pre002);
            this.groupBox2.Controls.Add(this.btn_pre001);
            this.groupBox2.Location = new System.Drawing.Point(5, 706);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 334);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox8.Location = new System.Drawing.Point(4, 242);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(190, 29);
            this.textBox8.TabIndex = 49;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox7.Location = new System.Drawing.Point(4, 210);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(190, 29);
            this.textBox7.TabIndex = 48;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox6.Location = new System.Drawing.Point(4, 179);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(190, 29);
            this.textBox6.TabIndex = 47;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox5.Location = new System.Drawing.Point(4, 147);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(190, 29);
            this.textBox5.TabIndex = 46;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox4.Location = new System.Drawing.Point(4, 115);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(190, 29);
            this.textBox4.TabIndex = 45;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.Location = new System.Drawing.Point(4, 83);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 29);
            this.textBox3.TabIndex = 44;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(3, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 29);
            this.textBox2.TabIndex = 43;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(4, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 29);
            this.textBox1.TabIndex = 42;
            // 
            // btn_preReg
            // 
            this.btn_preReg.BackColor = System.Drawing.Color.Transparent;
            this.btn_preReg.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_preReg.Image = global::Map_Form.Properties.Resources.cont_b015;
            this.btn_preReg.Location = new System.Drawing.Point(164, 288);
            this.btn_preReg.Name = "btn_preReg";
            this.btn_preReg.Size = new System.Drawing.Size(30, 30);
            this.btn_preReg.TabIndex = 41;
            this.btn_preReg.Click += new System.EventHandler(this.btn_preReg_Click);
            // 
            // btn_preNameChange
            // 
            this.btn_preNameChange.BackColor = System.Drawing.Color.Transparent;
            this.btn_preNameChange.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_preNameChange.Image = global::Map_Form.Properties.Resources.cont_b014;
            this.btn_preNameChange.Location = new System.Drawing.Point(7, 290);
            this.btn_preNameChange.Name = "btn_preNameChange";
            this.btn_preNameChange.Size = new System.Drawing.Size(30, 30);
            this.btn_preNameChange.TabIndex = 40;
            this.btn_preNameChange.Click += new System.EventHandler(this.btn_preNameChange_Click);
            // 
            // btn_pre008
            // 
            this.btn_pre008.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre008.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre008.Location = new System.Drawing.Point(4, 241);
            this.btn_pre008.Name = "btn_pre008";
            this.btn_pre008.Size = new System.Drawing.Size(190, 30);
            this.btn_pre008.TabIndex = 7;
            this.btn_pre008.Text = "プリセット８";
            this.btn_pre008.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre008.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre008_MouseDown);
            this.btn_pre008.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre008_MouseUp);
            // 
            // btn_pre007
            // 
            this.btn_pre007.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre007.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre007.Location = new System.Drawing.Point(4, 209);
            this.btn_pre007.Name = "btn_pre007";
            this.btn_pre007.Size = new System.Drawing.Size(190, 30);
            this.btn_pre007.TabIndex = 6;
            this.btn_pre007.Text = "プリセット７";
            this.btn_pre007.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre007.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre007_MouseDown);
            this.btn_pre007.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre007_MouseUp);
            // 
            // btn_pre006
            // 
            this.btn_pre006.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre006.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre006.Location = new System.Drawing.Point(4, 177);
            this.btn_pre006.Name = "btn_pre006";
            this.btn_pre006.Size = new System.Drawing.Size(190, 30);
            this.btn_pre006.TabIndex = 5;
            this.btn_pre006.Text = "プリセット６";
            this.btn_pre006.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre006.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre006_MouseDown);
            this.btn_pre006.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre006_MouseUp);
            // 
            // btn_pre005
            // 
            this.btn_pre005.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre005.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre005.Location = new System.Drawing.Point(4, 145);
            this.btn_pre005.Name = "btn_pre005";
            this.btn_pre005.Size = new System.Drawing.Size(190, 30);
            this.btn_pre005.TabIndex = 4;
            this.btn_pre005.Text = "プリセット５";
            this.btn_pre005.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre005.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre005_MouseDown);
            this.btn_pre005.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre005_MouseUp);
            // 
            // btn_pre004
            // 
            this.btn_pre004.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre004.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre004.Location = new System.Drawing.Point(4, 113);
            this.btn_pre004.Name = "btn_pre004";
            this.btn_pre004.Size = new System.Drawing.Size(190, 30);
            this.btn_pre004.TabIndex = 3;
            this.btn_pre004.Text = "プリセット４";
            this.btn_pre004.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre004.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre004_MouseDown);
            this.btn_pre004.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre004_MouseUp);
            // 
            // btn_pre003
            // 
            this.btn_pre003.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre003.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre003.Location = new System.Drawing.Point(4, 81);
            this.btn_pre003.Name = "btn_pre003";
            this.btn_pre003.Size = new System.Drawing.Size(190, 30);
            this.btn_pre003.TabIndex = 2;
            this.btn_pre003.Text = "プリセット３";
            this.btn_pre003.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre003_MouseDown);
            this.btn_pre003.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre003_MouseUp);
            // 
            // btn_pre002
            // 
            this.btn_pre002.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre002.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre002.Location = new System.Drawing.Point(4, 49);
            this.btn_pre002.Name = "btn_pre002";
            this.btn_pre002.Size = new System.Drawing.Size(190, 30);
            this.btn_pre002.TabIndex = 1;
            this.btn_pre002.Text = "プリセット２";
            this.btn_pre002.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre002.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre002_MouseDown);
            this.btn_pre002.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre002_MouseUp);
            // 
            // btn_pre001
            // 
            this.btn_pre001.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_pre001.Image = global::Map_Form.Properties.Resources.cont_pre001;
            this.btn_pre001.Location = new System.Drawing.Point(4, 17);
            this.btn_pre001.Name = "btn_pre001";
            this.btn_pre001.Size = new System.Drawing.Size(190, 30);
            this.btn_pre001.TabIndex = 0;
            this.btn_pre001.Text = "プリセット１";
            this.btn_pre001.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pre001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pre001_MouseDown);
            this.btn_pre001.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_pre001_MouseUp);
            // 
            // btn_rec
            // 
            this.btn_rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_rec.ForeColor = System.Drawing.Color.White;
            this.btn_rec.Image = global::Map_Form.Properties.Resources.cont_b017;
            this.btn_rec.Location = new System.Drawing.Point(206, -2);
            this.btn_rec.Name = "btn_rec";
            this.btn_rec.Size = new System.Drawing.Size(200, 50);
            this.btn_rec.TabIndex = 46;
            this.btn_rec.Text = "レコーダー";
            this.btn_rec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_rec.Click += new System.EventHandler(this.btn_rec_Click);
            // 
            // btn_map
            // 
            this.btn_map.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_map.ForeColor = System.Drawing.Color.White;
            this.btn_map.Image = global::Map_Form.Properties.Resources.cont_b016;
            this.btn_map.Location = new System.Drawing.Point(5, -1);
            this.btn_map.Name = "btn_map";
            this.btn_map.Size = new System.Drawing.Size(200, 50);
            this.btn_map.TabIndex = 45;
            this.btn_map.Text = "       マップ画面に切替";
            this.btn_map.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_map.Click += new System.EventHandler(this.btn_map_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Image = global::Map_Form.Properties.Resources.bg002;
            this.label7.Location = new System.Drawing.Point(5, 683);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 35);
            this.label7.TabIndex = 43;
            this.label7.Text = "プリセット";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Image = global::Map_Form.Properties.Resources.bg002;
            this.label5.Location = new System.Drawing.Point(5, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 35);
            this.label5.TabIndex = 40;
            this.label5.Text = "PTZコントロール";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Image = global::Map_Form.Properties.Resources.bg002;
            this.label6.Location = new System.Drawing.Point(5, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 35);
            this.label6.TabIndex = 41;
            this.label6.Text = "カメラ選択";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Camera_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1911, 1041);
            this.Controls.Add(this.btn_rec);
            this.Controls.Add(this.btn_map);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cam004_down);
            this.Controls.Add(this.cam004_right);
            this.Controls.Add(this.cam004_left);
            this.Controls.Add(this.cam003_down);
            this.Controls.Add(this.cam003_right);
            this.Controls.Add(this.cam003_left);
            this.Controls.Add(this.cam002_down);
            this.Controls.Add(this.cam002_right);
            this.Controls.Add(this.cam002_left);
            this.Controls.Add(this.cam001_down);
            this.Controls.Add(this.cam001_right);
            this.Controls.Add(this.cam001_left);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.webBrowser3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.webBrowser4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.treeView1);
            this.Name = "Camera_Form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser webBrowser4;
        private System.Windows.Forms.Label btn_cnt_LU;
        private System.Windows.Forms.Label btn_cnt_UP;
        private System.Windows.Forms.Label btn_cnt_RU;
        private System.Windows.Forms.Label btn_cnt_ZU;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label btn_cnt_ZO;
        private System.Windows.Forms.Label btn_cnt_FD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label btn_cnt_FU;
        private System.Windows.Forms.Label btn_cnt_RI;
        private System.Windows.Forms.Label btn_cnt_AF;
        private System.Windows.Forms.Label btn_cnt_LF;
        private System.Windows.Forms.Label btn_cnt_RD;
        private System.Windows.Forms.Label btn_cnt_DW;
        private System.Windows.Forms.Label btn_cnt_LD;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label cam001_left;
        private System.Windows.Forms.Label cam001_right;
        private System.Windows.Forms.Label cam001_down;
        private System.Windows.Forms.Label cam002_down;
        private System.Windows.Forms.Label cam002_right;
        private System.Windows.Forms.Label cam002_left;
        private System.Windows.Forms.Label cam003_down;
        private System.Windows.Forms.Label cam003_right;
        private System.Windows.Forms.Label cam003_left;
        private System.Windows.Forms.Label cam004_down;
        private System.Windows.Forms.Label cam004_right;
        private System.Windows.Forms.Label cam004_left;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label btn_pre001;
        private System.Windows.Forms.Label btn_pre008;
        private System.Windows.Forms.Label btn_pre007;
        private System.Windows.Forms.Label btn_pre006;
        private System.Windows.Forms.Label btn_pre005;
        private System.Windows.Forms.Label btn_pre004;
        private System.Windows.Forms.Label btn_pre003;
        private System.Windows.Forms.Label btn_pre002;
        private System.Windows.Forms.Label btn_preNameChange;
        private System.Windows.Forms.Label btn_preReg;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label btn_map;
        private System.Windows.Forms.Label btn_rec;
    }
}