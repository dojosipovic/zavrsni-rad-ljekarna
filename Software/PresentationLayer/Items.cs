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
    public partial class Items : Form
    {
        private ArtiklServices artiklServices = new ArtiklServices();
        public Items()
        {
            InitializeComponent();
        }

        private async void Items_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvItems.DataSource = await artiklServices.GetAll();

            dgvItems.Columns["ID"].Visible = false;
            dgvItems.Columns["JedinicaMjereID"].Visible = false;
            dgvItems.Columns["StavkeNarudzbe"].Visible = false;
            dgvItems.Columns["StavkePrimke"].Visible = false;
            dgvItems.Columns["StavkeRacuna"].Visible = false;
            dgvItems.Columns["StavkeRecepta"].Visible = false;

            dgvItems.Columns["JedinicaMjere"].HeaderText = "Jedinica mjere";
            dgvItems.Columns["Kolicina"].HeaderText = "Količina";
        }
    }
}
