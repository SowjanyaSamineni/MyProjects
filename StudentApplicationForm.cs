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
        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLAPPLICATION");
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string gender;
            gender = rdbMale.Checked ? rdbMale.Text : rdbFemale.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into STUDENT_TABLE values ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + BirthDate.Text + "','" + gender + "','" + txtFatherName.Text + "','" + txtAddress.Text + "','" + txtMobileNo.Text + "','" + txtAadharno.Text + "')", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY()", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(dr);
            int studentid;
            studentid = Convert.ToInt32(datatable.Rows[0][0]);
            SqlCommand cmd2 = new SqlCommand("insert into ADMISSION_TABLE values('" + studentid + "','" + txtTCno.Text + "','" + cmbPreviousGrade.SelectedValue+ "','" + txtPreInstitute.Text + "','" + txtPreAcdamicYear.Text + "','" + cmbAdmissionGrade.SelectedIndex+ "','" + DateOfAdmission.Value + "','" + txtAcadamicYear.Text + "')", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("new record inserted");
        }

        //private void insertStudentData()
        //{
        //    string gender;
        //    gender = rdbMale.Checked ? rdbMale.Text : rdbFemale.Text;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("Insert into STUDENT_TABLE values ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + BirthDate.Text + "','" + gender + "','" + txtFatherName.Text + "','" + txtAddress.Text + "','" + txtMobileNo.Text + "','" + txtAadharno.Text + "')", con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    MessageBox.Show("one record inserted");
        //}

        //private void InsertAdmisssionData()
        //{
        //    con.Open();
        //    SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY()", con);
        //    SqlDataReader dr = cmd1.ExecuteReader();
        //    DataTable datatable = new DataTable();
        //    datatable.Load(dr);
        //    int studentid;
        //    studentid = Convert.ToInt32(datatable.Rows[0][0]);
        //    SqlCommand cmd2 = new SqlCommand("insert into ADMISSION_TABLE values('" + studentid + "','" + txtTCno.Text + "','" + cmbPreviousGrade.SelectedValue + "','" + txtPreInstitute.Text + "','" + txtPreAcdamicYear.Text + "','" + cmbAdmissionGrade.SelectedValue+ "','" + DateOfAdmission.Value + "','" + txtAcadamicYear.Text + "')", con);
        //    cmd2.ExecuteNonQuery();
        //    con.Close();
        //    MessageBox.Show("new record inserted");
        //}
        private void StudentApplicationForm_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select  ID,CODE from GRADES_TABLE", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr);
            DataRow dataRow = dt1.NewRow();
            dataRow["ID"] = 0;
            dataRow["CODE"] = "Select";
            dt1.Rows.InsertAt(dataRow, 0);
            // dt1.Rows.Add(dataRow);
            cmbPreviousGrade.DataSource = dt1;
            cmbPreviousGrade.DisplayMember = "CODE";
            cmbPreviousGrade.ValueMember = "ID";
            DataTable dt2 = dt1.Copy();
            cmbAdmissionGrade.DataSource = dt2;
            cmbAdmissionGrade.DisplayMember = "CODE";
            cmbAdmissionGrade.ValueMember = "ID";
            con.Close();
        }
    }
}
