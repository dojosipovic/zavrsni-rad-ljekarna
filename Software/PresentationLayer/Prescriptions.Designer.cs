namespace PresentationLayer
{
    partial class Prescriptions
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
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();
            this.dgvPrescriptionDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMBO = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrescriptions
            // 
            this.dgvPrescriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptions.Location = new System.Drawing.Point(210, 92);
            this.dgvPrescriptions.Margin = new System.Windows.Forms.Padding(0);
            this.dgvPrescriptions.Name = "dgvPrescriptions";
            this.dgvPrescriptions.Size = new System.Drawing.Size(459, 358);
            this.dgvPrescriptions.TabIndex = 0;
            this.dgvPrescriptions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrescriptions_CellClick);
            // 
            // dgvPrescriptionDetails
            // 
            this.dgvPrescriptionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrescriptionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptionDetails.Location = new System.Drawing.Point(672, 197);
            this.dgvPrescriptionDetails.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dgvPrescriptionDetails.Name = "dgvPrescriptionDetails";
            this.dgvPrescriptionDetails.Size = new System.Drawing.Size(433, 253);
            this.dgvPrescriptionDetails.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liječnik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pacijent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(692, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Datum";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Enabled = false;
            this.txtDoctor.Location = new System.Drawing.Point(770, 89);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(116, 20);
            this.txtDoctor.TabIndex = 5;
            // 
            // txtPatient
            // 
            this.txtPatient.Enabled = false;
            this.txtPatient.Location = new System.Drawing.Point(770, 123);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(116, 20);
            this.txtPatient.TabIndex = 6;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(911, 89);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 7;
            // 
            // txtMBO
            // 
            this.txtMBO.Enabled = false;
            this.txtMBO.Location = new System.Drawing.Point(911, 123);
            this.txtMBO.Name = "txtMBO";
            this.txtMBO.Size = new System.Drawing.Size(100, 20);
            this.txtMBO.TabIndex = 8;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(770, 151);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 9;
            // 
            // Prescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 450);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtMBO);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPrescriptionDetails);
            this.Controls.Add(this.dgvPrescriptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Prescriptions";
            this.Padding = new System.Windows.Forms.Padding(210, 0, 0, 0);
            this.Text = "Recipes";
            this.Load += new System.EventHandler(this.Prescriptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrescriptions;
        private System.Windows.Forms.DataGridView dgvPrescriptionDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMBO;
        private System.Windows.Forms.TextBox txtDate;
    }
}