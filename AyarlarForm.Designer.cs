namespace KelimeOyunuProje
{
    partial class AyarlarForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBxQueCount = new System.Windows.Forms.ComboBox();
            this.Ayarları_Kaydet = new System.Windows.Forms.Button();
            this.geriayar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ayarlar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(24, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sınav Soru Sayısı :";
            // 
            // cmbBxQueCount
            // 
            this.cmbBxQueCount.FormattingEnabled = true;
            this.cmbBxQueCount.Location = new System.Drawing.Point(223, 117);
            this.cmbBxQueCount.Name = "cmbBxQueCount";
            this.cmbBxQueCount.Size = new System.Drawing.Size(89, 28);
            this.cmbBxQueCount.TabIndex = 2;
            // 
            // Ayarları_Kaydet
            // 
            this.Ayarları_Kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Ayarları_Kaydet.Location = new System.Drawing.Point(89, 188);
            this.Ayarları_Kaydet.Name = "Ayarları_Kaydet";
            this.Ayarları_Kaydet.Size = new System.Drawing.Size(169, 35);
            this.Ayarları_Kaydet.TabIndex = 3;
            this.Ayarları_Kaydet.Text = "Ayarları Kaydet";
            this.Ayarları_Kaydet.UseVisualStyleBackColor = true;
            this.Ayarları_Kaydet.Click += new System.EventHandler(this.Ayarları_Kaydet_Click);
            // 
            // geriayar
            // 
            this.geriayar.Location = new System.Drawing.Point(223, 13);
            this.geriayar.Name = "geriayar";
            this.geriayar.Size = new System.Drawing.Size(117, 28);
            this.geriayar.TabIndex = 4;
            this.geriayar.Text = "Ana Menü";
            this.geriayar.UseVisualStyleBackColor = true;
            this.geriayar.Click += new System.EventHandler(this.geriayar_Click);
            // 
            // AyarlarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(339, 262);
            this.Controls.Add(this.geriayar);
            this.Controls.Add(this.Ayarları_Kaydet);
            this.Controls.Add(this.cmbBxQueCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AyarlarForm";
            this.Text = "AyarlarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBxQueCount;
        private System.Windows.Forms.Button Ayarları_Kaydet;
        private System.Windows.Forms.Button geriayar;
    }
}