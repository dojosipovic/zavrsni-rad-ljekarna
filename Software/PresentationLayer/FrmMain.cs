using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FrmMain : Form
    {
        bool documentsPanelExpand = false;
        bool dataPanelExpand = false;
        bool catalogPanelExpand = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void documentsTransition_Tick(object sender, EventArgs e)
        {
            ToggleTransition(ref documentsPanel, ref documentsPanelExpand, ref documentsTransition, 200);
        }

        private void ToggleTransition(ref FlowLayoutPanel panel, ref bool expand, ref Timer transition, int maxHeight)
        {
            if (expand == false)
            {
                panel.Height += 10;
                if (panel.Height >= maxHeight)
                {
                    transition.Stop();
                    expand = true;
                    panel.Height = maxHeight;
                }
            } else
            {
                panel.Height -= 10;
                if (panel.Height <= 50)
                {
                    transition.Stop();
                    expand = false;
                    panel.Height = 50;
                }
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            dataTransition.Start();
        }

        private void dataTransition_Tick(object sender, EventArgs e)
        {
            ToggleTransition(ref dataPanel, ref dataPanelExpand, ref dataTransition, 200);
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            documentsTransition.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Items());
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private string GetTitleFromSender(object sender)
        {
            return sender.ToString().Split(':')[1].Trim();
        }

        private void btnMeasureUnits_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new MeasureUnit());
        }

        private void catalogTransition_Tick(object sender, EventArgs e)
        {
            ToggleTransition(ref catalogPanel, ref catalogPanelExpand, ref catalogTransition, 300);
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            catalogTransition.Start();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Doctors());
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Patients());
        }

        private void btnHospital_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Hospitals());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Orders());
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Receipts());
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Invoices());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Suppliers());
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Prescriptions());
        }

        private void btnPharmacists_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Pharmacists());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Account());
        }
    }
}
