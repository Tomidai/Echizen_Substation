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

        //コンストラクタ
        public Map_Form() {
            InitializeComponent();
        }

        private void Map_Form_Load(object sender, EventArgs e) {
            snObj = new Sensor(this);
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

        private void button7_Click(object sender, EventArgs e) {
            Form1 form1 = new Form1();
            form1.Camera_Show();
        }

        //アプリケーション終了
        private void button15_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //センサー設定ボタン
        private void button5_Click(object sender, EventArgs e) {
            SensorSettings_Form ssf = new SensorSettings_Form(this);
            ssf.ShowDialog();
        }

        //センサークリック時の処理
        //タグ状態に応じてセンサーの状態（設定ファイル、色）を変える
        //送りファイルに情報を送る
        private void SensorClick(PictureBox pic,int line,string str) {
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

        //センサークリック
        private void Sensor_01_Click(object sender, EventArgs e) {
            SensorClick(Sensor_01, 0,"01");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor01, Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                Properties.Resources.Sensor_EnvironLock_01);
        }

        private void Sensor_02_Click(object sender, EventArgs e) {
            SensorClick(Sensor_02, 1, "02");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor02, Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                Properties.Resources.Sensor_EnvironLock_02);
        }

        private void Sensor_03_Click(object sender, EventArgs e) {
            SensorClick(Sensor_03, 2, "03");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor03, Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                Properties.Resources.Sensor_EnvironLock_03);
        }

        private void Sensor_04_Click(object sender, EventArgs e) {
            SensorClick(Sensor_04, 3, "04");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor04, Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                Properties.Resources.Sensor_EnvironLock_04);
        }

        private void Sensor_05_Click(object sender, EventArgs e) {
            SensorClick(Sensor_05, 4, "05");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor05, Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                Properties.Resources.Sensor_Environ_05);
        }

        private void Sensor_06_Click(object sender, EventArgs e) {
            SensorClick(Sensor_06, 5, "06");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor06, Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                Properties.Resources.Sensor_EnvironLock_06);
        }

        private void Sensor_07_Click(object sender, EventArgs e) {
            SensorClick(Sensor_07, 6, "07");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor07, Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                Properties.Resources.Sensor_EnvironLock_07);
        }

        private void Sensor_08_Click(object sender, EventArgs e) {
            SensorClick(Sensor_08, 7, "08");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor08, Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                Properties.Resources.Sensor_EnvironLock_08);
        }

        private void Sensor_09_Click(object sender, EventArgs e) {
            SensorClick(Sensor_09, 8, "09");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor09, Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                Properties.Resources.Sensor_EnvironLock_09);
        }

        private void Sensor_10_Click(object sender, EventArgs e) {
            SensorClick(Sensor_10, 9, "10");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor10, Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                Properties.Resources.Sensor_EnvironLock_10);
        }

        private void Sensor_11_Click(object sender, EventArgs e) {
            SensorClick(Sensor_11, 10, "11");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor11, Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                Properties.Resources.Sensor_EnvironLock_11);
        }

        private void Sensor_12_Click(object sender, EventArgs e) {
            SensorClick(Sensor_12, 11, "12");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor12, Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                Properties.Resources.Sensor_EnvironLock_12);
        }

        private void Sensor_13_Click(object sender, EventArgs e) {
            SensorClick(Sensor_13, 12, "13");
            //センサー読み込み
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor13, Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                Properties.Resources.Sensor_Lock_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                Properties.Resources.Sensor_EnvironLock_13);
        }
    }
}
