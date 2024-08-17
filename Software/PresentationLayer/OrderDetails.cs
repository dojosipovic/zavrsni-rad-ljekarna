using BusinessLogicLayer;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class OrderDetails : Form
    {
        private ArtiklServices artiklServices = new ArtiklServices();
        private DobavljacService dobavljacService = new DobavljacService();
        private StatusServices statusServices = new StatusServices();
        private NarudzbaServices narudzbaServices = new NarudzbaServices();
        private Narudzba _order = null;

        public OrderDetails(Narudzba order = null)
        {
            InitializeComponent();
            if (order != null) _order = order;
            else
            {
                _order = new Narudzba();
                _order.StavkeNarudzbe = new List<StavkeNarudzbe>();
                _order.Status = StatusNarudzbeEnum.Uizradi;
                _order.Datum = DateTime.Now;
            }
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
            var orderItem = new StavkeNarudzbe { ArtiklID = item.ID, Artikl = item, Kolicina = amount };
            var orderItems = _order.StavkeNarudzbe.ToList();
            int indexOfItem = orderItems.IndexOf(orderItem);
            if (indexOfItem == -1) orderItems.Add(orderItem);
            else orderItems[indexOfItem] = orderItem;
            _order.StavkeNarudzbe = orderItems;
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            dgvOrderItems.DataSource = _order.StavkeNarudzbe;

            dgvOrderItems.Columns["ArtiklID"].Visible = false;
            dgvOrderItems.Columns["NarudzbaID"].Visible = false;
            dgvOrderItems.Columns["Narudzba"].Visible = false;

            dgvOrderItems.Columns["Artikl"].DisplayIndex = 0;
            dgvOrderItems.Columns["Kolicina"].DisplayIndex = 1;
        }

        private async void OrderDetails_Load(object sender, EventArgs e)
        {
            cmbItems.DataSource = await artiklServices.GetAll();
            cmbSupplier.DataSource = await dobavljacService.GetAll();
            cmbStatus.DataSource = await statusServices.GetAll();

            DateTime currentDate = DateTime.Now;
            txtDate.Text = currentDate.ToString("dd.MM.yyyy HH:mm");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = dgvOrderItems.CurrentRow?.DataBoundItem as StavkeNarudzbe;
            if (item != null)
            {
                var orderItems = _order.StavkeNarudzbe.ToList();
                orderItems = orderItems.FindAll(x => x.ArtiklID != item.ArtiklID);
                _order.StavkeNarudzbe = orderItems;
                RefreshGUI();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string dateTimeString = txtDate.Text.Replace(',', '.');
            MessageBox.Show(dateTimeString);
            string format = "dd.MM.yyyy HH:mm";
            DateTime orderDate;
            bool success = DateTime.TryParseExact(dateTimeString, format, null, DateTimeStyles.None, out orderDate);

            if (!success)
            {
                MessageBox.Show("Neispravan format datuma!");
                return;
            }

            var supplier = cmbSupplier.SelectedItem as Dobavljac;
            var status = cmbStatus.SelectedItem as StatusNarudzbe;
            _order.Dobavljac = supplier;
            _order.Datum = orderDate;
            _order.FarmaceutID = Login.User.ID;
            _order.StatusNarudzbe = status;

            await SaveOrder(_order);
        }

        private async Task SaveOrder(Narudzba order)
        {
            await narudzbaServices.Add(order);
        }
    }
}
