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
    public partial class Pharmacists : Form
    {
        private FarmaceusServices farmaceusServices = new FarmaceusServices();
        public Pharmacists()
        {
            InitializeComponent();
        }

        private async void Pharmacists_Load(object sender, EventArgs e)
        {
            dgvPharmacists.DataSource = await farmaceusServices.GetAll();
            dgvPharmacists.Columns["Korime"].Visible = false;
            dgvPharmacists.Columns["Lozinka"].Visible = false;
            dgvPharmacists.Columns["Adresa"].Visible = false;
            dgvPharmacists.Columns["Email"].Visible = false;
            dgvPharmacists.Columns["Narudzba"].Visible = false;
            dgvPharmacists.Columns["Primka"].Visible = false;
            dgvPharmacists.Columns["Racun"].Visible = false;
        }

        private void dgvPharmacists_SelectionChanged(object sender, EventArgs e)
        {
            var pharmacist = dgvPharmacists.CurrentRow?.DataBoundItem as Farmaceut;
            if (pharmacist != null)
            {
                txtAddress.Text = pharmacist.Adresa;
                txtEmail.Text = pharmacist.Email;
                txtName.Text = pharmacist.Ime;
                txtSurname.Text = pharmacist.Prezime;
            }
        }
    }
}
