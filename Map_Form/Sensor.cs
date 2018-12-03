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
        public void SensorSettingChange(string path, int to, string value) {
            string filePath = ConfigurationManager.AppSettings["SensorPath"] + path;
            string[] snInfo;
            try {
                //csvファイル読込
                using (FileStream fsr = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fsr)) {
                    snInfo = sr.ReadLine().Split(',');
                }
                snInfo[to] = value;
                //変更した値をcsvファイルに書込
                using (FileStream fsw = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                using (StreamWriter sw = new StreamWriter(fsw)) {
                    sw.WriteLine(string.Join(",", snInfo));
                }
            } catch {
                MessageBox.Show("他の拠点と操作が競合しました。もう一度実行します。");
                SensorSettingChange(path, to, value);
            }
        }

        //センサー設定ファイルの情報を返すメソッドstirng[]型
        public string[] ReturnSetting(string path) {
            string filePath = ConfigurationManager.AppSettings["SensorPath"] + path;
            try {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs)) {
                    //指定されたcsvファイルを配列に格納して返す
                    string[] cols = sr.ReadLine().Split(',');
                    return cols;
                }
            } catch {
                MessageBox.Show("設定読込みエラー");
                string[] clos = ReturnSetting(path);
                return clos;
            }
        }

        //送りファイルに送る情報を返すメソッド
        public string GetSendText(string path, int to, string value) {
            string sensorPath = ConfigurationManager.AppSettings["SensorPath"] + path;
            string[] info;
            using (FileStream fsr = new FileStream(sensorPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fsr)) {
                info = sr.ReadLine().Split(',');
            }
            info[to] = value;
            string str = string.Join(",", info);
            return str;
        }

        //送りファイルに実際に送るメソッド
        public void SetSendText(string[] text) {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SendPath"], false);
            try {
                for (int i = 0; i < text.Length; i++) {
                    sw.WriteLine(text[i]);
                }
            } catch {
                MessageBox.Show("エラー。実際の書き込みメソッド");
            } finally {
                sw.Close();
            }
        }

        //センサー情報変数をもとにセンサーの色、タグを変更するメソッド
        public void ChangeSensor(string[] str, PictureBox pic, Image n, Image l, Image a, Image e, Image f, Image el) {
            mfObj.Invoke((MethodInvoker)delegate {
                if (str[1] == "1") {
                    //センサーロック状態
                    pic.Image = l;
                    pic.Tag = "Lock";
                } else if (str[1] == "0") {
                    switch (int.Parse(str[3])) {
                        case 0:
                            //0の場合は環境状態をチェックする
                            if (str[2] == "1") {
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
                            if ((string)mfObj.MuteButton.Tag == "off") {
                                mfObj.MuteButton.Tag = "on";
                                snacObj.AlarmSound();
                            }
                            //カメラ判断
                            snacObj.CameraJudgment(int.Parse(str[0]));
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
                            //カメラ判断
                            snacObj.CameraJudgment(int.Parse(str[0]));
                            break;
                    }
                }
            });
        }

        //権限を確認してコントロールの有効かどうかを決める
        public void RightBool(string[] right) {
            int num = int.Parse(ConfigurationManager.AppSettings["MyNum"]);

            mfObj.Invoke((MethodInvoker)delegate {
                if (right[0] == "0" && right[1] == "0" && right[2] == "0") {
                    mfObj.RightButton.Image = Properties.Resources.operation_button_normal;
                    mfObj.RightButton.Text = "　操作";
                    mfObj.RightLabel.Text = "操作権取得可能";
                } else {
                    mfObj.RightButton.Image = Properties.Resources.operation_button_push;
                    mfObj.RightButton.Text = "　操作中";
                    //どこで操作しているか？
                    if(right[0] == "1") {
                        mfObj.RightLabel.Text = "越前変電所操作中";
                    }else if(right[1] == "1") {
                        mfObj.RightLabel.Text = "福井総合制御所操作中";
                    }else if(right[2] == "1") {
                        mfObj.RightLabel.Text = "福井電力部操作中";
                    }
                }
            });

            if (right[num] == "1") {
                //権限あり
                mfObj.Invoke((MethodInvoker)delegate {
                    mfObj.Sensor_01.Enabled = true;
                    mfObj.Sensor_02.Enabled = true;
                    mfObj.Sensor_03.Enabled = true;
                    mfObj.Sensor_04.Enabled = true;
                    mfObj.Sensor_05.Enabled = true;
                    mfObj.Sensor_06.Enabled = true;
                    mfObj.Sensor_07.Enabled = true;
                    mfObj.Sensor_08.Enabled = true;
                    mfObj.Sensor_09.Enabled = true;
                    mfObj.Sensor_10.Enabled = true;
                    mfObj.Sensor_11.Enabled = true;
                    mfObj.Sensor_12.Enabled = true;
                    mfObj.Sensor_13.Enabled = true;
                    mfObj.Sensor_14.Enabled = true;
                    mfObj.Sensor_15.Enabled = true;
                    mfObj.Sensor_16.Enabled = true;
                    mfObj.Sensor_17.Enabled = true;
                    mfObj.Sensor_18.Enabled = true;
                    mfObj.Sensor_19.Enabled = true;
                    mfObj.SensorLock500_on.Enabled = true;
                    mfObj.SensorLock500_off.Enabled = true;
                    mfObj.SensorLock77_on.Enabled = true;
                    mfObj.SensorLock77_off.Enabled = true;
                    mfObj.SettingButton.Enabled = true;
                    mfObj.RestrationButton.Enabled = true;
                });

            } else if (right[num] == "0") {
                //権限なし
                mfObj.Invoke((MethodInvoker)delegate {
                    mfObj.Sensor_01.Enabled = false;
                    mfObj.Sensor_02.Enabled = false;
                    mfObj.Sensor_03.Enabled = false;
                    mfObj.Sensor_04.Enabled = false;
                    mfObj.Sensor_05.Enabled = false;
                    mfObj.Sensor_06.Enabled = false;
                    mfObj.Sensor_07.Enabled = false;
                    mfObj.Sensor_08.Enabled = false;
                    mfObj.Sensor_09.Enabled = false;
                    mfObj.Sensor_10.Enabled = false;
                    mfObj.Sensor_11.Enabled = false;
                    mfObj.Sensor_12.Enabled = false;
                    mfObj.Sensor_13.Enabled = false;
                    mfObj.Sensor_14.Enabled = false;
                    mfObj.Sensor_15.Enabled = false;
                    mfObj.Sensor_16.Enabled = false;
                    mfObj.Sensor_17.Enabled = false;
                    mfObj.Sensor_18.Enabled = false;
                    mfObj.Sensor_19.Enabled = false;
                    mfObj.SensorLock500_on.Enabled = false;
                    mfObj.SensorLock500_off.Enabled = false;
                    mfObj.SensorLock77_on.Enabled = false;
                    mfObj.SensorLock77_off.Enabled = false;
                    mfObj.SettingButton.Enabled = false;
                    mfObj.RestrationButton.Enabled = false;
                });
            }
        }

        //設備故障かどうかの判断をする
        public void FaultBool(string[] Fault) {
            if (Fault[1] == "1") {
                mfObj.Invoke((MethodInvoker)delegate {
                    mfObj.FaultButton.Image = Properties.Resources.fault_button_push;
                });
            } else if (Fault[1] == "0") {
                mfObj.Invoke((MethodInvoker)delegate {
                    mfObj.FaultButton.Image = Properties.Resources.fault_button_normal;
                });
            }
        }

    }
}
