using BusinessLogicLayer;
using EntitiesLayer.Entities;
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
            var invoicesView = new List<RacunViewModel>();
            var invoices = await racunServices.GetALl();
            foreach(var item in invoices)
            {
                item.StavkeRacuna = await racunServices.GetInvoiceItems(item);
                double sum = item.StavkeRacuna.Sum(x => x.Kolicina * x.Artikl.Cijena);
                invoicesView.Add(new RacunViewModel
                {
                    ID = item.ID,
                    Farmaceut = item.Farmaceut,
                    Datum = item.Datum,
                    UkupnaVrijednost = sum.ToString(),
                    Racun = item
                });
            }

            dgvInvoices.DataSource = invoicesView;
            dgvInvoices.Columns["UkupnaVrijednost"].HeaderText = "Uk vrijednost";
            dgvInvoices.Columns["Racun"].Visible = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.ShowDialog();
            await RefreshGUI();
        }

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            var invoiceView = dgvInvoices.CurrentRow?.DataBoundItem as RacunViewModel;
            if (invoiceView != null)
            {
                var invoice = invoiceView.Racun;
                InvoiceDetails invoiceDetails = new InvoiceDetails(invoice);
                invoiceDetails.ShowDialog();
                await RefreshGUI();
            }
        }
    }
}
