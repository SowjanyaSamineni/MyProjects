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
namespace SchoolMgtSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLMANAGEMENTSYSTEM");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT(REG_NUMBER,FIRSTNAME,LASTNAME)VALUES('"+txtRegno.Text+"','"+txtFirstName.Text+"','"+txtLastName.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted");
        }
    }
}
