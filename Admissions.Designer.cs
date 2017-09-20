namespace SchoolMgtSystem
{
    partial class Admissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Admissionid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdmissionGradeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfJoining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousAcadamicYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Admissionid,
            this.StudentID,
            this.TCnumber,
            this.FirstName,
            this.LastName,
            this.AdmissionGradeId,
            this.DateOfJoining,
            this.PreviousAcadamicYear});
            this.dataGridView1.Location = new System.Drawing.Point(12, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 412);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // Admissionid
            // 
            this.Admissionid.DataPropertyName = "ID";
            this.Admissionid.HeaderText = "AdmissionID";
            this.Admissionid.Name = "Admissionid";
            this.Admissionid.ReadOnly = true;
            this.Admissionid.Visible = false;
            this.Admissionid.Width = 50;
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "Student_Id";
            this.StudentID.FillWeight = 50F;
            this.StudentID.HeaderText = "Stud_ID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Width = 50;
            // 
            // TCnumber
            // 
            this.TCnumber.DataPropertyName = "TC_Number";
            this.TCnumber.HeaderText = "TC number";
            this.TCnumber.Name = "TCnumber";
            this.TCnumber.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 50;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last  Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 50;
            // 
            // AdmissionGradeId
            // 
            this.AdmissionGradeId.DataPropertyName = "Admission_GradeId";
            this.AdmissionGradeId.HeaderText = "AdmissionGradeId";
            this.AdmissionGradeId.Name = "AdmissionGradeId";
            this.AdmissionGradeId.ReadOnly = true;
            this.AdmissionGradeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AdmissionGradeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DateOfJoining
            // 
            this.DateOfJoining.DataPropertyName = "DateOfAdmission";
            this.DateOfJoining.HeaderText = "DOJ";
            this.DateOfJoining.Name = "DateOfJoining";
            this.DateOfJoining.ReadOnly = true;
            this.DateOfJoining.Width = 60;
            // 
            // PreviousAcadamicYear
            // 
            this.PreviousAcadamicYear.DataPropertyName = "Previous_Acadamicyear";
            this.PreviousAcadamicYear.HeaderText = "PreviousAcadamicYear";
            this.PreviousAcadamicYear.Name = "PreviousAcadamicYear";
            this.PreviousAcadamicYear.ReadOnly = true;
            this.PreviousAcadamicYear.Width = 120;
            // 
            // Admissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 431);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Admissions";
            this.Text = "Admissions";
            this.Load += new System.EventHandler(this.Admissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Admissionid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdmissionGradeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfJoining;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousAcadamicYear;
    }
}