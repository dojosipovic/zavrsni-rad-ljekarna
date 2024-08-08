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
    public partial class MeasureUnit : Form
    {
        private JedinicaMjereServices JedinicaMjereServices = new JedinicaMjereServices();
        public MeasureUnit()
        {
            InitializeComponent();
        }

        private async void MeasureUnit_Load(object sender, EventArgs e)
        {
            await RefreshGUI();
        }

        private async Task RefreshGUI()
        {
            dgvMeasureUnits.DataSource = await JedinicaMjereServices.GetAll();

            dgvMeasureUnits.Columns["Artikl"].Visible = false;
        }
    }
}
