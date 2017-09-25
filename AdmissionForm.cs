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
using SchoolBAL;
using SchoolAppDomain;

namespace SchoolMgtSystem
{
    public partial class AdmissionForm : Form
    {
        public int admissionid;
        StudentBAL stdBal = new StudentBAL();
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
            string gender;
            gender = rdbMale.Checked ? rdbMale.Text : rdbFemale.Text;
            stdBal.CreateAdmission_BAL();
        }
        private void StudentApplicationForm_Load(object sender, EventArgs e)
        {
            BindComboboxdata();
            if (admissionid != 0)
            {
                LoadFormDetails();
            }
           
        }
        private void BindComboboxdata()
        {
            DataTable dt1=stdBal.GetAdmissionDetails_Bal(admissionid);
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
        }
        private void LoadFormDetails()
        {
            DataTable dt = stdBal.GetAdmissionDetails_Bal(admissionid);
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


