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
                } catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.InnerException is SqlException sqlEx)
                    {
                        string message = GetErrorMessage(sqlEx);
                        MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else MessageBox.Show("Greška prilikom brisanja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    MessageBox.Show("Neočekivana greška!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetErrorMessage(SqlException sqlEx)
        {
            string message = sqlEx.Message;
            if (message.Contains("FK_Artikl_JedinicaMjere")) return "Neki artikli koriste ovu jedinicu!";
            return "Greška prilikom brisanja!";
        }
    }
}
