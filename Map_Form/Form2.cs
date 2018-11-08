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
    public partial class Form2 : Form {
        String RecIP = "";

        public Form2(Camera_Form Form1, String IP) {
            InitializeComponent();
            RecIP = IP;
        }
        private void Form2_Load(object sender, EventArgs e) {


            String URI = "http://" + RecIP + "/cgi-bin/general-cgi/portalServer.cgi?command=get_page&p_name=AVPortalSetting&p_version=1&page_name=po_mainview.html";
            //URI = "http://" + RecIP;
            webBrowser1.Navigate(new Uri(URI));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) {

            Camera_Form.RecOn = 0;


        }
    }
}
