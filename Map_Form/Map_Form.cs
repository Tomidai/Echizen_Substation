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
            //ロード時は設定ファイルを読み込む
            snObj.ChangeSensor(snObj.ReturnSetting("sensor1.csv"), Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01, 
                Properties.Resources.Sensor_EnvironLock_01);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor2.csv"), Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                Properties.Resources.Sensor_EnvironLock_02);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor3.csv"), Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                Properties.Resources.Sensor_EnvironLock_03);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor4.csv"), Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                Properties.Resources.Sensor_EnvironLock_04);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor5.csv"), Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                Properties.Resources.Sensor_EnvironLock_05);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor6.csv"), Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                Properties.Resources.Sensor_EnvironLock_06);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor7.csv"), Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                Properties.Resources.Sensor_EnvironLock_07);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor8.csv"), Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                Properties.Resources.Sensor_EnvironLock_08);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor9.csv"), Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                Properties.Resources.Sensor_EnvironLock_09);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor10.csv"), Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                Properties.Resources.Sensor_EnvironLock_10);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor11.csv"), Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                Properties.Resources.Sensor_EnvironLock_11);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor12.csv"), Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                Properties.Resources.Sensor_EnvironLock_12);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor13.csv"), Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                Properties.Resources.Sensor_EnvironLock_13);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor14.csv"), Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                Properties.Resources.Sensor_EnvironLock_14);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor15.csv"), Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                Properties.Resources.Sensor_EnvironLock_15);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor16.csv"), Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                Properties.Resources.Sensor_EnvironLock_16);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor17.csv"), Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                Properties.Resources.Sensor_EnvironLock_17);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor18.csv"), Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                Properties.Resources.Sensor_EnvironLock_18);

            snObj.ChangeSensor(snObj.ReturnSetting("sensor19.csv"), Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                Properties.Resources.Sensor_EnvironLock_19);
        }

        //左クリックでセンサーロック/解除
        //またはアラーム復旧
        private void SensorClick_Left(PictureBox pic,string snPath) {
            if ((string)pic.Tag == "Normal" || (string)pic.Tag == "EnvironLock") {
                //通常からロック
                snObj.SensorSettingChange(snPath, 1, "1");
            } else if ((string)pic.Tag == "Alarm" || (string)pic.Tag == "Environ" || (string)pic.Tag == "Failed") {
                //アラームから通常に戻す処理
                snObj.SensorSettingChange(snPath, 3, "0");
            } else if ((string)pic.Tag == "Lock") {
                //ロックから通常に戻す処理
                snObj.SensorSettingChange(snPath, 1, "0");
            }
        }

        //右クリックで環境ロック/解除する処理
        private void SensorClick_Right(PictureBox pic,string snPath){
            //タグがNormalの場合のみ環境をロックできる
            if((string)pic.Tag == "Normal"){
                //設定ファイルを読み込む
                snObj.SensorSettingChange(snPath, 2, "1");
            }else if((string)pic.Tag == "EnvironLock"){
                //タグがEnvironLockの場合のみノーマルに戻る
                snObj.SensorSettingChange(snPath, 2, "0");
            }else{
                MessageBox.Show("センサーが通常状態か確認してください");
            }
        }

        //閉じるときは全て閉じる
        private void Map_Form_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        //マウスクリックイベント
        private void Sensor_01_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_01, "sensor1.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_01, "sensor1.csv");
            }
        }

        private void Sensor_02_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_02, "sensor2.csv");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_02, "sensor2.csv");
            }
        }

        private void Sensor_03_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_03, "sensor3.csv");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_03, "sensor3.csv");
            }
        }

        private void Sensor_04_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_04, "sensor4.csv");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_04, "sensor4.csv");
            }
        }

        private void Sensor_05_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_05, "sensor5.csv");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_05, "sensor5.csv");
            }
        }

        private void Sensor_06_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_06, "sensor6.csv");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_06, "sensor6.csv");
            }
        }

        private void Sensor_07_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_07, "sensor7.csv");
            } else if (e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_07, "sensor7.csv");
            }
        }

        private void Sensor_08_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_08, "sensor8.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_08, "sensor8.csv");
            }
        }

        private void Sensor_09_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_09, "sensor9.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_09, "sensor9.csv");
            }
        }

        private void Sensor_10_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_10, "sensor10.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_10, "sensor10.csv");
            }
        }

        private void Sensor_11_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_11, "sensor11.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_11, "sensor11.csv");
            }
        }

        private void Sensor_12_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_12, "sensor12.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_12, "sensor12.csv");
            }
        }

        private void Sensor_13_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_13, "sensor13.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_13, "sensor13.csv");
            }
        }

        private void Sensor_14_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_14, "sensor14.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_14, "sensor14.csv");
            }
        }

        private void Sensor_15_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_15, "sensor15.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_15, "sensor15.csv");
            }
        }

        private void Sensor_16_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_16, "sensor16.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_16, "sensor16.csv");
            }
        }

        private void Sensor_17_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_17, "sensor17.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_17, "sensor17.csv");
            }
        }

        private void Sensor_18_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_18, "sensor18.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_18, "sensor18.csv");
            }
        }

        private void Sensor_19_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                SensorClick_Left(Sensor_19, "sensor19.csv");
            } else if(e.Button == MouseButtons.Right) {
                SensorClick_Right(Sensor_19, "sensor19.csv");
            }
        }

        //カメラ切り替えボタン処理
        //ここは後に処理を変更する必要あり
        private void GotoCamera_Button1_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button1.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button1_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button1.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button2_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button2.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button2_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button2.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button3_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button3.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button3_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button3.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button4_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button4.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button4_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button4.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button5_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button5.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button5_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button5.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button6_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button6.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button6_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button6.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button7_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button7.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button7_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button7.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        private void GotoCamera_Button8_MouseDown(object sender, MouseEventArgs e) {
            GotoCamera_Button8.Image = Properties.Resources.camera_button_push;
        }
        private void GotoCamera_Button8_MouseUp(object sender, MouseEventArgs e) {
            GotoCamera_Button8.Image = Properties.Resources.camera_button_normal;
            cfObj.Camera_Show();
        }

        //カメラアイコンクリックの処理
        private void Camera_01_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_02_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_03_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_04_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_05_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_06_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_07_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        private void Camera_08_Click(object sender, EventArgs e) {
            cfObj.Camera_Show();
        }

        //センサー一括ロック/解除の処理
        private void SensorLock500_on_MouseDown(object sender, MouseEventArgs e) {
            SensorLock500_on.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock500_on_MouseUp(object sender, MouseEventArgs e) {
            SensorLock500_on.Image = Properties.Resources.electrical_button_normal;
            snObj.SensorSettingChange("sensor1.csv", 1, "1");
            snObj.SensorSettingChange("sensor2.csv", 1, "1");
            snObj.SensorSettingChange("sensor3.csv", 1, "1");
            snObj.SensorSettingChange("sensor4.csv", 1, "1");
            snObj.SensorSettingChange("sensor5.csv", 1, "1");
            snObj.SensorSettingChange("sensor6.csv", 1, "1");
            snObj.SensorSettingChange("sensor7.csv", 1, "1");
            snObj.SensorSettingChange("sensor8.csv", 1, "1");
            snObj.SensorSettingChange("sensor9.csv", 1, "1");
            snObj.SensorSettingChange("sensor10.csv", 1, "1");
            snObj.SensorSettingChange("sensor11.csv", 1, "1");
            snObj.SensorSettingChange("sensor12.csv", 1, "1");
            snObj.SensorSettingChange("sensor13.csv", 1, "1");
        }

        private void SensorLock500_off_MouseDown(object sender, MouseEventArgs e) {
            SensorLock500_off.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock500_off_MouseUp(object sender, MouseEventArgs e) {
            SensorLock500_off.Image = Properties.Resources.electrical_button_normal;
            snObj.SensorSettingChange("sensor1.csv", 1, "0");
            snObj.SensorSettingChange("sensor2.csv", 1, "0");
            snObj.SensorSettingChange("sensor3.csv", 1, "0");
            snObj.SensorSettingChange("sensor4.csv", 1, "0");
            snObj.SensorSettingChange("sensor5.csv", 1, "0");
            snObj.SensorSettingChange("sensor6.csv", 1, "0");
            snObj.SensorSettingChange("sensor7.csv", 1, "0");
            snObj.SensorSettingChange("sensor8.csv", 1, "0");
            snObj.SensorSettingChange("sensor9.csv", 1, "0");
            snObj.SensorSettingChange("sensor10.csv", 1, "0");
            snObj.SensorSettingChange("sensor11.csv", 1, "0");
            snObj.SensorSettingChange("sensor12.csv", 1, "0");
            snObj.SensorSettingChange("sensor13.csv", 1, "0");
        }

        private void SensorLock77_on_MouseDown(object sender, MouseEventArgs e) {
            SensorLock77_on.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock77_on_MouseUp(object sender, MouseEventArgs e) {
            SensorLock77_on.Image = Properties.Resources.electrical_button_normal;
            snObj.SensorSettingChange("sensor14.csv", 1, "1");
            snObj.SensorSettingChange("sensor15.csv", 1, "1");
            snObj.SensorSettingChange("sensor16.csv", 1, "1");
            snObj.SensorSettingChange("sensor17.csv", 1, "1");
            snObj.SensorSettingChange("sensor18.csv", 1, "1");
            snObj.SensorSettingChange("sensor19.csv", 1, "1");
        }

        private void SensorLock77_off_MouseDown(object sender, MouseEventArgs e) {
            SensorLock77_off.Image = Properties.Resources.electrical_button_push;
        }
        private void SensorLock77_off_MouseUp(object sender, MouseEventArgs e) {
            SensorLock77_off.Image = Properties.Resources.electrical_button_normal;
            snObj.SensorSettingChange("sensor14.csv", 1, "0");
            snObj.SensorSettingChange("sensor15.csv", 1, "0");
            snObj.SensorSettingChange("sensor16.csv", 1, "0");
            snObj.SensorSettingChange("sensor17.csv", 1, "0");
            snObj.SensorSettingChange("sensor18.csv", 1, "0");
            snObj.SensorSettingChange("sensor19.csv", 1, "0");
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
            snObj.SensorSettingChange("sensor1.csv", 3, "0");
            snObj.SensorSettingChange("sensor2.csv", 3, "0");
            snObj.SensorSettingChange("sensor3.csv", 3, "0");
            snObj.SensorSettingChange("sensor4.csv", 3, "0");
            snObj.SensorSettingChange("sensor5.csv", 3, "0");
            snObj.SensorSettingChange("sensor6.csv", 3, "0");
            snObj.SensorSettingChange("sensor7.csv", 3, "0");
            snObj.SensorSettingChange("sensor8.csv", 3, "0");
            snObj.SensorSettingChange("sensor9.csv", 3, "0");
            snObj.SensorSettingChange("sensor10.csv", 3, "0");
            snObj.SensorSettingChange("sensor11.csv", 3, "0");
            snObj.SensorSettingChange("sensor12.csv", 3, "0");
            snObj.SensorSettingChange("sensor13.csv", 3, "0");
            snObj.SensorSettingChange("sensor14.csv", 3, "0");
            snObj.SensorSettingChange("sensor15.csv", 3, "0");
            snObj.SensorSettingChange("sensor16.csv", 3, "0");
            snObj.SensorSettingChange("sensor17.csv", 3, "0");
            snObj.SensorSettingChange("sensor18.csv", 3, "0");
            snObj.SensorSettingChange("sensor19.csv", 3, "0");
        }

        //ブザー停止ボタン
        private void MuteButton_MouseDown(object sender, MouseEventArgs e) {
            MuteButton.Image = Properties.Resources.mute_button_push;
        }
        private void MuteButton_MouseUp(object sender, MouseEventArgs e) {
            MuteButton.Image = Properties.Resources.mute_button_normal;
            //ブザー停止処理
            MuteButton.Tag = "off";
        }

        //試験的なイベント後で削除異常ボタンから発生
        private void FaultButton_Click(object sender, EventArgs e) {
            snObj.SensorSettingChange("sensor1.csv", 1, "1");
        }
    }
}
