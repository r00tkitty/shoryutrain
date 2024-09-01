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
    public partial class controllerSettingsControl : UserControl
    {
        public controllerSettingsControl()
        {
            InitializeComponent();
            InitializeControllerSettings();
        }
        private void InitializeControllerSettings()
        {
            trackBarDeadZone.Value = Properties.Settings.Default.Deadzone;
            deadZoneTextBox.Text = trackBarDeadZone.Value.ToString();
            defaultInputComboBox.SelectedItem = Properties.Settings.Default.InputMethod;

        }
        private void trackBarDeadZone_Scroll(object sender, EventArgs e)
        {
            deadZoneTextBox.Text = trackBarDeadZone.Value.ToString();
            Properties.Settings.Default.Deadzone = trackBarDeadZone.Value;

        }

        private void deadZoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(deadZoneTextBox.Text, out int value))
            {
                if (value >= trackBarDeadZone.Minimum && value <= trackBarDeadZone.Maximum)
                {
                    trackBarDeadZone.Value = value;
                    Properties.Settings.Default.Deadzone = value;
                }
            }
        }

        private void defaultInputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputMethod = defaultInputComboBox.SelectedItem.ToString();

        }

        private void controllerSettingsApplyBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

        }

        private void controllerSettingsControl_Load(object sender, EventArgs e)
        {

        }
    }
}
