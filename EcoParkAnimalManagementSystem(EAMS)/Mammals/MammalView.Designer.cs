namespace EcoParkAnimalManagementSystem_EAMS_.Mammals
{
    partial class MammalView
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
            txtInput2 = new TextBox();
            txtInput1 = new TextBox();
            lblTitle2 = new Label();
            lblTitle1 = new Label();
            grpSpecies = new GroupBox();
            chkSpecies = new CheckBox();
            txtInput4 = new TextBox();
            txtInput3 = new TextBox();
            lblSpecies2 = new Label();
            lblSpecies1 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            grpCategory.SuspendLayout();
            grpSpecies.SuspendLayout();
            SuspendLayout();
            // 
            // grpCategory
            // 
            grpCategory.Controls.Add(txtInput2);
            grpCategory.Controls.Add(txtInput1);
            grpCategory.Controls.Add(lblTitle2);
            grpCategory.Controls.Add(lblTitle1);
            grpCategory.Location = new Point(12, 12);
            grpCategory.Name = "grpCategory";
            grpCategory.Size = new Size(320, 100);
            grpCategory.TabIndex = 0;
            grpCategory.TabStop = false;
            grpCategory.Text = "General Mammal Data";
            // 
            // txtInput2
            // 
            txtInput2.Location = new Point(172, 60);
            txtInput2.Name = "txtInput2";
            txtInput2.Size = new Size(125, 27);
            txtInput2.TabIndex = 3;
            // 
            // txtInput1
            // 
            txtInput1.Location = new Point(160, 28);
            txtInput1.Name = "txtInput1";
            txtInput1.Size = new Size(125, 27);
            txtInput1.TabIndex = 2;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Location = new Point(15, 63);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(151, 20);
            lblTitle2.TabIndex = 1;
            lblTitle2.Text = "Tail length (0=no tail)";
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Location = new Point(15, 31);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(119, 20);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "Number of teeth";
            // 
            // grpSpecies
            // 
            grpSpecies.Controls.Add(chkSpecies);
            grpSpecies.Controls.Add(txtInput4);
            grpSpecies.Controls.Add(txtInput3);
            grpSpecies.Controls.Add(lblSpecies2);
            grpSpecies.Controls.Add(lblSpecies1);
            grpSpecies.Location = new Point(12, 118);
            grpSpecies.Name = "grpSpecies";
            grpSpecies.Size = new Size(320, 150);
            grpSpecies.TabIndex = 1;
            grpSpecies.TabStop = false;
            grpSpecies.Text = "Specific Data for Species";
            // 
            // chkSpecies
            // 
            chkSpecies.AutoSize = true;
            chkSpecies.Location = new Point(18, 90);
            chkSpecies.Name = "chkSpecies";
            chkSpecies.Size = new Size(101, 24);
            chkSpecies.TabIndex = 4;
            chkSpecies.Text = "checkBox1";
            chkSpecies.UseVisualStyleBackColor = true;
            // 
            // txtInput4
            // 
            txtInput4.Location = new Point(160, 57);
            txtInput4.Name = "txtInput4";
            txtInput4.Size = new Size(125, 27);
            txtInput4.TabIndex = 3;
            // 
            // txtInput3
            // 
            txtInput3.Location = new Point(160, 24);
            txtInput3.Name = "txtInput3";
            txtInput3.Size = new Size(125, 27);
            txtInput3.TabIndex = 2;
            // 
            // lblSpecies2
            // 
            lblSpecies2.AutoSize = true;
            lblSpecies2.Location = new Point(15, 59);
            lblSpecies2.Name = "lblSpecies2";
            lblSpecies2.Size = new Size(67, 20);
            lblSpecies2.TabIndex = 1;
            lblSpecies2.Text = "Species2";
            // 
            // lblSpecies1
            // 
            lblSpecies1.AutoSize = true;
            lblSpecies1.Location = new Point(15, 27);
            lblSpecies1.Name = "lblSpecies1";
            lblSpecies1.Size = new Size(67, 20);
            lblSpecies1.TabIndex = 0;
            lblSpecies1.Text = "Species1";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(30, 283);
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
            btnCancel.Location = new Point(184, 282);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MammalView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 323);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(grpSpecies);
            Controls.Add(grpCategory);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MammalView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Animal Specifications";
            grpCategory.ResumeLayout(false);
            grpCategory.PerformLayout();
            grpSpecies.ResumeLayout(false);
            grpSpecies.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCategory;
        private Label lblTitle2;
        private Label lblTitle1;
        private TextBox txtInput2;
        private TextBox txtInput1;
        private GroupBox grpSpecies;
        private Label lblSpecies2;
        private Label lblSpecies1;
        private TextBox txtInput4;
        private TextBox txtInput3;
        private CheckBox chkSpecies;
        private Button btnOK;
        private Button btnCancel;
    }
}