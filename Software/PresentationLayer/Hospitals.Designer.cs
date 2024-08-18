namespace PresentationLayer
{
    partial class Hospitals
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHospitals = new System.Windows.Forms.DataGridView();
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ustanove";
            // 
            // dgvHospitals
            // 
            this.dgvHospitals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHospitals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitals.Location = new System.Drawing.Point(210, 93);
            this.dgvHospitals.Margin = new System.Windows.Forms.Padding(0);
            this.dgvHospitals.Name = "dgvHospitals";
            this.dgvHospitals.Size = new System.Drawing.Size(412, 357);
            this.dgvHospitals.TabIndex = 1;
            this.dgvHospitals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospitals_CellClick);
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.Location = new System.Drawing.Point(625, 93);
            this.dgvDoctors.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.Size = new System.Drawing.Size(374, 357);
            this.dgvDoctors.TabIndex = 2;
            // 
            // Hospitals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 450);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.dgvHospitals);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hospitals";
            this.Padding = new System.Windows.Forms.Padding(210, 0, 0, 0);
            this.Text = "Hospitals";
            this.Load += new System.EventHandler(this.Hospitals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHospitals;
        private System.Windows.Forms.DataGridView dgvDoctors;
    }
}