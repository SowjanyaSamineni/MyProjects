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
            int studentid = InsertStudentDetails();
            InsertAdmisssionDetails(studentid);
        }

        private int InsertStudentDetails()
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
            con.Close();
            int studentid;
            studentid = Convert.ToInt32(datatable.Rows[0][0]);
            return studentid;
        }
        private void InsertAdmisssionDetails(int studentid)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("insert into ADMISSION_TABLE values('" + studentid + "','" + txtTCno.Text + "','" + cmbPreviousGrade.SelectedValue+ "','" + txtPreInstitute.Text + "','" + txtPreAcdamicYear.Text + "','" + cmbAdmissionGrade.SelectedValue+ "','" + DateOfAdmission.Text + "','" + txtAcadamicYear.Text + "')", con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("new record inserted");
            con.Close();
        }
        private void StudentApplicationForm_Load(object sender, EventArgs e)
        {
            DataTable dt1 = GetGradesData();
            DisplayComboboxdata(dt1);
        }

        private void DisplayComboboxdata(DataTable dt1)
        {
            DataRow dataRow = dt1.NewRow();
            dataRow["ID"] = 0;
            dataRow["CODE"] = "Select";
            dt1.Rows.InsertAt(dataRow, 0);
            // dt1.Rows.Add(dataRow);
            cmbPreviousGrade.DataSource = dt1;         //the data table which contains data
            cmbPreviousGrade.DisplayMember = "CODE";  // column name that you need to display as text
            cmbPreviousGrade.ValueMember = "ID";     // column name which you want in SelectedValue
            DataTable dt2 = dt1.Copy();
            cmbAdmissionGrade.DataSource = dt2;
            cmbAdmissionGrade.DisplayMember = "CODE";
            cmbAdmissionGrade.ValueMember = "ID";
            con.Close();
        }

        private DataTable GetGradesData()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select  ID,CODE from GRADES_TABLE", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr);
            con.Close();
            return dt1;
        }

    }



}
