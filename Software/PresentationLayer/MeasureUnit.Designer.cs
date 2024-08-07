namespace PresentationLayer
{
    partial class MeasureUnit
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
            this.dgvMeasureUnits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMeasureUnits
            // 
            this.dgvMeasureUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureUnits.Location = new System.Drawing.Point(265, 83);
            this.dgvMeasureUnits.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMeasureUnits.Name = "dgvMeasureUnits";
            this.dgvMeasureUnits.Size = new System.Drawing.Size(535, 367);
            this.dgvMeasureUnits.TabIndex = 0;
            // 
            // MeasureUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMeasureUnits);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MeasureUnit";
            this.Padding = new System.Windows.Forms.Padding(210, 0, 0, 0);
            this.Text = "MeasureUnit";
            this.Load += new System.EventHandler(this.MeasureUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMeasureUnits;
    }
}