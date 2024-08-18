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
            btnDelete.Enabled = order.Status == StatusNarudzbeEnum.Uizradi;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.ShowDialog();
            await RefreshGUI();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var order = dgvOrders.CurrentRow?.DataBoundItem as Narudzba;
            if (order != null)
            {
                OrderDetails orderDetails = new OrderDetails(order);
                orderDetails.ShowDialog();
                await RefreshGUI();
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            var order = dgvOrders.CurrentRow.DataBoundItem as Narudzba;
            btnDelete.Enabled = order.Status == StatusNarudzbeEnum.Uizradi;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var order = dgvOrders.CurrentRow.DataBoundItem as Narudzba;
            try
            {
                await narudzbaServices.Remove(order);
            } catch (NarudzbaException ex)
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
                MessageBox.Show(GetErrorMessage(ex), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await RefreshGUI();
        }

        private string GetErrorMessage(Exception ex)
        {
            string message = ex.Message;
            if (message.Contains("FK_Primka_Narudzba")) return "Narudžba je povezana s primkom!";
            if (message.Contains("Value cannot be null.")) return "Narudžba ne postoji!";
            return message;
        }
    }
}
