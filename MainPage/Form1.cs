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

            labelT�me.Text = dt.ToString();
            guna2ToggleY�netici.Checked = true;
            textBoxUser.PlaceholderText = "Kullan�c� Ad�";
        }

        //Sql Sorgular�
        SqlConnection baglanti = new SqlConnection("Data Source = SERVERNAME; Initial Catalog= Sirket; Integrated Security=True");
        String query = ("Select * From Y�netim Where Y�netici_Password = @textpass AND Y�netici_id= @textid");
        String queryP = ("Select * From Personell Where Personel_pass = @textPersonel AND Personel_username= @textPuser");



        private void Form1_Load(object sender, EventArgs e)
        {
            //PERSONEL
            String user = textBoxUser.Text;
            String pass = textBoxPass.Text;
            //Y�netici
            String id = textBox3.Text;
            String text = textBoxPass.Text;
         
            textBoxUser.Focus();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {

            if (guna2ToggleY�netici.Checked == true)
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
                    MessageBox.Show("Y�netici Giri�i", "Patch Yaz�l�m",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 f2 = new Form2();
                    f2.Show();


                }
                else
                {
                    MessageBox.Show("// Kullan�c� ad� mevcut de�il");
                }
                baglanti.Close();
            }
            else if (guna2ToggleY�netici.Checked == false)
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
                    MessageBox.Show("PERSONEL G�R��� ", "Patch Yaz�l�m");

                }
                else if (count < 0)
                {
                    MessageBox.Show("// Kullan�c� ad� mevcut de�il");
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("EKS�K YADA HATALI B�LG� ", "Patch Yaz�l�m");

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

        private void guna2ToggleY�netici_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleY�netici.Checked == true)
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

