using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoryutrain
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel1.Controls.Clear();
            // Load the appropriate UserControl based on the selected node
            if (e.Node.Text == "About")
            {
                aboutSettingsControl aboutControl = new aboutSettingsControl();
                aboutControl.Dock = DockStyle.Fill; // Make the control fill the panel
                panel1.Controls.Add(aboutControl);
            }

            else if (e.Node.Text == "Appearance")
            {
                interfaceSettingsControl interfaceControl = new interfaceSettingsControl();
                interfaceControl.Dock = DockStyle.Fill; 
                panel1.Controls.Add(interfaceControl);
            }
            else if (e.Node.Text == "Controller")
            {
                controllerSettingsControl controllerControl = new controllerSettingsControl();
                controllerControl.Dock = DockStyle.Fill;
                panel1.Controls.Add(controllerControl);
            }

        }
    }
}
