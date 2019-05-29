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
    public partial class Form2 : Form
    {

        bool tasi = false;
        Point carpan = new Point(0, 0);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            zaman_birimi.SelectedIndex = 0;
            nakit_butonu.Checked = true;
            arac_tablosunu_goster.Checked = true;
            aracTipleriKutusunuDoldur();
            arac_tipleri.SelectedIndex = 0;
        }

        private void aracTipleriKutusunuDoldur()
        {
            arac_tipleri.Items.Clear();
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
            bag.Open();
            OleDbCommand kmt2 = new OleDbCommand("SELECT arac_tipi FROM aractipi", bag);
            OleDbDataReader oku = kmt2.ExecuteReader();
            while (oku.Read())
            {
                arac_tipleri.Items.Add(oku["arac_tipi"].ToString());
            }
            bag.Close();
        }

        private void Arac_tipleri_Click(object sender, EventArgs e)
        {
            aracTipleriKutusunuDoldur();
        }

        private void dataCagir()
        {
            string sorgu, baglanti;
            baglanti = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb";
            sorgu = "SELECT [aracID], [arac_marka], [arac_plaka], [arac_tipi], [zaman_bicimi], [sure], [tutar], [kk_no], [kk_skt], [kk_ccv] FROM arackira";
            OleDbConnection baglan = new OleDbConnection(baglanti);
            OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, baglan);
            baglan.Open();
            DataSet goster = new DataSet();
            getir.Fill(goster, "arackira");
            dataGridView1.DataSource = goster.Tables["arackira"];
            getir.Dispose();
            baglan.Close();
        }

        private void dataCagir2()
        {
            string sorgu, baglanti;
            baglanti = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb";
            sorgu = "SELECT [aracID], [musteri_adi], [musteri_soyad], [musteri_tcno], [musteri_telno] FROM musteritablo";
            OleDbConnection baglan = new OleDbConnection(baglanti);
            OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, baglan);
            baglan.Open();
            DataSet goster = new DataSet();
            getir.Fill(goster, "musteritablo");
            dataGridView1.DataSource = goster.Tables["musteritablo"];
            getir.Dispose();
            baglan.Close();
        }

        private void Nakit_butonu_CheckedChanged(object sender, EventArgs e)
        {
            if (nakit_butonu.Checked == true)
            {
                kredi_kartNo.ResetText();
                ccvNo.ResetText();
                kredi_kartTarih.ResetText();
                kredi_kartNo.Enabled = false;
                kredi_kartTarih.Enabled = false;
                ccvNo.Enabled = false;
            }
        }

        private void Kkarti_butonu_CheckedChanged(object sender, EventArgs e)
        {
            kredi_kartNo.Enabled = true;
            kredi_kartTarih.Enabled = true;
            ccvNo.Enabled = true;
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

        private void Sure_TextChanged(object sender, EventArgs e)
        {

            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");

            if (zaman_birimi.Text == "Saat")
            {

                if (sure.Text == "")
                {
                    tutar.Text = "₺ 00";
                    return;
                }

                int suree = Convert.ToInt32(sure.Text.Trim());
                int arac_tip_ucret = 0;
                int son_fiyat = 0;
                bag.Open();
                OleDbCommand kmt4 = new OleDbCommand("SELECT arac_tipi_saat_ucreti FROM aractipi WHERE [arac_tipi]=@arac_tipi", bag);
                kmt4.Parameters.AddWithValue("@arac_tipi", arac_tipleri.Text);
                OleDbDataReader oku2 = kmt4.ExecuteReader();
                while (oku2.Read())
                {
                    string okunan = oku2["arac_tipi_saat_ucreti"].ToString();
                    arac_tip_ucret = Convert.ToInt32(okunan.Substring(okunan.LastIndexOf(' ')).Trim());
                }
                bag.Close();

                Console.Write(arac_tip_ucret);
                son_fiyat = suree * arac_tip_ucret;
                if (son_fiyat < 10)
                {
                    tutar.Font = new Font("Microsoft Sans Serif", 72, FontStyle.Regular);
                    tutar.Text = "₺ 0" + Convert.ToString(son_fiyat);
                }
                else if (son_fiyat > 99)
                {
                    tutar.Font = new Font("Microsoft Sans Serif", 62, FontStyle.Regular);
                    tutar.Text = "₺ " + Convert.ToString(son_fiyat);
                }
                else
                {
                    tutar.Text = "₺ " + Convert.ToString(son_fiyat);
                }

            }
            else if (zaman_birimi.Text == "Gün")
            {
                if (sure.Text == "")
                {
                    tutar.Text = "₺ 00";
                    return;
                }

                int suree = Convert.ToInt32(sure.Text.Trim());
                int arac_tip_ucret = 0;
                int son_fiyat = 0;
                bag.Open();
                OleDbCommand kmt4 = new OleDbCommand("SELECT arac_tipi_saat_ucreti FROM aractipi WHERE [arac_tipi]=@arac_tipi", bag);
                kmt4.Parameters.AddWithValue("@arac_tipi", arac_tipleri.Text);
                OleDbDataReader oku2 = kmt4.ExecuteReader();
                while (oku2.Read())
                {
                    string okunan = oku2["arac_tipi_saat_ucreti"].ToString();
                    arac_tip_ucret = Convert.ToInt32(okunan.Substring(okunan.LastIndexOf(' ')).Trim());
                }
                bag.Close();

                Console.Write(arac_tip_ucret);
                suree *= 24;
                son_fiyat = suree * arac_tip_ucret;
                if (son_fiyat < 10)
                {
                    tutar.Font = new Font("Microsoft Sans Serif", 72, FontStyle.Regular);
                    tutar.Text = "₺ 0" + Convert.ToString(son_fiyat);
                }
                else if (son_fiyat > 99)
                {
                    tutar.Font = new Font("Microsoft Sans Serif", 62, FontStyle.Regular);
                    tutar.Text = "₺ " + Convert.ToString(son_fiyat);
                }
                else
                {
                    tutar.Text = "₺ " + Convert.ToString(son_fiyat);
                }
            }
            else
            {
                MessageBox.Show("Zaman birimi hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void Arac_kaydet_Click(object sender, EventArgs e)
        {

            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");

            if (kredi_kartNo.Enabled == false && kredi_kartTarih.Enabled == false && ccvNo.Enabled == false)
            {
                if (arac_marka.Text.Trim() == "" || arac_plaka.Text.Trim() == "" || arac_tipleri.Text.Trim() == "" || zaman_birimi.Text.Trim() == "" || sure.Text.Trim() == "" || musteri_ad.Text.Trim() == "" || musteri_soyad.Text.Trim() == "" || musteri_tcno.Text.Trim() == "" || musteri_telno.Text.Trim() == "")
                {
                    MessageBox.Show("Bilgiler boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (arac_marka.Text.Trim() == "" || arac_plaka.Text.Trim() == "" || arac_tipleri.Text.Trim() == "" || zaman_birimi.Text.Trim() == "" || sure.Text.Trim() == "" || kredi_kartNo.Text.Trim() == "" || kredi_kartTarih.Text.Trim() == "" || ccvNo.Text.Trim() == "" || musteri_ad.Text.Trim() == "" || musteri_soyad.Text.Trim() == "" || musteri_tcno.Text.Trim() == "" || musteri_telno.Text.Trim() == "")
                {
                    MessageBox.Show("Bilgiler boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bag.Open();
            OleDbCommand kmt = new OleDbCommand("INSERT INTO arackira ([arac_marka], [arac_plaka], [arac_tipi], [zaman_bicimi], [sure], [tutar], [kk_no], [kk_skt], [kk_ccv]) VALUES (@arac_marka, @arac_plaka, @arac_tipi, @zaman_bicimi, @sure, @tutar, @kk_no, @kk_skt, @kk_ccv)", bag);
            kmt.Parameters.AddWithValue("@arac_marka", arac_marka.Text.Trim());
            kmt.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
            kmt.Parameters.AddWithValue("@arac_tipi", arac_tipleri.Text.Trim());
            kmt.Parameters.AddWithValue("@zaman_bicimi", zaman_birimi.Text.Trim());
            kmt.Parameters.AddWithValue("@sure", sure.Text.Trim());
            kmt.Parameters.AddWithValue("@tutar", tutar.Text.Trim());
            if (nakit_butonu.Checked == true)
            {
                kmt.Parameters.AddWithValue("@kk_no", "Nakit Ödendi");
                kmt.Parameters.AddWithValue("@kk_skt", "Nakit Ödendi");
                kmt.Parameters.AddWithValue("@kk_ccv", "Nakit Ödendi");
            }

            if (kkarti_butonu.Checked == true)
            {
                kmt.Parameters.AddWithValue("@kk_no", kredi_kartNo.Text.Trim());
                kmt.Parameters.AddWithValue("@kk_skt", kredi_kartTarih.Text.Trim());
                kmt.Parameters.AddWithValue("@kk_ccv", ccvNo.Text.Trim());
            }
            kmt.ExecuteNonQuery();
            bag.Close();

            string plaka = "";
            bag.Open();
            OleDbCommand kmt2 = new OleDbCommand("SELECT aracID FROM aracKira WHERE [arac_plaka] = @arac_plaka", bag);
            kmt2.Parameters.AddWithValue("arac_plaka", arac_plaka.Text.Trim());
            OleDbDataReader oku = kmt2.ExecuteReader();
            while (oku.Read())
            {
                plaka = oku["aracID"].ToString();
            }
            bag.Close();

            bag.Open();
            OleDbCommand kmt3 = new OleDbCommand("INSERT INTO musteritablo ([aracID] ,[musteri_adi], [musteri_soyad], [musteri_tcno], [musteri_telno]) VALUES (@aracID, @musteri_adi, @musteri_soyad, @musteri_tcno, @musteri_telno)", bag);
            kmt3.Parameters.AddWithValue("@aracID", plaka.Trim());
            kmt3.Parameters.AddWithValue("@musteri_adi", musteri_ad.Text.Trim());
            kmt3.Parameters.AddWithValue("@musteri_soyad", musteri_soyad.Text.Trim());
            kmt3.Parameters.AddWithValue("@musteri_tcno", musteri_tcno.Text.Trim());
            kmt3.Parameters.AddWithValue("@musteri_telno", musteri_telno.Text.Trim());
            kmt3.ExecuteNonQuery();
            MessageBox.Show("Araç ekleme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bag.Close();

            dataCagir();

            arac_marka.ResetText();
            arac_plaka.ResetText();
            arac_tipleri.SelectedIndex = 0;

            musteri_ad.ResetText();
            musteri_soyad.ResetText();
            musteri_tcno.ResetText();
            musteri_telno.ResetText();

            zaman_birimi.SelectedIndex = 0;
            sure.ResetText();

            if (kkarti_butonu.Checked == true)
            {
                kredi_kartNo.ResetText();
                kredi_kartTarih.ResetText();
                ccvNo.ResetText();
            }
        }

        private void Arac_guncelle_Click(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");

            string kredi_karti = "";
            bag.Open();
            OleDbCommand kmt2 = new OleDbCommand("SELECT kk_no FROM arackira WHERE [arac_plaka]=@arac_plaka", bag);
            kmt2.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
            OleDbDataReader oku = kmt2.ExecuteReader();
            while (oku.Read())
            {
                kredi_karti = oku["kk_no"].ToString();
            }
            bag.Close();

            if(kredi_karti == "Nakit Ödendi")
            {
                nakit_butonu.Checked = true;
                kkarti_butonu.Checked = false;
            }
            else
            {
                kkarti_butonu.Checked = true;
                nakit_butonu.Checked = false;
            }

            string aracID = "";
            bag.Open();
            OleDbCommand kmt3 = new OleDbCommand("SELECT aracID FROM arackira WHERE [arac_plaka] = @arac_plaka", bag);
            kmt3.Parameters.AddWithValue("arac_plaka", arac_plaka.Text.Trim());
            OleDbDataReader oku2 = kmt3.ExecuteReader();
            while (oku2.Read())
            {
                aracID = oku2["aracID"].ToString();
            }
            bag.Close();

            bag.Open();
            OleDbCommand gncl = new OleDbCommand("UPDATE arackira SET [arac_marka]=@arac_marka, [arac_plaka]=@arac_plaka, [arac_tipi]=@arac_tipi, [zaman_bicimi]=@zaman_bicimi, [sure]=@sure, [tutar]=@tutar, [kk_no]=@kk_no, [kk_skt]=@kk_skt, [kk_ccv]=@kk_ccv WHERE [arac_plaka]=@arac_plaka", bag);
            gncl.Parameters.AddWithValue("@arac_marka", arac_marka.Text.Trim());
            gncl.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
            gncl.Parameters.AddWithValue("arac_tipi", arac_tipleri.Text.Trim());
            gncl.Parameters.AddWithValue("@zaman_bicimi", zaman_birimi.Text.Trim());
            gncl.Parameters.AddWithValue("@sure", sure.Text.Trim());
            gncl.Parameters.AddWithValue("@tutar", tutar.Text.Trim());
            if(kredi_karti == "Nakit Ödendi")
            {
                gncl.Parameters.AddWithValue("@kk_no", "Nakit Ödendi");
                gncl.Parameters.AddWithValue("@kk_skt", "Nakit Ödendi");
                gncl.Parameters.AddWithValue("@kk_ccv", "Nakit Ödendi");
            }
            else
            {
                gncl.Parameters.AddWithValue("@kk_no", kredi_kartNo.Text.Trim());
                gncl.Parameters.AddWithValue("@kk_skt", kredi_kartTarih.Text.Trim());
                gncl.Parameters.AddWithValue("@kk_ccv", ccvNo.Text.Trim());
            }
            gncl.ExecuteNonQuery();
            bag.Close();

            bag.Open();
            OleDbCommand gncl2 = new OleDbCommand("UPDATE musteritablo SET [musteri_adi]=@musteri_adi, [musteri_soyad]=@musteri_soyad, [musteri_tcno]=@musteri_tcno, [musteri_telno]=@musteri_telno WHERE [aracID]=@aracID", bag);
            gncl2.Parameters.AddWithValue("@aracID", aracID);
            gncl2.Parameters.AddWithValue("@musteri_adi", arac_marka.Text.Trim());
            gncl2.Parameters.AddWithValue("@musteri_soyad", arac_plaka.Text.Trim());
            gncl2.Parameters.AddWithValue("@musteri_tcno", zaman_birimi.Text.Trim());
            gncl2.Parameters.AddWithValue("@musteri_telno", sure.Text.Trim());
            gncl2.ExecuteNonQuery();
            MessageBox.Show("Araç güncelleme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bag.Close();

            if(arac_tablosunu_goster.Checked == true)
            {
                dataCagir();
            }

            if(musteri_tablosunu_goster.Checked == true)
            {
                dataCagir2();
            }

            arac_marka.ResetText();
            arac_plaka.ResetText();
            arac_tipleri.SelectedIndex = 0;

            musteri_ad.ResetText();
            musteri_soyad.ResetText();
            musteri_tcno.ResetText();
            musteri_telno.ResetText();

            zaman_birimi.SelectedIndex = 0;
            sure.ResetText();

            if (kkarti_butonu.Checked == true)
            {
                kredi_kartNo.ResetText();
                kredi_kartTarih.ResetText();
                ccvNo.ResetText();
            }
        }

        private void Arac_sil_Click(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");

            string aracID = "";
            bag.Open();
            OleDbCommand kmt = new OleDbCommand("SELECT aracID FROM arackira WHERE [arac_plaka] = @arac_plaka", bag);
            kmt.Parameters.AddWithValue("arac_plaka", arac_plaka.Text.Trim());
            OleDbDataReader oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                aracID = oku["aracID"].ToString();
            }
            bag.Close();

            bag.Open();
            OleDbCommand sil = new OleDbCommand("DELETE FROM arackira WHERE [arac_plaka]=@arac_plaka", bag);
            sil.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
            sil.ExecuteNonQuery();
            bag.Close();

            bag.Open();
            OleDbCommand sil2 = new OleDbCommand("DELETE FROM musteritablo WHERE [aracID]=@aracID", bag);
            sil2.Parameters.AddWithValue("@aracID", aracID);
            sil2.ExecuteNonQuery();
            MessageBox.Show("Araç silme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bag.Close();

            if (arac_tablosunu_goster.Checked == true)
            {
                dataCagir();
            }

            if (musteri_tablosunu_goster.Checked == true)
            {
                dataCagir2();
            }

            arac_marka.ResetText();
            arac_plaka.ResetText();
            arac_tipleri.SelectedIndex = 0;

            musteri_ad.ResetText();
            musteri_soyad.ResetText();
            musteri_tcno.ResetText();
            musteri_telno.ResetText();

            zaman_birimi.SelectedIndex = 0;
            sure.ResetText();

            if (kkarti_butonu.Checked == true)
            {
                kredi_kartNo.ResetText();
                kredi_kartTarih.ResetText();
                ccvNo.ResetText();
            }
        }

        private void Arac_tipi_ekle_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(arac_tablosunu_goster.Checked == true)
            {
                int sec = dataGridView1.SelectedCells[0].RowIndex;

                OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
                bag.Open();
                OleDbCommand kmt = new OleDbCommand("SELECT [musteri_adi], [musteri_soyad], [musteri_tcno], [musteri_telno] FROM musteritablo WHERE [aracID]=@aracID", bag);
                kmt.Parameters.AddWithValue("@aracID", dataGridView1.Rows[sec].Cells[0].Value.ToString());
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    musteri_ad.Text = oku["musteri_adi"].ToString();
                    musteri_soyad.Text = oku["musteri_soyad"].ToString();
                    musteri_tcno.Text = oku["musteri_tcno"].ToString();
                    musteri_telno.Text = oku["musteri_telno"].ToString();
                }
                bag.Close();

                arac_marka.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
                arac_plaka.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
                arac_tipleri.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
                zaman_birimi.Text= dataGridView1.Rows[sec].Cells[4].Value.ToString();
                sure.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
                tutar.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
                kredi_kartNo.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
                kredi_kartTarih.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
                ccvNo.Text = dataGridView1.Rows[sec].Cells[9].Value.ToString();
            }

            if(musteri_tablosunu_goster.Checked == true)
            {
                int sec = dataGridView1.SelectedCells[0].RowIndex;

                OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otopark.accdb");
                bag.Open();
                OleDbCommand kmt = new OleDbCommand("SELECT [aracID], [arac_marka], [arac_plaka], [arac_tipi], [zaman_bicimi], [sure], [tutar], [kk_no], [kk_skt], [kk_ccv] FROM arackira WHERE [aracID]=@aracID", bag);
                kmt.Parameters.AddWithValue("@aracID", dataGridView1.Rows[sec].Cells[0].Value.ToString());
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    arac_marka.Text = oku["arac_marka"].ToString();
                    arac_plaka.Text = oku["arac_plaka"].ToString();
                    arac_tipleri.Text = oku["arac_tipi"].ToString();
                    zaman_birimi.Text = oku["zaman_bicimi"].ToString();
                    sure.Text = oku["sure"].ToString();
                    tutar.Text = oku["tutar"].ToString();
                    kredi_kartNo.Text = oku["kk_no"].ToString();
                    kredi_kartTarih.Text = oku["kk_skt"].ToString();
                    ccvNo.Text = oku["kk_ccv"].ToString();
                }
                bag.Close();

                musteri_ad.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
                musteri_soyad.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
                musteri_tcno.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
                musteri_telno.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
                
            }

        }

        private void Arac_tablosunu_goster_CheckedChanged(object sender, EventArgs e)
        {
            dataCagir();
        }

        private void Musteri_tablosunu_goster_CheckedChanged(object sender, EventArgs e)
        {
            dataCagir2();
        }
    }
}
