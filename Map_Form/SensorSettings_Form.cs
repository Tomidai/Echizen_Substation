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
using System.Configuration;

namespace Map_Form {
    public partial class SensorSettings_Form:Form {
        //インスタンス
        public Map_Form mfObj;

        //コンストラクタ
        public SensorSettings_Form(Map_Form mf_obj) {
            InitializeComponent();
            mfObj = mf_obj;
        }

        private void SensorSettings_Form_Load(object sender, EventArgs e) {
            //設定ファイルを読み込み配列に入れる
            string[] settingInfo = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
            //１行づつ処理する
            for(int i =0; i<settingInfo.Length; i++) {
                //１行をCSVで配列に入れる
                string[] readLine = settingInfo[i].Split(',');
                //センサーロックかどうか
                if(readLine[1] == "1"){
                    //センサーロック状態を表示する
                    TextSet(i + 1,"ロックON");
                }else if(readLine[2] == "1"){
                    //環境ロック状態にする
                    TextSet(i + 1,"環境");
                }else{
                    //センサーロックOFFにする
                    TextSet(i + 1,"ロックOFF");
                }
            }
        }

        private void TextSet(int i, string str){
            switch(i){
                case 1:
                    comboBox1.Text = str;
                    break;
                case 2:
                    comboBox2.Text = str;
                    break;
                case 3:
                    comboBox3.Text = str;
                    break;
                case 4:
                    comboBox4.Text = str;
                    break;
                case 5:
                    comboBox5.Text = str;
                    break;
                case 6:
                    comboBox6.Text = str;
                    break;
                case 7:
                    comboBox7.Text = str;
                    break;
                case 8:
                    comboBox8.Text = str;
                    break;
                case 9:
                    comboBox9.Text = str;
                    break;
                case 10:
                    comboBox10.Text = str;
                    break;
                case 11:
                    comboBox11.Text = str;
                    break;
                case 12:
                    comboBox12.Text = str;
                    break;
                case 13:
                    comboBox13.Text = str;
                    break;
                case 14:
                    comboBox14.Text = str;
                    break;
                case 15:
                    comboBox15.Text = str;
                    break;
                case 16:
                    comboBox16.Text = str;
                    break;
                case 17:
                    comboBox17.Text = str;
                    break;
                case 18:
                    comboBox18.Text = str;
                    break;
                case 19:
                    comboBox19.Text = str;
                    break;
            }
        }

        //決定ボタン処理のメソッド
        private void AplySettings(ComboBox cb,int line){
            string str = cb.Text;
            if(str == "ロックON"){
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[1] = "1";
                changeLine[2] = "0";
                setPath[line] = string.Join(",",changeLine);
                //設定ファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"],false)){
                    for(int i = 0; i < setPath.Length; i++){
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                    //送りテキストは引数が必要かな
                    sw.WriteLine("01,1,0,0");
                }
            }else if(str == "ロックOFF"){
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[1] = "0";
                changeLine[2] = "0";
                setPath[line] = string.Join(",",changeLine);
                //設定ファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"],false)){
                    for(int i = 0; i < setPath.Length; i++){
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                    //送りテキストは引数が必要かな
                    sw.WriteLine("01,0,0,0");
                }
            }else if(str == "環境"){
                string[] setPath = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
                string[] changeLine = setPath[line].Split(',');
                changeLine[1] = "0";
                changeLine[2] = "1";
                setPath[line] = string.Join(",",changeLine);
                //設定ファイル書き換え
                using(StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"],false)){
                    for(int i = 0; i < setPath.Length; i++){
                        sw.WriteLine(setPath[i]);
                    }
                }
                //送りファイル書き換え
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false)) {
                    //送りテキストは引数が必要かな
                    sw.WriteLine("01,0,1,0");
                }
            }
        }

        //決定ボタンの処理
        private void button1_Click(object sender, EventArgs e) {
            Sensor snObj = new Sensor(mfObj);
            AplySettings(comboBox1,0);
            AplySettings(comboBox2,1);
            AplySettings(comboBox3,2);
            AplySettings(comboBox4,3);
            AplySettings(comboBox5,4);
            AplySettings(comboBox6,5);
            AplySettings(comboBox7,6);
            AplySettings(comboBox8,7);
            AplySettings(comboBox9,8);
            AplySettings(comboBox10,9);
            AplySettings(comboBox11,10);
            AplySettings(comboBox12,11);
            AplySettings(comboBox13,12);
            AplySettings(comboBox14,13);
            AplySettings(comboBox15,14);
            AplySettings(comboBox16,15);
            AplySettings(comboBox17,16);
            AplySettings(comboBox18,17);
            AplySettings(comboBox19,18);
            snObj.GetSensorInfo();
            snObj.ChangeSensor(snObj.sensor01, mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                Properties.Resources.Sensor_EnvironLock_01);
            snObj.ChangeSensor(snObj.sensor02, mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                Properties.Resources.Sensor_EnvironLock_02);
            snObj.ChangeSensor(snObj.sensor03, mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                Properties.Resources.Sensor_Action_03,Properties.Resources.Sensor_Environ_03,Properties.Resources.Sensor_Failed_03,
                Properties.Resources.Sensor_EnvironLock_03);
            snObj.ChangeSensor(snObj.sensor04, mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                Properties.Resources.Sensor_EnvironLock_04);
            snObj.ChangeSensor(snObj.sensor05, mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                Properties.Resources.Sensor_EnvironLock_05);
            snObj.ChangeSensor(snObj.sensor06, mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                Properties.Resources.Sensor_EnvironLock_06);
            snObj.ChangeSensor(snObj.sensor07, mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                Properties.Resources.Sensor_EnvironLock_07);
            snObj.ChangeSensor(snObj.sensor08, mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                Properties.Resources.Sensor_EnvironLock_08);
            snObj.ChangeSensor(snObj.sensor09, mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                Properties.Resources.Sensor_EnvironLock_09);
            snObj.ChangeSensor(snObj.sensor10, mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                Properties.Resources.Sensor_EnvironLock_10);
            snObj.ChangeSensor(snObj.sensor11, mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                Properties.Resources.Sensor_EnvironLock_11);
            snObj.ChangeSensor(snObj.sensor12, mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                Properties.Resources.Sensor_EnvironLock_12);
            snObj.ChangeSensor(snObj.sensor13, mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                Properties.Resources.Sensor_EnvironLock_13);
            snObj.ChangeSensor(snObj.sensor14, mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                Properties.Resources.Sensor_EnvironLock_14);
            snObj.ChangeSensor(snObj.sensor15, mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                Properties.Resources.Sensor_EnvironLock_15);
            snObj.ChangeSensor(snObj.sensor16, mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                Properties.Resources.Sensor_EnvironLock_16);
            snObj.ChangeSensor(snObj.sensor17, mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                Properties.Resources.Sensor_EnvironLock_17);
            snObj.ChangeSensor(snObj.sensor18, mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                Properties.Resources.Sensor_EnvironLock_18);
            snObj.ChangeSensor(snObj.sensor19, mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                Properties.Resources.Sensor_EnvironLock_19);
        }

        //キャンセルボタン
        private void button2_Click(object sender, EventArgs e) {

        }
    }
}
