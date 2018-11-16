using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Configuration;

namespace Map_Form {
    class Sensor {

        //Map_Formのインスタンス
        public Map_Form mfObj;
        public SensorAction snacObj;
        public Log logObj;

        //コンストラクタ
        public Sensor(Map_Form mf_obj) {
            mfObj = mf_obj;
            snacObj = new SensorAction(mfObj);
            logObj = new Log(mfObj);
        }

        //センサーの状態を表す変数
        public string[] sensor01;
        public string[] sensor02;
        public string[] sensor03;
        public string[] sensor04;
        public string[] sensor05;
        public string[] sensor06;
        public string[] sensor07;
        public string[] sensor08;
        public string[] sensor09;
        public string[] sensor10;
        public string[] sensor11;
        public string[] sensor12;
        public string[] sensor13;
        public string[] sensor14;
        public string[] sensor15;
        public string[] sensor16;
        public string[] sensor17;
        public string[] sensor18;
        public string[] sensor19;

        //セッティングファイルからセンサーの設定情報を読み込み、
        //センサー情報変数に格納するメソッド
        public void GetSensorInfo() {
            string[] str = new string[19];
            using(FileStream fs = new FileStream(ConfigurationManager.AppSettings["SettingPath"],
                FileMode.Open,FileAccess.Read,FileShare.ReadWrite)) {
                using (StreamReader sr = new StreamReader(fs)) {
                    for (int i = 0; i < 19; i++) {
                        str[i] = sr.ReadLine();
                    }
                } ;
            }
            sensor01 = str[0].Split(',');
            sensor02 = str[1].Split(',');
            sensor03 = str[2].Split(',');
            sensor04 = str[3].Split(',');
            sensor05 = str[4].Split(',');
            sensor06 = str[5].Split(',');
            sensor07 = str[6].Split(',');
            sensor08 = str[7].Split(',');
            sensor09 = str[8].Split(',');
            sensor10 = str[9].Split(',');
            sensor11 = str[10].Split(',');
            sensor12 = str[11].Split(',');
            sensor13 = str[12].Split(',');
            sensor14 = str[13].Split(',');
            sensor15 = str[14].Split(',');
            sensor16 = str[15].Split(',');
            sensor17 = str[16].Split(',');
            sensor18 = str[17].Split(',');
            sensor19 = str[18].Split(',');
        }

        //センサー情報変数をもとにセンサーの色、タグを変更するメソッド
        public void ChangeSensor(string[] str,PictureBox pic,Image n,Image l,Image a,Image e,Image f,Image el) {
            mfObj.Invoke((MethodInvoker)delegate {
                if (str[1] == "1") {
                    //センサーロック状態
                    pic.Image = l;
                    pic.Tag = "Lock";
                }else if (str[1] == "0") {
                    switch (int.Parse(str[3])) {
                        case 0:
                            //0の場合は環境状態をチェックする
                            if(str[2] == "1") {
                                pic.Image = el;
                                pic.Tag = "EnvironLock";
                            } else {
                                //通常
                                pic.Image = n;
                                pic.Tag = "Normal";
                            }
                            break;
                        case 1:
                            //侵入
                            pic.Image = a;
                            pic.Tag = "Alarm";
                            //アラーム音再生
                            if((string)mfObj.MuteButton.Tag == "off") {
                                mfObj.MuteButton.Tag = "on";
                                snacObj.AlarmSound();
                            }
                            break;
                        case 2:
                            //環境判断へ
                            if (str[2] == "1") {
                                pic.Image = el;
                                pic.Tag = "EnvironLock";
                            } else {
                                pic.Image = e;
                                pic.Tag = "Environ";
                                //環境発砲時もアラームするか
                            }
                            break;
                        case 3:
                            //故障
                            pic.Image = f;
                            pic.Tag = "Failed";
                            //アラーム再生
                            if ((string)mfObj.MuteButton.Tag == "off") {
                                mfObj.MuteButton.Tag = "on";
                                snacObj.AlarmSound();
                            }
                            break;
                    }
                }
            });
        }
    }
}
