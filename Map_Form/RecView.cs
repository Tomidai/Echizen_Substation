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
    public partial class RecView : Form {
        String RecIP = "";

        public RecView(Camera_Form Form1, String IP) {
            InitializeComponent();
            RecIP = IP;

            String URI = "http://" + RecIP + "/cgi-bin/general-cgi/portalServer.cgi?command=get_page&p_name=AVPortalSetting&p_version=1&page_name=po_mainview.html";
            
            webBrowser2.Navigate(new Uri(URI));


        }
        private void Form2_Load(object sender, EventArgs e) {


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) {

            Camera_Form.RecOn = 0;
            Camera_Form.recButton.Image= global::Map_Form.Properties.Resources.cont_b0171;
            webBrowser2.Dispose();

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
