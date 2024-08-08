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
using System.Xml.Linq;

namespace PresentationLayer
{
    public partial class MeasureUnitDetails : Form
    {
        private JedinicaMjere _measureUnit { get; set; }
        private JedinicaMjereServices jedinicaMjereServices = new JedinicaMjereServices();

        public MeasureUnitDetails(JedinicaMjere measureUnit = null)
        {
            InitializeComponent();
            _measureUnit = measureUnit;
        }

        private void ItemDetails_Load(object sender, EventArgs e)
        {
            if (_measureUnit != null)
            {
                txtID.Text = _measureUnit.ID;
                txtName.Text = _measureUnit.Naziv;
                txtID.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool success = true;
            try
            {
                string id = txtID.Text.Trim();
                string name = txtName.Text.Trim();
                var measureUnit = new JedinicaMjere { Naziv = name };

                if (_measureUnit != null)
                {
                    measureUnit.ID = _measureUnit.ID;
                    await jedinicaMjereServices.Update(measureUnit);
                } else
                {
                    measureUnit.ID = id;
                    await jedinicaMjereServices.Add(measureUnit);
                }
            } catch (JedinicaMjereException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            } catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    string message = GetErrorMessage(sqlEx);
                    MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else MessageBox.Show("Greška prilikom dodavanja", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            } catch (Exception ex)
            {
                MessageBox.Show("Neočekivana greška", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }

            if (success) Close();
        }

        private string GetErrorMessage(SqlException sqlEx)
        {
            string message = sqlEx.Message;
            if (message.Contains("IX_JedinicaMjere")) return "Takav naziv već postoji!";
            if (message.Contains("PK_JedinicaMjere")) return "Takav ID već postoji!";
            return "Greška prilikom dodavanja";
        }
    }
}
