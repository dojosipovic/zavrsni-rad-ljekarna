namespace PresentationLayer
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.documentsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDocuments = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRecipes = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnData = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnItems = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnMeasureUnits = new System.Windows.Forms.Button();
            this.catalogPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnCatalog = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnPatients = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnHospital = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.documentsTransition = new System.Windows.Forms.Timer(this.components);
            this.dataTransition = new System.Windows.Forms.Timer(this.components);
            this.catalogTransition = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.documentsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.catalogPanel.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.flowLayoutPanel1.Controls.Add(this.documentsPanel);
            this.flowLayoutPanel1.Controls.Add(this.dataPanel);
            this.flowLayoutPanel1.Controls.Add(this.catalogPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 400);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // documentsPanel
            // 
            this.documentsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.documentsPanel.Controls.Add(this.panel1);
            this.documentsPanel.Controls.Add(this.panel3);
            this.documentsPanel.Controls.Add(this.panel4);
            this.documentsPanel.Controls.Add(this.panel5);
            this.documentsPanel.Controls.Add(this.panel6);
            this.documentsPanel.Location = new System.Drawing.Point(0, 0);
            this.documentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.documentsPanel.Name = "documentsPanel";
            this.documentsPanel.Size = new System.Drawing.Size(210, 250);
            this.documentsPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDocuments);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 50);
            this.panel1.TabIndex = 2;
            // 
            // btnDocuments
            // 
            this.btnDocuments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.btnDocuments.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocuments.Image = ((System.Drawing.Image)(resources.GetObject("btnDocuments.Image")));
            this.btnDocuments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocuments.Location = new System.Drawing.Point(-14, -12);
            this.btnDocuments.Margin = new System.Windows.Forms.Padding(0);
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDocuments.Size = new System.Drawing.Size(244, 78);
            this.btnDocuments.TabIndex = 1;
            this.btnDocuments.Text = "Dokumenti";
            this.btnDocuments.UseVisualStyleBackColor = false;
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRecipes);
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 50);
            this.panel3.TabIndex = 4;
            // 
            // btnRecipes
            // 
            this.btnRecipes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecipes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.btnRecipes.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipes.Image = ((System.Drawing.Image)(resources.GetObject("btnRecipes.Image")));
            this.btnRecipes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipes.Location = new System.Drawing.Point(-14, -12);
            this.btnRecipes.Margin = new System.Windows.Forms.Padding(0);
            this.btnRecipes.Name = "btnRecipes";
            this.btnRecipes.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnRecipes.Size = new System.Drawing.Size(244, 78);
            this.btnRecipes.TabIndex = 1;
            this.btnRecipes.Text = "Recepti";
            this.btnRecipes.UseVisualStyleBackColor = false;
            this.btnRecipes.Click += new System.EventHandler(this.btnRecipes_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button4);
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 50);
            this.panel4.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.button4.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-14, -12);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(244, 78);
            this.button4.TabIndex = 1;
            this.button4.Text = "Primke";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button5);
            this.panel5.Location = new System.Drawing.Point(0, 150);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(210, 50);
            this.panel5.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.button5.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(-14, -12);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(244, 78);
            this.button5.TabIndex = 1;
            this.button5.Text = "Racuni";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button6);
            this.panel6.Location = new System.Drawing.Point(0, 200);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(210, 50);
            this.panel6.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.button6.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-14, -12);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(244, 78);
            this.button6.TabIndex = 1;
            this.button6.Text = "Narudžbe";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.dataPanel.Controls.Add(this.panel7);
            this.dataPanel.Controls.Add(this.panel8);
            this.dataPanel.Controls.Add(this.panel9);
            this.dataPanel.Location = new System.Drawing.Point(0, 250);
            this.dataPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(210, 50);
            this.dataPanel.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnData);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(210, 50);
            this.panel7.TabIndex = 2;
            // 
            // btnData
            // 
            this.btnData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.btnData.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnData.Image = ((System.Drawing.Image)(resources.GetObject("btnData.Image")));
            this.btnData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnData.Location = new System.Drawing.Point(-14, -12);
            this.btnData.Margin = new System.Windows.Forms.Padding(0);
            this.btnData.Name = "btnData";
            this.btnData.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnData.Size = new System.Drawing.Size(244, 78);
            this.btnData.TabIndex = 1;
            this.btnData.Text = "Maticni podaci";
            this.btnData.UseVisualStyleBackColor = false;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnItems);
            this.panel8.Location = new System.Drawing.Point(0, 50);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(210, 50);
            this.panel8.TabIndex = 4;
            // 
            // btnItems
            // 
            this.btnItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.btnItems.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Image = ((System.Drawing.Image)(resources.GetObject("btnItems.Image")));
            this.btnItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItems.Location = new System.Drawing.Point(-14, -12);
            this.btnItems.Margin = new System.Windows.Forms.Padding(0);
            this.btnItems.Name = "btnItems";
            this.btnItems.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnItems.Size = new System.Drawing.Size(244, 78);
            this.btnItems.TabIndex = 1;
            this.btnItems.Text = "Artikli";
            this.btnItems.UseVisualStyleBackColor = false;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnMeasureUnits);
            this.panel9.Location = new System.Drawing.Point(0, 100);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(210, 50);
            this.panel9.TabIndex = 5;
            // 
            // btnMeasureUnits
            // 
            this.btnMeasureUnits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMeasureUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.btnMeasureUnits.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeasureUnits.Image = ((System.Drawing.Image)(resources.GetObject("btnMeasureUnits.Image")));
            this.btnMeasureUnits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeasureUnits.Location = new System.Drawing.Point(-14, -12);
            this.btnMeasureUnits.Margin = new System.Windows.Forms.Padding(0);
            this.btnMeasureUnits.Name = "btnMeasureUnits";
            this.btnMeasureUnits.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnMeasureUnits.Size = new System.Drawing.Size(244, 78);
            this.btnMeasureUnits.TabIndex = 1;
            this.btnMeasureUnits.Text = "Jedinice mjere";
            this.btnMeasureUnits.UseVisualStyleBackColor = false;
            this.btnMeasureUnits.Click += new System.EventHandler(this.btnMeasureUnits_Click);
            // 
            // catalogPanel
            // 
            this.catalogPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.catalogPanel.Controls.Add(this.panel11);
            this.catalogPanel.Controls.Add(this.panel12);
            this.catalogPanel.Controls.Add(this.panel13);
            this.catalogPanel.Controls.Add(this.panel10);
            this.catalogPanel.Location = new System.Drawing.Point(0, 300);
            this.catalogPanel.Margin = new System.Windows.Forms.Padding(0);
            this.catalogPanel.Name = "catalogPanel";
            this.catalogPanel.Size = new System.Drawing.Size(210, 200);
            this.catalogPanel.TabIndex = 9;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnCatalog);
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(210, 50);
            this.panel11.TabIndex = 2;
            // 
            // btnCatalog
            // 
            this.btnCatalog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCatalog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.btnCatalog.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalog.Image = ((System.Drawing.Image)(resources.GetObject("btnCatalog.Image")));
            this.btnCatalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalog.Location = new System.Drawing.Point(-14, -12);
            this.btnCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCatalog.Size = new System.Drawing.Size(244, 78);
            this.btnCatalog.TabIndex = 1;
            this.btnCatalog.Text = "Katalog";
            this.btnCatalog.UseVisualStyleBackColor = false;
            this.btnCatalog.Click += new System.EventHandler(this.btnCatalog_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnDoctor);
            this.panel12.Location = new System.Drawing.Point(0, 50);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(210, 50);
            this.panel12.TabIndex = 4;
            // 
            // btnDoctor
            // 
            this.btnDoctor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.btnDoctor.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctor.Image = ((System.Drawing.Image)(resources.GetObject("btnDoctor.Image")));
            this.btnDoctor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoctor.Location = new System.Drawing.Point(-14, -12);
            this.btnDoctor.Margin = new System.Windows.Forms.Padding(0);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnDoctor.Size = new System.Drawing.Size(244, 78);
            this.btnDoctor.TabIndex = 1;
            this.btnDoctor.Text = "Lijecnici";
            this.btnDoctor.UseVisualStyleBackColor = false;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnPatients);
            this.panel13.Location = new System.Drawing.Point(0, 100);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(210, 50);
            this.panel13.TabIndex = 5;
            // 
            // btnPatients
            // 
            this.btnPatients.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.btnPatients.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatients.Image = ((System.Drawing.Image)(resources.GetObject("btnPatients.Image")));
            this.btnPatients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatients.Location = new System.Drawing.Point(-14, -12);
            this.btnPatients.Margin = new System.Windows.Forms.Padding(0);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnPatients.Size = new System.Drawing.Size(244, 78);
            this.btnPatients.TabIndex = 1;
            this.btnPatients.Text = "Pacijenti";
            this.btnPatients.UseVisualStyleBackColor = false;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnHospital);
            this.panel10.Location = new System.Drawing.Point(0, 150);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(210, 50);
            this.panel10.TabIndex = 6;
            // 
            // btnHospital
            // 
            this.btnHospital.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHospital.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.btnHospital.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHospital.Image = ((System.Drawing.Image)(resources.GetObject("btnHospital.Image")));
            this.btnHospital.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHospital.Location = new System.Drawing.Point(-14, -12);
            this.btnHospital.Margin = new System.Windows.Forms.Padding(0);
            this.btnHospital.Name = "btnHospital";
            this.btnHospital.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnHospital.Size = new System.Drawing.Size(244, 78);
            this.btnHospital.TabIndex = 1;
            this.btnHospital.Text = "Ustanove";
            this.btnHospital.UseVisualStyleBackColor = false;
            this.btnHospital.Click += new System.EventHandler(this.btnHospital_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Location = new System.Drawing.Point(0, 400);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 50);
            this.panel2.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.btnLogout.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(-14, -12);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(244, 78);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Odjava";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // documentsTransition
            // 
            this.documentsTransition.Interval = 10;
            this.documentsTransition.Tick += new System.EventHandler(this.documentsTransition_Tick);
            // 
            // dataTransition
            // 
            this.dataTransition.Interval = 10;
            this.dataTransition.Tick += new System.EventHandler(this.dataTransition_Tick);
            // 
            // catalogTransition
            // 
            this.catalogTransition.Interval = 10;
            this.catalogTransition.Tick += new System.EventHandler(this.catalogTransition_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.documentsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.catalogPanel.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel documentsPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRecipes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.FlowLayoutPanel dataPanel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnMeasureUnits;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnHospital;
        private System.Windows.Forms.Timer documentsTransition;
        private System.Windows.Forms.Timer dataTransition;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.FlowLayoutPanel catalogPanel;
        private System.Windows.Forms.Timer catalogTransition;
    }
}