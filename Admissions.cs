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
    public partial class Admissions : Form
    {
        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLAPPLICATION");
        public Admissions()
        {
            InitializeComponent();
        }

        private void Admissions_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select ADMISSION_TABLE.ID,ADMISSION_TABLE.Student_Id,ADMISSION_TABLE.TC_Number,ADMISSION_TABLE.Previous_Acadamicyear,STUDENT_TABLE.FirstName,STUDENT_TABLE.LastName,STUDENT_TABLE.DOB,
            STUDENT_TABLE.Gender,STUDENT_TABLE.AadharNumber,ADMISSION_TABLE.Admission_GradeId,ADMISSION_TABLE.DateOfAdmission 
            from STUDENT_TABLE inner join ADMISSION_TABLE on STUDENT_TABLE.ID=ADMISSION_TABLE.Student_Id", con);
            // SqlCommand cmd = new SqlCommand("select STUDENT_TABLE.*,ADMISSION_TABLE.* from STUDENT_TABLE inner join ADMISSION_TABLE on STUDENT_TABLE.ID=ADMISSION_TABLE.Student_Id", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dataTable;
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // admissionform.admissionid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            //DataTable dt=new DataTable;
            //dt=dataGridView1.DataSource;
            int admissionid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            AdmissionForm admissionform = new AdmissionForm(admissionid);
            admissionform.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
