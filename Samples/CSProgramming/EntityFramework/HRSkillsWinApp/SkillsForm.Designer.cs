namespace HRSkillsWinApp
{
    partial class SkillsForm
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
            this.components = new System.ComponentModel.Container();
            this.skillsRefsTextBox = new System.Windows.Forms.RichTextBox();
            this.SkillsDescriptionLabel = new System.Windows.Forms.Label();
            this.EmployeesLabel = new System.Windows.Forms.Label();
            this.SkillsLabel = new System.Windows.Forms.Label();
            this.labelSearchOnSkills = new System.Windows.Forms.Label();
            this.textBoxKeywords = new System.Windows.Forms.TextBox();
            this.buttonSkillSearch = new System.Windows.Forms.Button();
            this.groupBoxEmployee = new System.Windows.Forms.GroupBox();
            this.buttonSubmitEmployee = new System.Windows.Forms.Button();
            this.textBoxEmployeeEmail = new System.Windows.Forms.TextBox();
            this.labelEmailAddress = new System.Windows.Forms.Label();
            this.textBoxEmployeeAlias = new System.Windows.Forms.TextBox();
            this.labelAlias = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.groupBoxSkill = new System.Windows.Forms.GroupBox();
            this.buttonSubmitSkill = new System.Windows.Forms.Button();
            this.textBoxSkillBriefDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSkillShortName = new System.Windows.Forms.TextBox();
            this.labelShortSkillName = new System.Windows.Forms.Label();
            this.groupBoxReference = new System.Windows.Forms.GroupBox();
            this.buttonSubmitReference = new System.Windows.Forms.Button();
            this.textBoxRefEmail = new System.Windows.Forms.TextBox();
            this.labelRefEmail = new System.Windows.Forms.Label();
            this.textBoxRefPosition = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.textBoxRefLastName = new System.Windows.Forms.TextBox();
            this.labelRefLastName = new System.Windows.Forms.Label();
            this.textBoxRefFirstName = new System.Windows.Forms.TextBox();
            this.labelRefFirstName = new System.Windows.Forms.Label();
            this.groupSkillInfo = new System.Windows.Forms.GroupBox();
            this.buttonSubmitSkillInfo = new System.Windows.Forms.Button();
            this.textBoxUrlUncSkillInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewSkills = new System.Windows.Forms.DataGridView();
            this.skillNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.briefDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxEmployee.SuspendLayout();
            this.groupBoxSkill.SuspendLayout();
            this.groupBoxReference.SuspendLayout();
            this.groupSkillInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skillsRefsTextBox
            // 
            this.skillsRefsTextBox.Location = new System.Drawing.Point(417, 28);
            this.skillsRefsTextBox.Name = "skillsRefsTextBox";
            this.skillsRefsTextBox.Size = new System.Drawing.Size(360, 291);
            this.skillsRefsTextBox.TabIndex = 1;
            this.skillsRefsTextBox.Text = "";
            this.skillsRefsTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // SkillsDescriptionLabel
            // 
            this.SkillsDescriptionLabel.AutoSize = true;
            this.SkillsDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillsDescriptionLabel.Location = new System.Drawing.Point(417, 12);
            this.SkillsDescriptionLabel.Name = "SkillsDescriptionLabel";
            this.SkillsDescriptionLabel.Size = new System.Drawing.Size(108, 13);
            this.SkillsDescriptionLabel.TabIndex = 2;
            this.SkillsDescriptionLabel.Text = "Skills/References";
            // 
            // EmployeesLabel
            // 
            this.EmployeesLabel.AutoSize = true;
            this.EmployeesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeesLabel.Location = new System.Drawing.Point(12, 12);
            this.EmployeesLabel.Name = "EmployeesLabel";
            this.EmployeesLabel.Size = new System.Drawing.Size(282, 13);
            this.EmployeesLabel.TabIndex = 3;
            this.EmployeesLabel.Text = "Employees (Click to select an existing employee)";
            // 
            // SkillsLabel
            // 
            this.SkillsLabel.AutoSize = true;
            this.SkillsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillsLabel.Location = new System.Drawing.Point(12, 168);
            this.SkillsLabel.Name = "SkillsLabel";
            this.SkillsLabel.Size = new System.Drawing.Size(223, 13);
            this.SkillsLabel.TabIndex = 5;
            this.SkillsLabel.Text = "Skills (Click to get all skill information)";
            // 
            // labelSearchOnSkills
            // 
            this.labelSearchOnSkills.AutoSize = true;
            this.labelSearchOnSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchOnSkills.Location = new System.Drawing.Point(12, 339);
            this.labelSearchOnSkills.Name = "labelSearchOnSkills";
            this.labelSearchOnSkills.Size = new System.Drawing.Size(102, 13);
            this.labelSearchOnSkills.TabIndex = 6;
            this.labelSearchOnSkills.Text = "Search for skills:";
            // 
            // textBoxKeywords
            // 
            this.textBoxKeywords.Location = new System.Drawing.Point(114, 336);
            this.textBoxKeywords.Name = "textBoxKeywords";
            this.textBoxKeywords.Size = new System.Drawing.Size(371, 20);
            this.textBoxKeywords.TabIndex = 3;
            this.textBoxKeywords.Text = "Add keywords separated by a space. Press <Enter> to search.";
            this.textBoxKeywords.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxKeywords_PreviewKeyDown);
            // 
            // buttonSkillSearch
            // 
            this.buttonSkillSearch.Location = new System.Drawing.Point(410, 363);
            this.buttonSkillSearch.Name = "buttonSkillSearch";
            this.buttonSkillSearch.Size = new System.Drawing.Size(75, 21);
            this.buttonSkillSearch.TabIndex = 4;
            this.buttonSkillSearch.Text = "Search";
            this.buttonSkillSearch.UseVisualStyleBackColor = true;
            this.buttonSkillSearch.Click += new System.EventHandler(this.buttonSkillSearch_Click);
            // 
            // groupBoxEmployee
            // 
            this.groupBoxEmployee.Controls.Add(this.buttonSubmitEmployee);
            this.groupBoxEmployee.Controls.Add(this.textBoxEmployeeEmail);
            this.groupBoxEmployee.Controls.Add(this.labelEmailAddress);
            this.groupBoxEmployee.Controls.Add(this.textBoxEmployeeAlias);
            this.groupBoxEmployee.Controls.Add(this.labelAlias);
            this.groupBoxEmployee.Controls.Add(this.textBoxLastName);
            this.groupBoxEmployee.Controls.Add(this.labelLastName);
            this.groupBoxEmployee.Controls.Add(this.textBoxFirstName);
            this.groupBoxEmployee.Controls.Add(this.labelFirstName);
            this.groupBoxEmployee.Location = new System.Drawing.Point(9, 397);
            this.groupBoxEmployee.Name = "groupBoxEmployee";
            this.groupBoxEmployee.Size = new System.Drawing.Size(225, 178);
            this.groupBoxEmployee.TabIndex = 9;
            this.groupBoxEmployee.TabStop = false;
            this.groupBoxEmployee.Text = "New Employee";
            // 
            // buttonSubmitEmployee
            // 
            this.buttonSubmitEmployee.Location = new System.Drawing.Point(118, 139);
            this.buttonSubmitEmployee.Name = "buttonSubmitEmployee";
            this.buttonSubmitEmployee.Size = new System.Drawing.Size(98, 20);
            this.buttonSubmitEmployee.TabIndex = 8;
            this.buttonSubmitEmployee.Text = "Submit Employee";
            this.buttonSubmitEmployee.UseVisualStyleBackColor = true;
            this.buttonSubmitEmployee.Click += new System.EventHandler(this.buttonSubmitEmployee_Click);
            // 
            // textBoxEmployeeEmail
            // 
            this.textBoxEmployeeEmail.Location = new System.Drawing.Point(72, 98);
            this.textBoxEmployeeEmail.Name = "textBoxEmployeeEmail";
            this.textBoxEmployeeEmail.Size = new System.Drawing.Size(147, 20);
            this.textBoxEmployeeEmail.TabIndex = 7;
            // 
            // labelEmailAddress
            // 
            this.labelEmailAddress.AutoSize = true;
            this.labelEmailAddress.Location = new System.Drawing.Point(6, 101);
            this.labelEmailAddress.Name = "labelEmailAddress";
            this.labelEmailAddress.Size = new System.Drawing.Size(38, 13);
            this.labelEmailAddress.TabIndex = 6;
            this.labelEmailAddress.Text = "E-mail:";
            // 
            // textBoxEmployeeAlias
            // 
            this.textBoxEmployeeAlias.Location = new System.Drawing.Point(72, 71);
            this.textBoxEmployeeAlias.Name = "textBoxEmployeeAlias";
            this.textBoxEmployeeAlias.Size = new System.Drawing.Size(147, 20);
            this.textBoxEmployeeAlias.TabIndex = 5;
            // 
            // labelAlias
            // 
            this.labelAlias.AutoSize = true;
            this.labelAlias.Location = new System.Drawing.Point(6, 76);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(32, 13);
            this.labelAlias.TabIndex = 4;
            this.labelAlias.Text = "Alias:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(72, 45);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(147, 20);
            this.textBoxLastName.TabIndex = 3;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(5, 48);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 2;
            this.labelLastName.Text = "Last Name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(72, 19);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(147, 20);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(6, 22);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name:";
            // 
            // groupBoxSkill
            // 
            this.groupBoxSkill.Controls.Add(this.buttonSubmitSkill);
            this.groupBoxSkill.Controls.Add(this.textBoxSkillBriefDescription);
            this.groupBoxSkill.Controls.Add(this.label1);
            this.groupBoxSkill.Controls.Add(this.textBoxSkillShortName);
            this.groupBoxSkill.Controls.Add(this.labelShortSkillName);
            this.groupBoxSkill.Location = new System.Drawing.Point(237, 397);
            this.groupBoxSkill.Name = "groupBoxSkill";
            this.groupBoxSkill.Size = new System.Drawing.Size(257, 178);
            this.groupBoxSkill.TabIndex = 10;
            this.groupBoxSkill.TabStop = false;
            this.groupBoxSkill.Text = "New Skill";
            // 
            // buttonSubmitSkill
            // 
            this.buttonSubmitSkill.Location = new System.Drawing.Point(156, 142);
            this.buttonSubmitSkill.Name = "buttonSubmitSkill";
            this.buttonSubmitSkill.Size = new System.Drawing.Size(89, 23);
            this.buttonSubmitSkill.TabIndex = 6;
            this.buttonSubmitSkill.Text = "Submit Skill";
            this.buttonSubmitSkill.UseVisualStyleBackColor = true;
            this.buttonSubmitSkill.Click += new System.EventHandler(this.buttonSubmitSkill_Click);
            // 
            // textBoxSkillBriefDescription
            // 
            this.textBoxSkillBriefDescription.Location = new System.Drawing.Point(6, 93);
            this.textBoxSkillBriefDescription.Multiline = true;
            this.textBoxSkillBriefDescription.Name = "textBoxSkillBriefDescription";
            this.textBoxSkillBriefDescription.Size = new System.Drawing.Size(239, 43);
            this.textBoxSkillBriefDescription.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Brief Description of Skill:";
            // 
            // textBoxSkillShortName
            // 
            this.textBoxSkillShortName.Location = new System.Drawing.Point(6, 41);
            this.textBoxSkillShortName.Name = "textBoxSkillShortName";
            this.textBoxSkillShortName.Size = new System.Drawing.Size(239, 20);
            this.textBoxSkillShortName.TabIndex = 1;
            // 
            // labelShortSkillName
            // 
            this.labelShortSkillName.AutoSize = true;
            this.labelShortSkillName.Location = new System.Drawing.Point(6, 22);
            this.labelShortSkillName.Name = "labelShortSkillName";
            this.labelShortSkillName.Size = new System.Drawing.Size(171, 13);
            this.labelShortSkillName.TabIndex = 0;
            this.labelShortSkillName.Text = "Short Name of Skill or Technology:";
            // 
            // groupBoxReference
            // 
            this.groupBoxReference.Controls.Add(this.buttonSubmitReference);
            this.groupBoxReference.Controls.Add(this.textBoxRefEmail);
            this.groupBoxReference.Controls.Add(this.labelRefEmail);
            this.groupBoxReference.Controls.Add(this.textBoxRefPosition);
            this.groupBoxReference.Controls.Add(this.labelPosition);
            this.groupBoxReference.Controls.Add(this.textBoxRefLastName);
            this.groupBoxReference.Controls.Add(this.labelRefLastName);
            this.groupBoxReference.Controls.Add(this.textBoxRefFirstName);
            this.groupBoxReference.Controls.Add(this.labelRefFirstName);
            this.groupBoxReference.Location = new System.Drawing.Point(500, 408);
            this.groupBoxReference.Name = "groupBoxReference";
            this.groupBoxReference.Size = new System.Drawing.Size(277, 167);
            this.groupBoxReference.TabIndex = 11;
            this.groupBoxReference.TabStop = false;
            this.groupBoxReference.Text = "Add Reference Person to Selected Employee";
            // 
            // buttonSubmitReference
            // 
            this.buttonSubmitReference.Location = new System.Drawing.Point(179, 131);
            this.buttonSubmitReference.Name = "buttonSubmitReference";
            this.buttonSubmitReference.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmitReference.TabIndex = 10;
            this.buttonSubmitReference.Text = "Submit Ref";
            this.buttonSubmitReference.UseVisualStyleBackColor = true;
            this.buttonSubmitReference.Click += new System.EventHandler(this.buttonSubmitReference_Click);
            // 
            // textBoxRefEmail
            // 
            this.textBoxRefEmail.Location = new System.Drawing.Point(72, 105);
            this.textBoxRefEmail.Name = "textBoxRefEmail";
            this.textBoxRefEmail.Size = new System.Drawing.Size(182, 20);
            this.textBoxRefEmail.TabIndex = 8;
            // 
            // labelRefEmail
            // 
            this.labelRefEmail.AutoSize = true;
            this.labelRefEmail.Location = new System.Drawing.Point(6, 108);
            this.labelRefEmail.Name = "labelRefEmail";
            this.labelRefEmail.Size = new System.Drawing.Size(38, 13);
            this.labelRefEmail.TabIndex = 7;
            this.labelRefEmail.Text = "E-mail:";
            // 
            // textBoxRefPosition
            // 
            this.textBoxRefPosition.Location = new System.Drawing.Point(72, 79);
            this.textBoxRefPosition.Name = "textBoxRefPosition";
            this.textBoxRefPosition.Size = new System.Drawing.Size(182, 20);
            this.textBoxRefPosition.TabIndex = 6;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(6, 82);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(47, 13);
            this.labelPosition.TabIndex = 5;
            this.labelPosition.Text = "Position:";
            // 
            // textBoxRefLastName
            // 
            this.textBoxRefLastName.Location = new System.Drawing.Point(72, 53);
            this.textBoxRefLastName.Name = "textBoxRefLastName";
            this.textBoxRefLastName.Size = new System.Drawing.Size(182, 20);
            this.textBoxRefLastName.TabIndex = 3;
            // 
            // labelRefLastName
            // 
            this.labelRefLastName.AutoSize = true;
            this.labelRefLastName.Location = new System.Drawing.Point(6, 56);
            this.labelRefLastName.Name = "labelRefLastName";
            this.labelRefLastName.Size = new System.Drawing.Size(61, 13);
            this.labelRefLastName.TabIndex = 2;
            this.labelRefLastName.Text = "Last Name:";
            // 
            // textBoxRefFirstName
            // 
            this.textBoxRefFirstName.Location = new System.Drawing.Point(72, 27);
            this.textBoxRefFirstName.Name = "textBoxRefFirstName";
            this.textBoxRefFirstName.Size = new System.Drawing.Size(182, 20);
            this.textBoxRefFirstName.TabIndex = 1;
            // 
            // labelRefFirstName
            // 
            this.labelRefFirstName.AutoSize = true;
            this.labelRefFirstName.Location = new System.Drawing.Point(6, 29);
            this.labelRefFirstName.Name = "labelRefFirstName";
            this.labelRefFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelRefFirstName.TabIndex = 0;
            this.labelRefFirstName.Text = "First Name:";
            // 
            // groupSkillInfo
            // 
            this.groupSkillInfo.Controls.Add(this.buttonSubmitSkillInfo);
            this.groupSkillInfo.Controls.Add(this.textBoxUrlUncSkillInfo);
            this.groupSkillInfo.Controls.Add(this.label2);
            this.groupSkillInfo.Location = new System.Drawing.Point(500, 325);
            this.groupSkillInfo.Name = "groupSkillInfo";
            this.groupSkillInfo.Size = new System.Drawing.Size(277, 77);
            this.groupSkillInfo.TabIndex = 12;
            this.groupSkillInfo.TabStop = false;
            this.groupSkillInfo.Text = "Add Info to Current Skill";
            // 
            // buttonSubmitSkillInfo
            // 
            this.buttonSubmitSkillInfo.Location = new System.Drawing.Point(179, 45);
            this.buttonSubmitSkillInfo.Name = "buttonSubmitSkillInfo";
            this.buttonSubmitSkillInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmitSkillInfo.TabIndex = 4;
            this.buttonSubmitSkillInfo.Text = "Submit Info";
            this.buttonSubmitSkillInfo.UseVisualStyleBackColor = true;
            this.buttonSubmitSkillInfo.Click += new System.EventHandler(this.buttonSubmitSkillInfo_Click);
            // 
            // textBoxUrlUncSkillInfo
            // 
            this.textBoxUrlUncSkillInfo.Location = new System.Drawing.Point(72, 19);
            this.textBoxUrlUncSkillInfo.Name = "textBoxUrlUncSkillInfo";
            this.textBoxUrlUncSkillInfo.Size = new System.Drawing.Size(182, 20);
            this.textBoxUrlUncSkillInfo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "URL/ UNC:";
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.AutoGenerateColumns = false;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewEmployees.DataSource = this.employeesBindingSource;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(389, 125);
            this.dataGridViewEmployees.TabIndex = 1;
            this.dataGridViewEmployees.CurrentCellChanged += new System.EventHandler(this.dataGridViewEmployees_CurrentCellChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LastName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Last Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FirstName";
            this.dataGridViewTextBoxColumn3.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Alias";
            this.dataGridViewTextBoxColumn4.HeaderText = "Alias";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn5.HeaderText = "Email";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataSource = typeof(HRSkillsWinApp.Employee);
            // 
            // dataGridViewSkills
            // 
            this.dataGridViewSkills.AllowUserToAddRows = false;
            this.dataGridViewSkills.AllowUserToDeleteRows = false;
            this.dataGridViewSkills.AutoGenerateColumns = false;
            this.dataGridViewSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSkills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.skillNameDataGridViewTextBoxColumn,
            this.briefDescriptionDataGridViewTextBoxColumn});
            this.dataGridViewSkills.DataSource = this.skillsBindingSource;
            this.dataGridViewSkills.Location = new System.Drawing.Point(12, 184);
            this.dataGridViewSkills.MultiSelect = false;
            this.dataGridViewSkills.Name = "dataGridViewSkills";
            this.dataGridViewSkills.ReadOnly = true;
            this.dataGridViewSkills.Size = new System.Drawing.Size(389, 135);
            this.dataGridViewSkills.TabIndex = 2;
            this.dataGridViewSkills.CurrentCellChanged += new System.EventHandler(this.dataGridViewSkills_CurrentCellChanged);
            // 
            // skillNameDataGridViewTextBoxColumn
            // 
            this.skillNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.skillNameDataGridViewTextBoxColumn.DataPropertyName = "SkillName";
            this.skillNameDataGridViewTextBoxColumn.HeaderText = "Skill Name";
            this.skillNameDataGridViewTextBoxColumn.Name = "skillNameDataGridViewTextBoxColumn";
            this.skillNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.skillNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // briefDescriptionDataGridViewTextBoxColumn
            // 
            this.briefDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.briefDescriptionDataGridViewTextBoxColumn.DataPropertyName = "BriefDescription";
            this.briefDescriptionDataGridViewTextBoxColumn.HeaderText = "Brief Description";
            this.briefDescriptionDataGridViewTextBoxColumn.Name = "briefDescriptionDataGridViewTextBoxColumn";
            this.briefDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // skillsBindingSource
            // 
            this.skillsBindingSource.DataMember = "Skills";
            this.skillsBindingSource.DataSource = this.employeesBindingSource;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(329, 363);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 21);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(702, 588);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SkillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 612);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dataGridViewSkills);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Controls.Add(this.groupSkillInfo);
            this.Controls.Add(this.groupBoxReference);
            this.Controls.Add(this.groupBoxSkill);
            this.Controls.Add(this.groupBoxEmployee);
            this.Controls.Add(this.buttonSkillSearch);
            this.Controls.Add(this.textBoxKeywords);
            this.Controls.Add(this.labelSearchOnSkills);
            this.Controls.Add(this.SkillsLabel);
            this.Controls.Add(this.EmployeesLabel);
            this.Controls.Add(this.SkillsDescriptionLabel);
            this.Controls.Add(this.skillsRefsTextBox);
            this.MaximumSize = new System.Drawing.Size(800, 650);
            this.MinimumSize = new System.Drawing.Size(800, 650);
            this.Name = "SkillsForm";
            this.Text = "HR Skills Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxEmployee.ResumeLayout(false);
            this.groupBoxEmployee.PerformLayout();
            this.groupBoxSkill.ResumeLayout(false);
            this.groupBoxSkill.PerformLayout();
            this.groupBoxReference.ResumeLayout(false);
            this.groupBoxReference.PerformLayout();
            this.groupSkillInfo.ResumeLayout(false);
            this.groupSkillInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox skillsRefsTextBox;
        private System.Windows.Forms.Label SkillsDescriptionLabel;
        private System.Windows.Forms.Label EmployeesLabel;
        private System.Windows.Forms.Label SkillsLabel;
        private System.Windows.Forms.Label labelSearchOnSkills;
        private System.Windows.Forms.TextBox textBoxKeywords;
        private System.Windows.Forms.Button buttonSkillSearch;
        private System.Windows.Forms.GroupBox groupBoxEmployee;
        private System.Windows.Forms.GroupBox groupBoxSkill;
        private System.Windows.Forms.GroupBox groupBoxReference;
        private System.Windows.Forms.GroupBox groupSkillInfo;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxEmployeeEmail;
        private System.Windows.Forms.Label labelEmailAddress;
        private System.Windows.Forms.TextBox textBoxEmployeeAlias;
        private System.Windows.Forms.Label labelAlias;
        private System.Windows.Forms.TextBox textBoxSkillShortName;
        private System.Windows.Forms.Label labelShortSkillName;
        private System.Windows.Forms.TextBox textBoxSkillBriefDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRefLastName;
        private System.Windows.Forms.TextBox textBoxRefFirstName;
        private System.Windows.Forms.Label labelRefFirstName;
        private System.Windows.Forms.TextBox textBoxUrlUncSkillInfo;
        private System.Windows.Forms.TextBox textBoxRefLastName;
        private System.Windows.Forms.TextBox textBoxRefPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TextBox textBoxRefEmail;
        private System.Windows.Forms.Label labelRefEmail;
        private System.Windows.Forms.Button buttonSubmitEmployee;
        private System.Windows.Forms.Button buttonSubmitSkill;
        private System.Windows.Forms.Button buttonSubmitReference;
        private System.Windows.Forms.Button buttonSubmitSkillInfo;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.DataGridView dataGridViewSkills;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private System.Windows.Forms.BindingSource skillsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn skillNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn briefDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnClose;

    }
}

