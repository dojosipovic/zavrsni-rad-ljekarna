using BusinessLogicLayer;
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
    public partial class Orders : Form
    {
        private NarudzbaServices narudzbaServices = new NarudzbaServices();
        public Orders()
        {
            InitializeComponent();
        }

        private async void Orders_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvOrders.DataSource = await narudzbaServices.GetAll();
        }
    }
}
