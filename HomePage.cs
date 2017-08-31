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

        private void fORMSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nEWADMISSIONFORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentApplicationForm stapp = new StudentApplicationForm();
            stapp.Show();

        }
    }
}
