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
    public partial class Grades : Form
    {
        public Grades()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLMANAGEMENTSYSTEM");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into GRADES(CODE,NAME)VALUES('" + txtGcode.Text + "','" + txtGname.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("inserted successfully");
        }

        private void Grades_Load(object sender, EventArgs e)
        {
            showGradesData();
        }

        private void showGradesData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from GRADES", con);
            //cmd.ExecuteReader();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(dr);
            dataGridView1.DataSource = datatable;
            con.Close();
        }
    }
}