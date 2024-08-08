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
                } catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.InnerException is SqlException sqlEx)
                    {
                        string message = GetErrorMessage(sqlEx);
                        MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Greška prilikom dodavanja", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                } catch (Exception ex)
                {
                    MessageBox.Show("Neočekivana greška", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
            }

            if (success) Close();
        }

        private string GetErrorMessage(SqlException sqlEx)
        {
            string message = sqlEx.Message;
            if (message.Contains("UNIQUE_Dobavljac_OIB")) return "OIB već postoji!";
            if (message.Contains("UNIQUE_Dobavljac_Naziv")) return"Naziv mora biti jedinstven";
            if (message.Contains("UNIQUE_Dobavljac_IBAN")) return"IBAN mora biti jedinstven";
            if (message.Contains("UNIQUE_Dobavljac_Email")) return "Email već postoji";
            return "Greška prilikom dodavanja";
        }
    }
}
