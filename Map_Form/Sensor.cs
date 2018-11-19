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

        //コンストラクタ
        public Sensor(Map_Form mf_obj) {
            mfObj = mf_obj;
            snacObj = new SensorAction(mfObj);
        }

        //sensor.csvファイルを指定された値に変更するメソッド
        public void SensorSettingChange(string path,int to,string value) {
            string filePath = ConfigurationManager.AppSettings["SensorPath"] + path;
            string[] snInfo;
            //csvファイル読込
            try {
                using (FileStream fsr = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader sr = new StreamReader(fsr)) {
                    snInfo = sr.ReadLine().Split(',');
                }
                snInfo[to] = value;
                //変更した値をcsvファイルに書込
                using (FileStream fsw = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                using (StreamWriter sw = new StreamWriter(fsw)) {
                    sw.WriteLine(string.Join(",", snInfo));
                }
            } catch {
                SensorSettingChange(path, to, value);
            }
        }

        //センサー設定ファイルの情報を返すメソッドstirng[]型
        public string[] ReturnSetting(string path) {
            string filePath = ConfigurationManager.AppSettings["SensorPath"] + path;
            try {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader sr = new StreamReader(fs)) {
                    //指定されたcsvファイルを配列に格納して返す
                    string[] cols = sr.ReadLine().Split(',');
                    return cols;
                }
            } catch {
                string[] clos = ReturnSetting(path);
                return clos;
            }
        }

        //送りファイルに送る情報を返すメソッド
        public string SendSensorInfo(string path,int to,string value) {
            string sensorPath = ConfigurationManager.AppSettings["SensorPath"] + path;
            string sendPath = ConfigurationManager.AppSettings["SendPath"];
            string[] info;
            using (FileStream fsr = new FileStream(sensorPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using(StreamReader sr = new StreamReader(fsr)) {
                info = sr.ReadLine().Split(',');
            }
            info[to] = value;
            string str = string.Join(",", info);
            return str;
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
