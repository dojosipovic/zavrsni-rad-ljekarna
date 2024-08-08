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
    public partial class MeasureUnit : Form
    {
        private JedinicaMjereServices jedinicaMjereServices = new JedinicaMjereServices();
        public MeasureUnit()
        {
            InitializeComponent();
        }

        private async void MeasureUnit_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvMeasureUnits.DataSource = await jedinicaMjereServices.GetAll();

            dgvMeasureUnits.Columns["Artikl"].Visible = false;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var measureUnit = dgvMeasureUnits.CurrentRow?.DataBoundItem as JedinicaMjere;
            if (measureUnit != null)
            {
                MeasureUnitDetails measureUnitDetails = new MeasureUnitDetails(measureUnit);
                measureUnitDetails.ShowDialog();
                await RefreshGUI();
            }
        }

        private async void btnAdd_ClickAsync(object sender, EventArgs e)
        {
            MeasureUnitDetails measureUnitDetails = new MeasureUnitDetails();
            measureUnitDetails.ShowDialog();
            await RefreshGUI();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var measureUnit = dgvMeasureUnits.CurrentRow?.DataBoundItem as JedinicaMjere;
            if (measureUnit != null)
            {
                try
                {
                    await jedinicaMjereServices.Remove(measureUnit);
                    await RefreshGUI();
                } catch
                {
                    MessageBox.Show("Ne možete obrisati jedinicu na koju su povezani artikli!");
                }
            }
        }
    }
}
