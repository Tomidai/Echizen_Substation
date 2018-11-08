using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Map_Form {
    public partial class Camera_Form:Form {
        //    public ImageList imageList01;

        int camEnableNum = 0;
        public int F2State = 0;
        private int[] camX = new int[8];
        private int[] camY = new int[8];
        private int VrOn = 0;

        private string[] camName = new string[8];          //camlistファイルからカメラ名称
        private int[] camEnable = new int[8];              //camlistファイルからカメラ有効無効
        private int[] camMapNo = new int[8];
        private int[] camPosiX = new int[8];
        private int[] camPosiY = new int[8];
        private int[] camLabLong = new int[8];
        private static string[] camIP = new string[8];
        private int[] camEnc = new int[8];
        private int[] blackLevel = new int[8];
        private int[] camType = new int[8];

        private int NameChange = 0;
        private int PreReg = 0;

        private int Mode = 0;

        private int camNo_01 = 0;
        private int camNo_02 = 1;
        private int camNo_03 = 2;
        private int camNo_04 = 4;

        private int moniMode = 0;



        private string prefile = @"C:\Users\oh\Desktop\preset\";
        public static string path = "";
        private int REC = 0;
        private int[] encResetEnable = new int[8];         // 各拠点のファイルからカメラENCRESETの取得
        private int[] camContEnable = new int[8];          // 各拠点のファイルからカメラ制御権の取得
        private int[] camSetEnable = new int[8];　　　　   // 各拠点のファイルからカメラ可視権の取得
        private int[] camSpEnable = new int[8];            // 各拠点のファイルからカメラスピーカーの取得
        private Label[] camBtnLab = new Label[8];
        private Label[] camIconLab = new Label[8];
        private Label[] camNameLab = new Label[8];
        private Label[] preNameLab = new Label[8];
        private TextBox[] preNameTxt = new TextBox[8];
        private Label[] hoseiLabel = new Label[8];
        public int basho = 0;
        public String[,] kyoten = new String[10, 5];

        private char[] separator = { ' ', ',' };
        private static char[] separator2 = { ' ', ':' };
        private int Speed = 2;

        static System.Timers.Timer myTimer = new System.Timers.Timer(9000);

        static bool exitFlag = false;

        //   private FileSystemWatcher watcher = new FileSystemWatcher();

        private int preTourokuState = 0;
        public static int CamNo = 100;
        private static string IP = "";
        private static string URL = "";
        private static string CUID = "";
        private string Str01 = "cam_user_id=";
        private string Str02 = "";
        private string Str03 = "&camera_id=1&port_id=1&";
        private string Str04 = "";


        private static int FlagEncLogIn = 0;
        private static int FlagCamCont = 0;

        private int Hosei = 1;

        public static int RecOn = 0;
        private String RecIP = "192.168.1.111";
        private int timerTime = 10000;

        private int[] mapEnable = new int[5];
        private string[] mapName = new string[5];
        private string[] mapFile = new string[5];
        private float[] mapNameFS = new float[5];

        private Label[] mapBtnLab = new Label[5];

        private int EncRST_ON = 0;
        private String Pass = "";


        private int s41X;
        private int s41Y;
        private int s41W;
        private int s41H;

        private int s4LW;

        private int s42X;
        private int s42Y;
        private int s42W;
        private int s42H;

        private int s43X;
        private int s43Y;
        private int s43W;
        private int s43H;

        private int s44X;
        private int s44Y;
        private int s44W;
        private int s44H;

        private string[] patternName = new string[6];
        private int[,] patternNo = new int[6, 4];







        public Camera_Form() {
            InitializeComponent();


            preNameLab[0] = btn_pre001;
            preNameLab[1] = btn_pre002;
            preNameLab[2] = btn_pre003;
            preNameLab[3] = btn_pre004;
            preNameLab[4] = btn_pre005;
            preNameLab[5] = btn_pre006;
            preNameLab[6] = btn_pre007;
            preNameLab[7] = btn_pre008;


            preNameTxt[0] = textBox1;
            preNameTxt[1] = textBox2;
            preNameTxt[2] = textBox3;
            preNameTxt[3] = textBox4;
            preNameTxt[4] = textBox5;
            preNameTxt[5] = textBox6;
            preNameTxt[6] = textBox7;
            preNameTxt[7] = textBox8;


            for (int i = 0; i < 8; ++i) {
                preNameTxt[i].Visible = false;
            }



            setUP();



            ImageList imageList01 = new ImageList();

            imageList01.ImageSize = new Size(16, 16);
            //   imageList01.Images.Add(Image.FromFile(path + @"test_View001\m001.png"));
            //   imageList01.Images.Add(Image.FromFile(path + @"test_View001\m002.png"));
            //   imageList01.Images.Add(Image.FromFile(path + @"test_View001\m003.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\moni_ico.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\moni4_ico.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\cam_ico.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\camX_ico.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\moni4X_ico.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\moni4c_ico.png"));
            imageList01.Images.Add(Image.FromFile(path + @"test_View001\moni4cX_ico.png"));

            treeView1.ImageList = imageList01;

            TreeNode tn001 = treeView1.Nodes.Add("001", "1画面", 0);
            TreeNode tn002 = treeView1.Nodes.Add("002", "4画面", 1);




            for (int i = 0; i < 8; ++i) {
                tn001.Nodes.Add("", camName[i], 2, 3);

            }

            for (int j = 0; j < 6; ++j) {
                tn002.Nodes.Add("", patternName[j], 5, 6);
            }

            treeView1.ExpandAll();



        }





        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            int a = 0;
            int b = 0;




            for (int i = 0; i < 8; ++i) {
                if (camName[i].Equals(e.Node.Text)) {
                    a = 1;
                    b = i;
                }
            }

            for (int i = 0; i < 6; ++i) {
                if (patternName[i].Equals(e.Node.Text)) {
                    a = 2;
                    b = i;
                }
            }


            if (Mode == 0) {
                if (a == 1) {
                    setLocation_1();
                } else if (a == 2) {
                    setLocation_4();
                }

            } else {



            }

            camSelect(0);
            setBrowser(a, b);


        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

        }


        private void trackBar1_ValueChanged(object sender, EventArgs e) {

            Speed = trackBar1.Value + 1;


        }
        private void label1_Click(object sender, EventArgs e) {
            camSelect(1);
        }
        private void label2_Click(object sender, EventArgs e) {
            camSelect(2);
        }
        private void label3_Click(object sender, EventArgs e) {
            camSelect(3);
        }
        private void label4_Click(object sender, EventArgs e) {
            camSelect(4);
        }




        /// /// //  ↑  上
        private void btn_cnt_UP_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_UP.Image = Properties.Resources.cont_b002X;
            ComTX(1);
        }

        private void btn_cnt_UP_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_UP.Image = Properties.Resources.cont_b002;
            ComTX(0);

        }

        /// /// //  ↑→  右上
        private void btn_cnt_RU_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_RU.Image = Properties.Resources.cont_b003X;
            ComTX(2);
        }

        private void btn_cnt_RU_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_RU.Image = Properties.Resources.cont_b003;
            ComTX(0);
        }

        /// /// //  →　右
        private void btn_cnt_RI_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_RI.Image = Properties.Resources.cont_b006X;
            ComTX(3);
        }

        private void btn_cnt_RI_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_RI.Image = Properties.Resources.cont_b006;
            ComTX(0);
        }


        /// /// //  →　右下
        private void btn_cnt_RD_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_RD.Image = Properties.Resources.cont_b009X;
            ComTX(4);
        }

        private void btn_cnt_RD_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_RD.Image = Properties.Resources.cont_b009;
            ComTX(0);
        }


        /// /// //  →　下
        private void btn_cnt_DW_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_DW.Image = Properties.Resources.cont_b008X;
            ComTX(5);
        }

        private void btn_cnt_DW_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_DW.Image = Properties.Resources.cont_b008;
            ComTX(0);
        }


        /// /// //  ←↓　　左下
        private void btn_cnt_LD_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_LD.Image = Properties.Resources.cont_b007X;
            ComTX(6);
        }

        private void btn_cnt_LD_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_LD.Image = Properties.Resources.cont_b007;
            ComTX(0);
        }

        /// /// //  ←  左
        private void btn_cnt_LF_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_LF.Image = Properties.Resources.cont_b004X;
            ComTX(7);
        }

        private void btn_cnt_LF_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_LF.Image = Properties.Resources.cont_b004;
            ComTX(0);
        }

        /// /// //  ↑←  左上
        private void btn_cnt_LU_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_LU.Image = Properties.Resources.cont_b001X;
            ComTX(8);
        }

        private void btn_cnt_LU_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_LU.Image = Properties.Resources.cont_b001;
            ComTX(0);
        }

        /// /// //  オートフォーカス
        private void btn_cnt_AF_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_AF.Image = Properties.Resources.cont_b005X;
            ComTX(12);
        }

        private void btn_cnt_AF_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_AF.Image = Properties.Resources.cont_b005;
            ComTX(0);
        }

        /// /// //  ズームUP
        private void btn_cnt_ZU_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_ZU.Image = Properties.Resources.cont_b012X;
            ComTX(10);
        }

        private void btn_cnt_ZU_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_ZU.Image = Properties.Resources.cont_b012;
            ComTX(0);
        }

        /// /// //  ズームOUT
        private void btn_cnt_ZO_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_ZO.Image = Properties.Resources.cont_b013X;
            ComTX(11);
        }

        private void btn_cnt_ZO_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_ZO.Image = Properties.Resources.cont_b013;
            ComTX(0);
        }

        /// /// //  フォーカスUP
        private void btn_cnt_FU_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_FU.Image = Properties.Resources.cont_b012X;
            ComTX(13);
        }

        private void btn_cnt_FU_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_FU.Image = Properties.Resources.cont_b012;
            ComTX(0);
        }

        /// /// //  フォーカスDW
        private void btn_cnt_FD_MouseDown(object sender, MouseEventArgs e) {
            this.btn_cnt_FD.Image = Properties.Resources.cont_b013X;
            ComTX(14);
        }

        private void btn_cnt_FD_MouseUp(object sender, MouseEventArgs e) {
            this.btn_cnt_FD.Image = Properties.Resources.cont_b013;
            ComTX(0);
        }



        private void btn_pre001_MouseDown(object sender, MouseEventArgs e) {

            presetMove(1);
        }

        private void btn_pre001_MouseUp(object sender, MouseEventArgs e) {
            presetMove(11);
        }

        private void btn_pre002_MouseDown(object sender, MouseEventArgs e) {
            presetMove(2);
        }

        private void btn_pre002_MouseUp(object sender, MouseEventArgs e) {
            presetMove(12);
        }

        private void btn_pre003_MouseDown(object sender, MouseEventArgs e) {
            presetMove(3);
        }

        private void btn_pre003_MouseUp(object sender, MouseEventArgs e) {
            presetMove(13);
        }

        private void btn_pre004_MouseDown(object sender, MouseEventArgs e) {
            presetMove(4);
        }

        private void btn_pre004_MouseUp(object sender, MouseEventArgs e) {
            presetMove(14);
        }

        private void btn_pre005_MouseDown(object sender, MouseEventArgs e) {
            presetMove(5);
        }

        private void btn_pre005_MouseUp(object sender, MouseEventArgs e) {
            presetMove(15);
        }

        private void btn_pre006_MouseDown(object sender, MouseEventArgs e) {
            presetMove(6);
        }

        private void btn_pre006_MouseUp(object sender, MouseEventArgs e) {
            presetMove(16);
        }

        private void btn_pre007_MouseDown(object sender, MouseEventArgs e) {
            presetMove(7);
        }

        private void btn_pre007_MouseUp(object sender, MouseEventArgs e) {
            presetMove(17);
        }

        private void btn_pre008_MouseDown(object sender, MouseEventArgs e) {
            presetMove(8);
        }

        private void btn_pre008_MouseUp(object sender, MouseEventArgs e) {
            presetMove(18);
        }

        private void presetMove(int a) {
            if (PreReg == 0) {
                if (a == 1) {
                    this.btn_pre001.Image = Properties.Resources.cont_pre001X;
                    ComTX(21);
                } else if (a == 2) {
                    this.btn_pre002.Image = Properties.Resources.cont_pre001X;
                    ComTX(22);
                } else if (a == 3) {
                    this.btn_pre003.Image = Properties.Resources.cont_pre001X;
                    ComTX(23);
                } else if (a == 4) {
                    this.btn_pre004.Image = Properties.Resources.cont_pre001X;
                    ComTX(24);
                } else if (a == 5) {
                    this.btn_pre005.Image = Properties.Resources.cont_pre001X;
                    ComTX(25);
                } else if (a == 6) {
                    this.btn_pre006.Image = Properties.Resources.cont_pre001X;
                    ComTX(26);
                } else if (a == 7) {
                    this.btn_pre007.Image = Properties.Resources.cont_pre001X;
                    ComTX(27);
                } else if (a == 8) {
                    this.btn_pre008.Image = Properties.Resources.cont_pre001X;
                    ComTX(28);
                } else if (a == 11) {
                    this.btn_pre001.Image = Properties.Resources.cont_pre001;
                } else if (a == 12) {
                    this.btn_pre002.Image = Properties.Resources.cont_pre001;
                } else if (a == 13) {
                    this.btn_pre003.Image = Properties.Resources.cont_pre001;
                } else if (a == 14) {
                    this.btn_pre004.Image = Properties.Resources.cont_pre001;
                } else if (a == 15) {
                    this.btn_pre005.Image = Properties.Resources.cont_pre001;
                } else if (a == 16) {
                    this.btn_pre006.Image = Properties.Resources.cont_pre001;
                } else if (a == 17) {
                    this.btn_pre007.Image = Properties.Resources.cont_pre001;
                } else if (a == 18) {
                    this.btn_pre008.Image = Properties.Resources.cont_pre001;
                }



            } else {
                if (a == 1) {
                    this.btn_pre001.Image = Properties.Resources.cont_pre001X;
                    ComTX(31);
                } else if (a == 2) {
                    this.btn_pre002.Image = Properties.Resources.cont_pre001X;
                    ComTX(32);
                } else if (a == 3) {
                    this.btn_pre003.Image = Properties.Resources.cont_pre001X;
                    ComTX(33);
                } else if (a == 4) {
                    this.btn_pre004.Image = Properties.Resources.cont_pre001X;
                    ComTX(34);
                } else if (a == 5) {
                    this.btn_pre005.Image = Properties.Resources.cont_pre001X;
                    ComTX(35);
                } else if (a == 6) {
                    this.btn_pre006.Image = Properties.Resources.cont_pre001X;
                    ComTX(36);
                } else if (a == 7) {
                    this.btn_pre007.Image = Properties.Resources.cont_pre001X;
                    ComTX(37);
                } else if (a == 8) {
                    this.btn_pre008.Image = Properties.Resources.cont_pre001X;
                    ComTX(38);
                } else if (a == 11) {
                    this.btn_pre001.Image = Properties.Resources.cont_pre001;
                } else if (a == 12) {
                    this.btn_pre002.Image = Properties.Resources.cont_pre001;
                } else if (a == 13) {
                    this.btn_pre003.Image = Properties.Resources.cont_pre001;
                } else if (a == 14) {
                    this.btn_pre004.Image = Properties.Resources.cont_pre001;
                } else if (a == 15) {
                    this.btn_pre005.Image = Properties.Resources.cont_pre001;
                } else if (a == 16) {
                    this.btn_pre006.Image = Properties.Resources.cont_pre001;
                } else if (a == 17) {
                    this.btn_pre007.Image = Properties.Resources.cont_pre001;
                } else if (a == 18) {
                    this.btn_pre008.Image = Properties.Resources.cont_pre001;
                }

                this.btn_preReg.Image = Properties.Resources.cont_b015;
                PreReg = 0;


            }



        }

        private void btn_preNameChange_Click(object sender, EventArgs e) {
            if (NameChange == 0) {
                NameChange = 1;
                this.btn_preNameChange.Image = Properties.Resources.cont_b014X;
                preNameChange();
            } else {
                NameChange = 0;
                this.btn_preNameChange.Image = Properties.Resources.cont_b014;
                preNameChange();
            }
        }

        private void btn_preReg_Click(object sender, EventArgs e) {
            if (PreReg == 0) {
                PreReg = 1;
                this.btn_preReg.Image = Properties.Resources.cont_b015X;

            } else {
                PreReg = 0;
                this.btn_preReg.Image = Properties.Resources.cont_b015;

            }

        }



        public void preNameChange() {
            if (NameChange == 1) {

                for (int i = 0; i < 8; ++i) {
                    preNameTxt[i].Visible = true;
                    preNameLab[i].Visible = false;
                }
                groupBox2.BackColor = Color.Red;
            } else {
                for (int i = 0; i < 8; ++i) {
                    preNameTxt[i].Visible = false;
                    preNameLab[i].Visible = true;
                }
                groupBox2.BackColor = Color.Black;
                preNameRegFileWright();

            }
        }

        public void preNameRegFileWright() {
            string file = prefile;
            string s = (CamNo + 1).ToString();
            if (CamNo < 10) {
                s = "0" + s;
            }

            file = file + "cam0" + s + @".txt";
            string Data = "";

            int NameChangeFlag = 0;

            for (int i = 0; i < 8; ++i) {
                if (preNameTxt[i].Text.Equals(preNameLab[i].Text)) {

                } else {
                    NameChangeFlag++;
                }
            }

            if (NameChangeFlag > 0) {
                for (int i = 0; i < 8; ++i) {
                    Data = Data + (i + 1) + "," + preNameTxt[i].Text + "\r\n";
                    preNameLab[i].Text = preNameTxt[i].Text;
                }

                try {

                    StreamWriter sw = new StreamWriter(file, false, Encoding.GetEncoding("shift_jis"));

                    sw.Write(Data);
                    sw.Close();
                    //   MessageBox.Show("登録完了");

                } catch {
                    MessageBox.Show("登録に失敗しました");
                }


            }
        }

        public static void encLogIn() {
            FlagEncLogIn = 1;
            string result = "";
            if (CamNo != 100) {

                myTimer.Start();


                //   Encoding enc = Encoding.GetEncoding("Shift_JIS");

                String Refer = "";

                WebRequest req = null;
                HttpWebResponse response = null;
                Encoding encS = Encoding.GetEncoding("Shift_JIS");
                Encoding encU = Encoding.GetEncoding("UTF-8");



                string postData = "cam_login=user&camera_id=1";
                URL = "http://" + camIP[CamNo] + "/ptipcam.cgi";

                try {

                    ServicePointManager.Expect100Continue = false;
                    req = System.Net.WebRequest.Create(URL);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.Headers.Add("Refer", Refer);
                    req.Headers.Add("Authorization", "Basic cm9vdDphZG1pbg==");


                    CredentialCache cache = new CredentialCache();
                    cache.Add(new Uri(URL), "Basic", new NetworkCredential("root", "admin"));
                    req.Credentials = cache;


                    byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);
                    req.ContentLength = postDataBytes.Length;


                    using (Stream requestStream = req.GetRequestStream()) {
                        requestStream.Write(postDataBytes, 0, postData.Length);
                    }

                    try {
                        response = req.GetResponse() as HttpWebResponse;
                    } catch (WebException ex) {
                        // レスポンスのHTTPステータスが500などの場合
                        response = ex.Response as HttpWebResponse;
                        if (response == null) {
                            // 接続不能だったりタイムアウトの場合は 0 を返す

                        }
                    }

                    using (Stream responseStream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(responseStream, encU)) {
                        result = reader.ReadToEnd();
                        string Code = response.StatusCode.ToString();


                    }






                } finally {
                    if (req != null) {
                        // 連続呼び出しでエラーになる場合があるのでその対策
                        req.Abort();
                    }
                    if (response != null) {
                        response.Close();
                    }


                    convCUID(result);
                    FlagEncLogIn = 0;
                }


            }
        }

        public static void convCUID(string res) {
            string[] words = res.Split(separator2);

            CUID = words[1];


        }

        public static void comTimeOutExt() {
            string result = "";
            if (CamNo != 100) {

                //   Encoding enc = Encoding.GetEncoding("Shift_JIS");

                String Refer = "";

                WebRequest req = null;
                HttpWebResponse response = null;
                Encoding encS = Encoding.GetEncoding("Shift_JIS");
                Encoding encU = Encoding.GetEncoding("UTF-8");



                string postData = "extend_timeout=0&cam_user_id=" + CUID;
                URL = "http://" + camIP[CamNo] + "/ptipcam.cgi";

                try {

                    ServicePointManager.Expect100Continue = false;
                    req = System.Net.WebRequest.Create(URL);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.Headers.Add("Refer", Refer);
                    req.Headers.Add("Authorization", "Basic cm9vdDphZG1pbg==");


                    CredentialCache cache = new CredentialCache();
                    cache.Add(new Uri(URL), "Basic", new NetworkCredential("root", "admin"));
                    req.Credentials = cache;


                    byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);
                    req.ContentLength = postDataBytes.Length;


                    using (Stream requestStream = req.GetRequestStream()) {
                        requestStream.Write(postDataBytes, 0, postData.Length);
                    }

                    try {
                        response = req.GetResponse() as HttpWebResponse;
                    } catch (WebException ex) {
                        // レスポンスのHTTPステータスが500などの場合
                        response = ex.Response as HttpWebResponse;
                        if (response == null) {
                            // 接続不能だったりタイムアウトの場合は 0 を返す

                        }
                    }

                    using (Stream responseStream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(responseStream, encU)) {
                        result = reader.ReadToEnd();
                        string Code = response.StatusCode.ToString();


                    }


                } finally {
                    if (req != null) {
                        // 連続呼び出しでエラーになる場合があるのでその対策
                        req.Abort();
                    }
                    if (response != null) {
                        response.Close();
                    }
                    FlagEncLogIn = 0;
                    //    MessageBox.Show(CUID + "!!!");
                }
            }
        }

        public void ComTX(int X) {
            if (CamNo != 100) {
                FlagCamCont = 1;

                string Dir = "";
                Str04 = "speed=" + Speed;

                if (X == 0) {
                    Dir = "camera_stop=";
                    Str04 = "";
                } else if (X == 1) {
                    Dir = "tilt_direction=up&tilt_";
                } else if (X == 2) {
                    Dir = "slant_direction=rightup&slant_direction_";
                } else if (X == 3) {
                    Dir = "pan_direction=right&pan_";
                } else if (X == 4) {
                    Dir = "slant_direction=rightdown&slant_direction_";
                } else if (X == 5) {
                    Dir = "tilt_direction=down&tilt_";
                } else if (X == 6) {
                    Dir = "slant_direction=leftdown&slant_direction_";
                } else if (X == 7) {
                    Dir = "pan_direction=left&pan_";
                } else if (X == 8) {
                    Dir = "slant_direction=leftup&slant_direction_";
                } else if (X == 10) {
                    Dir = "zoom_direction=tale&zoom_";
                } else if (X == 11) {
                    Dir = "zoom_direction=wide&zoom_";
                } else if (X == 12) {
                    Dir = "auto_focus";
                    Str04 = "";
                } else if (X == 13) {
                    Dir = "focus_direction=near&focus_";
                } else if (X == 14) {
                    Dir = "focus_direction=far&focus_";
                } else if (X == 15) {
                    Dir = "wiper_move=1";
                    Str04 = "";
                } else if (X == 16) {
                    Dir = "wiper_move=2";
                    Str04 = "";
                } else if (X == 21) {
                    Dir = "preset_move=1";
                    Str04 = "";
                } else if (X == 22) {
                    Dir = "preset_move=2";
                    Str04 = "";
                } else if (X == 23) {
                    Dir = "preset_move=3";
                    Str04 = "";
                } else if (X == 24) {
                    Dir = "preset_move=4";
                    Str04 = "";
                } else if (X == 25) {
                    Dir = "preset_move=5";
                    Str04 = "";
                } else if (X == 26) {
                    Dir = "preset_move=6";
                    Str04 = "";
                } else if (X == 27) {
                    Dir = "preset_move=7";
                    Str04 = "";
                } else if (X == 28) {
                    Dir = "preset_move=8";
                    Str04 = "";
                } else if (X == 29) {
                    Dir = "preset_move=9";
                    Str04 = "";
                } else if (X == 31) {
                    Dir = "preset_memory=1";
                    Str04 = "";
                } else if (X == 32) {
                    Dir = "preset_memory=2";
                    Str04 = "";
                } else if (X == 33) {
                    Dir = "preset_memory=3";
                    Str04 = "";
                } else if (X == 34) {
                    Dir = "preset_memory=4";
                    Str04 = "";
                } else if (X == 35) {
                    Dir = "preset_memory=5";
                    Str04 = "";
                } else if (X == 36) {
                    Dir = "preset_memory=6";
                    Str04 = "";
                } else if (X == 37) {
                    Dir = "preset_memory=7";
                    Str04 = "";
                } else if (X == 38) {
                    Dir = "preset_memory=8";
                    Str04 = "";
                } else if (X == 39) {
                    Dir = "preset_memory=9";
                    Str04 = "";
                } else if (X == 51) {
                    if (camEnc[CamNo] == 1) {
                        Dir = "aux_para1_out_value=1";
                    } else if (camEnc[CamNo] == 2) {
                        Dir = "aux_para1_out_value=1";
                    }

                    Str04 = "";
                } else if (X == 52) {
                    if (camEnc[CamNo] == 1) {
                        Dir = "aux_para1_out_value=2";
                    } else if (camEnc[CamNo] == 2) {
                        Dir = "aux_para1_out_value=2";
                    }
                    Str04 = "";
                }


                //Str01 = "cam_user_id=";
                //Str02 = "";
                //Str03 = "&camera_id=1&port_id=1&";
                //Str04 = "";
                String Str05 = "&video_channel=1";

                string postData = "";
                URL = "http://" + camIP[CamNo] + "/ptipcam.cgi";


                if (X < 100) {
                    postData = Str01 + CUID + Str03 + Dir + Str04 + Str05;
                    URL = "http://" + camIP[CamNo] + "/ptipcam.cgi";
                } else if (X == 101) {
                    postData = Str01 + CUID + Str03 + "CompPage=PComp.htm&Fail_Pg_Type=LOGO&NextPage=AMainte.htm&reset=1";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 201) {
                    postData = Str01 + CUID + Str03 + "ST_alarmoutput1=1&ST_alarmoutput2=2&ST_alarmoutput3=2&ST_alarmoutput4=2&nextpage=auth%2Fapioset.htm&freemsg=1";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 202) {
                    postData = Str01 + CUID + Str03 + "ST_alarmoutput1=2&ST_alarmoutput2=2&ST_alarmoutput3=2&ST_alarmoutput4=2&nextpage=auth%2Fapioset.htm&freemsg=1";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 211) {
                    postData = Str01 + CUID + Str03 + "ST_DRC_STS=1&ST_DRC_IN_BLK_LVL=" + blackLevel[CamNo] + " & ST_DRC_LOAD_PRESET=1&nextpage=auth%2Favconfset.htm";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 212) {
                    postData = Str01 + CUID + Str03 + "ST_DRC_STS=1&ST_DRC_IN_BLK_LVL=" + blackLevel[CamNo] + " &ST_DRC_LOAD_PRESET=2&nextpage=auth%2Favconfset.htm";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 213) {
                    postData = Str01 + CUID + Str03 + "ST_DRC_STS=1&ST_DRC_IN_BLK_LVL=" + blackLevel[CamNo] + "&ST_DRC_LOAD_PRESET=3&nextpage=auth%2Favconfset.htm";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 214) {
                    postData = Str01 + CUID + Str03 + "ST_DRC_STS=1&ST_DRC_IN_BLK_LVL=" + blackLevel[CamNo] + "&ST_DRC_LOAD_PRESET=4&nextpage=auth%2Favconfset.htm";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 215) {
                    postData = Str01 + CUID + Str03 + "ST_DRC_STS=1&ST_DRC_IN_BLK_LVL=" + blackLevel[CamNo] + "&ST_DRC_LOAD_PRESET=5&nextpage=auth%2Favconfset.htm";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 216) {
                    postData = Str01 + CUID + Str03 + "ST_DRC_STS=1&ST_DRC_IN_BLK_LVL=" + blackLevel[CamNo] + "&ST_DRC_LOAD_PRESET=6&nextpage=auth%2Favconfset.htm";
                    URL = "http://" + camIP[CamNo] + "/ptipset.cgi";
                } else if (X == 220) {
                    postData = "audio_multi_start";
                    URL = "http://" + camIP[CamNo] + "/ptipaudio.cgi";

                    String CamNoStr = "";
                    int a = CamNo + 1;
                    if (a < 10) {
                        CamNoStr = "0" + a;
                    } else {
                        CamNoStr = a.ToString();
                    }
                    this.webBrowser2.Visible = true;
                    this.webBrowser2.Url = new System.Uri(path + @"audio\cam1" + CamNoStr + ".html", System.UriKind.Absolute);
                } else if (X == 221) {
                    postData = "audio_multi_stop";
                    URL = "http://" + camIP[CamNo] + "/ptipaudio.cgi";

                    String CamNoStr = "";
                    int a = CamNo + 1;
                    if (a < 10) {
                        CamNoStr = "0" + a;
                    } else {
                        CamNoStr = a.ToString();
                    }
                    this.webBrowser2.Url = new System.Uri(path + @"audio\cam000.html", System.UriKind.Absolute);
                    this.webBrowser2.Visible = false;


                }





                string Refer = "";
                string result = "";

                WebRequest req = null;
                HttpWebResponse response = null;
                Encoding encS = Encoding.GetEncoding("Shift_JIS");
                Encoding encU = Encoding.GetEncoding("UTF-8");

                try {

                    ServicePointManager.Expect100Continue = false;
                    req = System.Net.WebRequest.Create(URL);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.Headers.Add("Refer", Refer);
                    req.Headers.Add("Authorization", "Basic cm9vdDphZG1pbg==");


                    CredentialCache cache = new CredentialCache();
                    cache.Add(new Uri(URL), "Basic", new NetworkCredential("root", "admin"));
                    req.Credentials = cache;


                    byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);
                    req.ContentLength = postDataBytes.Length;


                    using (Stream requestStream = req.GetRequestStream()) {
                        requestStream.Write(postDataBytes, 0, postData.Length);
                    }









                } finally {
                    if (req != null) {
                        // 連続呼び出しでエラーになる場合があるのでその対策
                        req.Abort();
                    }
                    if (X == 0) {
                        FlagCamCont = 0;
                    }

                    if (X == 101) {
                        EncRST_ON = 1;
                        timer1.Enabled = true;
                    }



                }




            }
        }

        private void setUP() {
            iniFileRead();

            camListFileRead();
            //  kyotenFileRead();
            preFileRead();

            setLocation_4();

            paternFileRead();

            //    camNameGet();

            this.webBrowser1.Visible = true;
            this.webBrowser2.Visible = true;
            this.webBrowser3.Visible = true;
            this.webBrowser4.Visible = true;
            this.webBrowser1.Url = new Uri(path + @"camViewer\cam001.html", UriKind.Absolute);
            this.webBrowser2.Url = new Uri(path + @"camViewer\cam002.html", UriKind.Absolute);
            this.webBrowser3.Url = new Uri(path + @"camViewer\cam003.html", UriKind.Absolute);
            this.webBrowser4.Url = new Uri(path + @"camViewer\cam004.html", UriKind.Absolute);

            //     this.btnSpeed01.Image = global::WindowsFormsApp3.Properties.Resources.button_109;
            //     this.btnSpeed02.Image = global::WindowsFormsApp3.Properties.Resources.button_109;
            Speed = 2;



        }

        private void preFileRead() {
            string line = "";

            if (CamNo < 100) {
                String CN = "" + (CamNo + 1);

                for (int i = 0; i < 8; ++i) {
                    preNameLab[i].Visible = true;
                }

                btn_preNameChange.Visible = true;
                btn_preReg.Visible = true;


                try {
                    FileStream fs = new FileStream(path + @"preset\cam00" + CN + ".txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));


                    int index = 0;



                    while ((line = sr.ReadLine()) != null) {
                        string[] words = line.Split(separator);

                        preNameLab[index].Text = words[1];
                        preNameTxt[index].Text = words[1];
                        ++index;

                    }
                } catch {

                }
            } else {
                for (int i = 0; i < 8; ++i) {
                    preNameLab[i].Visible = false;
                }

                btn_preNameChange.Visible = false;
                btn_preReg.Visible = false;
            }
        }

        private void iniFileRead() {
            string line = "";
            try {
                FileStream fs = new FileStream("set.ini", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));


                int index = 0;

                while ((line = sr.ReadLine()) != null) {
                    string[] words = line.Split(separator);

                    if (index == 0) {
                        path = words[1];
                    } else if (index == 1) {
                        prefile = words[1];

                    } else if (index == 2) {
                        basho = int.Parse(words[1]);
                        if (basho == 1) {
                            //        this.preTouroku.Size = new Size(90, 50);
                        } else {
                            //        this.preTouroku.Size = new Size(0, 0);
                        }
                    } else if (index == 3) {
                        //    FormType = int.Parse(words[1]);
                        //MessageBox.Show("FormType=" + FormType);
                    } else if (index == 4) {
                        RecIP = words[1];
                    } else if (index == 5) {
                        timerTime = int.Parse(words[1]);
                    } else if (index == 6) {
                        Pass = words[1];
                    }

                    index++;

                }
            } catch {

            }

        }
        /*
                private void kyotenFileRead()
                {
                    string line = "";

                    try
                    {
                        FileStream fs = new FileStream(path + "kyoten.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));

                        int index = 0;

                        while ((line = sr.ReadLine()) != null)
                        {

                            if (line.IndexOf("[") == 0)
                            {
                                index = 0;
                            }

                            if (index >= 1)
                            {
                                string[] words = line.Split(separator);
                                kyoten[index - 1, 0] = words[1];
                                kyoten[index - 1, 1] = words[2];
                                kyoten[index - 1, 2] = words[3];
                                kyoten[index - 1, 3] = words[4];
                                kyoten[index - 1, 4] = words[5];
                            }


                            index++;


                        }





                    }
                    catch
                    {

                    }


                    //      ↓各拠点ファイルを読み込む


                    this.Text = kyoten[basho - 1, 0];


                    try
                    {
                        FileStream fs = new FileStream(path + kyoten[basho - 1, 1] + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));

                        int index = 0;

                        while ((line = sr.ReadLine()) != null)
                        {

                            if (line.IndexOf("[RecCont]") == 0)
                            {
                                string[] words = line.Split(separator);
                                REC = int.Parse(words[1]);
                            }

                            if (line.IndexOf("[") == 0)
                            {
                                index = 0;
                            }

                            if (index >= 1)
                            {
                                string[] words = line.Split(separator);


                                camContEnable[index - 1] = int.Parse(words[1]);
                                camSetEnable[index - 1] = int.Parse(words[2]);
                                encResetEnable[index - 1] = int.Parse(words[3]);
                                camSpEnable[index - 1] = int.Parse(words[4]);


                            }


                            index++;


                        }





                    }
                    catch
                    {

                    }


                    //////  map.csvの読み込み部分   ///////

                    try
                    {
                        FileStream fs = new FileStream(path + "map.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));

                        int index = 0;

                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] words = line.Split(separator);

                            if (index >= 1)
                            {
                                mapName[index - 1] = words[1];
                                mapFile[index - 1] = words[2];
                                mapEnable[index - 1] = int.Parse(words[3]);
                                mapNameFS[index - 1] = float.Parse(words[4]);
                            }


                            ++index;
                        }
                    }
                    catch
                    {

                    }



        ///*
                    if (REC == 0)
                    {
                        this.btnRec.Size = new System.Drawing.Size(0, 0);
                    }
                    else if (REC == 1)
                    {
                        this.btnRec.Size = new System.Drawing.Size(190, 50);
                    }

        //*/
        /*

                    for (int i = 0; i < camEnableNum; ++i)
                    {
                        if (camSetEnable[i] == 0)
                        {
                       //     camBtnLab[i].Visible = false;
                       //     camIconLab[i].Visible = false;
                       //     camNameLab[i].Visible = false;
                        }
                        else
                        {
                       //     camBtnLab[i].Visible = true;
                       //     camIconLab[i].Visible = true;
                       //     camNameLab[i].Visible = true;
                        }
                    }


                    for (int i = 0; i < 5; ++i)
                    {
                        if (mapEnable[i] == 1)
                        {
                            // mapBtnLab[i].Text = mapName[i];
                          ////  mapBtnLab[i].Font = new System.Drawing.Font("HGPｺﾞｼｯｸE", mapNameFS[i], System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));


                        }
                        else
                        {
                         //   mapBtnLab[i].Text = "";
                         //   mapBtnLab[i].Enabled = false;
                        }


                    }



                }

        */

        private void camListFileRead() {
            string line = "";

            try {

                FileStream fs = new FileStream(path + "camlist.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));

                int index = 0;


                while ((line = sr.ReadLine()) != null) {

                    if (line.IndexOf("[") == 0) {
                        index = 0;
                    }

                    if (index >= 1) {
                        string[] words = line.Split(separator);
                        camName[index - 1] = words[1];
                        camEnable[index - 1] = int.Parse(words[2]);
                        camMapNo[index - 1] = int.Parse(words[3]);
                        camPosiX[index - 1] = int.Parse(words[4]);
                        camPosiY[index - 1] = int.Parse(words[5]);
                        camLabLong[index - 1] = int.Parse(words[6]);
                        camIP[index - 1] = words[7];
                        camEnc[index - 1] = int.Parse(words[8]);
                        blackLevel[index - 1] = int.Parse(words[9]);
                        camType[index - 1] = int.Parse(words[10]);

                        if (camEnable[index - 1] == 1) {
                            camEnableNum++;
                        }
                    }


                    index++;

                }
            } catch {

            }

        }

        private void paternFileRead() {
            string line = "";

            try {

                FileStream fs = new FileStream(path + "patern.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"));

                int index = 0;


                while ((line = sr.ReadLine()) != null) {


                    string[] words = line.Split(separator);
                    patternName[index] = words[0];
                    patternNo[index, 0] = (int.Parse(words[1])) - 1;
                    patternNo[index, 1] = (int.Parse(words[2])) - 1;
                    patternNo[index, 2] = (int.Parse(words[3])) - 1;
                    patternNo[index, 3] = (int.Parse(words[4])) - 1;


                    index++;
                }
            } catch {

            }

        }

        private void setLocation_4() {

            moniMode = 4;

            s41X = 216;
            s41Y = 58;
            s41W = 840;
            s41H = 472;
            s4LW = 15;

            s42X = s41X + 846;
            s42Y = s41Y;
            s42W = s41W;
            s42H = s41H;

            s43X = s41X;
            s43Y = s41Y + 500;
            s43W = s41W;
            s43H = s41H;

            s44X = s42X;
            s44Y = s41Y + 500;
            s44W = s41W;
            s44H = s41H;


            this.label2.Visible = true;
            this.webBrowser2.Visible = true;
            this.cam002_left.Visible = true;
            this.cam002_right.Visible = true;
            this.cam002_down.Visible = true;

            this.label3.Visible = true;
            this.webBrowser3.Visible = true;
            this.cam003_left.Visible = true;
            this.cam003_right.Visible = true;
            this.cam003_down.Visible = true;

            this.label4.Visible = true;
            this.webBrowser4.Visible = true;
            this.cam004_left.Visible = true;
            this.cam004_right.Visible = true;
            this.cam004_down.Visible = true;


            this.label1.Location = new System.Drawing.Point(s41X + 13, s41Y - 8);
            this.label1.Size = new System.Drawing.Size(s41W - 24, s4LW + 10);

            this.webBrowser1.Location = new System.Drawing.Point(s41X + 1, s41Y - 4);
            this.webBrowser1.Size = new System.Drawing.Size(s41W, s41H);

            this.cam001_left.Location = new System.Drawing.Point(s41X, s41Y - 8);
            this.cam001_left.Size = new System.Drawing.Size(s4LW, s41H + 9);

            this.cam001_right.Location = new System.Drawing.Point(s41W + s41X + 1 - s4LW, s41Y - 8);
            this.cam001_right.Size = new System.Drawing.Size(s4LW, s41H + 9);

            this.cam001_down.Location = new System.Drawing.Point(s41X, s41H + s41Y - 8);
            this.cam001_down.Size = new System.Drawing.Size(s41W + 1, s4LW);



            this.label2.Location = new System.Drawing.Point(s42X + 13, s42Y - 8);
            this.label2.Size = new System.Drawing.Size(s42W - 24, s4LW + 10);

            this.webBrowser2.Location = new System.Drawing.Point(s42X + 1, s42Y - 4);
            this.webBrowser2.Size = new System.Drawing.Size(s42W, s42H);

            this.cam002_left.Location = new System.Drawing.Point(s42X, s42Y - 8);
            this.cam002_left.Size = new System.Drawing.Size(s4LW, s42H + 9);

            this.cam002_right.Location = new System.Drawing.Point(s42W + s42X + 1 - s4LW, s42Y - 8);
            this.cam002_right.Size = new System.Drawing.Size(s4LW, s42H + 9);

            this.cam002_down.Location = new System.Drawing.Point(s42X, s42H + s42Y - 8);
            this.cam002_down.Size = new System.Drawing.Size(s42W + 1, s4LW);


            this.label3.Location = new System.Drawing.Point(s43X + 13, s43Y - 8);
            this.label3.Size = new System.Drawing.Size(s43W - 24, s4LW + 10);

            this.webBrowser3.Location = new System.Drawing.Point(s43X + 1, s43Y - 4);
            this.webBrowser3.Size = new System.Drawing.Size(s43W, s43H);

            this.cam003_left.Location = new System.Drawing.Point(s43X, s43Y - 8);
            this.cam003_left.Size = new System.Drawing.Size(s4LW, s44H + 9);

            this.cam003_right.Location = new System.Drawing.Point(s43W + s43X + 1 - s4LW, s43Y - 8);
            this.cam003_right.Size = new System.Drawing.Size(s4LW, s43H + 9);

            this.cam003_down.Location = new System.Drawing.Point(s43X, s43H + s43Y - 8);
            this.cam003_down.Size = new System.Drawing.Size(s43W + 1, s4LW);


            this.label4.Location = new System.Drawing.Point(s44X + 13, s44Y - 8);
            this.label4.Size = new System.Drawing.Size(s44W - 24, s4LW + 10);

            this.webBrowser4.Location = new System.Drawing.Point(s44X + 1, s44Y - 4);
            this.webBrowser4.Size = new System.Drawing.Size(s44W, s44H);

            this.cam004_left.Location = new System.Drawing.Point(s44X, s44Y - 8);
            this.cam004_left.Size = new System.Drawing.Size(s4LW, s44H + 9);

            this.cam004_right.Location = new System.Drawing.Point(s44W + s44X + 1 - s4LW, s44Y - 8);
            this.cam004_right.Size = new System.Drawing.Size(s4LW, s44H + 9);

            this.cam004_down.Location = new System.Drawing.Point(s44X, s44H + s44Y - 8);
            this.cam004_down.Size = new System.Drawing.Size(s44W + 1, s4LW);

        }

        private void setLocation_1() {
            moniMode = 1;

            s41X = 216;
            s41Y = 58;
            s41W = 1680;
            s41H = 945;
            s4LW = 15;

            s42X = 0;
            s42Y = 0;
            s42W = 0;
            s42H = 0;

            s43X = 0;
            s43Y = 0;
            s43W = 0;
            s43H = 0;

            s44X = 0;
            s44Y = 0;
            s44W = 0;
            s44H = 0;

            this.label2.Visible = false;
            this.webBrowser2.Visible = false;
            this.cam002_left.Visible = false;
            this.cam002_right.Visible = false;
            this.cam002_down.Visible = false;

            this.label3.Visible = false;
            this.webBrowser3.Visible = false;
            this.cam003_left.Visible = false;
            this.cam003_right.Visible = false;
            this.cam003_down.Visible = false;

            this.label4.Visible = false;
            this.webBrowser4.Visible = false;
            this.cam004_left.Visible = false;
            this.cam004_right.Visible = false;
            this.cam004_down.Visible = false;




            this.label1.Location = new System.Drawing.Point(s41X + 13, s41Y - 8);
            this.label1.Size = new System.Drawing.Size(s41W - 24, s4LW + 10);

            this.webBrowser1.Location = new System.Drawing.Point(s41X + 1, s41Y - 4);
            this.webBrowser1.Size = new System.Drawing.Size(s41W, s41H);

            this.cam001_left.Location = new System.Drawing.Point(s41X, s41Y - 8);
            this.cam001_left.Size = new System.Drawing.Size(s4LW, s41H + 9);

            this.cam001_right.Location = new System.Drawing.Point(s41W + s41X + 1 - s4LW, s41Y - 8);
            this.cam001_right.Size = new System.Drawing.Size(s4LW, s41H + 9);

            this.cam001_down.Location = new System.Drawing.Point(s41X, s41H + s41Y - 6);
            this.cam001_down.Size = new System.Drawing.Size(s41W + 1, s4LW);



        }

        private void camSelect(int a) {


            this.label1.BackColor = Color.DeepSkyBlue;
            this.cam001_left.BackColor = Color.Black;
            this.cam001_right.BackColor = Color.Black;
            this.cam001_down.BackColor = Color.Black;

            this.label2.BackColor = Color.DeepSkyBlue;
            this.cam002_left.BackColor = Color.Black;
            this.cam002_right.BackColor = Color.Black;
            this.cam002_down.BackColor = Color.Black;

            this.label3.BackColor = Color.DeepSkyBlue;
            this.cam003_left.BackColor = Color.Black;
            this.cam003_right.BackColor = Color.Black;
            this.cam003_down.BackColor = Color.Black;

            this.label4.BackColor = Color.DeepSkyBlue;
            this.cam004_left.BackColor = Color.Black;
            this.cam004_right.BackColor = Color.Black;
            this.cam004_down.BackColor = Color.Black;

            if (a == 1) {
                this.label1.BackColor = Color.Red;
                this.cam001_left.BackColor = Color.Red;
                this.cam001_right.BackColor = Color.Red;
                this.cam001_down.BackColor = Color.Red;
                CamNo = camNo_01;
                Mode = 0;
            } else if (a == 2) {
                this.label2.BackColor = Color.Red;
                this.cam002_left.BackColor = Color.Red;
                this.cam002_right.BackColor = Color.Red;
                this.cam002_down.BackColor = Color.Red;
                CamNo = camNo_02;
                Mode = 0;

            } else if (a == 3) {
                this.label3.BackColor = Color.Red;
                this.cam003_left.BackColor = Color.Red;
                this.cam003_right.BackColor = Color.Red;
                this.cam003_down.BackColor = Color.Red;
                CamNo = camNo_03;
                Mode = 0;
            } else if (a == 4) {
                this.label4.BackColor = Color.Red;
                this.cam004_left.BackColor = Color.Red;
                this.cam004_right.BackColor = Color.Red;
                this.cam004_down.BackColor = Color.Red;
                CamNo = camNo_04;
                Mode = 0;
            } else if (a == 11) {
                this.label1.BackColor = Color.Green;
                this.cam001_left.BackColor = Color.Green;
                this.cam001_right.BackColor = Color.Green;
                this.cam001_down.BackColor = Color.Green;
                CamNo = camNo_01;
            } else if (a == 22) {
                this.label2.BackColor = Color.Green;
                this.cam002_left.BackColor = Color.Green;
                this.cam002_right.BackColor = Color.Green;
                this.cam002_down.BackColor = Color.Green;
                CamNo = camNo_02;
            } else if (a == 33) {
                this.label3.BackColor = Color.Green;
                this.cam003_left.BackColor = Color.Green;
                this.cam003_right.BackColor = Color.Green;
                this.cam003_down.BackColor = Color.Green;
                CamNo = camNo_03;
            } else if (a == 44) {
                this.label4.BackColor = Color.Green;
                this.cam004_left.BackColor = Color.Green;
                this.cam004_right.BackColor = Color.Green;
                this.cam004_down.BackColor = Color.Green;
                CamNo = camNo_04;
            }


            preFileRead();


        }

        private void setBrowser(int a, int b) {

            if (a == 1) {
                if (Mode == 0) {
                    this.webBrowser1.Url = new Uri(path + @"camViewer\000.html", UriKind.Absolute);
                    this.webBrowser2.Url = new Uri(path + @"camViewer\000.html", UriKind.Absolute);
                    this.webBrowser3.Url = new Uri(path + @"camViewer\000.html", UriKind.Absolute);
                    this.webBrowser4.Url = new Uri(path + @"camViewer\000.html", UriKind.Absolute);




                    this.webBrowser1.Url = new Uri(path + @"camViewer\cam00" + (b + 1) + "X.html", UriKind.Absolute);



                    CamNo = b;
                    preFileRead();
                    this.label1.Text = camName[b];


                } else if (Mode == 1) {
                    this.webBrowser1.Url = new Uri(path + @"camViewer\cam00" + (b + 1) + ".html", UriKind.Absolute);



                    CamNo = b;

                    this.label1.Text = camName[b];

                    Mode = 0;


                } else if (Mode == 2) {
                    this.webBrowser2.Url = new Uri(path + @"camViewer\cam00" + (b + 1) + ".html", UriKind.Absolute);



                    CamNo = b;

                    this.label2.Text = camName[b];

                    Mode = 0;


                } else if (Mode == 3) {
                    this.webBrowser3.Url = new Uri(path + @"camViewer\cam00" + (b + 1) + ".html", UriKind.Absolute);



                    CamNo = b;

                    this.label3.Text = camName[b];

                    Mode = 0;


                } else if (Mode == 4) {
                    this.webBrowser4.Url = new Uri(path + @"camViewer\cam00" + (b + 1) + ".html", UriKind.Absolute);



                    CamNo = b;

                    this.label4.Text = camName[b];

                    Mode = 0;


                }


            } else if (a == 2) {
                this.webBrowser1.Url = new Uri(path + @"camViewer\cam00" + (patternNo[b, 0] + 1) + ".html", UriKind.Absolute);
                this.webBrowser2.Url = new Uri(path + @"camViewer\cam00" + (patternNo[b, 1] + 1) + ".html", UriKind.Absolute);
                this.webBrowser3.Url = new Uri(path + @"camViewer\cam00" + (patternNo[b, 2] + 1) + ".html", UriKind.Absolute);
                this.webBrowser4.Url = new Uri(path + @"camViewer\cam00" + (patternNo[b, 3] + 1) + ".html", UriKind.Absolute);

                this.label1.Text = camName[patternNo[b, 0]];
                this.label2.Text = camName[patternNo[b, 1]];
                this.label3.Text = camName[patternNo[b, 2]];
                this.label4.Text = camName[patternNo[b, 3]];

                camNo_01 = patternNo[b, 0];
                camNo_02 = patternNo[b, 1];
                camNo_03 = patternNo[b, 2];
                camNo_04 = patternNo[b, 3];


                CamNo = 100;
                preFileRead();

            } else {
                this.webBrowser1.Url = new Uri(path + @"camViewer\cam000.html", UriKind.Absolute);
                this.webBrowser2.Url = new Uri(path + @"camViewer\cam000.html", UriKind.Absolute);
                this.webBrowser3.Url = new Uri(path + @"camViewer\cam000.html", UriKind.Absolute);
                this.webBrowser4.Url = new Uri(path + @"camViewer\cam000.html", UriKind.Absolute);
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e) {
            if (moniMode == 4) {
                camSelect(11);
                Mode = 1;
            }
        }

        private void label2_DoubleClick(object sender, EventArgs e) {
            if (moniMode == 4) {
                camSelect(22);
                Mode = 2;
            }
        }

        private void label3_DoubleClick(object sender, EventArgs e) {
            if (moniMode == 4) {
                camSelect(33);
                Mode = 3;
            }
        }

        private void label4_DoubleClick(object sender, EventArgs e) {
            if (moniMode == 4) {
                camSelect(44);
                Mode = 4;
            }

        }

        private void btn_map_Click(object sender, EventArgs e) {
            Control_Form cfObj = new Control_Form();
            cfObj.Map_Show();
        }

        private void btn_rec_Click(object sender, EventArgs e) {

            //    setLocation_1();
            //    setBrowser(3, 0);

            Form2 form2 = new Form2(this, RecIP);
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
            RecOn = 1;
        }
    }
}
