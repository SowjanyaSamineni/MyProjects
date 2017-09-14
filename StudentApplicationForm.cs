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
    public partial class AdmissonForm : Form
    {
        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLAPPLICATION");
        public int admissionid;
        public AdmissonForm()
        {
            InitializeComponent();
        }
        public AdmissonForm(int adminid)
        {
            admissionid = adminid;
            InitializeComponent();

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            int studentid;
            studentid = InsertStudentDetails();
            InsertAdmisssionDetails(studentid);
            con.Close();

        }
        //    if (isInsertValidationSucess())
        //    {
        //        int student_id = InsertStudentDetails();
        //        InsertAdmisssionDetails(student_id);

        //    }
        //}
        //private bool isInsertValidationSucess()
        //{
        //    if (txtFirstName.Text == "" && txtLastName.Text == "")
        //    {
        //        MessageBox.Show("Please Enter FirstName  and  LastName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    else if ((txtFirstName.Text.Length < 2) && (txtLastName.Text.Length < 2))
        //    {
        //        MessageBox.Show("Length should be greaterthan 2 charaters");
        //        return false;
        //    }
        //    return true;
        //}


        //    else if ((txtFname.Text.Length > 15) || (txtLname.Text.Length > 15))
        //    {
        //        MessageBox.Show("Length should be lessthan 15 characters");
        //        return false;
        //    }

        //    if (!ValidateNumber())
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        private int InsertStudentDetails()
        {
            string gender;
            gender = rdbMale.Checked ? rdbMale.Text : rdbFemale.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into STUDENT_TABLE values ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + this.BirthDate.Value.Date + "','" + gender + "','" + txtFatherName.Text + "','" + txtAddress.Text + "','" + txtMobileNo.Text + "','" + txtAadharno.Text + "')", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY()", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(dr);
            int studentid;
            studentid = Convert.ToInt32(datatable.Rows[0][0]);
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
            GradeDAL grad1 = new GradeDAL();
            DataTable dt1 = grad1.GetGradesData();
            BindComboboxdata(dt1);
            if (admissionid != 0)
            {
                LoadFormDetails();
            }
            //  DataRow dr1  = GetStudentData();
            //BindDataControls(dr1);
        }
        //private DataRow  GetStudentData()
        //{
        //    DataTable datatable = new DataTable();
        //    return datatable.Rows[0];

        //}

        private void BindDataControls(DataRow dr)
        {
            txtFirstName.Text = dr["FirstName"].ToString();

        }
        private void BindComboboxdata(DataTable dt1)
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

        private DataTable GetAdmissionDetails(int admissionid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select STUDENT_TABLE.FirstName,STUDENT_TABLE.LastName,STUDENT_TABLE.MobileNumber,ADMISSION_TABLE.Acadamic_Year from STUDENT_TABLE inner join ADMISSION_TABLE on STUDENT_TABLE.ID=ADMISSION_TABLE.Student_Id where ADMISSION_TABLE.ID=" + admissionid, con);  
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
            txtFatherName.Text = dt.Rows[0]["GuardianName"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            //txtMobileNo.Text = dt.Rows[0]["MobileNumber"].ToString();
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


