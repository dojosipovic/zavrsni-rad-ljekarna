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
    public partial class Orders : Form
    {
        private NarudzbaServices narudzbaServices = new NarudzbaServices();
        public Orders()
        {
            InitializeComponent();
        }

        private async void Orders_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvOrders.DataSource = await narudzbaServices.GetAll();

            dgvOrders.Columns["Primka"].Visible = false;
            dgvOrders.Columns["StavkeNarudzbe"].Visible = false;
            dgvOrders.Columns["DobavljacID"].Visible = false;
            dgvOrders.Columns["FarmaceutID"].Visible = false;
            dgvOrders.Columns["StatusID"].Visible = false;
            dgvOrders.Columns["Status"].Visible = false;

            dgvOrders.Columns["StatusNarudzbe"].HeaderText = "Status";
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var order = dgvOrders.CurrentRow.DataBoundItem as Narudzba;
            btnEdit.Enabled = order.Status == StatusNarudzbeEnum.Uizradi;
        }
    }
}
