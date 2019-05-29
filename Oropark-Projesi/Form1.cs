using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oropark_Projesi
{
    public partial class Form1 : Form
    {

        bool tasi = false;
        Point carpan = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Giris_butonu_Click(object sender, EventArgs e)
        {
            string kullanici_ad = null;
            string kullanici_sifr = null;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
            bag.Open();
            OleDbCommand kmt = new OleDbCommand("SELECT kullanici_adi, kullanici_sifre FROM giriskont", bag);
            OleDbDataReader oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                kullanici_ad = oku["kullanici_adi"].ToString();
                kullanici_sifr = oku["kullanici_sifre"].ToString();
            }
            bag.Close();

            if(kullanici_ad == kullanici_adi.Text && kullanici_sifr == kullanici_sifre.Text)
            {
                MessageBox.Show("Giriş başarılı", "Otopark", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void Kapatma_buttonu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (tasi)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.carpan.X, p.Y - this.carpan.Y);
            }
        }

        private void Panel5_MouseDown(object sender, MouseEventArgs e)
        {
            tasi = true;
            carpan = new Point(e.X, e.Y);
        }

        private void Panel5_MouseUp(object sender, MouseEventArgs e)
        {
            tasi = false;
        }
    }
}
