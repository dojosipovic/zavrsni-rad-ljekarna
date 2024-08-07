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
    public partial class FrmMain : Form
    {
        bool documentsPanelExpand = false;
        bool dataPanelExpand = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void documentsTransition_Tick(object sender, EventArgs e)
        {
            ToggleTransition(ref documentsPanel, ref documentsPanelExpand, ref documentsTransition, 250);
        }

        private void ToggleTransition(ref FlowLayoutPanel panel, ref bool expand, ref Timer transition, int maxHeight)
        {
            if (expand == false)
            {
                panel.Height += 10;
                if (panel.Height >= maxHeight)
                {
                    transition.Stop();
                    expand = true;
                    panel.Height = maxHeight;
                }
            } else
            {
                panel.Height -= 10;
                if (panel.Height <= 50)
                {
                    transition.Stop();
                    expand = false;
                    panel.Height = 50;
                }
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            dataTransition.Start();
        }

        private void dataTransition_Tick(object sender, EventArgs e)
        {
            ToggleTransition(ref dataPanel, ref dataPanelExpand, ref dataTransition, 200);
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            documentsTransition.Start();
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Form1());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            Text = GetTitleFromSender(sender);
            OpenForm(new Items());
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private string GetTitleFromSender(object sender)
        {
            return sender.ToString().Split(':')[1].Trim();
        }
    }
}
