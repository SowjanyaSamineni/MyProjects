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
    public partial class Category1 : Form
    {
        public Category1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLMANAGEMENTSYSTEM");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CATEGORY(DESCRIPTION)values('" + txtCategory.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("one record inserted");
            getCategoryData();
        }

        private DataTable getCategoryData()
        {
             con.Open();
             SqlCommand cmd= new SqlCommand("select * from  Category",con);
             SqlDataReader dr;
             dr=cmd.ExecuteReader();
             DataTable dt1 = new DataTable();
             dt1.Load(dr);
             con.Close();
             return dt1;
        }

        private void Category1_Load(object sender, EventArgs e)
        {
            DataTable dt1;
            dt1 = getCategoryData();
            dataGridView1.DataSource = dt1;
        
        }
    }
}
