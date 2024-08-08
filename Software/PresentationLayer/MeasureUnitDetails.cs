using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (_measureUnit == null)
            {
                try
                {
                    string id = txtID.Text.Trim();
                    string name = txtName.Text.Trim();
                    var measureUnit = new JedinicaMjere { ID = id, Naziv = name };
                    await jedinicaMjereServices.Add(measureUnit);
                } catch (JedinicaMjereException ex)
                {
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                } catch (Exception ex)
                {
                    MessageBox.Show("ID ili Naziv već postoje!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
            }
            else
            {
                try
                {
                    _measureUnit.Naziv = txtName.Text.Trim();
                    await jedinicaMjereServices.Update(_measureUnit);
                } catch (JedinicaMjereException ex)
                {
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                } catch (Exception ex)
                {
                    MessageBox.Show("Naziv već postoji!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
            }

            if (success) Close();
        }
    }
}
