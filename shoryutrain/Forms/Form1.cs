using SharpDX.DirectInput; //DirectInput support
using SharpDX.XInput; //XInput support
using System; // General shit
using System.Diagnostics; // Debug shit
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader; // more debug shit
using System.Drawing.Text; // Draw shit
using System.Windows.Forms; // UI
using shoryutrain.Managers; // LET ME SPEAK TO YO MANAGER NIGGA

namespace shoryutrain // Application namespace
{
    public partial class Form1 : Form // Define the Form1 class that inherits from Form, making it a Windows Form
    {
        private int Deadzone = SettingsManager.Deadzone; // Define a deadzone constant value
        private DirectInput directInput; // Make DirectInput object to handle DirectInput
        private Joystick joystick;  // Joystick for DirectInput joystick info
        private Controller xinputController; // Controller object for XInput
        private System.Windows.Forms.Timer inputPollTimer; // Timer to poll inputs
        private string inputMethod = SettingsManager.InputMethod; // Default to XInput
        private InputManager inputManager;


        //DirectInput un-fucking
        private int calibrationX = 0;
        private int calibrationY = 0;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Init()
        {
            // Ensure inputMethodMenu is initialized
            if (inputMethodMenu == null)
            {
                throw new InvalidOperationException("inputMethodMenu is not initialized.");
            }

            // Retrieve the saved input method from settings
            string savedInputMethod = Properties.Settings.Default.InputMethod;

            // Default to a known input method if none is saved
            if (string.IsNullOrEmpty(savedInputMethod))
            {
                savedInputMethod = "XInput"; // Default method
            }

            // Find the ToolStripMenuItem corresponding to the saved input method
            ToolStripMenuItem selectedItem = inputMethodMenu.DropDownItems
                .OfType<ToolStripMenuItem>()
                .FirstOrDefault(item => item.Text.Equals(savedInputMethod, StringComparison.OrdinalIgnoreCase));

            // If no matching item found, default to "XInput"
            if (selectedItem == null)
            {
                selectedItem = inputMethodMenu.DropDownItems
                    .OfType<ToolStripMenuItem>()
                    .FirstOrDefault(item => item.Text.Equals("XInput", StringComparison.OrdinalIgnoreCase));
            }

            // Update menu selection
            if (selectedItem != null)
            {
                UpdateMenuSelection(selectedItem);
            }

            // Initialize inputManager with the selected method
            inputManager = new InputManager(savedInputMethod);
            inputManager.OnInputChanged += UpdateButtonColors;
        }

        private void InitializeTimer()
        {
            inputPollTimer = new System.Windows.Forms.Timer(); // Create a new Timer object
            inputPollTimer.Interval = CalculateTimerInterval(60); // I don't want any offset. calcluate the exact numer of ms per frame on 60fps
            inputPollTimer.Tick += InputPollTimer_Tick; // Add the event handler for the Tick event
            inputPollTimer.Start(); // Start the timer
        }
        private int CalculateTimerInterval(int fps) // calculate the interval by dividing a second (1000ms) by 60 (frames per second)
        {
            return (int)Math.Round(1000.0 / fps);
        }

