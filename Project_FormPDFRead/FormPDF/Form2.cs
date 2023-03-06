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
using AxAcroPDFLib;

namespace FormPDF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            txt_Notes.Click += Txt_Notes_Click;
        }

        int clickCount = 0; // GET Textbox click count

        /// <summary>
        /// this Method  run -> if one click on textbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Notes_Click(object sender, EventArgs e)
        {
            clickCount += 1;
            
            if (clickCount < 2) {

                txt_Notes.Clear();
            }
          
        }
        Color color;
      
        /// <summary>
        ///  CREATE PDF DOCUMENT CODE 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPDFsave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog svFile = new SaveFileDialog();
                svFile.Title = "PDF Dosyası Olarak Kaydet";
                svFile.Filter = "PDF Dosyaları (*.pdf) | *.pdf";
                if (svFile.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(svFile.FileName, FileMode.Create);
                    Document pdf = new Document();
                    PdfWriter.GetInstance(pdf, fs);
                    pdf.Open();
                    pdf.AddAuthor("PDF Program");
                    pdf.AddCreator("PDF Program");
                    pdf.AddTitle(txt_Title.Text);
                    pdf.AddSubject(txt_Subject.Text);
                    pdf.AddCreationDate();
                    BaseColor baseColor = new BaseColor(ColorSelect());
                      // BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,"CP1252",true);
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "CP1252", true);

                    iTextSharp.text.Font iFont = new iTextSharp.text.Font(baseFont, 25, iTextSharp.text.Font.BOLD, baseColor);
                    
                    Paragraph prg = new Paragraph(txt_Notes.Text, iFont);
                    pdf.Add(prg);
                    pdf.Close();
                    MessageBox.Show("İşlem Başarılı !");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata : "+ex.Message);
            }
        }
        
        private void btn_Color_Click(object sender, EventArgs e)
        {
            txt_Notes.ForeColor = ColorSelect();
        }

        // Save Color for apply on PDF Filr
        public  Color ColorSelect()
        {
            colorDialog1.ShowDialog();
            color= colorDialog1.Color;
            return color;
          
        }


        // Try Text Font Kint Settings
        private void btn_Font_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            txt_Notes.Font = fontDialog1.Font;
            MessageBox.Show("Yazı Türü Ayarlandı !!");

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
