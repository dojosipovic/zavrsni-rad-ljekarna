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
    public partial class Hospitals : Form
    {
        private UstanovaServices ustanovaServices = new UstanovaServices();
        public Hospitals()
        {
            InitializeComponent();
        }

        private async void Hospitals_Load(object sender, EventArgs e)
        {
            dgvHospitals.DataSource = await ustanovaServices.GetAll();
            dgvHospitals.Columns["ID"].Visible = false;
            dgvHospitals.Columns["Lijecnik"].Visible = false;
        }

        private void dgvHospitals_SelectionChanged(object sender, EventArgs e)
        {
            var hospital = dgvHospitals.CurrentRow?.DataBoundItem as Ustanova;
            if (hospital != null)
            {
                dgvDoctors.DataSource = hospital.Lijecnik.ToList();
                dgvDoctors.Columns["Ustanova"].Visible = false;
                dgvDoctors.Columns["Recept"].Visible = false;
                dgvDoctors.Columns["ID"].Visible = false;
                dgvDoctors.Columns["UstanovaID"].Visible = false;
            }
        }
    }
}
