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
            SqlCommand cmd = new SqlCommand("select STUDENT_TABLE.ID,ADMISSION_TABLE.ID,ADMISSION_TABLE.Admission_GradeId,ADMISSION_TABLE.DateOfAdmission,STUDENT_TABLE.FirstName from STUDENT_TABLE inner join ADMISSION_TABLE on STUDENT_TABLE.ID=ADMISSION_TABLE.Student_Id", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dataGridView1.DataSource = dataTable;
            con.Close();
            //int admissionid; 
            //admissionid = Convert.ToInt32(dataTable.Rows[0][0]);
            //return admissionid;
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AdmissonForm admissionform = new AdmissonForm();
            admissionform.admissionid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            admissionform.Show();
        }
    }
}
