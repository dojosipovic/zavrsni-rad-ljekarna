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
    public partial class Prescriptions : Form
    {
        private ReceptServices receptServices = new ReceptServices();
        public Prescriptions()
        {
            InitializeComponent();
        }

        private async void Prescriptions_Load(object sender, EventArgs e)
        {
            dgvPrescriptions.DataSource = await receptServices.GetAll();

            dgvPrescriptions.Columns["StavkeRecepta"].Visible = false;
            dgvPrescriptions.Columns["LijecnikID"].Visible = false;
            dgvPrescriptions.Columns["PacijentID"].Visible = false;
        }

        private async void dgvPrescriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var prescription = dgvPrescriptions.CurrentRow?.DataBoundItem as Recept;
            if (prescription != null)
            {
                txtDoctor.Text = prescription.Lijecnik.ToString();
                txtID.Text = prescription.LijecnikID.ToString();
                txtPatient.Text = prescription.Pacijent.ToString();
                txtMBO.Text = prescription.Pacijent.MBO;
                txtDate.Text = prescription.Datum.ToString("dd.MM.yyyy.");

                dgvPrescriptionDetails.DataSource = await receptServices.GetPrescrioptionItems(prescription);
                dgvPrescriptionDetails.Columns["ReceptID"].Visible = false;
                dgvPrescriptionDetails.Columns["ArtiklID"].Visible = false;
                dgvPrescriptionDetails.Columns["Recept"].Visible = false;
                dgvPrescriptionDetails.Columns["Artikl"].DisplayIndex = 0;
            }
        }
    }
}
