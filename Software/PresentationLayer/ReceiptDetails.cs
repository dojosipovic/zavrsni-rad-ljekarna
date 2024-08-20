using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
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
        private PrimkaServices primkaServices = new PrimkaServices();
        private NarudzbaServices narudzbaServices = new NarudzbaServices();
        private Primka _receipt = null;
        public ReceiptDetails(Primka receipt = null)
        {
            InitializeComponent();
            _receipt = receipt;
            if (_receipt != null)
            {
                dgvReceiptItems.Enabled = false;
                txtAmount.Enabled = false;
                cmbItems.Enabled = false;
                cmbOrder.Enabled = false;
                cmbSupplier.Enabled = false;
                txtDate.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
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
                var orders = await narudzbaServices.GetAll();
                orders.Insert(0, new Narudzba { ID = 0 });
                cmbOrder.DataSource = orders;

                SelectSupplier();
                
                if (_receipt.NarudzbaID != null) SelectOrder();
                else cmbOrder.SelectedIndex = 0;
                txtDate.Text = _receipt.DatumKnjizenja.ToString("dd.MM.yyyy HH:mm");
                _receipt.StavkePrimke = await primkaServices.GetReceiptItems(_receipt);
                RefreshGUI();
            }
        }

        private void SelectOrder()
        {
            for (int i = 0; i < cmbOrder.Items.Count; i++)
            {
                var order = cmbOrder.Items[i] as Narudzba;
                if (order.ID == _receipt.NarudzbaID)
                {
                    cmbOrder.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SelectSupplier()
        {
            for (int i = 0; i < cmbSupplier.Items.Count; i++)
            {
                var supplier = cmbSupplier.Items[i] as Dobavljac;
                if (supplier.ID == _receipt.DobavljacID)
                {
                    cmbSupplier.SelectedIndex = i;
                    break;
                }
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string dateTimeString = txtDate.Text.Replace(',', '.');
            string format = "dd.MM.yyyy HH:mm";
            DateTime receiptDate;
            bool success = DateTime.TryParseExact(dateTimeString, format, null, DateTimeStyles.None, out receiptDate);

            if (!success)
            {
                MessageBox.Show("Neispravan format datuma!");
                return;
            }

            var supplier = cmbSupplier.SelectedItem as Dobavljac;
            var order = cmbOrder.SelectedItem as Narudzba;

            _receipt.DobavljacID = supplier.ID;
            _receipt.DatumKnjizenja = receiptDate;
            _receipt.FarmaceutID = Login.User.ID;
            if (order.ID != 0) _receipt.NarudzbaID = order.ID;

            await SaveReceipt(_receipt);
        }

        private async Task SaveReceipt(Primka receipt)
        {
            try
            {
                await primkaServices.Add(receipt);
                Close();
            } catch (PrimkaException ex)
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
            if (message.Contains("FK_Primka_Narudzba")) return "Narudžba s tim brojem ne postoji!";
            if (message.Contains("FK_Primka_Dobavljac")) return "Dobavljač ne postoji!";
            if (message.Contains("unexpected number of rows (0)")) return "Jedan od dodanih artikala više ne postoji!";
            if (message.Contains("FK_Primka_Farmaceut")) return "Greška prilikom kreiranja, molimo prijavite se ponovno!";
            return message;
        }
    }
}
