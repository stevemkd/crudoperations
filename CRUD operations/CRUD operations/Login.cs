using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_operations
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
        SqlConnection conn= new SqlConnection("Data Source=STEVE\\SQLEXPRESS;Initial Catalog=Registeration;Integrated Security=True");


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;

            username = textpassword.Text;
            password = textusername.Text;
            try
            {
                string query = "SELECT*FROM tblLoginData  WHERE username='" +textusername.Text + "' AND password='" + textpassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    username=textpassword.Text;
                    password=textusername.Text;

                    UsersInfo form1 = new UsersInfo();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid details","error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textpassword.Clear();
                    textusername.Clear();
                    textpassword.Focus();
                }
            }
            catch {
                MessageBox.Show("error");
            }
            finally { conn.Close(); }
        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SignIn form2 = new SignIn();
            form2.Show();
            this.Hide();
        }
    }
}
