using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace MainPage
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            dateTimeİş.Value = DateTime.Now;
        }

        DataTable dt = new DataTable();
        SqlConnection baglanti = new SqlConnection("Data Source= SERVER NAME ; Initial Catalog=Sirket; Integrated Security=True");

        // String query = "Select * From Personell where Personel_Adı Add Like @textPersonel";

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();

            cmbCinsiyet.Items.Add("E");
            cmbCinsiyet.Items.Add("K");


            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From Birimler", baglanti);
            sqlDataAdapter.Fill(dt);

            comboBox1.ValueMember = "Birim_id";
            comboBox1.DisplayMember = "Birim_Ad";
            comboBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {


                // Birimde Çalışan, Personel Bilgilerini Görmek İçin. 
                string birimler = comboBox1.Text;
                string query = "SELECT * FROM Personell  JOIN Birimler  ON Birim_ID = Birim_id WHERE Birim_Ad = @birimler";
                SqlCommand sqlCommand = new SqlCommand(query, baglanti);
                sqlCommand.Parameters.AddWithValue("@birimler", birimler);

                baglanti.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);

                dataGridView1.DataSource = dt;


                sqlCommand = new SqlCommand("SELECT Personell.*, Birimler.Birim_Ad\r\nFROM Personell\r\nINNER JOIN Birimler ON Personell.Birim_ID = Birimler.birim_id;", baglanti);



            }
            baglanti.Close();
        }


        private void Arama_Click(object sender, EventArgs e)
        {
            // DATAGRİDVİEW DE ARAMA YAPMAK İÇİN..

            string aranan = textBox1.Text.Trim().ToUpper();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                dataGridView1.CurrentCell = cell;
                                dataGridView1.Focus();

                            }

                        }

                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        { //TİMER TETİKLENDİKTEN 5 SANİYE SONRA FORM 1' İ KAPATMAK İÇİN.
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 != null)
            {
                form1.Visible = false;
            }

            // Timer'ı durdur
            timer1.Stop();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Uygulamayı tamamen kapat
                Application.Exit();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Veriler 
            string personelK = personelKullanıcı.Text;
            string personelA = personelAd.Text;
            string birimId = birimID.Text;

            string Cinsiyet = cmbCinsiyet.Text;
            DateTime İşeBaşlama = dateTimeİş.Value;
            string ünvan = textUnvan.Text;
            //
            baglanti.Open();
            if (personelKullanıcı.Text != "" && personelAd.Text != "" && birimID.Text != "" && cmbCinsiyet.SelectedIndex != -1 && dateTimeİş.Value != null && textUnvan.Text != "")
            {


                String sqlQuery = "Insert into Personell(Personel_username,Personel_Adı,Birim_ID,Cinsiyet,[İşe Başlama Tarihi],Ünvan) values(@personelUsername,@personelAd,@birimId,@Cinsiyet,@İsebaslama,@Ünvan)";

                SqlCommand cmd = new SqlCommand(sqlQuery, baglanti);
                cmd.Parameters.AddWithValue("@personelUsername", personelK);

                cmd.Parameters.AddWithValue("@personelAd", personelA);
                cmd.Parameters.AddWithValue("@birimId", birimId);
                cmd.Parameters.AddWithValue("@Cinsiyet", Cinsiyet);
                cmd.Parameters.AddWithValue("@İseBaslama", İşeBaşlama);
                cmd.Parameters.AddWithValue("@Ünvan", ünvan);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Veriler Başarıyla Eklendi", "İNFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personelKullanıcı.Clear();
                personelAd.Clear();

                birimID.Clear();
                textUnvan.Clear();

            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Doldurunuz.", "EKSİK BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void birimID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //İNT Değer alacaklar için sadece rakam girdisi.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Sadece rakam girişi yapılabilir.", birimID, 0, -30, 2000);
            }
        }


        private void tabPage3_Enter(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Personell", baglanti);
            dataAdapter.Fill(dt);
            datagridKayıtGüncelle.DataSource = dt;

        }

        private void guna2TabControl1_Enter(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Personell", baglanti);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void buttonPersonel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Personell", baglanti);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable güncelle = ((DataTable)datagridKayıtGüncelle.DataSource).GetChanges();

            if (güncelle != null)
            {

                SqlDataAdapter da = new SqlDataAdapter("Select * From Personell", baglanti);
                new SqlCommandBuilder(da);
                da.Update(güncelle);
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < datagridKayıtGüncelle.SelectedRows.Count; i++)
            {
                baglanti.Open();
                // Seçili Satırı Silmek için
                SqlCommand komut = new SqlCommand("Delete From Personell where Personel_TC=" + datagridKayıtGüncelle.SelectedRows[i].Cells["Personel_TC"].Value.ToString(), baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                // Güncel Veri İçin.
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Personell", baglanti);
                dataAdapter.Fill(dt);
                datagridKayıtGüncelle.DataSource = dt;
            }
            baglanti.Close();
        }

        private void personelKullanıcı_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Sadece harf girişi yapılabilir.", personelKullanıcı, 0, -30, 2000);
            }
        }

        private void personelAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Sadece harf girişi yapılabilir.", personelAd, 0, -30, 2000);
            }
        }

      
    }
}
       
 

