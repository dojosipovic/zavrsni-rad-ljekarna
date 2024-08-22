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
    public partial class Doctors : Form
    {
        private LijecnikServices lijecnikServices = new LijecnikServices();
        private ReceptServices receptServices = new ReceptServices();
        public Doctors()
        {
            InitializeComponent();
        }

        private async void Doctors_Load(object sender, EventArgs e)
        {
            dgvDoctors.DataSource = await lijecnikServices.GetAll();

            dgvDoctors.Columns["Adresa"].Visible = false;
            dgvDoctors.Columns["Telefon"].Visible = false;
            dgvDoctors.Columns["UstanovaID"].Visible = false;
            dgvDoctors.Columns["Ustanova"].Visible = false;
            dgvDoctors.Columns["Recept"].Visible = false;
        }

        private async void dgvDoctors_SelectionChanged(object sender, EventArgs e)
        {
            var doctor = dgvDoctors.CurrentRow?.DataBoundItem as Lijecnik;
            if (doctor != null)
            {
                dgvPrescriptions.DataSource = await receptServices.GetDoctorPrescrioptions(doctor);
                dgvPrescriptions.Columns["Lijecnik"].Visible = false;
                dgvPrescriptions.Columns["StavkeRecepta"].Visible = false;
                dgvPrescriptions.Columns["LijecnikID"].Visible = false;
                dgvPrescriptions.Columns["PacijentID"].Visible = false;

                txtName.Text = doctor.Ime;
                txtSurname.Text = doctor.Prezime;
                txtAddress.Text = doctor.Adresa;
                txtTelephone.Text = doctor.Telefon;
            }
        }
    }
}
