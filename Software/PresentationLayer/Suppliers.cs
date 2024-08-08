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
    }
}
