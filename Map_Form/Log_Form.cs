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
    public partial class Log_Form : Form {
        public Log_Form() {
            InitializeComponent();
        }

        private void Log_Form_Load(object sender, EventArgs e) {
            string path = ConfigurationManager.AppSettings["LogPath"];

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using(StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis"))) {
                while (!sr.EndOfStream) {
                    listBox1.Items.Add(sr.ReadLine());
                }
            }
            listBox1.TopIndex = listBox1.Items.Count-1;
        }
    }
}
