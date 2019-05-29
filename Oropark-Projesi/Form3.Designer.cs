namespace Oropark_Projesi
{
    partial class Form3
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.kapatma_buttonu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.arac_bilgileri = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.arac_tip_ucret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.arac_tip = new System.Windows.Forms.TextBox();
            this.tip = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.arac_tip_guncelle = new System.Windows.Forms.Button();
            this.arac_tip_sil = new System.Windows.Forms.Button();
            this.arac_tip_kaydet = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.arac_bilgileri.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.panel5.Controls.Add(this.kapatma_buttonu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 26);
            this.panel5.TabIndex = 31;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel5_MouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel5_MouseMove);
            this.panel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel5_MouseUp);
            // 
            // kapatma_buttonu
            // 
            this.kapatma_buttonu.BackColor = System.Drawing.Color.Transparent;
            this.kapatma_buttonu.BackgroundImage = global::Oropark_Projesi.Properties.Resources.icons8_delete_50;
            this.kapatma_buttonu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.kapatma_buttonu.Dock = System.Windows.Forms.DockStyle.Right;
            this.kapatma_buttonu.FlatAppearance.BorderSize = 0;
            this.kapatma_buttonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kapatma_buttonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.kapatma_buttonu.ForeColor = System.Drawing.Color.White;
            this.kapatma_buttonu.Location = new System.Drawing.Point(533, 0);
            this.kapatma_buttonu.Name = "kapatma_buttonu";
            this.kapatma_buttonu.Size = new System.Drawing.Size(31, 26);
            this.kapatma_buttonu.TabIndex = 31;
            this.kapatma_buttonu.TabStop = false;
            this.kapatma_buttonu.UseVisualStyleBackColor = false;
            this.kapatma_buttonu.Click += new System.EventHandler(this.Kapatma_buttonu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(564, 115);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // arac_bilgileri
            // 
            this.arac_bilgileri.Controls.Add(this.label4);
            this.arac_bilgileri.Controls.Add(this.arac_tip_ucret);
            this.arac_bilgileri.Controls.Add(this.label3);
            this.arac_bilgileri.Controls.Add(this.arac_tip);
            this.arac_bilgileri.Location = new System.Drawing.Point(12, 52);
            this.arac_bilgileri.Name = "arac_bilgileri";
            this.arac_bilgileri.Size = new System.Drawing.Size(318, 123);
            this.arac_bilgileri.TabIndex = 33;
            this.arac_bilgileri.TabStop = false;
            this.arac_bilgileri.Text = "Araç Tip Bilgileri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(1, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipin Saatlik Ücreti";
            // 
            // arac_tip_ucret
            // 
            this.arac_tip_ucret.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arac_tip_ucret.Location = new System.Drawing.Point(147, 74);
            this.arac_tip_ucret.Name = "arac_tip_ucret";
            this.arac_tip_ucret.Size = new System.Drawing.Size(136, 26);
            this.arac_tip_ucret.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(47, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Araç Tip Adı";
            // 
            // arac_tip
            // 
            this.arac_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arac_tip.Location = new System.Drawing.Point(147, 33);
            this.arac_tip.Name = "arac_tip";
            this.arac_tip.Size = new System.Drawing.Size(136, 26);
            this.arac_tip.TabIndex = 1;
            // 
            // tip
            // 
            this.tip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.tip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tip.ForeColor = System.Drawing.SystemColors.Control;
            this.tip.Location = new System.Drawing.Point(336, 91);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(221, 132);
            this.tip.TabIndex = 35;
            this.tip.Text = "00";
            this.tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(336, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 33);
            this.panel3.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 33);
            this.label12.TabIndex = 1;
            this.label12.Text = "Güncel Tip Sayısı";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // arac_tip_guncelle
            // 
            this.arac_tip_guncelle.BackColor = System.Drawing.Color.Transparent;
            this.arac_tip_guncelle.BackgroundImage = global::Oropark_Projesi.Properties.Resources.icons8_refresh_filled_50;
            this.arac_tip_guncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.arac_tip_guncelle.FlatAppearance.BorderSize = 0;
            this.arac_tip_guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arac_tip_guncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.arac_tip_guncelle.ForeColor = System.Drawing.Color.White;
            this.arac_tip_guncelle.Location = new System.Drawing.Point(262, 188);
            this.arac_tip_guncelle.Name = "arac_tip_guncelle";
            this.arac_tip_guncelle.Size = new System.Drawing.Size(31, 35);
            this.arac_tip_guncelle.TabIndex = 36;
            this.arac_tip_guncelle.TabStop = false;
            this.arac_tip_guncelle.UseVisualStyleBackColor = false;
            this.arac_tip_guncelle.Click += new System.EventHandler(this.Arac_tip_guncelle_Click);
            // 
            // arac_tip_sil
            // 
            this.arac_tip_sil.BackColor = System.Drawing.Color.Transparent;
            this.arac_tip_sil.BackgroundImage = global::Oropark_Projesi.Properties.Resources.icons8_trash_filled_50;
            this.arac_tip_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.arac_tip_sil.FlatAppearance.BorderSize = 0;
            this.arac_tip_sil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arac_tip_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.arac_tip_sil.ForeColor = System.Drawing.Color.White;
            this.arac_tip_sil.Location = new System.Drawing.Point(299, 188);
            this.arac_tip_sil.Name = "arac_tip_sil";
            this.arac_tip_sil.Size = new System.Drawing.Size(31, 35);
            this.arac_tip_sil.TabIndex = 37;
            this.arac_tip_sil.TabStop = false;
            this.arac_tip_sil.UseVisualStyleBackColor = false;
            this.arac_tip_sil.Click += new System.EventHandler(this.Arac_tip_sil_Click);
            // 
            // arac_tip_kaydet
            // 
            this.arac_tip_kaydet.BackColor = System.Drawing.Color.YellowGreen;
            this.arac_tip_kaydet.FlatAppearance.BorderSize = 0;
            this.arac_tip_kaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arac_tip_kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.arac_tip_kaydet.ForeColor = System.Drawing.Color.White;
            this.arac_tip_kaydet.Location = new System.Drawing.Point(168, 188);
            this.arac_tip_kaydet.Name = "arac_tip_kaydet";
            this.arac_tip_kaydet.Size = new System.Drawing.Size(88, 35);
            this.arac_tip_kaydet.TabIndex = 38;
            this.arac_tip_kaydet.TabStop = false;
            this.arac_tip_kaydet.Text = "Kaydet";
            this.arac_tip_kaydet.UseVisualStyleBackColor = false;
            this.arac_tip_kaydet.Click += new System.EventHandler(this.Arac_tip_kaydet_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(564, 344);
            this.Controls.Add(this.arac_tip_guncelle);
            this.Controls.Add(this.arac_tip_sil);
            this.Controls.Add(this.arac_tip_kaydet);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.arac_bilgileri);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.arac_bilgileri.ResumeLayout(false);
            this.arac_bilgileri.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button kapatma_buttonu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox arac_bilgileri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox arac_tip_ucret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox arac_tip;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button arac_tip_guncelle;
        private System.Windows.Forms.Button arac_tip_sil;
        private System.Windows.Forms.Button arac_tip_kaydet;
    }
}