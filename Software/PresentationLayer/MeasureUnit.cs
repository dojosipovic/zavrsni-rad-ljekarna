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

        private void MeasureUnit_Load(object sender, EventArgs e)
        {
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            dgvMeasureUnits.DataSource = JedinicaMjereServices.GetAll();

            dgvMeasureUnits.Columns["Artikl"].Visible = false;
        }
    }
}
