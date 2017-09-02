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
    public partial class Admissions: Form
    {
        public Admissions()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("uid=sa;password=surya;database=SCHOOLAPPLICATION");
        private void Admissions_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("");

        }
    }
}
