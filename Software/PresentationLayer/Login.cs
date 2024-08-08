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
    public partial class Login : Form
    {
        private FarmaceusServices farmaceusServices = new FarmaceusServices();
        public static Farmaceut User = null;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginUser();
            if (User != null) OpenMainForm();
        }

        private void OpenMainForm()
        {
            FrmMain frmMain = new FrmMain();
            Hide();
            frmMain.ShowDialog();
            Close();
        }

        private void LoginUser()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            var farmaceut = farmaceusServices.GetFarmaceutByKorime(username);

            if (farmaceut == null)
            {
                MessageBox.Show("Krivo korisničko ime ili lozinka", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (farmaceut.Lozinka == password)
            {
                User = farmaceut;
            }
            else
            {
                MessageBox.Show("Krivo korisničko ime ili lozinka", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
