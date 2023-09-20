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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=STEVE\SQLEXPRESS;Initial Catalog=Registeration;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[tblLoginData]
           ([FirstName]
           ,[LastName]
           ,[Address]
           ,[Gender]
           ,[Email]
           ,[UserName]
           ,[Password])
     VALUES
           ('"+textfirstname.Text+"','"+textlastname.Text+"','"+textaddress.Text+"','"+textgender.Text+"','"+textemail.Text+"','"+textusername.Text+"','"+textpassword.Text+"')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register Successful");
            Login form1 = new Login();
            form1.Show();
            this.Hide();
        }
    }
}
