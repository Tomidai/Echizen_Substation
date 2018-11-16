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
        }

        //キャンセルボタン
        private void button2_Click(object sender, EventArgs e) {

        }
    }
}
