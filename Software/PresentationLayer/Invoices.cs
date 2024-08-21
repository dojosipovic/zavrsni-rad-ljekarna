using BusinessLogicLayer;
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
    public partial class Invoices : Form
    {
        private RacunServices racunServices = new RacunServices();
        public Invoices()
        {
            InitializeComponent();
        }

        private async void Invoices_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvInvoices.DataSource = await racunServices.GetALl();
            dgvInvoices.Columns["StavkeRacuna"].Visible = false;
            dgvInvoices.Columns["FarmaceutID"].Visible = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.ShowDialog();
            await RefreshGUI();
        }
    }
}
