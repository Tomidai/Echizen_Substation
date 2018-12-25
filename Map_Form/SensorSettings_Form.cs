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
        Map_Form mfObj;
        Sensor snObj;

        //送りファイルに送信するテキスト情報
        string sn1, sn2, sn3, sn4, sn5, sn6, sn7, sn8, sn9, sn10, 
            sn11, sn12, sn13, sn14, sn15, sn16, sn17, sn18, sn19;

        //コンストラクタ
        public SensorSettings_Form(Map_Form mf_obj) {
            InitializeComponent();
            mfObj = mf_obj;
            snObj = new Sensor(mfObj);

        }

        //起動時センサーの状態に合わせる
        private void SensorSettings_Form_Load(object sender, EventArgs e) {
            SetRadioButton(snObj.ReturnSetting("sensor1.csv"), normal1, lock1, environ1);
            SetRadioButton(snObj.ReturnSetting("sensor2.csv"), normal2, lock2, environ2);
            SetRadioButton(snObj.ReturnSetting("sensor3.csv"), normal3, lock3, environ3);
            SetRadioButton(snObj.ReturnSetting("sensor4.csv"), normal4, lock4, environ4);
            SetRadioButton(snObj.ReturnSetting("sensor5.csv"), normal5, lock5, environ5);
            SetRadioButton(snObj.ReturnSetting("sensor6.csv"), normal6, lock6, environ6);
            SetRadioButton(snObj.ReturnSetting("sensor7.csv"), normal7, lock7, environ7);
            SetRadioButton(snObj.ReturnSetting("sensor8.csv"), normal8, lock8, environ8);
            SetRadioButton(snObj.ReturnSetting("sensor9.csv"), normal9, lock9, environ9);
            SetRadioButton(snObj.ReturnSetting("sensor10.csv"), normal10, lock10, environ10);
            SetRadioButton(snObj.ReturnSetting("sensor11.csv"), normal11, lock11, environ11);
            SetRadioButton(snObj.ReturnSetting("sensor12.csv"), normal12, lock12, environ12);
            SetRadioButton(snObj.ReturnSetting("sensor13.csv"), normal13, lock13, environ13);
            SetRadioButton(snObj.ReturnSetting("sensor14.csv"), normal14, lock14, environ14);
            SetRadioButton(snObj.ReturnSetting("sensor15.csv"), normal15, lock15, environ15);
            SetRadioButton(snObj.ReturnSetting("sensor16.csv"), normal16, lock16, environ16);
            SetRadioButton(snObj.ReturnSetting("sensor17.csv"), normal17, lock17, environ17);
            SetRadioButton(snObj.ReturnSetting("sensor18.csv"), normal18, lock18, environ18);
            SetRadioButton(snObj.ReturnSetting("sensor19.csv"), normal19, lock19, environ19);

            //起動時に門の状態に合わせてコントロールを制御する
            string[] gateState500 = snObj.ReturnSetting("GateOpen500.csv");
            string[] gateState77 = snObj.ReturnSetting("GateOpen77.csv");
            if(gateState500[1] == "1" && gateState77[1] == "1") {
                //両方無効
                groupSensor1.Enabled = false;
                groupSensor2.Enabled = false;
                groupSensor3.Enabled = false;
                groupSensor4.Enabled = false;
                groupSensor5.Enabled = false;
                groupSensor6.Enabled = false;
                groupSensor7.Enabled = false;
                groupSensor8.Enabled = false;
                groupSensor9.Enabled = false;
                groupSensor10.Enabled = false;
                groupSensor11.Enabled = false;
                groupSensor12.Enabled = false;
                groupSensor13.Enabled = false;
                groupSensor14.Enabled = false;
                groupSensor15.Enabled = false;
                groupSensor16.Enabled = false;
                groupSensor17.Enabled = false;
                groupSensor18.Enabled = false;
                groupSensor19.Enabled = false;
            } else if(gateState500[1] == "0" && gateState77[1] == "0") {
                //両方有効
                groupSensor1.Enabled = true;
                groupSensor2.Enabled = true;
                groupSensor3.Enabled = true;
                groupSensor4.Enabled = true;
                groupSensor5.Enabled = true;
                groupSensor6.Enabled = true;
                groupSensor7.Enabled = true;
                groupSensor8.Enabled = true;
                groupSensor9.Enabled = true;
                groupSensor10.Enabled = true;
                groupSensor11.Enabled = true;
                groupSensor12.Enabled = true;
                groupSensor13.Enabled = true;
                groupSensor14.Enabled = true;
                groupSensor15.Enabled = true;
                groupSensor16.Enabled = true;
                groupSensor17.Enabled = true;
                groupSensor18.Enabled = true;
                groupSensor19.Enabled = true;
            } else if(gateState500[1] == "0" && gateState77[1] == "1") {
                //500区間有効
                groupSensor1.Enabled = true;
                groupSensor2.Enabled = true;
                groupSensor3.Enabled = true;
                groupSensor4.Enabled = true;
                groupSensor5.Enabled = true;
                groupSensor6.Enabled = true;
                groupSensor7.Enabled = true;
                groupSensor8.Enabled = true;
                groupSensor9.Enabled = true;
                groupSensor10.Enabled = true;
                groupSensor11.Enabled = true;
                groupSensor12.Enabled = true;
                groupSensor13.Enabled = true;
                groupSensor14.Enabled = false;
                groupSensor15.Enabled = false;
                groupSensor16.Enabled = false;
                groupSensor17.Enabled = false;
                groupSensor18.Enabled = false;
                groupSensor19.Enabled = false;
            } else if(gateState500[1] == "1" && gateState77[1] == "0") {
                //77区間有効
                groupSensor1.Enabled = false;
                groupSensor2.Enabled = false;
                groupSensor3.Enabled = false;
                groupSensor4.Enabled = false;
                groupSensor5.Enabled = false;
                groupSensor6.Enabled = false;
                groupSensor7.Enabled = false;
                groupSensor8.Enabled = false;
                groupSensor9.Enabled = false;
                groupSensor10.Enabled = false;
                groupSensor11.Enabled = false;
                groupSensor12.Enabled = false;
                groupSensor13.Enabled = false;
                groupSensor14.Enabled = true;
                groupSensor15.Enabled = true;
                groupSensor16.Enabled = true;
                groupSensor17.Enabled = true;
                groupSensor18.Enabled = true;
                groupSensor19.Enabled = true;
            }

        }

        //配列を参照し、ラジオボタンの状態を決めるメソッド
        public void SetRadioButton(string[] snSetting, RadioButton normal, RadioButton locked, RadioButton environ) {
            if(snSetting[1] == "1") {
                locked.Checked = true;
            }else if(snSetting[2] == "1") {
                environ.Checked = true;
            }else if(snSetting[1] == "0") {
                normal.Checked = true;
            } 
        }


        //決定を反映させるメソッド
        public string Change(RadioButton locked, RadioButton environ, RadioButton normal, string path, string tage) {
            if (locked.Checked == true) {
                snObj.SensorSettingChange(path, 2, "0");    //環境を0にする
                snObj.SensorSettingChange(path, 1, "1");    //ロックを1にする
                string str = snObj.GetSendText(path, 1, "1");   //実際に送るテキストはロックを1にした情報だけでよい
                return str;
            } else if (environ.Checked == true) {
                snObj.SensorSettingChange(path, 1, "0");    //ロックを0にする
                snObj.SensorSettingChange(path, 2, "1");    //環境を1にする
                string str = snObj.GetSendText(path, 2, "1");
                return str;
            } else {
                snObj.SensorSettingChange(path, 2, "0");
                snObj.SensorSettingChange(path, 1, "0");
                string str = snObj.GetSendText(path, 1, "0");
                return str;
            }
        }

        //一括通常
        private void buttonAllNormal_Click(object sender, EventArgs e) {
            normal1.Checked = true;
            normal2.Checked = true;
            normal3.Checked = true;
            normal4.Checked = true;
            normal5.Checked = true;
            normal6.Checked = true;
            normal7.Checked = true;
            normal8.Checked = true;
            normal9.Checked = true;
            normal10.Checked = true;
            normal11.Checked = true;
            normal12.Checked = true;
            normal13.Checked = true;
            normal14.Checked = true;
            normal15.Checked = true;
            normal16.Checked = true;
            normal17.Checked = true;
            normal18.Checked = true;
            normal19.Checked = true;
        }

        //一括ロック
        private void buttonAllLock_Click(object sender, EventArgs e) {
            lock1.Checked = true;
            lock2.Checked = true;
            lock3.Checked = true;
            lock4.Checked = true;
            lock5.Checked = true;
            lock6.Checked = true;
            lock7.Checked = true;
            lock8.Checked = true;
            lock9.Checked = true;
            lock10.Checked = true;
            lock11.Checked = true;
            lock12.Checked = true;
            lock13.Checked = true;
            lock14.Checked = true;
            lock15.Checked = true;
            lock16.Checked = true;
            lock17.Checked = true;
            lock18.Checked = true;
            lock19.Checked = true;
        }

        //一括環境
        private void buttonAllEnviron_Click(object sender, EventArgs e) {
            environ1.Checked = true;
            environ2.Checked = true;
            environ3.Checked = true;
            environ4.Checked = true;
            environ5.Checked = true;
            environ6.Checked = true;
            environ7.Checked = true;
            environ8.Checked = true;
            environ9.Checked = true;
            environ10.Checked = true;
            environ11.Checked = true;
            environ12.Checked = true;
            environ13.Checked = true;
            environ14.Checked = true;
            environ15.Checked = true;
            environ16.Checked = true;
            environ17.Checked = true;
            environ18.Checked = true;
            environ19.Checked = true;
        }

        //決定ボタン
        private void buttonOK_Click(object sender, EventArgs e) {
            //門の状態に合わせて送る情報を決める
            string[] gateState500 = snObj.ReturnSetting("GateOpen500.csv");
            string[] gateState77 = snObj.ReturnSetting("GateOpen77.csv");
            if(gateState500[1] == "1" && gateState77[1] == "1") {
                //門が両方開いているので何もしない
            }else if(gateState500[1] == "0" && gateState77[1] == "0") {
                //門は両方閉じているので全て送る
                sn1 = Change(lock1, environ1, normal1, "sensor1.csv", "01");
                sn2 = Change(lock2, environ2, normal2, "sensor2.csv", "02");
                sn3 = Change(lock3, environ3, normal3, "sensor3.csv", "03");
                sn4 = Change(lock4, environ4, normal4, "sensor4.csv", "04");
                sn5 = Change(lock5, environ5, normal5, "sensor5.csv", "05");
                sn6 = Change(lock6, environ6, normal6, "sensor6.csv", "06");
                sn7 = Change(lock7, environ7, normal7, "sensor7.csv", "07");
                sn8 = Change(lock8, environ8, normal8, "sensor8.csv", "08");
                sn9 = Change(lock9, environ9, normal9, "sensor9.csv", "09");
                sn10 = Change(lock10, environ10, normal10, "sensor10.csv", "10");
                sn11 = Change(lock11, environ11, normal11, "sensor11.csv", "11");
                sn12 = Change(lock12, environ12, normal12, "sensor12.csv", "12");
                sn13 = Change(lock13, environ13, normal13, "sensor13.csv", "13");
                sn14 = Change(lock14, environ14, normal14, "sensor14.csv", "14");
                sn15 = Change(lock15, environ15, normal15, "sensor15.csv", "15");
                sn16 = Change(lock16, environ16, normal16, "sensor16.csv", "16");
                sn17 = Change(lock17, environ17, normal17, "sensor17.csv", "17");
                sn18 = Change(lock18, environ18, normal18, "sensor18.csv", "18");
                sn19 = Change(lock19, environ19, normal19, "sensor19.csv", "19");
                //テキスト送信
                string[] send = { sn1, sn2, sn3, sn4, sn5, sn6, sn7, sn8, sn9, sn10, sn11, sn12, sn13, sn14, sn15, sn16, sn17, sn18, sn19 };
                snObj.SetSendText(send);
            } else if (gateState500[1] == "0" && gateState77[1] == "1") {
                //500のみ送信する
                sn1 = Change(lock1, environ1, normal1, "sensor1.csv", "01");
                sn2 = Change(lock2, environ2, normal2, "sensor2.csv", "02");
                sn3 = Change(lock3, environ3, normal3, "sensor3.csv", "03");
                sn4 = Change(lock4, environ4, normal4, "sensor4.csv", "04");
                sn5 = Change(lock5, environ5, normal5, "sensor5.csv", "05");
                sn6 = Change(lock6, environ6, normal6, "sensor6.csv", "06");
                sn7 = Change(lock7, environ7, normal7, "sensor7.csv", "07");
                sn8 = Change(lock8, environ8, normal8, "sensor8.csv", "08");
                sn9 = Change(lock9, environ9, normal9, "sensor9.csv", "09");
                sn10 = Change(lock10, environ10, normal10, "sensor10.csv", "10");
                sn11 = Change(lock11, environ11, normal11, "sensor11.csv", "11");
                sn12 = Change(lock12, environ12, normal12, "sensor12.csv", "12");
                sn13 = Change(lock13, environ13, normal13, "sensor13.csv", "13");
                //テキスト送信
                string[] send = { sn1, sn2, sn3, sn4, sn5, sn6, sn7, sn8, sn9, sn10, sn11, sn12, sn13 };
                snObj.SetSendText(send);
            } else if (gateState500[1] == "1" && gateState77[1] == "0") {
                //77のみ送信する
                sn14 = Change(lock14, environ14, normal14, "sensor14.csv", "14");
                sn15 = Change(lock15, environ15, normal15, "sensor15.csv", "15");
                sn16 = Change(lock16, environ16, normal16, "sensor16.csv", "16");
                sn17 = Change(lock17, environ17, normal17, "sensor17.csv", "17");
                sn18 = Change(lock18, environ18, normal18, "sensor18.csv", "18");
                sn19 = Change(lock19, environ19, normal19, "sensor19.csv", "19");
                //テキスト送信
                string[] send = { sn14, sn15, sn16, sn17, sn18, sn19 };
                snObj.SetSendText(send);
            }

        }

        //キャンセルボタン
        private void buttonCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
