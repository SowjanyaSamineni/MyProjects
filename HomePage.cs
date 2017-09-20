using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMgtSystem
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void nEWADMISSIONFORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdmissionForm stapp = new AdmissionForm();
            stapp.Show();

        }

        private void sTUDENTLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admissions admissions = new Admissions();
            admissions.Show();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
