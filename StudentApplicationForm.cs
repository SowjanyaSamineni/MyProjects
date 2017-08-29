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
            SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT(REG_NUMBER,FIRSTNAME,LASTNAME,AADHARNUMBER)VALUES('" +txtRegno.Text + "','" +txtFname.Text+ "','"+txtLname.Text+"','"+txtAadharno.Text+"')",con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY()",con);
            SqlDataReader dr;
            dr=cmd1.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(dr);
            int studentid;
            studentid=Convert.ToInt32(datatable.Rows[0][0]);
           // MessageBox.Show("inserted one record successfully");
           //SqlCommand cmd2 = new SqlCommand("INSERT INTO ADMISSIONS(Admission_no,Admission_GradeId,Previous_Tc_Number,Previous_GradeId,Previous_Institute,Previous_Acadamicyear)
            SqlCommand cmd2 = new SqlCommand("insert into ADMISSIONS(Admission_no,Student_Id,Admission_GradeId)values('" + txtAdmissionno.Text + "','"+studentid+"','" + txtAdmissionGrade.Text + "')", con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        private void txtGradeid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
