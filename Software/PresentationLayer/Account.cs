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
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Account : Form
    {
        private FarmaceusServices farmaceusServices = new FarmaceusServices();
        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            var pharmacist = Login.User;
            txtAddress.Text = pharmacist.Adresa;
            txtEmail.Text = pharmacist.Email;
            txtName.Text = pharmacist.Ime;
            txtSurname.Text = pharmacist.Prezime;
            txtUsername.Text = pharmacist.Korime;
        }

        private Farmaceut CreatePharmacist(Farmaceut pharmacist)
        {
            return new Farmaceut
            {
                ID = pharmacist.ID,
                Adresa = pharmacist.Adresa,
                Ime = pharmacist.Ime,
                Email = pharmacist.Email,
                Korime = pharmacist.Korime,
                Lozinka = pharmacist.Lozinka,
                Prezime = pharmacist.Prezime,
            };
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var pharmacist = CreatePharmacist(Login.User);
            pharmacist.Adresa = txtAddress.Text.Trim();
            pharmacist.Ime = txtName.Text.Trim();
            pharmacist.Prezime = txtSurname.Text.Trim();
            pharmacist.Email = txtEmail.Text.Trim();

            await UpdatePharmacist(pharmacist);
        }

        private async Task UpdatePharmacist(Farmaceut pharmacist)
        {
            try
            {
                await farmaceusServices.Update(pharmacist);
                Login.User = pharmacist;
                txtOld.Text = "";
                txtNew.Text = "";
                txtRepeat.Text = "";
                MessageBox.Show("Podaci uspješno ažurirani!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (FarmaceutException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    string message = GetErrorMessage(sqlEx);
                    MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else MessageBox.Show(GetErrorMessage(ex), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                MessageBox.Show("Neočekivana greška", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetErrorMessage(Exception sqlEx)
        {
            string message = sqlEx.Message;
            if (message.Contains("UNIQUE_Farmaceut_Email")) return "Email već postoji!";
            return message;
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            var pharmacist = CreatePharmacist(Login.User);
            string oldPassword = txtOld.Text;
            string newPassword = txtNew.Text;
            string repeated = txtRepeat.Text;

            if (oldPassword != pharmacist.Lozinka) MessageBox.Show("Stara lozinka nije ispravna!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (newPassword != repeated) MessageBox.Show("Nove lozinke se ne podudaraju!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                pharmacist.Lozinka = newPassword;
                await UpdatePharmacist(pharmacist);
            }
        }
    }
}
