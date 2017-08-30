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
    public partial class StudentApplicationForm : Form
    {
        public StudentApplicationForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLMANAGEMENTSYSTEM");
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT(REG_NUMBER,FIRSTNAME,LASTNAME,AADHARNUMBER)VALUES('" + txtRegno.Text + "','" + txtFname.Text + "','" + txtLname.Text + "','" + txtAadharno.Text + "')", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY()", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(dr);
            int studentid;
            studentid = Convert.ToInt32(datatable.Rows[0][0]);
            MessageBox.Show("inserted one record successfully");
            SqlCommand cmd2 = new SqlCommand("insert into ADMISSIONS(Admission_no,Student_Id,Admission_GradeId)values('" + txtAdmissionno.Text + "','" + studentid + "','" + cmbpregid + "')", con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        private void StudentApplicationForm_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select  ID,CODE from GRADES", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cmbpregid.DataSource = dt;
            cmbpregid.DisplayMember = "CODE";
            cmbpregid.ValueMember = "ID";
            cmdgradeadmission.DataSource = dt;
            cmdgradeadmission.DisplayMember = "CODE";
            cmdgradeadmission.ValueMember = "ID";
        }

        private void cmbpregid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