        private string GetXInputControllerName()
        {
            // In the absence of a direct way to get the name, match against DirectInput devices
            directInput = new DirectInput(); // Initialize DirectInput

            foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)) // Enumerate all connected gamepads
            {
                // Since exact matching is complex, a basic check against known GUIDs or properties could be done
                // For example, check against common product GUIDs or other known identifiers
                // This is a simplified approach and may need refinement for more accurate identification
                return deviceInstance.InstanceName; // Return the name of the matched gamepad
            }
            return "Unknown XInput Controller"; // Return a default name if no match is found

        }

        private void InputPollTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                inputManager.PollInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while polling the controller: {ex.Message}");
            }
        }







        private void directInputNeutralSetter_Click(object sender, EventArgs e)
        {
            // Show a message box to prompt the user to leave the stick in neutral position
            var result = MessageBox.Show("To calibrate the stick, put the stick in a neutral position." + Environment.NewLine + "Do not touch the stick." + Environment.NewLine + "Press \"OK\" when ready.",
                                         "Stick Calibration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {

                try
                {
                    inputManager.CalibrateNeutral();
                    MessageBox.Show("Neutral position calibrated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void UpdateButtonColors(int x, int y, bool dpadDown, bool dpadUp, bool dpadRight, bool dpadLeft)
        {
            ResetButtonColors();
            // Determine which button to highlight based on the X and Y axis values
            if (y > Deadzone || dpadUp)
            {
                if (x < -Deadzone || dpadLeft) // Top-left direction
                {
                    buttonUpLeft.BackColor = Color.Black;
                    buttonUpLeft.ForeColor = Color.White;
                }
                else if (x > Deadzone || dpadRight) // Top-right direction
                {
                    buttonUpRight.BackColor = Color.Black;
                    buttonUpRight.ForeColor = Color.White;
                }
                else // Up direction
                {
                    buttonUp.BackColor = Color.Black;
                    buttonUp.ForeColor = Color.White;
                }
            }
            else if (y < -Deadzone || dpadDown)
            {
                if (x < -Deadzone || dpadLeft) // Bottom-left direction
                {
                    buttonDownLeft.BackColor = Color.Black;
                    buttonDownLeft.ForeColor = Color.White;
                }
                else if (x > Deadzone || dpadRight) // Bottom-right direction
                {
                    buttonDownRight.BackColor = Color.Black;
                    buttonDownRight.ForeColor = Color.White;
                }
                else // Down direction
                {
                    buttonDown.BackColor = Color.Black;
                    buttonDown.ForeColor = Color.White;
                }
            }
            else
            {
                if (x < -Deadzone || dpadLeft) // Left direction
                {
                    buttonLeft.BackColor = Color.Black;
                    buttonLeft.ForeColor = Color.White;
                }
                else if (x > Deadzone || dpadRight) // Right direction
                {
                    buttonRight.BackColor = Color.Black;
                    buttonRight.ForeColor = Color.White;
                }
                else // Center position
                {
                    buttonNeutral.BackColor = Color.Black;
                    buttonNeutral.ForeColor = Color.White;
                }
            }
        }



        private void ResetButtonColors()
        {
            buttonUp.BackColor = SystemColors.Control;
            buttonUp.ForeColor = SystemColors.ControlText;

            buttonDown.BackColor = SystemColors.Control;
            buttonDown.ForeColor = SystemColors.ControlText;

            buttonLeft.BackColor = SystemColors.Control;
            buttonLeft.ForeColor = SystemColors.ControlText;

            buttonRight.BackColor = SystemColors.Control;
            buttonRight.ForeColor = SystemColors.ControlText;

            buttonNeutral.BackColor = SystemColors.Control;
            buttonNeutral.ForeColor = SystemColors.ControlText;

            buttonUpLeft.BackColor = SystemColors.Control;
            buttonUpLeft.ForeColor = SystemColors.ControlText;

            buttonUpRight.BackColor = SystemColors.Control;
            buttonUpRight.ForeColor = SystemColors.ControlText;

            buttonDownLeft.BackColor = SystemColors.Control;
            buttonDownLeft.ForeColor = SystemColors.ControlText;

            buttonDownRight.BackColor = SystemColors.Control;
            buttonDownRight.ForeColor = SystemColors.ControlText;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init(); 
            string savedInputMethod = Properties.Settings.Default.InputMethod;

            // Ensure that MainMenuStrip.Items[1] is a ToolStripMenuItem
            if (MainMenuStrip.Items[1] is ToolStripMenuItem settingsMenuItem)
            {
                // Check if savedInputMethod is null or empty
                if (string.IsNullOrEmpty(savedInputMethod))
                {
                    // Default to a known input method, e.g., "XInput"
                    savedInputMethod = "XInput";
                }

                // Find the menu item that matches the saved input method
                ToolStripMenuItem selectedItem = settingsMenuItem.DropDownItems
                    .OfType<ToolStripMenuItem>()
                    .FirstOrDefault(item => item.Text.Equals(savedInputMethod, StringComparison.OrdinalIgnoreCase));

                if (selectedItem != null)
                {
                    UpdateMenuSelection(selectedItem);
                }
                else
                {
                    // Default to XInput if no matching input method is found
                    ToolStripMenuItem defaultItem = settingsMenuItem.DropDownItems
                        .OfType<ToolStripMenuItem>()
                        .FirstOrDefault(item => item.Text.Equals("XInput", StringComparison.OrdinalIgnoreCase));

                    if (defaultItem != null)
                    {
                        UpdateMenuSelection(defaultItem);
                    }
                }
            }
        }




        private void UpdateMenuSelection(ToolStripMenuItem selectedItem)
        {
            if (inputMethodMenu == null)
            {
                throw new InvalidOperationException("inputMethodMenu is not initialized.");
            }

            foreach (ToolStripMenuItem item in inputMethodMenu.DropDownItems)
            {
                item.Checked = item == selectedItem;
            }
        }



        private void inputMethodMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                string selectedInputMethod = clickedItem.Text;

                // Update settings with the selected input method
                Properties.Settings.Default.InputMethod = selectedInputMethod;
                Properties.Settings.Default.Save();

                // Reinitialize the InputManager with the new method
                inputManager = new InputManager(selectedInputMethod);
                inputManager.OnInputChanged += UpdateButtonColors;

                // Update UI to reflect the new selection
                UpdateMenuSelection(clickedItem);
            }
        }






        private void xinputMenuItem_Click(object sender, EventArgs e)
        {
            inputMethodMenuItem_Click(sender, e);
        }

        private void directInputMenuItem_Click(object sender, EventArgs e)
        {
            inputMethodMenuItem_Click(sender, e);
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void About_Click(object sender, EventArgs e)
        {

        }
       


        private void connectedControllerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();

            settingsForm.ShowDialog();
        }
    }
}
