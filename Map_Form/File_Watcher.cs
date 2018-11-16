using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;

namespace Map_Form {
    class File_Watcher {

        //Map_Formのインスタンス
        public Map_Form mfObj;
        public Sensor snObj;
        public SensorAction snacObj;
        //コンストラクタ
        public File_Watcher(Map_Form mf_obj) {
            mfObj = mf_obj;
            snObj = new Sensor(mfObj);
            snacObj = new SensorAction(mfObj);
        }

        private  FileSystemWatcher Watcher;
        private FileSystemWatcher SensorWatcher;

        public void StartWatching() {
            //PLCから送られてくるファイルを監視するWatcherの定義
            Watcher = new FileSystemWatcher {
                Path = ConfigurationManager.AppSettings["WatchDir"],
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.txt",
                IncludeSubdirectories = false
            };
            Watcher.Changed += Changed;
            Watcher.EnableRaisingEvents = true;

            //SensorSettingsファイルを監視するSensorWatcherの定義
            SensorWatcher = new FileSystemWatcher {
                Path = ConfigurationManager.AppSettings["SensorPath"],
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.csv",
                IncludeSubdirectories = false
            };
            SensorWatcher.Changed += SensorChanged;
            SensorWatcher.EnableRaisingEvents = true;
        }

        //Reciveファイルを読込反映させるメソッド
        public void Receive(string[] receiveInfo ,string snPath) {
            if (receiveInfo[3] == "1") {
                //故障の判断
                snObj.SensorSettingChange(snPath, 3, "3");
            } else if (receiveInfo[1] == "1") {
                //侵入の判断
                snObj.SensorSettingChange(snPath, 3, "1");
            } else if (receiveInfo[2] == "1") {
                //環境の判断
                snObj.SensorSettingChange(snPath, 3, "2");
            }
        }

        //SensorSettingsファイルが変更されたら発生するイベント
        public void SensorChanged(object source, FileSystemEventArgs e) {
            switch (e.Name) {
                case "sensor1.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                      Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                      Properties.Resources.Sensor_EnvironLock_01);
                    break;
                case "sensor2.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                      Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                      Properties.Resources.Sensor_EnvironLock_02);
                    break;
                case "sensor3.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                      Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                      Properties.Resources.Sensor_EnvironLock_03);
                    break;
                case "sensor4.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                      Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                      Properties.Resources.Sensor_EnvironLock_04);
                    break;
                case "sensor5.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                      Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                      Properties.Resources.Sensor_EnvironLock_05);
                    break;
                case "sensor6.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                      Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                      Properties.Resources.Sensor_EnvironLock_06);
                    break;
                case "sensor7.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                      Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                      Properties.Resources.Sensor_EnvironLock_07);
                    break;
                case "sensor8.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                      Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                      Properties.Resources.Sensor_EnvironLock_08);
                    break;
                case "sensor9.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                      Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                      Properties.Resources.Sensor_EnvironLock_09);
                    break;
                case "sensor10.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                      Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                      Properties.Resources.Sensor_EnvironLock_10);
                    break;
                case "sensor11.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                      Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                      Properties.Resources.Sensor_EnvironLock_11);
                    break;
                case "sensor12.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                      Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                      Properties.Resources.Sensor_EnvironLock_12);
                    break;
                case "sensor13.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                      Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                      Properties.Resources.Sensor_EnvironLock_13);
                    break;
                case "sensor14.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                      Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                      Properties.Resources.Sensor_EnvironLock_14);
                    break;
                case "sensor15.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                      Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                      Properties.Resources.Sensor_EnvironLock_15);
                    break;
                case "sensor16.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                      Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                      Properties.Resources.Sensor_EnvironLock_16);
                    break;
                case "sensor17.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                      Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                      Properties.Resources.Sensor_EnvironLock_17);
                    break;
                case "sensor18.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                      Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                      Properties.Resources.Sensor_EnvironLock_18);
                    break;
                case "sensor19.csv":
                    snObj.ChangeSensor(snObj.ReturnSetting(e.Name), mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                      Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                      Properties.Resources.Sensor_EnvironLock_19);
                    break;
            }
        }

        //Receiveファイルが変更されたら発生するイベント
        public void Changed(object source, FileSystemEventArgs e) {
            //センサーからの情報受信
            using (FileStream fs = new FileStream(ConfigurationManager.AppSettings["ReceivePath"], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs)) {
                while (!sr.EndOfStream) {
                    //読み込んだ1行をcsvで分けて配列に入れる
                    string[] receiveInfo = sr.ReadLine().Split(',');
                    //センサーを判断する条件分岐1~19
                    switch (int.Parse(receiveInfo[0])) {
                        case 1:
                            //Receiveファイルを読込反映させるメソッドを呼び出す
                            Receive(receiveInfo, "sensor1.csv");
                            snacObj.Action("1");
                            break;
                        case 2:
                            Receive(receiveInfo, "sensor2.csv");
                            snacObj.Action("2");
                            break;
                        case 3:
                            Receive(receiveInfo, "sensor3.csv");
                            snacObj.Action("3");
                            break;
                        case 4:
                            Receive(receiveInfo, "sensor4.csv");
                            snacObj.Action("4");
                            break;
                        case 5:
                            Receive(receiveInfo, "sensor5.csv");
                            snacObj.Action("5");
                            break;
                        case 6:
                            Receive(receiveInfo, "sensor6.csv");
                            snacObj.Action("6");
                            break;
                        case 7:
                            Receive(receiveInfo, "sensor7.csv");
                            snacObj.Action("7");
                            break;
                        case 8:
                            Receive(receiveInfo, "sensor8.csv");
                            snacObj.Action("8");
                            break;
                        case 9:
                            Receive(receiveInfo, "sensor9.csv");
                            snacObj.Action("9");
                            break;
                        case 10:
                            Receive(receiveInfo, "sensor10.csv");
                            snacObj.Action("10");
                            break;
                        case 11:
                            Receive(receiveInfo, "sensor11.csv");
                            snacObj.Action("11");
                            break;
                        case 12:
                            Receive(receiveInfo, "sensor12.csv");
                            snacObj.Action("12");
                            break;
                        case 13:
                            Receive(receiveInfo, "sensor13.csv");
                            snacObj.Action("13");
                            break;
                        case 14:
                            Receive(receiveInfo, "sensor14.csv");
                            snacObj.Action("14");
                            break;
                        case 15:
                            Receive(receiveInfo, "sensor15.csv");
                            snacObj.Action("15");
                            break;
                        case 16:
                            Receive(receiveInfo, "sensor16.csv");
                            snacObj.Action("16");
                            break;
                        case 17:
                            Receive(receiveInfo, "sensor17.csv");
                            snacObj.Action("17");
                            break;
                        case 18:
                            Receive(receiveInfo, "sensor18.csv");
                            snacObj.Action("18");
                            break;
                        case 19:
                            Receive(receiveInfo, "sensor19.csv");
                            snacObj.Action("19");
                            break;
                    }
                }
            }
        }
    }
}
