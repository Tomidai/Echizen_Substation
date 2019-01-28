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

namespace Map_Form {
    public partial class Control_Form:Form {

        //インスタンス固定
        public static Map_Form map_form = new Map_Form();
        public static Camera_Form camera_form = new Camera_Form();

        public Control_Form() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //マップフォーム起動
            map_form.Show();
            map_form.Hide();
            //カメラフォーム起動
            camera_form.Show();
            //ファイル監視実行
            File_Watcher fw = new File_Watcher(map_form);
            fw.StartWatching();
        }

        private void Form1_Activated(object sender, EventArgs e) {
            //このフォームを非表示
            this.Hide();
        }

        //マップからカメラへ画面遷移する
        public void Camera_Show(int i) {
            map_form.Hide();
            camera_form.Show();
            //カメラの色を戻す
            SensorAction snac = new SensorAction(map_form);
            snac.CameraReturn();

            camera_form.treeView1.SelectedNode = null;

            camera_form.setLocation_1();
            camera_form.camSelect(0);
            camera_form.setBrowser(1, i-1);
            camera_form.camNo_01=i - 1;
        }

        //カメラからマップへ画面遷移する
        public void Map_Show() {
            camera_form.Hide();
            map_form.Show();
        }
    }
}
