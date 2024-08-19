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
    public partial class ReceiptDetails : Form
    {
        private DobavljacService dobavljacService = new DobavljacService();
        private ArtiklServices artiklServices = new ArtiklServices();
        private Primka _receipt = null;
        private bool newReceipt = true;
        public ReceiptDetails(Primka receipt = null)
        {
            InitializeComponent();
            _receipt = receipt;
            if (_receipt != null) newReceipt = false;
        }

        private async void ReceiptDetails_Load(object sender, EventArgs e)
        {
            cmbSupplier.DataSource = await dobavljacService.GetAll();
            cmbItems.DataSource = await artiklServices.GetAll();

            if (_receipt == null)
            {
                _receipt = new Primka();
                _receipt.StavkePrimke = new List<StavkePrimke>();
                _receipt.DatumKnjizenja = DateTime.Now;
                DateTime currentDate = DateTime.Now;
                txtDate.Text = currentDate.ToString("dd.MM.yyyy HH:mm");
            } else
            {
                /*
                SelectSupplier();
                SelectStatus();
                txtDate.Text = _order.Datum.ToString("dd.MM.yyyy HH:mm");
                _order.StavkeNarudzbe = await narudzbaServices.GetOrderItems(_order);*/
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplier = cmbSupplier.SelectedItem as Dobavljac;
            var orders = supplier.Narudzba.ToList();
            orders.Insert(0, new Narudzba { ID = 0 });
            cmbOrder.DataSource = orders;
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
            var receiptItem = new StavkePrimke { ArtiklID = item.ID, Artikl = item, Kolicina = amount };
            var receiptItems = _receipt.StavkePrimke.ToList();
            int indexOfItem = receiptItems.IndexOf(receiptItem);
            if (indexOfItem == -1) receiptItems.Add(receiptItem);
            else receiptItems[indexOfItem] = receiptItem;
            _receipt.StavkePrimke = receiptItems;
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            dgvReceiptItems.DataSource = _receipt.StavkePrimke;
            dgvReceiptItems.Columns["PrimkaID"].Visible = false;
            dgvReceiptItems.Columns["ArtiklID"].Visible = false;
            dgvReceiptItems.Columns["Primka"].Visible = false;
            dgvReceiptItems.Columns["Artikl"].DisplayIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = dgvReceiptItems.CurrentRow?.DataBoundItem as StavkePrimke;
            if (item != null)
            {
                var receiptItems = _receipt.StavkePrimke.ToList();
                receiptItems = receiptItems.FindAll(x => x.ArtiklID != item.ArtiklID);
                _receipt.StavkePrimke = receiptItems;
                RefreshGUI();
            }
        }
    }
}
