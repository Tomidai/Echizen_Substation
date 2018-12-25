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
        public Control_Form cfObj;

        //コンストラクタ
        public Sensor(Map_Form mf_obj) {
            mfObj = mf_obj;
            snacObj = new SensorAction(mfObj);
            cfObj = new Control_Form();
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
                //少し待ってリトライ
                System.Threading.Thread.Sleep(50);
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
                //少し待ってリトライ
                System.Threading.Thread.Sleep(50);
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
                sw.Close();
                System.Threading.Thread.Sleep(50);
                SetSendText(text);
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
                            //カメラ判断
                            snacObj.CameraJudgment(int.Parse(str[0]));
                            //マップにフォーカスする
                            cfObj.Map_Show();
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
                            //カメラ判断
                            snacObj.CameraJudgment(int.Parse(str[0]));
                            //マップにフォーカスする
                            cfObj.Map_Show();
                            break;
                    }
                }
            });
        }

        //権限を確認してコントロールの有効かどうかを決める
        public void RightBool(string[] right) {
            int num = int.Parse(ConfigurationManager.AppSettings["MyNum"]);
            string[] gateState_500 = ReturnSetting("GateOpen500.csv");
            string[] gateState_77 = ReturnSetting("GateOpen77.csv");


            mfObj.Invoke((MethodInvoker)delegate {
                if (right[0] == "0" && right[1] == "0" && right[2] == "0") {
                    mfObj.RightButton.Image = Properties.Resources.operation_button_normal;
                    mfObj.RightButton.Text = "　操作";
                    mfObj.RightLabel.Text = "操作権限取得可能";
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
                if (gateState_500[1] == "1") {
                    if (gateState_77[1] == "1") {

                        //権限あり、500開、77開
                        mfObj.Invoke((MethodInvoker)delegate {
                            mfObj.gateState500.Text = "500KV扉開中";
                            mfObj.gateState77.Text = "77KV扉開中";

                            mfObj.Sensor_01.Image = Properties.Resources.Sensor_Lock_01;
                            mfObj.Sensor_02.Image = Properties.Resources.Sensor_Lock_02;
                            mfObj.Sensor_03.Image = Properties.Resources.Sensor_Lock_03;
                            mfObj.Sensor_04.Image = Properties.Resources.Sensor_Lock_04;
                            mfObj.Sensor_05.Image = Properties.Resources.Sensor_Lock_05;
                            mfObj.Sensor_06.Image = Properties.Resources.Sensor_Lock_06;
                            mfObj.Sensor_07.Image = Properties.Resources.Sensor_Lock_07;
                            mfObj.Sensor_08.Image = Properties.Resources.Sensor_Lock_08;
                            mfObj.Sensor_09.Image = Properties.Resources.Sensor_Lock_09;
                            mfObj.Sensor_10.Image = Properties.Resources.Sensor_Lock_10;
                            mfObj.Sensor_11.Image = Properties.Resources.Sensor_Lock_11;
                            mfObj.Sensor_12.Image = Properties.Resources.Sensor_Lock_12;
                            mfObj.Sensor_13.Image = Properties.Resources.Sensor_Lock_13;
                            mfObj.Sensor_14.Image = Properties.Resources.Sensor_Lock_14;
                            mfObj.Sensor_15.Image = Properties.Resources.Sensor_Lock_15;
                            mfObj.Sensor_16.Image = Properties.Resources.Sensor_Lock_16;
                            mfObj.Sensor_17.Image = Properties.Resources.Sensor_Lock_17;
                            mfObj.Sensor_18.Image = Properties.Resources.Sensor_Lock_18;
                            mfObj.Sensor_19.Image = Properties.Resources.Sensor_Lock_19;

                            mfObj.Sensor_01.Tag = "Lock";
                            mfObj.Sensor_02.Tag = "Lock";
                            mfObj.Sensor_03.Tag = "Lock";
                            mfObj.Sensor_04.Tag = "Lock";
                            mfObj.Sensor_05.Tag = "Lock";
                            mfObj.Sensor_06.Tag = "Lock";
                            mfObj.Sensor_07.Tag = "Lock";
                            mfObj.Sensor_08.Tag = "Lock";
                            mfObj.Sensor_09.Tag = "Lock";
                            mfObj.Sensor_10.Tag = "Lock";
                            mfObj.Sensor_11.Tag = "Lock";
                            mfObj.Sensor_12.Tag = "Lock";
                            mfObj.Sensor_13.Tag = "Lock";
                            mfObj.Sensor_14.Tag = "Lock";
                            mfObj.Sensor_15.Tag = "Lock";
                            mfObj.Sensor_16.Tag = "Lock";
                            mfObj.Sensor_17.Tag = "Lock";
                            mfObj.Sensor_18.Tag = "Lock";
                            mfObj.Sensor_19.Tag = "Lock";

                            mfObj.SensorLock500_on.Enabled = false;
                            mfObj.SensorLock500_off.Enabled = false;
                            mfObj.SensorLock77_on.Enabled = false;
                            mfObj.SensorLock77_off.Enabled = false;
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

                            mfObj.SettingButton.Enabled = true;
                            mfObj.RestrationButton.Enabled = true;
                        });

                    } else if(gateState_77[1] == "0") {
                        

                        //権限あり、500開、77閉
                        mfObj.Invoke((MethodInvoker)delegate {
                            mfObj.gateState500.Text = "500KV扉開中";
                            mfObj.gateState77.Text = "77KV扉閉中";

                            mfObj.Sensor_01.Image = Properties.Resources.Sensor_Lock_01;
                            mfObj.Sensor_02.Image = Properties.Resources.Sensor_Lock_02;
                            mfObj.Sensor_03.Image = Properties.Resources.Sensor_Lock_03;
                            mfObj.Sensor_04.Image = Properties.Resources.Sensor_Lock_04;
                            mfObj.Sensor_05.Image = Properties.Resources.Sensor_Lock_05;
                            mfObj.Sensor_06.Image = Properties.Resources.Sensor_Lock_06;
                            mfObj.Sensor_07.Image = Properties.Resources.Sensor_Lock_07;
                            mfObj.Sensor_08.Image = Properties.Resources.Sensor_Lock_08;
                            mfObj.Sensor_09.Image = Properties.Resources.Sensor_Lock_09;
                            mfObj.Sensor_10.Image = Properties.Resources.Sensor_Lock_10;
                            mfObj.Sensor_11.Image = Properties.Resources.Sensor_Lock_11;
                            mfObj.Sensor_12.Image = Properties.Resources.Sensor_Lock_12;
                            mfObj.Sensor_13.Image = Properties.Resources.Sensor_Lock_13;

                            mfObj.Sensor_01.Tag = "Lock";
                            mfObj.Sensor_02.Tag = "Lock";
                            mfObj.Sensor_03.Tag = "Lock";
                            mfObj.Sensor_04.Tag = "Lock";
                            mfObj.Sensor_05.Tag = "Lock";
                            mfObj.Sensor_06.Tag = "Lock";
                            mfObj.Sensor_07.Tag = "Lock";
                            mfObj.Sensor_08.Tag = "Lock";
                            mfObj.Sensor_09.Tag = "Lock";
                            mfObj.Sensor_10.Tag = "Lock";
                            mfObj.Sensor_11.Tag = "Lock";
                            mfObj.Sensor_12.Tag = "Lock";
                            mfObj.Sensor_13.Tag = "Lock";

                            ChangeSensor(ReturnSetting("sensor14.csv"), mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                            Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                            Properties.Resources.Sensor_EnvironLock_14);

                            ChangeSensor(ReturnSetting("sensor15.csv"), mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                                Properties.Resources.Sensor_EnvironLock_15);

                            ChangeSensor(ReturnSetting("sensor16.csv"), mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                                Properties.Resources.Sensor_EnvironLock_16);

                            ChangeSensor(ReturnSetting("sensor17.csv"), mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                                Properties.Resources.Sensor_EnvironLock_17);

                            ChangeSensor(ReturnSetting("sensor18.csv"), mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                                Properties.Resources.Sensor_EnvironLock_18);

                            ChangeSensor(ReturnSetting("sensor19.csv"), mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                                Properties.Resources.Sensor_EnvironLock_19);

                            mfObj.SensorLock500_on.Enabled = false;
                            mfObj.SensorLock500_off.Enabled = false;
                            mfObj.SensorLock77_on.Enabled = true;
                            mfObj.SensorLock77_off.Enabled = true;
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
                            mfObj.Sensor_14.Enabled = true;
                            mfObj.Sensor_15.Enabled = true;
                            mfObj.Sensor_16.Enabled = true;
                            mfObj.Sensor_17.Enabled = true;
                            mfObj.Sensor_18.Enabled = true;
                            mfObj.Sensor_19.Enabled = true;

                            mfObj.SettingButton.Enabled = true;
                            mfObj.RestrationButton.Enabled = true;
                        });

                    }
                }else if(gateState_500[1] == "0") {
                    if (gateState_77[1] == "1") {
                        
                        //権限あり、500閉、77開
                        mfObj.Invoke((MethodInvoker)delegate {
                            mfObj.gateState500.Text = "500KV扉閉中";
                            mfObj.gateState77.Text = "77KV扉開中";

                            ChangeSensor(ReturnSetting("sensor1.csv"), mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                                Properties.Resources.Sensor_EnvironLock_01);

                            ChangeSensor(ReturnSetting("sensor2.csv"), mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                                Properties.Resources.Sensor_EnvironLock_02);

                            ChangeSensor(ReturnSetting("sensor3.csv"), mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                                Properties.Resources.Sensor_EnvironLock_03);

                            ChangeSensor(ReturnSetting("sensor4.csv"), mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                                Properties.Resources.Sensor_EnvironLock_04);

                            ChangeSensor(ReturnSetting("sensor5.csv"), mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                                Properties.Resources.Sensor_EnvironLock_05);

                            ChangeSensor(ReturnSetting("sensor6.csv"), mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                                Properties.Resources.Sensor_EnvironLock_06);

                            ChangeSensor(ReturnSetting("sensor7.csv"), mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                                Properties.Resources.Sensor_EnvironLock_07);

                            ChangeSensor(ReturnSetting("sensor8.csv"), mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                                Properties.Resources.Sensor_EnvironLock_08);

                            ChangeSensor(ReturnSetting("sensor9.csv"), mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                                Properties.Resources.Sensor_EnvironLock_09);

                            ChangeSensor(ReturnSetting("sensor10.csv"), mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                                Properties.Resources.Sensor_EnvironLock_10);

                            ChangeSensor(ReturnSetting("sensor11.csv"), mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                                Properties.Resources.Sensor_EnvironLock_11);

                            ChangeSensor(ReturnSetting("sensor12.csv"), mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                                Properties.Resources.Sensor_EnvironLock_12);

                            ChangeSensor(ReturnSetting("sensor13.csv"), mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                                Properties.Resources.Sensor_EnvironLock_13);

                            mfObj.Sensor_14.Image = Properties.Resources.Sensor_Lock_14;
                            mfObj.Sensor_15.Image = Properties.Resources.Sensor_Lock_15;
                            mfObj.Sensor_16.Image = Properties.Resources.Sensor_Lock_16;
                            mfObj.Sensor_17.Image = Properties.Resources.Sensor_Lock_17;
                            mfObj.Sensor_18.Image = Properties.Resources.Sensor_Lock_18;
                            mfObj.Sensor_19.Image = Properties.Resources.Sensor_Lock_19;

                            mfObj.Sensor_14.Tag = "Lock";
                            mfObj.Sensor_15.Tag = "Lock";
                            mfObj.Sensor_16.Tag = "Lock";
                            mfObj.Sensor_17.Tag = "Lock";
                            mfObj.Sensor_18.Tag = "Lock";
                            mfObj.Sensor_19.Tag = "Lock";

                            mfObj.SensorLock500_on.Enabled = true;
                            mfObj.SensorLock500_off.Enabled = true;
                            mfObj.SensorLock77_on.Enabled = false;
                            mfObj.SensorLock77_off.Enabled = false;
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
                            mfObj.Sensor_14.Enabled = false;
                            mfObj.Sensor_15.Enabled = false;
                            mfObj.Sensor_16.Enabled = false;
                            mfObj.Sensor_17.Enabled = false;
                            mfObj.Sensor_18.Enabled = false;
                            mfObj.Sensor_19.Enabled = false;

                            mfObj.SettingButton.Enabled = true;
                            mfObj.RestrationButton.Enabled = true;
                        });

                    } else if (gateState_77[1] == "0") {
                        
                        //権限あり、500閉、77閉
                        mfObj.Invoke((MethodInvoker)delegate {
                            mfObj.gateState500.Text = "500KV扉閉中";
                            mfObj.gateState77.Text = "77KV扉閉中";

                            ChangeSensor(ReturnSetting("sensor1.csv"), mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                                Properties.Resources.Sensor_EnvironLock_01);

                            ChangeSensor(ReturnSetting("sensor2.csv"), mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                                Properties.Resources.Sensor_EnvironLock_02);

                            ChangeSensor(ReturnSetting("sensor3.csv"), mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                                Properties.Resources.Sensor_EnvironLock_03);

                            ChangeSensor(ReturnSetting("sensor4.csv"), mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                                Properties.Resources.Sensor_EnvironLock_04);

                            ChangeSensor(ReturnSetting("sensor5.csv"), mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                                Properties.Resources.Sensor_EnvironLock_05);

                            ChangeSensor(ReturnSetting("sensor6.csv"), mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                                Properties.Resources.Sensor_EnvironLock_06);

                            ChangeSensor(ReturnSetting("sensor7.csv"), mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                                Properties.Resources.Sensor_EnvironLock_07);

                            ChangeSensor(ReturnSetting("sensor8.csv"), mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                                Properties.Resources.Sensor_EnvironLock_08);

                            ChangeSensor(ReturnSetting("sensor9.csv"), mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                                Properties.Resources.Sensor_EnvironLock_09);

                            ChangeSensor(ReturnSetting("sensor10.csv"), mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                                Properties.Resources.Sensor_EnvironLock_10);

                            ChangeSensor(ReturnSetting("sensor11.csv"), mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                                Properties.Resources.Sensor_EnvironLock_11);

                            ChangeSensor(ReturnSetting("sensor12.csv"), mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                                Properties.Resources.Sensor_EnvironLock_12);

                            ChangeSensor(ReturnSetting("sensor13.csv"), mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                                Properties.Resources.Sensor_EnvironLock_13);

                            ChangeSensor(ReturnSetting("sensor14.csv"), mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                                Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                                Properties.Resources.Sensor_EnvironLock_14);

                            ChangeSensor(ReturnSetting("sensor15.csv"), mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                                Properties.Resources.Sensor_EnvironLock_15);

                            ChangeSensor(ReturnSetting("sensor16.csv"), mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                                Properties.Resources.Sensor_EnvironLock_16);

                            ChangeSensor(ReturnSetting("sensor17.csv"), mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                                Properties.Resources.Sensor_EnvironLock_17);

                            ChangeSensor(ReturnSetting("sensor18.csv"), mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                                Properties.Resources.Sensor_EnvironLock_18);

                            ChangeSensor(ReturnSetting("sensor19.csv"), mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                                Properties.Resources.Sensor_EnvironLock_19);

                            mfObj.SensorLock500_on.Enabled = true;
                            mfObj.SensorLock500_off.Enabled = true;
                            mfObj.SensorLock77_on.Enabled = true;
                            mfObj.SensorLock77_off.Enabled = true;
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

                            mfObj.SettingButton.Enabled = true;
                            mfObj.RestrationButton.Enabled = true;
                        });

                    }
                }
                

            } else if (right[num] == "0") {
                if (gateState_500[1] == "1") {
                    if (gateState_77[1] == "1") {
                        
                        //権限なし、500開、77開
                        mfObj.Invoke((MethodInvoker)delegate {

                            mfObj.gateState500.Text = "500KV扉開中";
                            mfObj.gateState77.Text = "77KV扉開中";

                            mfObj.SensorLock500_on.Enabled = false;
                            mfObj.SensorLock500_off.Enabled = false;
                            mfObj.SensorLock77_on.Enabled = false;
                            mfObj.SensorLock77_off.Enabled = false;
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

                            mfObj.SettingButton.Enabled = false;
                            mfObj.RestrationButton.Enabled = false;

                            mfObj.Sensor_01.Image = Properties.Resources.Sensor_Lock_01;
                            mfObj.Sensor_02.Image = Properties.Resources.Sensor_Lock_02;
                            mfObj.Sensor_03.Image = Properties.Resources.Sensor_Lock_03;
                            mfObj.Sensor_04.Image = Properties.Resources.Sensor_Lock_04;
                            mfObj.Sensor_05.Image = Properties.Resources.Sensor_Lock_05;
                            mfObj.Sensor_06.Image = Properties.Resources.Sensor_Lock_06;
                            mfObj.Sensor_07.Image = Properties.Resources.Sensor_Lock_07;
                            mfObj.Sensor_08.Image = Properties.Resources.Sensor_Lock_08;
                            mfObj.Sensor_09.Image = Properties.Resources.Sensor_Lock_09;
                            mfObj.Sensor_10.Image = Properties.Resources.Sensor_Lock_10;
                            mfObj.Sensor_11.Image = Properties.Resources.Sensor_Lock_11;
                            mfObj.Sensor_12.Image = Properties.Resources.Sensor_Lock_12;
                            mfObj.Sensor_13.Image = Properties.Resources.Sensor_Lock_13;
                            mfObj.Sensor_14.Image = Properties.Resources.Sensor_Lock_14;
                            mfObj.Sensor_15.Image = Properties.Resources.Sensor_Lock_15;
                            mfObj.Sensor_16.Image = Properties.Resources.Sensor_Lock_16;
                            mfObj.Sensor_17.Image = Properties.Resources.Sensor_Lock_17;
                            mfObj.Sensor_18.Image = Properties.Resources.Sensor_Lock_18;
                            mfObj.Sensor_19.Image = Properties.Resources.Sensor_Lock_19;

                            mfObj.Sensor_01.Tag = "Lock";
                            mfObj.Sensor_02.Tag = "Lock";
                            mfObj.Sensor_03.Tag = "Lock";
                            mfObj.Sensor_04.Tag = "Lock";
                            mfObj.Sensor_05.Tag = "Lock";
                            mfObj.Sensor_06.Tag = "Lock";
                            mfObj.Sensor_07.Tag = "Lock";
                            mfObj.Sensor_08.Tag = "Lock";
                            mfObj.Sensor_09.Tag = "Lock";
                            mfObj.Sensor_10.Tag = "Lock";
                            mfObj.Sensor_11.Tag = "Lock";
                            mfObj.Sensor_12.Tag = "Lock";
                            mfObj.Sensor_13.Tag = "Lock";
                            mfObj.Sensor_14.Tag = "Lock";
                            mfObj.Sensor_15.Tag = "Lock";
                            mfObj.Sensor_16.Tag = "Lock";
                            mfObj.Sensor_17.Tag = "Lock";
                            mfObj.Sensor_18.Tag = "Lock";
                            mfObj.Sensor_19.Tag = "Lock";
                        });

                    } else if (gateState_77[1] == "0") {
                        
                        //権限なし、500開、77閉
                        mfObj.Invoke((MethodInvoker)delegate {

                            mfObj.gateState500.Text = "500KV扉開中";
                            mfObj.gateState77.Text = "77KV扉閉中";

                            mfObj.SensorLock500_on.Enabled = false;
                            mfObj.SensorLock500_off.Enabled = false;
                            mfObj.SensorLock77_on.Enabled = false;
                            mfObj.SensorLock77_off.Enabled = false;
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

                            mfObj.SettingButton.Enabled = false;
                            mfObj.RestrationButton.Enabled = false;

                            mfObj.Sensor_01.Image = Properties.Resources.Sensor_Lock_01;
                            mfObj.Sensor_02.Image = Properties.Resources.Sensor_Lock_02;
                            mfObj.Sensor_03.Image = Properties.Resources.Sensor_Lock_03;
                            mfObj.Sensor_04.Image = Properties.Resources.Sensor_Lock_04;
                            mfObj.Sensor_05.Image = Properties.Resources.Sensor_Lock_05;
                            mfObj.Sensor_06.Image = Properties.Resources.Sensor_Lock_06;
                            mfObj.Sensor_07.Image = Properties.Resources.Sensor_Lock_07;
                            mfObj.Sensor_08.Image = Properties.Resources.Sensor_Lock_08;
                            mfObj.Sensor_09.Image = Properties.Resources.Sensor_Lock_09;
                            mfObj.Sensor_10.Image = Properties.Resources.Sensor_Lock_10;
                            mfObj.Sensor_11.Image = Properties.Resources.Sensor_Lock_11;
                            mfObj.Sensor_12.Image = Properties.Resources.Sensor_Lock_12;
                            mfObj.Sensor_13.Image = Properties.Resources.Sensor_Lock_13;

                            mfObj.Sensor_01.Tag = "Lock";
                            mfObj.Sensor_02.Tag = "Lock";
                            mfObj.Sensor_03.Tag = "Lock";
                            mfObj.Sensor_04.Tag = "Lock";
                            mfObj.Sensor_05.Tag = "Lock";
                            mfObj.Sensor_06.Tag = "Lock";
                            mfObj.Sensor_07.Tag = "Lock";
                            mfObj.Sensor_08.Tag = "Lock";
                            mfObj.Sensor_09.Tag = "Lock";
                            mfObj.Sensor_10.Tag = "Lock";
                            mfObj.Sensor_11.Tag = "Lock";
                            mfObj.Sensor_12.Tag = "Lock";
                            mfObj.Sensor_13.Tag = "Lock";

                            ChangeSensor(ReturnSetting("sensor14.csv"), mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                            Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                            Properties.Resources.Sensor_EnvironLock_14);

                            ChangeSensor(ReturnSetting("sensor15.csv"), mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                                Properties.Resources.Sensor_EnvironLock_15);

                            ChangeSensor(ReturnSetting("sensor16.csv"), mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                                Properties.Resources.Sensor_EnvironLock_16);

                            ChangeSensor(ReturnSetting("sensor17.csv"), mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                                Properties.Resources.Sensor_EnvironLock_17);

                            ChangeSensor(ReturnSetting("sensor18.csv"), mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                                Properties.Resources.Sensor_EnvironLock_18);

                            ChangeSensor(ReturnSetting("sensor19.csv"), mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                                Properties.Resources.Sensor_EnvironLock_19);
                        });

                    }
                } else if (gateState_500[1] == "0") {
                    if (gateState_77[1] == "1") {
                        
                        //権限なし、500閉、77開
                        mfObj.Invoke((MethodInvoker)delegate {

                            mfObj.gateState500.Text = "500KV扉閉中";
                            mfObj.gateState77.Text = "77KV扉開中";

                            mfObj.SensorLock500_on.Enabled = false;
                            mfObj.SensorLock500_off.Enabled = false;
                            mfObj.SensorLock77_on.Enabled = false;
                            mfObj.SensorLock77_off.Enabled = false;
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

                            mfObj.SettingButton.Enabled = false;
                            mfObj.RestrationButton.Enabled = false;

                            ChangeSensor(ReturnSetting("sensor1.csv"), mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                                Properties.Resources.Sensor_EnvironLock_01);

                            ChangeSensor(ReturnSetting("sensor2.csv"), mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                                Properties.Resources.Sensor_EnvironLock_02);

                            ChangeSensor(ReturnSetting("sensor3.csv"), mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                                Properties.Resources.Sensor_EnvironLock_03);

                            ChangeSensor(ReturnSetting("sensor4.csv"), mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                                Properties.Resources.Sensor_EnvironLock_04);

                            ChangeSensor(ReturnSetting("sensor5.csv"), mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                                Properties.Resources.Sensor_EnvironLock_05);

                            ChangeSensor(ReturnSetting("sensor6.csv"), mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                                Properties.Resources.Sensor_EnvironLock_06);

                            ChangeSensor(ReturnSetting("sensor7.csv"), mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                                Properties.Resources.Sensor_EnvironLock_07);

                            ChangeSensor(ReturnSetting("sensor8.csv"), mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                                Properties.Resources.Sensor_EnvironLock_08);

                            ChangeSensor(ReturnSetting("sensor9.csv"), mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                                Properties.Resources.Sensor_EnvironLock_09);

                            ChangeSensor(ReturnSetting("sensor10.csv"), mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                                Properties.Resources.Sensor_EnvironLock_10);

                            ChangeSensor(ReturnSetting("sensor11.csv"), mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                                Properties.Resources.Sensor_EnvironLock_11);

                            ChangeSensor(ReturnSetting("sensor12.csv"), mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                                Properties.Resources.Sensor_EnvironLock_12);

                            ChangeSensor(ReturnSetting("sensor13.csv"), mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                                Properties.Resources.Sensor_EnvironLock_13);

                            mfObj.Sensor_14.Image = Properties.Resources.Sensor_Lock_14;
                            mfObj.Sensor_15.Image = Properties.Resources.Sensor_Lock_15;
                            mfObj.Sensor_16.Image = Properties.Resources.Sensor_Lock_16;
                            mfObj.Sensor_17.Image = Properties.Resources.Sensor_Lock_17;
                            mfObj.Sensor_18.Image = Properties.Resources.Sensor_Lock_18;
                            mfObj.Sensor_19.Image = Properties.Resources.Sensor_Lock_19;

                            mfObj.Sensor_14.Tag = "Lock";
                            mfObj.Sensor_15.Tag = "Lock";
                            mfObj.Sensor_16.Tag = "Lock";
                            mfObj.Sensor_17.Tag = "Lock";
                            mfObj.Sensor_18.Tag = "Lock";
                            mfObj.Sensor_19.Tag = "Lock";
                        });

                    } else if (gateState_77[1] == "0") {
                        
                        //権限なし、500閉、77閉
                        mfObj.Invoke((MethodInvoker)delegate {
                            mfObj.gateState500.Text = "500KV扉閉中";
                            mfObj.gateState77.Text = "77KV扉閉中";
                            mfObj.SensorLock500_on.Enabled = false;
                            mfObj.SensorLock500_off.Enabled = false;
                            mfObj.SensorLock77_on.Enabled = false;
                            mfObj.SensorLock77_off.Enabled = false;
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

                            mfObj.SettingButton.Enabled = false;
                            mfObj.RestrationButton.Enabled = false;

                            ChangeSensor(ReturnSetting("sensor1.csv"), mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                                Properties.Resources.Sensor_EnvironLock_01);

                            ChangeSensor(ReturnSetting("sensor2.csv"), mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                                Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                                Properties.Resources.Sensor_EnvironLock_02);

                            ChangeSensor(ReturnSetting("sensor3.csv"), mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                                Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                                Properties.Resources.Sensor_EnvironLock_03);

                            ChangeSensor(ReturnSetting("sensor4.csv"), mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                                Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                                Properties.Resources.Sensor_EnvironLock_04);

                            ChangeSensor(ReturnSetting("sensor5.csv"), mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                                Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                                Properties.Resources.Sensor_EnvironLock_05);

                            ChangeSensor(ReturnSetting("sensor6.csv"), mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                                Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                                Properties.Resources.Sensor_EnvironLock_06);

                            ChangeSensor(ReturnSetting("sensor7.csv"), mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                                Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                                Properties.Resources.Sensor_EnvironLock_07);

                            ChangeSensor(ReturnSetting("sensor8.csv"), mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                                Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                                Properties.Resources.Sensor_EnvironLock_08);

                            ChangeSensor(ReturnSetting("sensor9.csv"), mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                                Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                                Properties.Resources.Sensor_EnvironLock_09);

                            ChangeSensor(ReturnSetting("sensor10.csv"), mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                                Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                                Properties.Resources.Sensor_EnvironLock_10);

                            ChangeSensor(ReturnSetting("sensor11.csv"), mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                                Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                                Properties.Resources.Sensor_EnvironLock_11);

                            ChangeSensor(ReturnSetting("sensor12.csv"), mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                                Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                                Properties.Resources.Sensor_EnvironLock_12);

                            ChangeSensor(ReturnSetting("sensor13.csv"), mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                                Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                                Properties.Resources.Sensor_EnvironLock_13);

                            ChangeSensor(ReturnSetting("sensor14.csv"), mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                                Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                                Properties.Resources.Sensor_EnvironLock_14);

                            ChangeSensor(ReturnSetting("sensor15.csv"), mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                                Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                                Properties.Resources.Sensor_EnvironLock_15);

                            ChangeSensor(ReturnSetting("sensor16.csv"), mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                                Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                                Properties.Resources.Sensor_EnvironLock_16);

                            ChangeSensor(ReturnSetting("sensor17.csv"), mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                                Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                                Properties.Resources.Sensor_EnvironLock_17);

                            ChangeSensor(ReturnSetting("sensor18.csv"), mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                                Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                                Properties.Resources.Sensor_EnvironLock_18);

                            ChangeSensor(ReturnSetting("sensor19.csv"), mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                                Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                                Properties.Resources.Sensor_EnvironLock_19);
                        });
                    }
                }
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
