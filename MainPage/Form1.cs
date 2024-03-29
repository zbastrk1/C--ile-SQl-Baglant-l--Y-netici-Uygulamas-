using System.Data;
using System.Data.SqlClient;

namespace MainPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Form2 f2 = new Form2();
            // f2.Show();
            DateTime dt = DateTime.Now;

            labelTÝme.Text = dt.ToString();
            guna2ToggleYönetici.Checked = true;
            textBoxUser.PlaceholderText = "Kullanýcý Adý";
        }

        //Sql Sorgularý
        SqlConnection baglanti = new SqlConnection("Data Source = SERVERNAME; Initial Catalog= Sirket; Integrated Security=True");
        String query = ("Select * From Yönetim Where Yönetici_Password = @textpass AND Yönetici_id= @textid");
        String queryP = ("Select * From Personell Where Personel_pass = @textPersonel AND Personel_username= @textPuser");



        private void Form1_Load(object sender, EventArgs e)
        {
            //PERSONEL
            String user = textBoxUser.Text;
            String pass = textBoxPass.Text;
            //Yönetici
            String id = textBox3.Text;
            String text = textBoxPass.Text;
         
            textBoxUser.Focus();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {

            if (guna2ToggleYönetici.Checked == true)
            {
                String id = textBox3.Text;
                String text = textBoxPass.Text;
                SqlCommand command = new SqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@textpass", text);
                command.Parameters.AddWithValue("@textid", id);
                
                baglanti.Open();

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Yönetici Giriþi", "Patch Yazýlým",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 f2 = new Form2();
                    f2.Show();


                }
                else
                {
                    MessageBox.Show("// Kullanýcý adý mevcut deðil");
                }
                baglanti.Close();
            }
            else if (guna2ToggleYönetici.Checked == false)
            {
                String user = textBoxUser.Text;
                String pass = textBoxPass.Text;
                SqlCommand command = new SqlCommand(queryP, baglanti);
                command.Parameters.AddWithValue("@textPersonel", pass);
                command.Parameters.AddWithValue("@textPuser", user);

                baglanti.Open();

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("PERSONEL GÝRÝÞÝ ", "Patch Yazýlým");

                }
                else if (count < 0)
                {
                    MessageBox.Show("// Kullanýcý adý mevcut deðil");
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("EKSÝK YADA HATALI BÝLGÝ ", "Patch Yazýlým");

            }
            }
            catch (SqlException ex) {

                MessageBox.Show("SQL HATASI");

            }
            catch (Exception ex)
            {
                MessageBox.Show("HATASI");
            }


        }

        private void guna2ToggleYönetici_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleYönetici.Checked == true)
            {
               
                textBox3.Visible = true;
            }
            else
            {
                
                textBox3.Visible = false;

            }
        }


    }
}

