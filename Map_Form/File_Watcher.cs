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
        //コンストラクタ
        public File_Watcher(Map_Form mf_obj) {
            mfObj = mf_obj;
            snObj = new Sensor(mfObj);
        }

        private  FileSystemWatcher Watcher;

        public void StartWatching() {
            Watcher = new FileSystemWatcher();

            //監視するパス
            Watcher.Path = ConfigurationManager.AppSettings["WatchDir"];

            //ファイル名と最終書き込み時間
            Watcher.NotifyFilter = NotifyFilters.LastWrite;

            //フィルタで監視するファイルを.txtのみにする
            Watcher.Filter = "*.txt";

            //サブディレクトリ以下も監視する
            Watcher.IncludeSubdirectories = false;

            //変更発生時のイベントを定義する
            Watcher.Changed += Changed;

            //監視開始
            Watcher.EnableRaisingEvents = true;

            //必要がなくなったら監視終了(StopWatching)を呼ぶ
        }

        //ファイル監視ストップ
        public void StopWatching() {
            Watcher.EnableRaisingEvents = false;
            Watcher.Dispose();
        }

        //Receiveファイルを読み込み、反映させる
        public void Receive(string[] receiveInfo,int n) {
            string[] settingsInfo = File.ReadAllLines(ConfigurationManager.AppSettings["SettingPath"]);
            string[] changeline = settingsInfo[n].Split(',');
            if (receiveInfo[3] == "1") {
                //故障
                changeline[3] = "3";
                settingsInfo[n] = string.Join(",", changeline);
            } else if (receiveInfo[1] == "1") {
                //侵入
                changeline[3] = "1";
                settingsInfo[n] = string.Join(",", changeline);
            } else if (receiveInfo[2] == "1") {
                //環境
                changeline[3] = "2";
                settingsInfo[n] = string.Join(",", changeline);
            }
            //読み込んだ情報をセッティングファイルに反映させる
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["SettingPath"], false)) {
                for (int i = 0; i < settingsInfo.Length; i++) {
                    sw.WriteLine(settingsInfo[i]);
                }
            }
        }

        //Receiveファイルが変更されたら発生するイベント
        public async void Changed(object source, FileSystemEventArgs e) {
            //センサーからの情報受信
            if(e.FullPath == ConfigurationManager.AppSettings["ReceivePath"]) {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["ReceivePath"])) {
                    while (!sr.EndOfStream) {
                        //読み込んだ1行をcsvで分けて配列に入れる
                        string[] receiveInfo = sr.ReadLine().Split(',');
                        //センサーを判断する条件分岐1~19
                        switch (int.Parse(receiveInfo[0])) {
                            case 1:
                                //Receiveファイルを読込反映させるメソッドを呼び出す
                                Receive(receiveInfo, 0);
                                break;
                            case 2:
                                Receive(receiveInfo, 1);
                                break;
                            case 3:
                                Receive(receiveInfo, 2);
                                break;
                            case 4:
                                Receive(receiveInfo, 3);
                                break;
                            case 5:
                                Receive(receiveInfo, 4);
                                break;
                            case 6:
                                Receive(receiveInfo, 5);
                                break;
                            case 7:
                                Receive(receiveInfo, 6);
                                break;
                            case 8:
                                Receive(receiveInfo, 7);
                                break;
                            case 9:
                                Receive(receiveInfo, 8);
                                break;
                            case 10:
                                Receive(receiveInfo, 9);
                                break;
                            case 11:
                                Receive(receiveInfo, 10);
                                break;
                            case 12:
                                Receive(receiveInfo, 11);
                                break;
                            case 13:
                                Receive(receiveInfo, 12);
                                break;
                            case 14:
                                Receive(receiveInfo, 13);
                                break;
                            case 15:
                                Receive(receiveInfo, 14);
                                break;
                            case 16:
                                Receive(receiveInfo, 15);
                                break;
                            case 17:
                                Receive(receiveInfo, 16);
                                break;
                            case 18:
                                Receive(receiveInfo, 17);
                                break;
                            case 19:
                                Receive(receiveInfo, 18);
                                break;
                        }
                    }
                }
            } else if(e.FullPath == ConfigurationManager.AppSettings["SettingPath"]){
                //設定ファイルが変更されたときに色、タグを変更する
                snObj.GetSensorInfo();

                snObj.ChangeSensor(snObj.sensor01, mfObj.Sensor_01, Properties.Resources.Sensor_Normal_01, Properties.Resources.Sensor_Lock_01,
                Properties.Resources.Sensor_Action_01, Properties.Resources.Sensor_Environ_01, Properties.Resources.Sensor_Failed_01,
                Properties.Resources.Sensor_EnvironLock_01);

                snObj.ChangeSensor(snObj.sensor02, mfObj.Sensor_02, Properties.Resources.Sensor_Normal_02, Properties.Resources.Sensor_Lock_02,
                    Properties.Resources.Sensor_Action_02, Properties.Resources.Sensor_Environ_02, Properties.Resources.Sensor_Failed_02,
                    Properties.Resources.Sensor_EnvironLock_02);

                snObj.ChangeSensor(snObj.sensor03, mfObj.Sensor_03, Properties.Resources.Sensor_Normal_03, Properties.Resources.Sensor_Lock_03,
                    Properties.Resources.Sensor_Action_03, Properties.Resources.Sensor_Environ_03, Properties.Resources.Sensor_Failed_03,
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
        }
    }
}
