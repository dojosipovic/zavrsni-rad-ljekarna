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

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var item = dgvItems.CurrentRow?.DataBoundItem as Artikl;
            if (item != null)
            {
                ItemDetails itemDetails = new ItemDetails(item);
                itemDetails.ShowDialog();
                await RefreshGUI();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ItemDetails itemDetails = new ItemDetails();
            itemDetails.ShowDialog();
            await RefreshGUI();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = dgvItems.CurrentRow?.DataBoundItem as Artikl;
            if (item != null)
            {
                try
                {
                    await artiklServices.Remove(item);
                } catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.InnerException is SqlException sqlEx)
                    {
                        string message = GetErrorMessage(sqlEx);
                        MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else MessageBox.Show(GetErrorMessage(ex), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    MessageBox.Show("Neočekivana greška" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                await RefreshGUI();
            }
        }

        private string GetErrorMessage(Exception sqlEx)
        {
            string message = sqlEx.Message;
            if (message.Contains("unexpected number of rows (0)")) return "Ovaj artikl ne postoji!";
            if (message.Contains("FK_StavkeRecepta_Artikl")) return "Artikl se nalazi u receptima!";
            if (message.Contains("FK_StavkeNarudzbe_Artikl")) return "Artikl se nalazi u narudžbama!";
            if (message.Contains("FK_StavkePrimke_Artikl")) return "Artikl se nalazi u primkama!";
            if (message.Contains("FK_StavkeRacuna_Artikl")) return "Artikl se nalazi u računima!";
            return message;
        }
    }
}
