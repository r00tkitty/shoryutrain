using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoryutrain
{
    public partial class aboutSettingsControl : UserControl
    {
        public aboutSettingsControl()
        {
            InitializeComponent();
            // Clear existing links if any
            aboutTextfield.Links.Clear();
            aboutTextfield.Links.Add(119, 20, "https://discord.com/invite/0pyTHFGvV3sA7QGX");

            shoryukenSettingsBG.Controls.Add(logoProgramAboutBox);
            logoProgramAboutBox.Location = new System.Drawing.Point(0, 0);
            logoProgramAboutBox.BackColor = Color.Transparent;

        }

        private void aboutTextfield_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });

        }

        private void eggField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
