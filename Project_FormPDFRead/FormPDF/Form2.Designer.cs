namespace FormPDF
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPDFsave = new System.Windows.Forms.Button();
            this.txt_Notes = new System.Windows.Forms.RichTextBox();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Subject = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_Color = new System.Windows.Forms.Button();
            this.btn_Font = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.SuspendLayout();
            // 
            // btnPDFsave
            // 
            this.btnPDFsave.Location = new System.Drawing.Point(561, 763);
            this.btnPDFsave.Name = "btnPDFsave";
            this.btnPDFsave.Size = new System.Drawing.Size(246, 47);
            this.btnPDFsave.TabIndex = 0;
            this.btnPDFsave.Text = "Kaydet (PDF) ";
            this.btnPDFsave.UseVisualStyleBackColor = true;
            this.btnPDFsave.Click += new System.EventHandler(this.btnPDFsave_Click);
            // 
            // txt_Notes
            // 
            this.txt_Notes.Location = new System.Drawing.Point(15, 130);
            this.txt_Notes.Name = "txt_Notes";
            this.txt_Notes.Size = new System.Drawing.Size(1240, 622);
            this.txt_Notes.TabIndex = 1;
            this.txt_Notes.Text = "Note....";
            // 
            // txt_Title
            // 
            this.txt_Title.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Title.Location = new System.Drawing.Point(68, 30);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(364, 28);
            this.txt_Title.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Başlık :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Konu :";
            // 
            // txt_Subject
            // 
            this.txt_Subject.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Subject.Location = new System.Drawing.Point(531, 30);
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.Size = new System.Drawing.Size(721, 28);
            this.txt_Subject.TabIndex = 4;
            // 
            // btn_Color
            // 
            this.btn_Color.Location = new System.Drawing.Point(531, 71);
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.Size = new System.Drawing.Size(135, 37);
            this.btn_Color.TabIndex = 8;
            this.btn_Color.Text = "Yazı Rengi Seç";
            this.btn_Color.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Color.UseVisualStyleBackColor = true;
            this.btn_Color.Click += new System.EventHandler(this.btn_Color_Click);
            // 
            // btn_Font
            // 
            this.btn_Font.Location = new System.Drawing.Point(681, 71);
            this.btn_Font.Name = "btn_Font";
            this.btn_Font.Size = new System.Drawing.Size(135, 37);
            this.btn_Font.TabIndex = 9;
            this.btn_Font.Text = "Yazı Türü Seç";
            this.btn_Font.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_Font.UseVisualStyleBackColor = true;
            this.btn_Font.Click += new System.EventHandler(this.btn_Font_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 822);
            this.Controls.Add(this.btn_Font);
            this.Controls.Add(this.btn_Color);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Title);
            this.Controls.Add(this.txt_Notes);
            this.Controls.Add(this.btnPDFsave);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Not Oluştur";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPDFsave;
        private System.Windows.Forms.RichTextBox txt_Notes;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Subject;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_Color;
        private System.Windows.Forms.Button btn_Font;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}