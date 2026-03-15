namespace EcoParkAnimalManagementSystem_EAMS_
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtAnimalDetails = new TextBox();
            menuStrip = new MenuStrip();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            fileToolStripMenuItem = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuFileNew = new ToolStripMenuItem();
            mnuFileSave = new ToolStripMenuItem();
            mnuFileOpen = new ToolStripMenuItem();
            mnuFileSaveAs = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            grpCreateAnimal = new GroupBox();
            btnCreateAnimal = new Button();
            chkListAllSpecies = new CheckBox();
            lstSpecies = new ListBox();
            lstCategory = new ListBox();
            btnLoadImage = new Button();
            grpGeneralData = new GroupBox();
            btnAdd = new Button();
            cmbGender = new ComboBox();
            lblGender = new Label();
            txtWeight = new TextBox();
            lblWeight = new Label();
            txtAge = new TextBox();
            lblAge = new Label();
            txtName = new TextBox();
            lblName = new Label();
            picAnimal = new PictureBox();
            lstAnimals = new ListBox();
            btnDelete = new Button();
            btnChange = new Button();
            lstQueryResults = new ListBox();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnFilterAge = new Button();
            nudMaxAge = new NumericUpDown();
            nudMinAge = new NumericUpDown();
            btnFilterCategory = new Button();
            cmbCategory = new ComboBox();
            btnSortByAge = new Button();
            btnSortByName = new Button();
            lblAverageAge = new Label();
            lblTotalCount = new Label();
            menuStrip.SuspendLayout();
            grpCreateAnimal.SuspendLayout();
            grpGeneralData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnimal).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaxAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinAge).BeginInit();
            SuspendLayout();
            // 
            // txtAnimalDetails
            // 
            txtAnimalDetails.AllowDrop = true;
            txtAnimalDetails.Location = new Point(425, 293);
            txtAnimalDetails.Multiline = true;
            txtAnimalDetails.Name = "txtAnimalDetails";
            txtAnimalDetails.ReadOnly = true;
            txtAnimalDetails.ScrollBars = ScrollBars.Vertical;
            txtAnimalDetails.Size = new Size(494, 441);
            txtAnimalDetails.TabIndex = 8;
            txtAnimalDetails.WordWrap = false;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4, fileToolStripMenuItem, helpToolStripMenuItem1 });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1520, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(14, 24);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(14, 24);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuExit, mnuFileNew, mnuFileSave, mnuFileOpen, mnuFileSaveAs });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(143, 26);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuFileNew
            // 
            mnuFileNew.Name = "mnuFileNew";
            mnuFileNew.Size = new Size(143, 26);
            mnuFileNew.Text = "New";
            mnuFileNew.Click += mnuFileNew_Click;
            // 
            // mnuFileSave
            // 
            mnuFileSave.Name = "mnuFileSave";
            mnuFileSave.Size = new Size(143, 26);
            mnuFileSave.Text = "Save";
            mnuFileSave.Click += mnuFileSave_Click;
            // 
            // mnuFileOpen
            // 
            mnuFileOpen.Name = "mnuFileOpen";
            mnuFileOpen.Size = new Size(143, 26);
            mnuFileOpen.Text = "Open";
            mnuFileOpen.Click += mnuFileOpen_Click;
            // 
            // mnuFileSaveAs
            // 
            mnuFileSaveAs.Name = "mnuFileSaveAs";
            mnuFileSaveAs.Size = new Size(143, 26);
            mnuFileSaveAs.Text = "Save As";
            mnuFileSaveAs.Click += mnuFileSaveAs_Click;
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(55, 24);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(224, 26);
            mnuAbout.Text = "About";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // grpCreateAnimal
            // 
            grpCreateAnimal.Controls.Add(btnCreateAnimal);
            grpCreateAnimal.Controls.Add(chkListAllSpecies);
            grpCreateAnimal.Controls.Add(lstSpecies);
            grpCreateAnimal.Controls.Add(lstCategory);
            grpCreateAnimal.Location = new Point(12, 35);
            grpCreateAnimal.Name = "grpCreateAnimal";
            grpCreateAnimal.Size = new Size(315, 202);
            grpCreateAnimal.TabIndex = 1;
            grpCreateAnimal.TabStop = false;
            grpCreateAnimal.Text = "Create Animal";
            // 
            // btnCreateAnimal
            // 
            btnCreateAnimal.ForeColor = SystemColors.ActiveCaptionText;
            btnCreateAnimal.Location = new Point(50, 165);
            btnCreateAnimal.Name = "btnCreateAnimal";
            btnCreateAnimal.Size = new Size(183, 29);
            btnCreateAnimal.TabIndex = 3;
            btnCreateAnimal.Text = "Create Animal";
            btnCreateAnimal.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCreateAnimal.UseVisualStyleBackColor = true;
            btnCreateAnimal.Click += btnCreateAnimal_Click;
            // 
            // chkListAllSpecies
            // 
            chkListAllSpecies.AutoSize = true;
            chkListAllSpecies.Location = new Point(121, 26);
            chkListAllSpecies.Name = "chkListAllSpecies";
            chkListAllSpecies.Size = new Size(174, 24);
            chkListAllSpecies.TabIndex = 2;
            chkListAllSpecies.Text = "List all animal species";
            chkListAllSpecies.UseVisualStyleBackColor = true;
            chkListAllSpecies.CheckedChanged += chkListAllSpecies_CheckedChanged;
            // 
            // lstSpecies
            // 
            lstSpecies.FormattingEnabled = true;
            lstSpecies.Location = new Point(160, 57);
            lstSpecies.Name = "lstSpecies";
            lstSpecies.Size = new Size(135, 104);
            lstSpecies.TabIndex = 1;
            lstSpecies.SelectedIndexChanged += lstSpecies_SelectedIndexChanged;
            // 
            // lstCategory
            // 
            lstCategory.FormattingEnabled = true;
            lstCategory.Location = new Point(6, 54);
            lstCategory.Name = "lstCategory";
            lstCategory.Size = new Size(133, 104);
            lstCategory.TabIndex = 0;
            lstCategory.SelectedIndexChanged += lstCategory_SelectedIndexChanged;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(828, 235);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(109, 29);
            btnLoadImage.TabIndex = 4;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // grpGeneralData
            // 
            grpGeneralData.Controls.Add(btnAdd);
            grpGeneralData.Controls.Add(cmbGender);
            grpGeneralData.Controls.Add(lblGender);
            grpGeneralData.Controls.Add(txtWeight);
            grpGeneralData.Controls.Add(lblWeight);
            grpGeneralData.Controls.Add(txtAge);
            grpGeneralData.Controls.Add(lblAge);
            grpGeneralData.Controls.Add(txtName);
            grpGeneralData.Controls.Add(lblName);
            grpGeneralData.Location = new Point(376, 35);
            grpGeneralData.Name = "grpGeneralData";
            grpGeneralData.Size = new Size(309, 212);
            grpGeneralData.TabIndex = 2;
            grpGeneralData.TabStop = false;
            grpGeneralData.Text = "General Data";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(95, 177);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(77, 130);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(151, 28);
            cmbGender.TabIndex = 7;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(15, 133);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(57, 20);
            lblGender.TabIndex = 6;
            lblGender.Text = "Gender";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(77, 88);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(125, 27);
            txtWeight.TabIndex = 5;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(15, 91);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(56, 20);
            lblWeight.TabIndex = 4;
            lblWeight.Text = "Weight";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(77, 58);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(125, 27);
            txtAge.TabIndex = 3;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(18, 58);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(36, 20);
            lblAge.TabIndex = 2;
            lblAge.Text = "Age";
            // 
            // txtName
            // 
            txtName.Location = new Point(77, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(9, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // picAnimal
            // 
            picAnimal.BorderStyle = BorderStyle.FixedSingle;
            picAnimal.Location = new Point(719, 35);
            picAnimal.Name = "picAnimal";
            picAnimal.Size = new Size(276, 194);
            picAnimal.SizeMode = PictureBoxSizeMode.Zoom;
            picAnimal.TabIndex = 3;
            picAnimal.TabStop = false;
            // 
            // lstAnimals
            // 
            lstAnimals.FormattingEnabled = true;
            lstAnimals.Location = new Point(12, 293);
            lstAnimals.Name = "lstAnimals";
            lstAnimals.Size = new Size(396, 204);
            lstAnimals.TabIndex = 5;
            lstAnimals.SelectedIndexChanged += lstAnimals_SelectedIndexChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(40, 524);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(213, 524);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(143, 29);
            btnChange.TabIndex = 7;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // lstQueryResults
            // 
            lstQueryResults.FormattingEnabled = true;
            lstQueryResults.Location = new Point(19, 400);
            lstQueryResults.Name = "lstQueryResults";
            lstQueryResults.Size = new Size(326, 404);
            lstQueryResults.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(lstQueryResults);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(btnFilterAge);
            groupBox1.Controls.Add(nudMaxAge);
            groupBox1.Controls.Add(nudMinAge);
            groupBox1.Controls.Add(btnFilterCategory);
            groupBox1.Controls.Add(cmbCategory);
            groupBox1.Controls.Add(btnSortByAge);
            groupBox1.Controls.Add(btnSortByName);
            groupBox1.Controls.Add(lblAverageAge);
            groupBox1.Controls.Add(lblTotalCount);
            groupBox1.Location = new Point(1067, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 810);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Query and Search";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(195, 294);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(122, 29);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search Row";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(51, 294);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 9;
            // 
            // btnFilterAge
            // 
            btnFilterAge.Location = new Point(239, 219);
            btnFilterAge.Name = "btnFilterAge";
            btnFilterAge.Size = new Size(169, 29);
            btnFilterAge.TabIndex = 8;
            btnFilterAge.Text = "Filter Age Range";
            btnFilterAge.UseVisualStyleBackColor = true;
            btnFilterAge.Click += btnFilterAge_Click;
            // 
            // nudMaxAge
            // 
            nudMaxAge.Location = new Point(133, 221);
            nudMaxAge.MaximumSize = new Size(100, 0);
            nudMaxAge.Name = "nudMaxAge";
            nudMaxAge.Size = new Size(100, 27);
            nudMaxAge.TabIndex = 7;
            // 
            // nudMinAge
            // 
            nudMinAge.Location = new Point(19, 221);
            nudMinAge.MaximumSize = new Size(100, 0);
            nudMinAge.Name = "nudMinAge";
            nudMinAge.Size = new Size(100, 27);
            nudMinAge.TabIndex = 6;
            // 
            // btnFilterCategory
            // 
            btnFilterCategory.Location = new Point(195, 145);
            btnFilterCategory.Name = "btnFilterCategory";
            btnFilterCategory.Size = new Size(190, 29);
            btnFilterCategory.TabIndex = 5;
            btnFilterCategory.Text = "Filter Category";
            btnFilterCategory.UseVisualStyleBackColor = true;
            btnFilterCategory.Click += btnFilterCategory_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(19, 145);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 4;
            // 
            // btnSortByAge
            // 
            btnSortByAge.Location = new Point(223, 82);
            btnSortByAge.Name = "btnSortByAge";
            btnSortByAge.Size = new Size(162, 29);
            btnSortByAge.TabIndex = 3;
            btnSortByAge.Text = "Sort by Age";
            btnSortByAge.UseVisualStyleBackColor = true;
            btnSortByAge.TextChanged += btnSortByAge_Clicked;
            btnSortByAge.Click += btnSortByAge_Click;
            // 
            // btnSortByName
            // 
            btnSortByName.Location = new Point(19, 82);
            btnSortByName.Name = "btnSortByName";
            btnSortByName.Size = new Size(165, 29);
            btnSortByName.TabIndex = 2;
            btnSortByName.Text = "Sort by Name";
            btnSortByName.UseVisualStyleBackColor = true;
            btnSortByName.Click += btnSortByName_Click;
            // 
            // lblAverageAge
            // 
            lblAverageAge.AutoSize = true;
            lblAverageAge.Location = new Point(133, 47);
            lblAverageAge.Name = "lblAverageAge";
            lblAverageAge.Size = new Size(112, 20);
            lblAverageAge.TabIndex = 1;
            lblAverageAge.Text = "Avg age: 0.0 yrs";
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(33, 47);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(57, 20);
            lblTotalCount.TabIndex = 0;
            lblTotalCount.Text = "Total: 0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1520, 896);
            Controls.Add(groupBox1);
            Controls.Add(txtAnimalDetails);
            Controls.Add(btnChange);
            Controls.Add(btnDelete);
            Controls.Add(lstAnimals);
            Controls.Add(picAnimal);
            Controls.Add(btnLoadImage);
            Controls.Add(grpGeneralData);
            Controls.Add(grpCreateAnimal);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoPark Animal Management System";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            grpCreateAnimal.ResumeLayout(false);
            grpCreateAnimal.PerformLayout();
            grpGeneralData.ResumeLayout(false);
            grpGeneralData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAnimal).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaxAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem mnuAbout;
        private GroupBox grpCreateAnimal;
        private ListBox lstSpecies;
        private ListBox lstCategory;
        private Button btnCreateAnimal;
        private CheckBox chkListAllSpecies;
        private Button btnLoadImage;
        private GroupBox grpGeneralData;
        private Label lblAge;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtAge;
        private TextBox txtWeight;
        private Label lblWeight;
        private Label lblGender;
        private Button btnAdd;
        private ComboBox cmbGender;
        private PictureBox picAnimal;
        private ListBox lstAnimals;
        private Button btnDelete;
        private Button btnChange;
        private TextBox txtAnimalDetails;
        private ListBox lstQueryResults;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem mnuFileNew;
        private ToolStripMenuItem mnuFileSave;
        private ToolStripMenuItem mnuFileOpen;
        private ToolStripMenuItem mnuFileSaveAs;
        private GroupBox groupBox1;
        private Label lblTotalCount;
        private Button btnSortByAge;
        private Button btnSortByName;
        private Label lblAverageAge;
        private ComboBox cmbCategory;
        private Button btnFilterCategory;
        private NumericUpDown nudMinAge;
        private NumericUpDown nudMaxAge;
        private Button btnFilterAge;
        private Button btnSearch;
        private TextBox txtSearch;
    }
}
