using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Collections.Generic;


namespace CRUD_operations
{
    public partial class UsersInfo : Form
    {
        public UsersInfo()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=STEVE\SQLEXPRESS;Initial Catalog=Registeration;Integrated Security=True");
        public int UserId;
        public string Gender;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UsersInfo_Load(object sender, EventArgs e)
        {
            GetUsersRecord();
        }
        private void GetUsersRecord() { 
        
           
            SqlCommand cmd = new SqlCommand("SELECT*FROM tblUsers", con);
            DataTable dt=new DataTable();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            UserDataGridView.DataSource = dt;
        }

        private void Insert_Click(object sender, EventArgs e)

        {
            if (IsValid())
            {
               

                SqlCommand cmd = new SqlCommand("INSERT INTO tblUsers VALUES (@FirstName,@LastName,@DateOfBirth,@Age,@Gender,@PhoneNo,@Email,@Address,@State)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", textFirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", textLastname.Text);
                cmd.Parameters.AddWithValue("@DateofBirth",textDateOfBrith.Value);
                cmd.Parameters.AddWithValue("@Age", int.Parse(textAge.Text));
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", textPhoneno.Text);
                cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                cmd.Parameters.AddWithValue("@Address", textAddress.Text);
                cmd.Parameters.AddWithValue("@State", textState.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                
               
                con.Close();
                MessageBox.Show("new user data saved successfully","saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                GetUsersRecord();
            }

        }
        private bool IsValid()
        {
            if (textFirstname.Text==string.Empty)
            {
                MessageBox.Show("User First Name is required","failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            NewMethod();

        }

        private void NewMethod()

          
        {
            UserId = 0;
            textFirstname.Clear();
            textLastname.Clear();
       
            
            textAge.Clear();
          

            textPhoneno.Clear();
            textEmail.Clear();
            textAddress.Clear();
            textState.Clear();
        }

        private void UserDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserId =Convert.ToInt32(UserDataGridView.SelectedRows[0].Cells[0].Value);
            textFirstname.Text = UserDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textLastname.Text = UserDataGridView.SelectedRows[0].Cells[2].Value.ToString();
          
            textAge.Text = UserDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            Gender = UserDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textPhoneno.Text = UserDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            textEmail.Text = UserDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            textAddress.Text = UserDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            textState.Text = UserDataGridView.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (UserId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE  tblUsers SET FirstName= @FirstName,LastName=@LastName,DateOfBirth=@DateOfBirth,Age=@Age,Gender=@Gender,PhoneNo=@PhoneNo,Email=@Email,Address=@Address,State=@State  WHERE Id=@Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", textFirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", textLastname.Text);
                cmd.Parameters.AddWithValue("@DateofBirth",textDateOfBrith.Value);
                cmd.Parameters.AddWithValue("@Age", int.Parse(textAge.Text));
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@PhoneNo", textPhoneno.Text);
                cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                cmd.Parameters.AddWithValue("@Address", textAddress.Text);
                cmd.Parameters.AddWithValue("@State", textState.Text);
                cmd.Parameters.AddWithValue("@Id", this.UserId);

                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show(" user data updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUsersRecord();

            }
            else
            {
                MessageBox.Show("Select user data to update", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (UserId > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE  tblUsers WHERE Id=@Id", con);
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("@Id", this.UserId);

                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show(" user data deleted successfully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUsersRecord();
            }
            else
            {
                MessageBox.Show(" select user data to delete", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Reset_MouseHover(object sender, EventArgs e)
        {
            Reset.BackColor = Color.Green;
        }

        private void Reset_MouseLeave(object sender, EventArgs e)
        {
            Reset.BackColor= Color.White;
        }

        private void Delete_MouseHover(object sender, EventArgs e)
        {
            Delete.BackColor = Color.Green;
        }

        private void Delete_MouseLeave(object sender, EventArgs e)
        {
            Delete.BackColor = Color.White;
        }

        private void Update_MouseHover(object sender, EventArgs e)
        {
            Update.BackColor = Color.Green;
        }

        private void Update_MouseLeave(object sender, EventArgs e)
        {
            Update.BackColor = Color.White;
        }

        private void Insert_MouseHover(object sender, EventArgs e)
        {
            Insert.BackColor = Color.Green;

        }

        private void Insert_MouseLeave(object sender, EventArgs e)
        {
            Insert.BackColor = Color.White;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textDateOfBrith.CustomFormat = "dd/MM/yyyy";
            DateTime timeStart = Convert.ToDateTime(textDateOfBrith.Value);
            DateTime timeEnd = DateTime.Today;
            TimeSpan span=timeEnd.Subtract(timeStart);
            var daysTotal = span.TotalDays;
            var yearsTotal = Math.Truncate(daysTotal / 365);

            textAge.Text=Convert.ToString(yearsTotal);
        }

        private void textAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }
    }
}
