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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FormPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "PDF Dosyası Seç";
                op.Filter = "PDF Dosyaları (*.pdf) | *.pdf";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    axAcroPDF1.LoadFile(op.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void btn_Note_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 fr2 = new Form2();
                fr2.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
