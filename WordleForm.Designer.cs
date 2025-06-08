namespace KelimeOyunuProje
{
    partial class WordleForm
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
            this.txtTahmin = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnTahminEt = new System.Windows.Forms.Button();
            this.btnYeniOyun = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDurum2 = new System.Windows.Forms.Label();
            this.geriwordle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(39, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wordle";
            // 
            // txtTahmin
            // 
            this.txtTahmin.Location = new System.Drawing.Point(359, 233);
            this.txtTahmin.Name = "txtTahmin";
            this.txtTahmin.Size = new System.Drawing.Size(108, 26);
            this.txtTahmin.TabIndex = 2;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label27.Location = new System.Drawing.Point(354, 186);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(113, 25);
            this.label27.TabIndex = 3;
            this.label27.Text = "Kelime gir:";
            // 
            // btnTahminEt
            // 
            this.btnTahminEt.Location = new System.Drawing.Point(359, 281);
            this.btnTahminEt.Name = "btnTahminEt";
            this.btnTahminEt.Size = new System.Drawing.Size(108, 34);
            this.btnTahminEt.TabIndex = 4;
            this.btnTahminEt.Text = "Tahmin et";
            this.btnTahminEt.UseVisualStyleBackColor = true;
            this.btnTahminEt.Click += new System.EventHandler(this.btnTahminEt_Click);
            // 
            // btnYeniOyun
            // 
            this.btnYeniOyun.Location = new System.Drawing.Point(359, 23);
            this.btnYeniOyun.Name = "btnYeniOyun";
            this.btnYeniOyun.Size = new System.Drawing.Size(108, 34);
            this.btnYeniOyun.TabIndex = 5;
            this.btnYeniOyun.Text = "Yeni Oyun";
            this.btnYeniOyun.UseVisualStyleBackColor = true;
            this.btnYeniOyun.Click += new System.EventHandler(this.btnYeniOyun_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(416, 281);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 20);
            this.lblDurum.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 299);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblDurum2
            // 
            this.lblDurum2.AutoSize = true;
            this.lblDurum2.Location = new System.Drawing.Point(84, 380);
            this.lblDurum2.Name = "lblDurum2";
            this.lblDurum2.Size = new System.Drawing.Size(54, 20);
            this.lblDurum2.TabIndex = 8;
            this.lblDurum2.Text = "durum";
            // 
            // geriwordle
            // 
            this.geriwordle.Location = new System.Drawing.Point(359, 376);
            this.geriwordle.Name = "geriwordle";
            this.geriwordle.Size = new System.Drawing.Size(108, 28);
            this.geriwordle.TabIndex = 9;
            this.geriwordle.Text = "Ana Menü";
            this.geriwordle.UseVisualStyleBackColor = true;
            this.geriwordle.Click += new System.EventHandler(this.geriwordle_Click);
            // 
            // WordleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(499, 409);
            this.Controls.Add(this.geriwordle);
            this.Controls.Add(this.lblDurum2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.btnYeniOyun);
            this.Controls.Add(this.btnTahminEt);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtTahmin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WordleForm";
            this.Text = "WordleForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTahmin;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnTahminEt;
        private System.Windows.Forms.Button btnYeniOyun;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDurum2;
        private System.Windows.Forms.Button geriwordle;
    }
}