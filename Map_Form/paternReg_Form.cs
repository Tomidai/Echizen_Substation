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

namespace Map_Form
{
    public partial class PaternReg_Form : Form
    {

        private TextBox[] textName = new TextBox[6];
        private ComboBox[,] comboBox = new ComboBox[6, 4];
        private string[] patternName = new string[6];
        private int[,] patternNo = new int[6, 4];
        private string[] camName = new string[8];
        private string path = "";
        public TreeNode tn001;
        public TreeNode tn002;
        public TreeView treeView;
        public ImageList imageList;



        public PaternReg_Form(Camera_Form  form)
        {
            InitializeComponent();

            textName[0] = textBox1;
            textName[1] = textBox2;
            textName[2] = textBox3;
            textName[3] = textBox4;
            textName[4] = textBox5;
            textName[5] = textBox6;

            comboBox[0, 0] = comboBox1;
            comboBox[0, 1] = comboBox2;
            comboBox[0, 2] = comboBox3;
            comboBox[0, 3] = comboBox4;

            comboBox[1, 0] = comboBox5;
            comboBox[1, 1] = comboBox6;
            comboBox[1, 2] = comboBox7;
            comboBox[1, 3] = comboBox8;

            comboBox[2, 0] = comboBox9;
            comboBox[2, 1] = comboBox10;
            comboBox[2, 2] = comboBox11;
            comboBox[2, 3] = comboBox12;

            comboBox[3, 0] = comboBox13;
            comboBox[3, 1] = comboBox14;
            comboBox[3, 2] = comboBox15;
            comboBox[3, 3] = comboBox16;

            comboBox[4, 0] = comboBox17;
            comboBox[4, 1] = comboBox18;
            comboBox[4, 2] = comboBox19;
            comboBox[4, 3] = comboBox20;

            comboBox[5, 0] = comboBox21;
            comboBox[5, 1] = comboBox22;
            comboBox[5, 2] = comboBox23;
            comboBox[5, 3] = comboBox24;

            camName = form.camName;
            patternName = form.patternName;
            patternNo = Camera_Form.patternNo;
            path = form.path;
            treeView = form.treeView;
            imageList = form.imageList01;
            tn001 = form.tn001;
            tn002 = form.tn002;



            for (int i = 0; i < 6; ++i)
            {
                textName[i].Text = form.patternName[i];
                for(int j=0; j < 4; ++j)
                {



                    for (int k = 0; k < 8; ++k)
                    {
                        comboBox[i, j].Items.Add(form.camName[k]);

                    }
                    comboBox[i, j].SelectedIndex = Camera_Form.patternNo[i, j];
                }
            }




        }

        public void textInput()
        {

        }

        public void PaternReg_Form_FormClosed(object sender, FormClosedEventArgs e)
        {

            Camera_Form.camNameChangeMode = 0;
            Camera_Form.camNameChangeBtn.Image = Properties.Resources.cont_b018;
            
        }


        public void treeNameChange()
        {
            //   treeView = new TreeView();
            //   treeView.ImageList = imageList;

            tn001.Nodes.Clear();
            tn002.Nodes.Clear();

        //    tn001 = new TreeNode();
        //    tn002 = new TreeNode();

        //    tn001 = treeView.Nodes.Add("001", "1画面", 0);
        //    tn002 = treeView.Nodes.Add("002", "4画面", 1);

            tn002.Nodes.Clear();
       
            for (int i = 0; i < 8; ++i)
            {
                tn001.Nodes.Add("", camName[i], 2, 3);
            }

            for (int j = 0; j < 6; ++j)
            {
                tn002.Nodes.Add("", patternName[j], 5, 6);
            }


        }


        public void patternFileWright()
        {
            string file = path+ "patern.csv";
            string Data = "";

            for (int i = 0; i < 6; ++i)
            {
                Data = Data + textName[i].Text+",";
                patternName[i] = textName[i].Text;


                for (int j = 0; j < 4; ++j)
                {

                   Camera_Form.patternNo[i, j] = comboBox[i, j].SelectedIndex;

                    if (j != 3)
                    {
                        Data = Data + (comboBox[i, j].SelectedIndex + 1) + ",";
                    }
                    else
                    {
                        Data = Data + (comboBox[i, j].SelectedIndex + 1) + "\r\n";
                    }
                }
            }



            try
            {
                
                StreamWriter sw = new StreamWriter(file, false, Encoding.GetEncoding("shift_jis"));

                sw.Write(Data);
                sw.Close();
                //   MessageBox.Show("登録完了");

            }
            catch
            {
                MessageBox.Show("登録に失敗しました");
            }




            





        }





        private void btn_reg_MouseDown(object sender, MouseEventArgs e)
        {


            this.btn_reg.Image = Properties.Resources.cont_pre001X;
            patternFileWright();
            treeNameChange();
           // this.Close();
        }

        private void btn_reg_MouseUp(object sender, MouseEventArgs e)
        {

            this.btn_reg.Image = Properties.Resources.cont_pre001;
            
            

        }




        private void btn_cancel_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 6; ++i)
            {
                textName[i].Text = patternName[i];
                for (int j = 0; j < 4; ++j)
                {
                    comboBox[i, j].Items.Clear();


                    for (int k = 0; k < 8; ++k)
                    {

                        comboBox[i, j].Items.Add(camName[k]);

                    }
                    comboBox[i, j].SelectedIndex = patternNo[i, j];
                }
            }

            this.btn_cancel.Image = global::Map_Form.Properties.Resources.cont_pre001X;


        }

        private void btn_cancel_MouseUp(object sender, MouseEventArgs e)
        {

            this.btn_cancel.Image = global::Map_Form.Properties.Resources.cont_pre001;

        }
    }


}
