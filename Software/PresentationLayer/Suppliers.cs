using BusinessLogicLayer;
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
    public partial class Suppliers : Form
    {
        private DobavljacService dobavljacService = new DobavljacService();
        public Suppliers()
        {
            InitializeComponent();
        }

        private async void Suppliers_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvSuppliers.DataSource = await dobavljacService.GetAll();

            dgvSuppliers.Columns["Narudzba"].Visible = false;
            dgvSuppliers.Columns["Primka"].Visible = false;
            dgvSuppliers.Columns["IBAN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dgvItems.Columns["JedinicaMjere"].HeaderText = "Jedinica mjere";
            //dgvItems.Columns["Kolicina"].HeaderText = "Količina";
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var supplier = dgvSuppliers.CurrentRow?.DataBoundItem as Dobavljac;
            if (supplier != null)
            {
                SupplierDetails supplierDetails = new SupplierDetails(supplier);
                supplierDetails.ShowDialog();
                await RefreshGUI();
            }
        }

        private async void btnAdd_ClickAsync(object sender, EventArgs e)
        {
            SupplierDetails supplierDetails = new SupplierDetails();
            supplierDetails.ShowDialog();
            await RefreshGUI();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var supplier = dgvSuppliers.CurrentRow?.DataBoundItem as Dobavljac;
            if (supplier != null)
            {
                try
                {
                    await dobavljacService.Remove(supplier);
                } catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.InnerException is SqlException sqlEx)
                    {
                        string message = GetErrorMessage(sqlEx);
                        MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else MessageBox.Show(GetErrorMessage(ex), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    MessageBox.Show("Neočekivana greška!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                await RefreshGUI();
            }
        }

        private string GetErrorMessage(Exception ex)
        {
            string message = ex.Message;
            if (message.Contains("FK_Narudzba_Dobavljac")) return "Dobavljač ima upisane narudžbe!";
            if (message.Contains("FK_Primka_Dobavljac")) return "Dobavljač ima upisane primke!";
            if (message.Contains("unexpected number of rows (0)")) return "Ovaj dobavljač ne postoji!";
            return message;
        }
    }
}
