using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace Map_Form {
    public partial class Map_Form:Form {

        //インスタンス固定
        Sensor snObj;
        Control_Form cfObj;

        //コンストラクタ
        public Map_Form() {
            InitializeComponent();
            snObj = new Sensor(this);
            cfObj = new Control_Form();
        }

        private void Map_Form_Load(object sender, EventArgs e) {
            snObj.GetSensorInfo();
            //ロード時は設定ファイルを読み込む
            snObj.ChangeSensor(snObj.sensor01, Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01, 
                Properties.Resources.Sensor_EnvironLock_01);

            snObj.ChangeSensor(snObj.sensor02, Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                Properties.Resources.Sensor_EnvironLock_02);

            snObj.ChangeSensor(snObj.sensor03, Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                Properties.Resources.Sensor_EnvironLock_03);

            snObj.ChangeSensor(snObj.sensor04, Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                Properties.Resources.Sensor_EnvironLock_04);

            snObj.ChangeSensor(snObj.sensor05, Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                Properties.Resources.Sensor_EnvironLock_05);

            snObj.ChangeSensor(snObj.sensor06, Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                Properties.Resources.Sensor_EnvironLock_06);

            snObj.ChangeSensor(snObj.sensor07, Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                Properties.Resources.Sensor_EnvironLock_07);

            snObj.ChangeSensor(snObj.sensor08, Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                Properties.Resources.Sensor_EnvironLock_08);

            snObj.ChangeSensor(snObj.sensor09, Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                Properties.Resources.Sensor_EnvironLock_09);

            snObj.ChangeSensor(snObj.sensor10, Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                Properties.Resources.Sensor_EnvironLock_10);

            snObj.ChangeSensor(snObj.sensor11, Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                Properties.Resources.Sensor_EnvironLock_11);

            snObj.ChangeSensor(snObj.sensor12, Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                Properties.Resources.Sensor_EnvironLock_12);

            snObj.ChangeSensor(snObj.sensor13, Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                Properties.Resources.Sensor_EnvironLock_13);

            snObj.ChangeSensor(snObj.sensor14, Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                Properties.Resources.Sensor_EnvironLock_14);

            snObj.ChangeSensor(snObj.sensor15, Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                Properties.Resources.Sensor_EnvironLock_15);

            snObj.ChangeSensor(snObj.sensor16, Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                Properties.Resources.Sensor_EnvironLock_16);

            snObj.ChangeSensor(snObj.sensor17, Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                Properties.Resources.Sensor_EnvironLock_17);

            snObj.ChangeSensor(snObj.sensor18, Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                Properties.Resources.Sensor_EnvironLock_18);

            snObj.ChangeSensor(snObj.sensor19, Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                Properties.Resources.Sensor_EnvironLock_19);
        }

        //左クリックでセンサーロック/解除
        //またはアラーム復旧
        private void SensorClick_Left(PictureBox pic,int line,string str) {
            if ((string)pic.Tag == "Normal") {
                //通常からロックにする処理
                //自分の設定ファイルを変更
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[1] = "1";
                setPath[line] = string.Join(",", changeLine);
                //設定ファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"], false)) {
                    for (int i = 0; i < setPath.Length; i++) {
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                    //送りテキストは引数が必要かな
                    sw.WriteLine(str + ",1,0,0");
                }

            } else if ((string)pic.Tag == "Alarm" || (string)pic.Tag == "Environ" || (string)pic.Tag == "Failed") {
                //アラームから通常に戻す処理
                //自分の設定ファイルを変更
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[3] = "0";
                setPath[line] = string.Join(",", changeLine);
                //設定ファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"], false)) {
                    for (int i = 0; i < setPath.Length; i++) {
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                    //ここも送りテキストなので引数かする必要あり
                    sw.WriteLine(str + ",0,0,1");
                }
            } else if ((string)pic.Tag == "Lock") {
                //ロックから通常に戻す処理
                //自分の設定ファイルを変更
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[1] = "0";
                setPath[line] = string.Join(",", changeLine);
                //設定ファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"], false)) {
                    for (int i = 0; i < setPath.Length; i++) {
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                    //ここも送りテキスト引数化
                    sw.WriteLine(str + ",0,0,0");
                }
            }
        }

        //右クリックで環境ロック/解除する処理
        private void SensorClick_Right(PictureBox pic,int line,string str){
            //タグがNormalの場合のみ環境をロックできる
            if((string)pic.Tag == "Normal"){
                //設定ファイルを読み込む
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[2] = "1";
                setPath[line] = string.Join(",",changeLine);
                //設定ファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"],false)){
                    for(int i = 0; i < setPath.Length; i++){
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"],false)){
                    sw.WriteLine(str + ",0,1,0");
                }
            }else if((string)pic.Tag == "EnvironLock"){
                //タグがEnvironLockの場合のみノーマルに戻る
                //設定ファイルを読み込む
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[2] = "0";
                setPath[line] = string.Join(",",changeLine);
                //設定ファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"],false)){
                    for(int i = 0; i < setPath.Length; i++){
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"],false)){
                    sw.WriteLine(str + ",0,0,0");
                }
            }else{
                MessageBox.Show("センサーが通常状態か確認してください");
            }
        }

        //一括処理のメソッド
        private void BulkChange(int bigin, int end, string change,int set) {
            string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
            for (int line = bigin; line < end; line++) {
                string[] changeLine = setPath[line].Split(',');
                changeLine[set] = change;
                setPath[line] = string.Join(",", changeLine);
            }
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"], false)) {
                //設定ファイル書き換え
                for (int i = 0; i < setPath.Length; i++) {
                    sw.WriteLine(setPath[i]);
                }
            }
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                for (int line = bigin; line < end; line++) {
                    //送りテキスト
                    switch (set) {
                        case 1:
                            sw.WriteLine((line + 1).ToString("00") + "," + change + ",0,0");
                            break;
                        case 2:
                            
                            break;
                        case 3:
                            sw.WriteLine((line + 1).ToString("00") + ",0,0,1");
                            break;
                    }
                }
            }
        }

        //マウスクリックイベント
        private void Sensor_01_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_01, 0, "01");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_01, 0, "01");
            }
        }

        private void Sensor_02_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_02, 1, "02");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_02, 1, "02");
            }
        }

        private void Sensor_03_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_03, 2, "03");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_03, 2, "03");
            }
        }

        private void Sensor_04_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_04, 3, "04");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_04, 3, "04");
            }
        }

        private void Sensor_05_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_05, 4, "05");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_05, 4, "05");
            }
        }

        private void Sensor_06_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_06, 5, "06");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_06, 5, "06");
            }
        }

        private void Sensor_07_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_07, 6, "07");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_07, 6, "07");
            }
        }

        private void Sensor_08_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_08, 7, "08");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_08, 7, "08");
            }
        }

        private void Sensor_09_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_09, 8, "09");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_09, 8, "09");
            }
        }

        private void Sensor_10_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_10, 9, "10");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_10, 9, "10");
            }
        }

        private void Sensor_11_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_11, 10, "11");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_11, 10, "11");
            }
        }

        private void Sensor_12_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_12, 11, "12");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_12, 11, "12");
            }
        }

        private void Sensor_13_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_13, 12, "13");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_13, 12, "13");
            }
        }

        private void Sensor_14_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_14, 13, "14");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_14, 13, "14");
            }
        }

        private void Sensor_15_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_15, 14, "15");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_15, 14, "15");
            }
        }

        private void Sensor_16_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_16, 15, "16");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_16, 15, "16");
            }
        }

        private void Sensor_17_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_17, 16, "17");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_17, 16, "17");
            }
        }

        private void Sensor_18_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_18, 17, "18");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_18, 17, "18");
            }
        }

        private void Sensor_19_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_19, 18, "19");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_19, 18, "19");
            }
        }

        //カメラ切り替えボタン処理
        //ここは後に処理を変更する必要あり
        private void GotoCamera_Button1_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button1.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button1_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button1.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(1);
        }

        private void GotoCamera_Button2_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button2.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button2_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button2.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(2);
        }

        private void GotoCamera_Button3_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button3.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button3_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button3.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(3);
        }

        private void GotoCamera_Button4_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button4.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button4_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button4.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(4);
        }

        private void GotoCamera_Button5_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button5.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button5_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button5.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(5);
        }

        private void GotoCamera_Button6_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button6.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button6_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button6.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(6);
        }

        private void GotoCamera_Button7_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button7.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button7_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button7.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(7);
        }

        private void GotoCamera_Button8_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button8.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button8_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button8.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show(8);
        }

        //カメラアイコンクリックの処理
        private void Camera_01_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(1);
        }

        private void Camera_02_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(2);
        }

        private void Camera_03_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(3);
        }

        private void Camera_04_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(4);
        }

        private void Camera_05_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(5);
        }

        private void Camera_06_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(6);
        }

        private void Camera_07_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(7);
        }

        private void Camera_08_Click(object sender, EventArgs e) {
            cfObj.Camera_Show(8);
        }

        //センサー一括ロック/解除の処理
        private void SensorLock500_on_MouseDown(object sender, MouseEventArgs e) {
            SensorLock500_on.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock500_on_MouseUp(object sender, MouseEventArgs e) {
            SensorLock500_on.Image = Properties.Resources.electrical_button_normal;
            BulkChange(0, 13, "1", 1);
        }

        private void SensorLock500_off_MouseDown(object sender, MouseEventArgs e) {
            SensorLock500_off.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock500_off_MouseUp(object sender, MouseEventArgs e) {
            SensorLock500_off.Image = Properties.Resources.electrical_button_normal;
            BulkChange(0, 13, "0", 1);
        }

        private void SensorLock77_on_MouseDown(object sender, MouseEventArgs e) {
            SensorLock77_on.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock77_on_MouseUp(object sender, MouseEventArgs e) {
            SensorLock77_on.Image = Properties.Resources.electrical_button_normal;
            BulkChange(13, 19, "1", 1);
        }

        private void SensorLock77_off_MouseDown(object sender, MouseEventArgs e) {
            SensorLock77_off.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock77_off_MouseUp(object sender, MouseEventArgs e) {
            SensorLock77_off.Image = Properties.Resources.electrical_button_normal;
            BulkChange(13, 19, "0", 1);
        }

        //システム終了ボタン
        private void ExitButton_MouseDown(object sender, MouseEventArgs e) {
            ExitButton.Image = Properties.Resources.exit_button_push;
        }
        private void ExitButton_MouseUp(object sender, MouseEventArgs e) {
            ExitButton.Image = Properties.Resources.exit_button_normal;
            Application.Exit();
        }

        //センサー設定ボタン
        private void SettingButton_MouseDown(object sender, MouseEventArgs e) {
            SettingButton.Image = Properties.Resources.setting_button_push;
        }
        private void SettingButton_MouseUp(object sender, MouseEventArgs e) {
            SettingButton.Image = Properties.Resources.setting_button_normal;
            SensorSettings_Form ssf = new SensorSettings_Form(this);
            ssf.ShowDialog();
        }

        //センサー復旧ボタン
        private void RestrationButton_MouseDown(object sender, MouseEventArgs e) {
            RestrationButton.Image = Properties.Resources.restoration_button_push;
        }
        private void RestrationButton_MouseUp(object sender, MouseEventArgs e) {
            RestrationButton.Image = Properties.Resources.restoration_button_normal;
            BulkChange(0, 19, "0", 3);
        }
    }
}
