using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map_Form {
    public partial class Camera_Form:Form {
        public Camera_Form() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Form1 form1 = new Form1();
            form1.Map_Show();
        }

        private void Camera_Form_Load(object sender, EventArgs e) {

        }
    }
}
