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
    public partial class Form3 : Form
    {

        bool tasi = false;
        Point carpan = new Point(0, 0);

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataCagir();
            guncelAracTipSayisi();
        }

        private void dataCagir()
        {
            string sorgu, baglanti;
            baglanti = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb";
            sorgu = "SELECT [arac_tipi], [arac_tipi_saat_ucreti] FROM aractipi";
            OleDbConnection baglan = new OleDbConnection(baglanti);
            OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, baglan);
            baglan.Open();
            DataSet goster = new DataSet();
            getir.Fill(goster, "aractipi");
            dataGridView1.DataSource = goster.Tables["aractipi"];
            getir.Dispose();
            baglan.Close();
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

        private void Kapatma_buttonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Arac_tip_kaydet_Click(object sender, EventArgs e)
        {

            if(arac_tip.Text.Trim() == "" || arac_tip_ucret.Text.Trim() == "")
            {
                MessageBox.Show("Bilgiler boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(arac_tip_ucret.Text.IndexOf(' ') >= 1)
            {
                MessageBox.Show("Lütfen saatlik ücret den sonra boşluk bırakmayınız veya birim eklemeyiniz. Para birimi oromatik olarak eklenir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
            bag.Open();
            OleDbCommand kmt = new OleDbCommand("INSERT INTO aractipi ([arac_tipi], [arac_tipi_saat_ucreti]) VALUES (@arac_tipi, @arac_tipi_saat_ucreti)", bag);
            kmt.Parameters.AddWithValue("@arac_tipi", arac_tip.Text.Trim());
            kmt.Parameters.AddWithValue("@arac_tipi_saat_ucreti", "₺ " + arac_tip_ucret.Text.Trim());
            kmt.ExecuteNonQuery();
            bag.Close();

            MessageBox.Show("Araç tipi ekleme başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataCagir();
            guncelAracTipSayisi();

            arac_tip.ResetText();
            arac_tip_ucret.ResetText();
        }

        private void Arac_tip_guncelle_Click(object sender, EventArgs e)
        {
            if (arac_tip.Text.Trim() == "" || arac_tip_ucret.Text.Trim() == "")
            {
                MessageBox.Show("Bilgiler boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
            bag.Open();
            OleDbCommand gncl = new OleDbCommand("UPDATE aractipi SET [arac_tipi]=@arac_tipi, [arac_tipi_saat_ucreti]=@arac_tipi_saat_ucreti WHERE [arac_tipi]=@arac_tipi", bag);
            gncl.Parameters.AddWithValue("@arac_tipi", arac_tip.Text.Trim());
            gncl.Parameters.AddWithValue("@arac_tipi_saat_ucreti", arac_tip_ucret.Text.Trim());
            gncl.ExecuteNonQuery();
            bag.Close();

            MessageBox.Show("Araç tipi güncelleme başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataCagir();
            guncelAracTipSayisi();

            arac_tip.ResetText();
            arac_tip_ucret.ResetText();
        }

        private void Arac_tip_sil_Click(object sender, EventArgs e)
        {
            if (arac_tip.Text.Trim() == "" || arac_tip_ucret.Text.Trim() == "")
            {
                MessageBox.Show("Bilgiler boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
            bag.Open();
            OleDbCommand sil = new OleDbCommand("DELETE FROM aractipi WHERE [arac_tipi]=@arac_tipi", bag);
            sil.Parameters.AddWithValue("@arac_tipi", arac_tip.Text.Trim());
            sil.ExecuteNonQuery();
            sil.Dispose();
            bag.Close();

            MessageBox.Show("Araç tipi silme başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataCagir();
            guncelAracTipSayisi();

            arac_tip.ResetText();
            arac_tip_ucret.ResetText();
        }

        private void guncelAracTipSayisi()
        {
            int tipSay = 0;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
            bag.Open();
            OleDbCommand kmt2 = new OleDbCommand("SELECT arac_tipID FROM aractipi", bag);
            OleDbDataReader oku = kmt2.ExecuteReader();
            while (oku.Read())
            {
                tipSay++;
            }
            bag.Close();
            if(tipSay < 10)
            {
                tip.Text = "0" + string.Concat(tipSay);
            }
            else
            {
                tip.Text = string.Concat(tipSay);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            arac_tip.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            arac_tip_ucret.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
        }
    }
}
