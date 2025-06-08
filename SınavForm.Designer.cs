namespace KelimeOyunuProje
{
    partial class SınavForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSoruNo = new System.Windows.Forms.Label();
            this.lblSoruYanlis = new System.Windows.Forms.Label();
            this.lblSoruDogru1 = new System.Windows.Forms.Label();
            this.lblSoru = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gerisınav = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kelime Sınavı";
            // 
            // lblSoruNo
            // 
            this.lblSoruNo.AutoSize = true;
            this.lblSoruNo.Location = new System.Drawing.Point(340, 132);
            this.lblSoruNo.Name = "lblSoruNo";
            this.lblSoruNo.Size = new System.Drawing.Size(114, 20);
            this.lblSoruNo.TabIndex = 1;
            this.lblSoruNo.Text = "Soru Numarası";
            // 
            // lblSoruYanlis
            // 
            this.lblSoruYanlis.AutoSize = true;
            this.lblSoruYanlis.Location = new System.Drawing.Point(340, 194);
            this.lblSoruYanlis.Name = "lblSoruYanlis";
            this.lblSoruYanlis.Size = new System.Drawing.Size(97, 20);
            this.lblSoruYanlis.TabIndex = 2;
            this.lblSoruYanlis.Text = "Yanlış Sayısı";
            // 
            // lblSoruDogru1
            // 
            this.lblSoruDogru1.AutoSize = true;
            this.lblSoruDogru1.Location = new System.Drawing.Point(340, 225);
            this.lblSoruDogru1.Name = "lblSoruDogru1";
            this.lblSoruDogru1.Size = new System.Drawing.Size(98, 20);
            this.lblSoruDogru1.TabIndex = 3;
            this.lblSoruDogru1.Text = "Doğru Sayısı";
            // 
            // lblSoru
            // 
            this.lblSoru.AutoSize = true;
            this.lblSoru.Location = new System.Drawing.Point(19, 327);
            this.lblSoru.Name = "lblSoru";
            this.lblSoru.Size = new System.Drawing.Size(105, 20);
            this.lblSoru.TabIndex = 4;
            this.lblSoru.Text = "Örnek Cümle:";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(12, 383);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(112, 54);
            this.btnA.TabIndex = 5;
            this.btnA.Text = "btnA";
            this.btnA.UseVisualStyleBackColor = true;
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(130, 383);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(112, 54);
            this.btnB.TabIndex = 6;
            this.btnB.Text = "btnB";
            this.btnB.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(248, 383);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(112, 54);
            this.btnC.TabIndex = 7;
            this.btnC.Text = "btnC";
            this.btnC.UseVisualStyleBackColor = true;
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(366, 383);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(112, 54);
            this.btnD.TabIndex = 8;
            this.btnD.Text = "btnD";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 205);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Soru:  İlgili kelimeyi seçiniz";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gerisınav
            // 
            this.gerisınav.Location = new System.Drawing.Point(366, 13);
            this.gerisınav.Name = "gerisınav";
            this.gerisınav.Size = new System.Drawing.Size(103, 31);
            this.gerisınav.TabIndex = 11;
            this.gerisınav.Text = "Ana Menü";
            this.gerisınav.UseVisualStyleBackColor = true;
            this.gerisınav.Click += new System.EventHandler(this.gerisınav_Click);
            // 
            // SınavForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(489, 464);
            this.Controls.Add(this.gerisınav);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.lblSoru);
            this.Controls.Add(this.lblSoruDogru1);
            this.Controls.Add(this.lblSoruYanlis);
            this.Controls.Add(this.lblSoruNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SınavForm";
            this.Text = "SınavForm";
            this.Load += new System.EventHandler(this.SınavForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoruNo;
        private System.Windows.Forms.Label lblSoruYanlis;
        private System.Windows.Forms.Label lblSoruDogru1;
        private System.Windows.Forms.Label lblSoru;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gerisınav;
    }
}