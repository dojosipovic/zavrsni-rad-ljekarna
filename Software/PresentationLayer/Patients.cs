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
    public partial class Patients : Form
    {
        private PacijentServices pacijentServices = new PacijentServices();
        private ReceptServices receptServices = new ReceptServices();
        public Patients()
        {
            InitializeComponent();
        }

        private async void Patients_Load(object sender, EventArgs e)
        {
            dgvPatients.DataSource = await pacijentServices.GetAll();

            dgvPatients.Columns["ID"].Visible = false;
            dgvPatients.Columns["Recept"].Visible = false;
            dgvPatients.Columns["Adresa"].Visible = false;
            dgvPatients.Columns["DatumRodenja"].Visible = false;
        }

        private async void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var patient = dgvPatients.CurrentRow?.DataBoundItem as Pacijent;
            if (patient != null)
            {
                txtName.Text = patient.Ime;
                txtSurname.Text = patient.Prezime;
                txtAddress.Text = patient.Adresa;
                txtDate.Text = patient.DatumRodenja?.ToString("dd.MM.yyyy");

                dgvPrescriptions.DataSource = await receptServices.GetPatientPrescrioptions(patient);
                dgvPrescriptions.Columns["LijecnikID"].Visible = false;
                dgvPrescriptions.Columns["PacijentID"].Visible = false;
                dgvPrescriptions.Columns["Pacijent"].Visible = false;
                dgvPrescriptions.Columns["StavkeRecepta"].Visible = false;
            }
        }
    }
}
