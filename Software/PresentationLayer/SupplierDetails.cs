using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
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
    public partial class SupplierDetails : Form
    {
        private DobavljacService dobavljacService = new DobavljacService();
        private Dobavljac _dobavljac = null;
        public SupplierDetails(Dobavljac dobavljac = null)
        {
            InitializeComponent();
            _dobavljac = dobavljac;
        }

        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            if (_dobavljac != null)
            {
                txtOIB.Text = _dobavljac.OIB;
                txtName.Text = _dobavljac.Naziv;
                txtIBAN.Text = _dobavljac.IBAN;
                txtEmail.Text = _dobavljac.Email;
                txtAddress.Text = _dobavljac.Adresa;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool success = true;
            if (_dobavljac == null)
            {
                try
                {
                    var supplier = new Dobavljac
                    {
                        OIB = txtOIB.Text.Trim(),
                        Naziv = txtName.Text.Trim(),
                        Adresa = txtAddress.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        IBAN = txtIBAN.Text.Trim(),
                    };
                    await dobavljacService.Add(supplier);
                } catch (DobavljacException ex)
                {
                    success = false;
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success) Close();
        }
    }
}
