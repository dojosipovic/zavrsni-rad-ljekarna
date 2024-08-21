using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class InvoiceDetails : Form
    {
        private ArtiklServices artiklServices = new ArtiklServices();
        private RacunServices racunServices = new RacunServices();
        private Racun _invoice = null;
        public InvoiceDetails(Racun invoice = null)
        {
            InitializeComponent();
            _invoice = invoice;
            if (_invoice != null)
            {
                txtAmount.Enabled = false;
                txtDate.Enabled = false;
                cmbItems.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private async void InvoiceDetails_Load(object sender, EventArgs e)
        {
            cmbItems.DataSource = await artiklServices.GetAll();

            if (_invoice == null)
            {
                _invoice = new Racun();
                _invoice.StavkeRacuna = new List<StavkeRacuna>();
                _invoice.Datum = DateTime.Now;
                DateTime currentDate = DateTime.Now;
                txtDate.Text = currentDate.ToString("dd.MM.yyyy HH:mm");
            } else
            {
                txtDate.Text = _invoice.Datum.ToString("dd.MM.yyyy HH:mm");
                _invoice.StavkeRacuna = await racunServices.GetInvoiceItems(_invoice);
            }

            RefreshGUI();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var item = cmbItems.SelectedItem as Artikl;
            int amount;
            bool isConverted = int.TryParse(txtAmount.Text, out amount);
            if (!isConverted) MessageBox.Show("Broj mora biti cijeli!", "Unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (amount < 1) MessageBox.Show("Broj mora biti veći od 0!", "Unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else AddItem(item, amount);
        }

        private void AddItem(Artikl item, int amount)
        {
            var invoiceItem = new StavkeRacuna { ArtiklID = item.ID, Artikl = item, Kolicina = amount };
            var invoiceItems = _invoice.StavkeRacuna.ToList();
            int indexOfItem = invoiceItems.IndexOf(invoiceItem);
            if (indexOfItem == -1) invoiceItems.Add(invoiceItem);
            else invoiceItems[indexOfItem] = invoiceItem;
            _invoice.StavkeRacuna = invoiceItems;
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            var invoiceItemsViewModel = _invoice.StavkeRacuna.Select(item => new StavkeRacunaViewModel
            {
                Artikl = item.Artikl,
                Cijena = item.Artikl.Cijena,
                Kolicina = item.Kolicina,
                StavkaRacuna = item
            }).ToList();

            double sum = 0;
            invoiceItemsViewModel.ForEach(x => sum += x.UkupnaCijena);
            txtSum.Text = sum.ToString();
            dgvInvoiceItems.DataSource = invoiceItemsViewModel;
            
            dgvInvoiceItems.Columns["StavkaRacuna"].Visible = false;
            dgvInvoiceItems.Columns["UkupnaCijena"].HeaderText = "Uk cijena";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var itemView = dgvInvoiceItems.CurrentRow?.DataBoundItem as StavkeRacunaViewModel;
            if (itemView != null)
            {
                var item = itemView.Artikl;
                var invoiceItems = _invoice.StavkeRacuna.ToList();
                invoiceItems = invoiceItems.FindAll(x => x.ArtiklID != item.ID);
                _invoice.StavkeRacuna = invoiceItems;
                RefreshGUI();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string dateTimeString = txtDate.Text.Replace(',', '.');
            string format = "dd.MM.yyyy HH:mm";
            DateTime invoiceDate;
            bool success = DateTime.TryParseExact(dateTimeString, format, null, DateTimeStyles.None, out invoiceDate);

            if (!success)
            {
                MessageBox.Show("Neispravan format datuma!");
                return;
            }

            _invoice.Datum = invoiceDate;
            _invoice.FarmaceutID = Login.User.ID;

            await SaveInvoice(_invoice);
        }

        private async Task SaveInvoice(Racun invoice)
        {
            try
            {
                await racunServices.Add(invoice);
                Close();
            } catch (RacunException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    string message = GetErrorMessage(sqlEx);
                    MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else MessageBox.Show(GetErrorMessage(ex), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                MessageBox.Show("Neočekivana greška", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetErrorMessage(Exception sqlEx)
        {
            string message = sqlEx.Message;
            if (message.Contains("unexpected number of rows (0)")) return "Jedan od artikala ne postoji!";
            if (message.Contains("FK_Racun_Farmaceut")) return "Greška prilikom kreiranja, molimo prijavite se ponovno!";
            return message;
        }
    }
}
