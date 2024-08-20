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
    public partial class Receipts : Form
    {
        private PrimkaServices primkaServices = new PrimkaServices();
        public Receipts()
        {
            InitializeComponent();
        }

        private async void Receipts_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvReceipts.DataSource = await primkaServices.GetAll();
            dgvReceipts.Columns["StavkePrimke"].Visible = false;
            dgvReceipts.Columns["DobavljacID"].Visible = false;
            dgvReceipts.Columns["FarmaceutID"].Visible = false;
            dgvReceipts.Columns["FarmaceutID"].Visible = false;
            dgvReceipts.Columns["Narudzba"].Visible = false;

            dgvReceipts.Columns["DatumKnjizenja"].HeaderText = "Datum knjiženja";
            dgvReceipts.Columns["NarudzbaID"].HeaderText = "ID narudžbe";
            dgvReceipts.Columns["Dobavljac"].HeaderText = "Dobavljač";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ReceiptDetails receiptDetails = new ReceiptDetails();
            receiptDetails.ShowDialog();
            await RefreshGUI();
        }

        private async void btnDetails_ClickAsync(object sender, EventArgs e)
        {
            var receipt = dgvReceipts.CurrentRow?.DataBoundItem as Primka;
            if (receipt != null)
            {
                ReceiptDetails receiptDetails = new ReceiptDetails(receipt);
                receiptDetails.ShowDialog();
                await RefreshGUI();
            }
        }
    }
}
