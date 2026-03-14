namespace EcoParkAnimalManagementSystem_EAMS_.Reptiles
{
    partial class ReptileView
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
            grpCategory = new GroupBox();
            numAggression = new NumericUpDown();
            lblAggression = new Label();
            radNo = new RadioButton();
            radYes = new RadioButton();
            lblLivesInWater = new Label();
            txtBodyLength = new TextBox();
            lblBodyLength = new Label();
            grpSpecies = new GroupBox();
            chkSpecies = new CheckBox();
            txtInput2 = new TextBox();
            txtInput1 = new TextBox();
            lblSpecies2 = new Label();
            lblSpecies1 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            grpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAggression).BeginInit();
            grpSpecies.SuspendLayout();
            SuspendLayout();
            // 
            // grpCategory
            // 
            grpCategory.Controls.Add(numAggression);
            grpCategory.Controls.Add(lblAggression);
            grpCategory.Controls.Add(radNo);
            grpCategory.Controls.Add(radYes);
            grpCategory.Controls.Add(lblLivesInWater);
            grpCategory.Controls.Add(txtBodyLength);
            grpCategory.Controls.Add(lblBodyLength);
            grpCategory.Location = new Point(12, 12);
            grpCategory.Name = "grpCategory";
            grpCategory.Size = new Size(320, 130);
            grpCategory.TabIndex = 0;
            grpCategory.TabStop = false;
            grpCategory.Text = "General Reptile Data";
            // 
            // numAggression
            // 
            numAggression.Location = new Point(160, 94);
            numAggression.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numAggression.Name = "numAggression";
            numAggression.Size = new Size(150, 27);
            numAggression.TabIndex = 6;
            // 
            // lblAggression
            // 
            lblAggression.AutoSize = true;
            lblAggression.Location = new Point(15, 94);
            lblAggression.Name = "lblAggression";
            lblAggression.Size = new Size(113, 20);
            lblAggression.TabIndex = 5;
            lblAggression.Text = "Aggressiveness ";
            // 
            // radNo
            // 
            radNo.AutoSize = true;
            radNo.Location = new Point(220, 59);
            radNo.Name = "radNo";
            radNo.Size = new Size(50, 24);
            radNo.TabIndex = 4;
            radNo.TabStop = true;
            radNo.Text = "No";
            radNo.UseVisualStyleBackColor = true;
            // 
            // radYes
            // 
            radYes.AutoSize = true;
            radYes.Location = new Point(160, 59);
            radYes.Name = "radYes";
            radYes.Size = new Size(51, 24);
            radYes.TabIndex = 3;
            radYes.TabStop = true;
            radYes.Text = "Yes";
            radYes.UseVisualStyleBackColor = true;
            // 
            // lblLivesInWater
            // 
            lblLivesInWater.AutoSize = true;
            lblLivesInWater.Location = new Point(15, 61);
            lblLivesInWater.Name = "lblLivesInWater";
            lblLivesInWater.Size = new Size(98, 20);
            lblLivesInWater.TabIndex = 2;
            lblLivesInWater.Text = "Lives in water";
            // 
            // txtBodyLength
            // 
            txtBodyLength.Location = new Point(160, 25);
            txtBodyLength.Name = "txtBodyLength";
            txtBodyLength.Size = new Size(125, 27);
            txtBodyLength.TabIndex = 1;
            // 
            // lblBodyLength
            // 
            lblBodyLength.AutoSize = true;
            lblBodyLength.Location = new Point(15, 28);
            lblBodyLength.Name = "lblBodyLength";
            lblBodyLength.Size = new Size(92, 20);
            lblBodyLength.TabIndex = 0;
            lblBodyLength.Text = "Body Length";
            // 
            // grpSpecies
            // 
            grpSpecies.Controls.Add(chkSpecies);
            grpSpecies.Controls.Add(txtInput2);
            grpSpecies.Controls.Add(txtInput1);
            grpSpecies.Controls.Add(lblSpecies2);
            grpSpecies.Controls.Add(lblSpecies1);
            grpSpecies.Location = new Point(12, 148);
            grpSpecies.Name = "grpSpecies";
            grpSpecies.Size = new Size(320, 120);
            grpSpecies.TabIndex = 1;
            grpSpecies.TabStop = false;
            grpSpecies.Text = "Specific Data for Species";
            // 
            // chkSpecies
            // 
            chkSpecies.AutoSize = true;
            chkSpecies.Location = new Point(15, 88);
            chkSpecies.Name = "chkSpecies";
            chkSpecies.Size = new Size(101, 24);
            chkSpecies.TabIndex = 4;
            chkSpecies.Text = "checkBox1";
            chkSpecies.UseVisualStyleBackColor = true;
            // 
            // txtInput2
            // 
            txtInput2.Location = new Point(137, 62);
            txtInput2.Name = "txtInput2";
            txtInput2.Size = new Size(125, 27);
            txtInput2.TabIndex = 3;
            // 
            // txtInput1
            // 
            txtInput1.Location = new Point(137, 29);
            txtInput1.Name = "txtInput1";
            txtInput1.Size = new Size(125, 27);
            txtInput1.TabIndex = 2;
            // 
            // lblSpecies2
            // 
            lblSpecies2.AutoSize = true;
            lblSpecies2.Location = new Point(15, 65);
            lblSpecies2.Name = "lblSpecies2";
            lblSpecies2.Size = new Size(67, 20);
            lblSpecies2.TabIndex = 1;
            lblSpecies2.Text = "Species2";
            // 
            // lblSpecies1
            // 
            lblSpecies1.AutoSize = true;
            lblSpecies1.Location = new Point(15, 31);
            lblSpecies1.Name = "lblSpecies1";
            lblSpecies1.Size = new Size(67, 20);
            lblSpecies1.TabIndex = 0;
            lblSpecies1.Text = "Species1";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(44, 286);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(172, 286);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ReptileView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 323);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(grpSpecies);
            Controls.Add(grpCategory);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ReptileView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Animal Specifications";
            grpCategory.ResumeLayout(false);
            grpCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAggression).EndInit();
            grpSpecies.ResumeLayout(false);
            grpSpecies.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCategory;
        private Label lblBodyLength;
        private Label lblLivesInWater;
        private TextBox txtBodyLength;
        private RadioButton radNo;
        private RadioButton radYes;
        private Label lblAggression;
        private NumericUpDown numAggression;
        private GroupBox grpSpecies;
        private Label lblSpecies1;
        private CheckBox chkSpecies;
        private TextBox txtInput2;
        private TextBox txtInput1;
        private Label lblSpecies2;
        private Button btnOK;
        private Button btnCancel;
    }
}