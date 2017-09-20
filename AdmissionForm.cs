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
using DAL;

namespace SchoolMgtSystem
{
    public partial class AdmissionForm : Form
    {
        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLAPPLICATION");
        public int admissionid;
        public AdmissionForm()
        {
            InitializeComponent();
        }
        public AdmissionForm(int adminid)
        {
            admissionid = adminid;
            InitializeComponent();

        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            int studentid = InsertStudentDetails();
            InsertAdmisssionDetails(studentid);
            con.Close();
        }
        private int InsertStudentDetails()
        {
            string gender;
            gender = rdbMale.Checked ? rdbMale.Text : rdbFemale.Text;
            SqlCommand cmd = new SqlCommand("Insert into STUDENT_TABLE values ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + this.BirthDate.Value.Date + "','" + gender + "','" + txtFatherName.Text + "','" + txtAddress.Text + "','" + txtMobileNo.Text + "','" + txtAadharno.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("one record inserted");
            SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY()", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(dr);
            int studentid = Convert.ToInt32(datatable.Rows[0][0]);
            return studentid;
        }
        private void InsertAdmisssionDetails(int studentid)
        {
            SqlCommand cmd2 = new SqlCommand("insert into ADMISSION_TABLE values('" + studentid + "','" + txtTCno.Text + "','" + cmbPreviousGrade.SelectedValue + "','" + txtPreInstitute.Text + "','" + txtPreAcdamicYear.Text + "','" + cmbAdmissionGrade.SelectedValue + "','" + DateOfAdmission.Text + "','" + txtAcadamicYear.Text + "')", con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("In Admission Table New record inserted");
            //int i = cmd2.ExecuteNonQuery();
            //MessageBox.Show(i + "  record added");
        }
        private void StudentApplicationForm_Load(object sender, EventArgs e)
        {
            GradeDAL gradal = new GradeDAL();
            gradal.GetGradesData();
            BindComboboxdata();
            if (admissionid != 0)
            {
                LoadFormDetails();
            }
            //DataRow dr1 = GetStudentData();
            //BindDataControls(dr1);
        }
        //private DataRow GetStudentData()
        //{
        //    DataTable datatable = new DataTable();
        //    return datatable.Rows[0];

        //}
        //private void BindDataControls(DataRow dr)
        //{
        //    txtFirstName.Text = dr["FirstName"].ToString();

        //}
        private void BindComboboxdata()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand(); //first method
            cmd1.CommandText = "select ID,CODE from GRADES_TABLE;";
            cmd1.Connection = con;
            // SqlCommand cmd = new SqlCommand("select * from GRADES_TABLE", con);// second method
            SqlDataReader DR = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(DR);

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
        private DataTable GetAdmissionDetails(int admissionid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select ADMISSION_TABLE.ID,STUDENT_TABLE.FirstName,STUDENT_TABLE.LastName,STUDENT_TABLE.AadharNumber,ADMISSION_TABLE.DateOfAdmission,ADMISSION_TABLE.Previous_GradeId,ADMISSION_TABLE.ADMISSION_GradeId from STUDENT_TABLE inner join ADMISSION_TABLE on STUDENT_TABLE.ID=ADMISSION_TABLE.Student_Id where ADMISSION_TABLE.ID=" + admissionid, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            return dataTable;
        }
        private void LoadFormDetails()
        {
            DataTable dt = GetAdmissionDetails(admissionid);
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            // txtFatherName.Text = dt.Rows[0]["GuardianName"].ToString();
            //txtAddress.Text = dt.Rows[0]["Address"].ToString();
            cmbPreviousGrade.SelectedValue = dt.Rows[0]["Previous_GradeId"].ToString();
            txtAadharno.Text = dt.Rows[0]["AadharNumber"].ToString();
            //txtMobileNo.Text = dt.Rows[0]["MobileNumber"].ToString();
            cmbAdmissionGrade.SelectedValue = dt.Rows[0]["Admission_GradeId"].ToString();
        }

    }
}


