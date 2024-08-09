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
    public partial class OrderDetails : Form
    {
        private ArtiklServices artiklServices = new ArtiklServices();
        private DobavljacService dobavljacService = new DobavljacService();
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
        }
    }
}
