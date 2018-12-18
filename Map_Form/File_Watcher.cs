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

        private FileSystemWatcher SensorWatcher;

        public void StartWatching() {
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

        //SensorSettingsファイルが変更されたら発生するイベント
        public void SensorChanged(object source, FileSystemEventArgs e) {
            //反応が早すぎるので少し止める
            Thread.Sleep(50);
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

                //門開閉500ファイル
                case "GateOpen500.csv":
                    string[] gateOpen500_info = snObj.ReturnSetting(e.Name);
                    if(gateOpen500_info[1]== "1") {
                        snacObj.GateOpen_SensorAllLock_500();
                    }else if(gateOpen500_info[1] == "0") {
                        snObj.ChangeSensor(snObj.ReturnSetting("sensor1.csv"), mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                            Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                            Properties.Resources.Sensor_EnvironLock_01);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor2.csv"), mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                            Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                            Properties.Resources.Sensor_EnvironLock_02);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor3.csv"), mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                            Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
                            Properties.Resources.Sensor_EnvironLock_03);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor4.csv"), mfObj.Sensor_04, Properties.Resources.Sensor_Normal_04, Properties.Resources.Sensor_Lock_04,
                            Properties.Resources.Sensor_Action_04, Properties.Resources.Sensor_Environ_04, Properties.Resources.Sensor_Failed_04,
                            Properties.Resources.Sensor_EnvironLock_04);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor5.csv"), mfObj.Sensor_05, Properties.Resources.Sensor_Normal_05, Properties.Resources.Sensor_Lock_05,
                            Properties.Resources.Sensor_Action_05, Properties.Resources.Sensor_Environ_05, Properties.Resources.Sensor_Failed_05,
                            Properties.Resources.Sensor_EnvironLock_05);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor6.csv"), mfObj.Sensor_06, Properties.Resources.Sensor_Normal_06, Properties.Resources.Sensor_Lock_06,
                            Properties.Resources.Sensor_Action_06, Properties.Resources.Sensor_Environ_06, Properties.Resources.Sensor_Failed_06,
                            Properties.Resources.Sensor_EnvironLock_06);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor7.csv"), mfObj.Sensor_07, Properties.Resources.Sensor_Normal_07, Properties.Resources.Sensor_Lock_07,
                            Properties.Resources.Sensor_Action_07, Properties.Resources.Sensor_Environ_07, Properties.Resources.Sensor_Failed_07,
                            Properties.Resources.Sensor_EnvironLock_07);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor8.csv"), mfObj.Sensor_08, Properties.Resources.Sensor_Normal_08, Properties.Resources.Sensor_Lock_08,
                            Properties.Resources.Sensor_Action_08, Properties.Resources.Sensor_Environ_08, Properties.Resources.Sensor_Failed_08,
                            Properties.Resources.Sensor_EnvironLock_08);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor9.csv"), mfObj.Sensor_09, Properties.Resources.Sensor_Normal_09, Properties.Resources.Sensor_Lock_09,
                            Properties.Resources.Sensor_Action_09, Properties.Resources.Sensor_Environ_09, Properties.Resources.Sensor_Failed_09,
                            Properties.Resources.Sensor_EnvironLock_09);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor10.csv"), mfObj.Sensor_10, Properties.Resources.Sensor_Normal_10, Properties.Resources.Sensor_Lock_10,
                            Properties.Resources.Sensor_Action_10, Properties.Resources.Sensor_Environ_10, Properties.Resources.Sensor_Failed_10,
                            Properties.Resources.Sensor_EnvironLock_10);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor11.csv"), mfObj.Sensor_11, Properties.Resources.Sensor_Normal_11, Properties.Resources.Sensor_Lock_11,
                            Properties.Resources.Sensor_Action_11, Properties.Resources.Sensor_Environ_11, Properties.Resources.Sensor_Failed_11,
                            Properties.Resources.Sensor_EnvironLock_11);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor12.csv"), mfObj.Sensor_12, Properties.Resources.Sensor_Normal_12, Properties.Resources.Sensor_Lock_12,
                            Properties.Resources.Sensor_Action_12, Properties.Resources.Sensor_Environ_12, Properties.Resources.Sensor_Failed_12,
                            Properties.Resources.Sensor_EnvironLock_12);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor13.csv"), mfObj.Sensor_13, Properties.Resources.Sensor_Normal_13, Properties.Resources.Sensor_Lock_13,
                            Properties.Resources.Sensor_Action_13, Properties.Resources.Sensor_Environ_13, Properties.Resources.Sensor_Failed_13,
                            Properties.Resources.Sensor_EnvironLock_13);
                    }
                    break;
                //門開閉77ファイル
                case "GateOpen77.csv":
                    string[] gateOpen77_info = snObj.ReturnSetting(e.Name);
                    if (gateOpen77_info[1] == "1") {
                        snacObj.GateOpen_SensorAllLock_77();
                    } else if (gateOpen77_info[1] == "0") {
                        snObj.ChangeSensor(snObj.ReturnSetting("sensor14.csv"), mfObj.Sensor_14, Properties.Resources.Sensor_Normal_14, Properties.Resources.Sensor_Lock_14,
                            Properties.Resources.Sensor_Action_14, Properties.Resources.Sensor_Environ_14, Properties.Resources.Sensor_Failed_14,
                            Properties.Resources.Sensor_EnvironLock_14);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor15.csv"), mfObj.Sensor_15, Properties.Resources.Sensor_Normal_15, Properties.Resources.Sensor_Lock_15,
                            Properties.Resources.Sensor_Action_15, Properties.Resources.Sensor_Environ_15, Properties.Resources.Sensor_Failed_15,
                            Properties.Resources.Sensor_EnvironLock_15);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor16.csv"), mfObj.Sensor_16, Properties.Resources.Sensor_Normal_16, Properties.Resources.Sensor_Lock_16,
                            Properties.Resources.Sensor_Action_16, Properties.Resources.Sensor_Environ_16, Properties.Resources.Sensor_Failed_16,
                            Properties.Resources.Sensor_EnvironLock_16);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor17.csv"), mfObj.Sensor_17, Properties.Resources.Sensor_Normal_17, Properties.Resources.Sensor_Lock_17,
                            Properties.Resources.Sensor_Action_17, Properties.Resources.Sensor_Environ_17, Properties.Resources.Sensor_Failed_17,
                            Properties.Resources.Sensor_EnvironLock_17);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor18.csv"), mfObj.Sensor_18, Properties.Resources.Sensor_Normal_18, Properties.Resources.Sensor_Lock_18,
                            Properties.Resources.Sensor_Action_18, Properties.Resources.Sensor_Environ_18, Properties.Resources.Sensor_Failed_18,
                            Properties.Resources.Sensor_EnvironLock_18);

                        snObj.ChangeSensor(snObj.ReturnSetting("sensor19.csv"), mfObj.Sensor_19, Properties.Resources.Sensor_Normal_19, Properties.Resources.Sensor_Lock_19,
                            Properties.Resources.Sensor_Action_19, Properties.Resources.Sensor_Environ_19, Properties.Resources.Sensor_Failed_19,
                            Properties.Resources.Sensor_EnvironLock_19);
                    }
                    break;
                //権限ファイル
                case "right.csv":
                    snObj.RightBool(snObj.ReturnSetting(e.Name));
                    break;
                //設備故障ファイル
                case "fault.csv":
                    snObj.FaultBool(snObj.ReturnSetting(e.Name));
                    break;
            }
        }
        
    }
}
