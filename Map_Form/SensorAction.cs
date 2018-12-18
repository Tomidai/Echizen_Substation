using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;


namespace Map_Form {
    class SensorAction {
        //インスタンスの固定
        public Map_Form mfObj;

        //コンストラクタ
        public SensorAction(Map_Form mf_obj) {
            mfObj = mf_obj;
        }

        //カメラプリセット情報を読み込み、マップ上のどのカメラアイコンを
        //変更させるかを判断する処理
        public void CameraJudgment(int snNum) {
            //ここにカメラアイコンの色を変化させる処理を追加
            using (FileStream fs = new FileStream(ConfigurationManager.AppSettings["CameraPresetPath"],
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                using (StreamReader stream = new StreamReader(fs)) {
                    while (!stream.EndOfStream) {
                        string[] values = stream.ReadLine().Split(',');
                        if (values[0] == snNum.ToString()) {
                            CameraColorChange(values[1]);
                            CameraColorChange(values[2]);
                            CameraColorChange(values[3]);
                        }
                    }
                }
            }
        }

        //実際にカメラアイコンの色を変更させる処理
        public void CameraColorChange(string str) {
            mfObj.Invoke((MethodInvoker)delegate {
                switch (str) {
                    case "1":
                        mfObj.Camera_01.Image = Properties.Resources.Camera_Action;
                        break;
                    case "2":
                        mfObj.Camera_02.Image = Properties.Resources.Camera_Action;
                        break;
                    case "3":
                        mfObj.Camera_03.Image = Properties.Resources.Camera_Action;
                        break;
                    case "4":
                        mfObj.Camera_04.Image = Properties.Resources.Camera_Action;
                        break;
                    case "5":
                        mfObj.Camera_05.Image = Properties.Resources.Camera_Action;
                        break;
                    case "6":
                        mfObj.Camera_06.Image = Properties.Resources.Camera_Action;
                        break;
                    case "7":
                        mfObj.Camera_07.Image = Properties.Resources.Camera_Action;
                        break;
                    case "8":
                        mfObj.Camera_08.Image = Properties.Resources.Camera_Action;
                        break;
                }
            });
        }

        //カメラアイコンの色をもとに戻す処理
        public void CameraReturn() {
            mfObj.Invoke((MethodInvoker)delegate {
                mfObj.Camera_01.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_02.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_03.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_04.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_05.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_06.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_07.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_08.Image = Properties.Resources.Camera_Normal;
            });
        }

        //全ての区間を一時的にロックにする処理
        public void GateOpen_SensorAllLock_500() {
            mfObj.Invoke((MethodInvoker)delegate {
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
            });
        }


        public void GateOpen_SensorAllLock_77() {
            mfObj.Invoke((MethodInvoker)delegate {
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
        }
    }
}
