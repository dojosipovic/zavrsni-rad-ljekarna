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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ItemDetails : Form
    {
        private Artikl _item = null;
        private JedinicaMjereServices jedinicaMjereServices = new JedinicaMjereServices();
        private ArtiklServices artiklServices = new ArtiklServices();
        public ItemDetails(Artikl item = null)
        {
            InitializeComponent();
            _item = item;
        }

        private async void ItemDetails_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.DataSource = await jedinicaMjereServices.GetAll();
            if (_item != null)
            {
                txtName.Text = _item.Naziv;
                txtAmount.Text = _item.Kolicina.ToString();
                txtPrice.Text = _item.Cijena.ToString();

                foreach(JedinicaMjere unit in cmbMeasureUnit.Items)
                {
                    if (unit.ID == _item.JedinicaMjereID)
                    {
                        cmbMeasureUnit.SelectedItem = unit;
                        break;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            JedinicaMjere measureUnit = cmbMeasureUnit.SelectedItem as JedinicaMjere;
            string name = txtName.Text;
            int amount;
            double price;
            bool validAmount = int.TryParse(txtAmount.Text, out amount);
            bool validPrice = double.TryParse(txtPrice.Text, out price) && Regex.IsMatch(txtPrice.Text, @"^\d+(\,\d+)?$");

            if (!validAmount) MessageBox.Show("Količina mora biti cijeli broj!", "Unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!validPrice) MessageBox.Show("Cijena mora biti broj sa zarezom!", "Unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                var item = new Artikl
                {
                    Naziv = name,
                    Cijena = price,
                    Kolicina = amount,
                    JedinicaMjereID = measureUnit.ID,
                };
                await SaveItem(item);
            }
        }

        private async Task SaveItem(Artikl item)
        {
            bool success = true;
            try
            {
                if (_item == null) await artiklServices.Add(item);
                else
                {
                    item.ID = _item.ID;
                    await artiklServices.Update(item);
                }
            } catch (ArtiklException ex)
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
            if (message.Contains("UNIQUE_Artikl_Naziv")) return "Takav naziv artikla već postoji!";
            if (message.Contains("FK_Artikl_JedinicaMjere")) return "Ova jedinica mjere ne postoji!";
            return "Greška prilikom dodavanja";
        }
    }
}
