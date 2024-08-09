using SharpDX.DirectInput;
using SharpDX.XInput;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Windows.Forms;

namespace shoryutrain
{
    public partial class Form1 : Form
    {
        private const int Deadzone = 20000; // Define a deadzone constant value
        private DirectInput directInput;
        private Joystick joystick;  
        private Controller xinputController; // Controller object for XInput
        private System.Windows.Forms.Timer inputPollTimer;
        private bool useDirectInput = false; // Default to XInput
        public Form1()
        {

            InitializeComponent();
            InitController();
            InitializeTimer();
        }

        private void InitController()
        {
            try
            {
                if (useDirectInput)
                {
                    InitializeDirectInputController();
                }
                else
                {
                    InitializeXInputController();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the controller: {ex.Message}"); // Show error message if initialization fails
            }
        }

        private void InitializeDirectInputController()
        {
            directInput = new DirectInput(); // Initialize DirectInput
            var joystickGuid = Guid.Empty; // Initialize GUID for joystick

            foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)) // Enumerate all connected gamepads
            {
                joystickGuid = deviceInstance.InstanceGuid; // Get the GUID of the first gamepad
                connectedControllerName.Text = "Connected controller: " + deviceInstance.InstanceName; // Set textbox text to the name of the connected controller
                break; // Exit the loop once a gamepad is found
            }

            if (joystickGuid == Guid.Empty)
            {
                MessageBox.Show("There is no controller detected.");
                connectedControllerName.Text = "There is no controller connected."; // Set textbox text if no gamepad is found
                return;
            }

            joystick = new Joystick(directInput, joystickGuid); // Create a new Joystick object with the found GUID
            joystick.Acquire(); // Acquire the joystick for use
            xinputController = null; // Ensure XInput controller is not used
        }

        private void InitializeXInputController()
        {
            xinputController = new Controller(UserIndex.One); // Initialize the first XInput controller

            if (xinputController.IsConnected)
            {
                string controllerName = GetXInputControllerName();
                connectedControllerName.Text = "Connected controller: " + controllerName; // Set textbox text to the name of the connected controller
            }
            else
            {
                MessageBox.Show("There is no Xinput controller detected." + Environment.NewLine + "Try using DirectInput");
                connectedControllerName.Text = "There is no controller connected."; // Set textbox text if no Xbox controller is connected
                return;
            }

            joystick = null; // Ensure DirectInput joystick is not used
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


        private void InitializeTimer()
        {
            inputPollTimer = new System.Windows.Forms.Timer(); // Create a new Timer object
            inputPollTimer.Interval = CalculateTimerInterval(60); // Set the timer interval to approximately 16 milliseconds (60 FPS)
            inputPollTimer.Tick += InputPollTimer_Tick; // Add the event handler for the Tick event
            inputPollTimer.Start(); // Start the timer
        }
        private int CalculateTimerInterval(int fps)
        {
            return (int)Math.Round(1000.0 / fps);
        }


        private void InputPollTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (useDirectInput)
                {
                    if (joystick == null)
                    {
                        return; // Exit if joystick is not initialized
                    }

                    joystick.Poll(); // Poll the joystick for its current state
                    var state = joystick.GetCurrentState(); // Get the current state of the joystick

                    int x = state.X; // Get the X axis value
                    int y = state.Y; // Get the Y axis value
                    bool dpadUp = false;
                    bool dpadDown = false;
                    bool dpadLeft = false;
                    bool dpadRight = false;

                    Debug.WriteLine($"DirectInput - X: {x}, Y: {y}");



                    ResetButtonColors(); // Reset the colors of all buttons to their default

                    UpdateButtonColors(x, y, dpadDown, dpadUp, dpadRight, dpadLeft); // Update button colors based on controller state
                }
                else
                {
                    if (xinputController == null || !xinputController.IsConnected)
                    {
                        return; // Exit if XInput controller is not initialized or not connected
                    }

                    var state = xinputController.GetState(); // Get the current state of the XInput controller
                    int x = state.Gamepad.LeftThumbX; // Get the X axis value of the left thumbstick
                    int y = state.Gamepad.LeftThumbY; // Get the Y axis value of the left thumbstick
                    var buttons = state.Gamepad.Buttons;

                    bool dpadUp = (buttons & GamepadButtonFlags.DPadUp) == GamepadButtonFlags.DPadUp;
                    bool dpadDown = (buttons & GamepadButtonFlags.DPadDown) == GamepadButtonFlags.DPadDown;
                    bool dpadRight = (buttons & GamepadButtonFlags.DPadRight) == GamepadButtonFlags.DPadRight;
                    bool dpadLeft = (buttons & GamepadButtonFlags.DPadLeft) == GamepadButtonFlags.DPadLeft;

                    Debug.WriteLine($"XInput - X: {x}, Y: {y}");


                    ResetButtonColors(); // Reset the colors of all buttons to their default

                    UpdateButtonColors(x, y, dpadDown, dpadUp, dpadRight, dpadLeft); // Update button colors based on controller state
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while polling the controller: {ex.Message}"); // Show error message if polling fails
            }
        }

        private void UpdateButtonColors(int x, int y, bool dpadDown, bool dpadUp, bool dpadRight, bool dpadLeft)
        {

            y = -y; // Invert the Y-axis value

            // Determine which button to highlight based on the X and Y axis values
            if (y < -Deadzone || dpadUp)
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
            else if (y > Deadzone || dpadDown)
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
        private void UpdateMenuSelection(ToolStripMenuItem selectedItem)
        {
            foreach (ToolStripMenuItem item in ((ToolStripMenuItem)MainMenuStrip.Items[0]).DropDownItems) // Iterate through all items in the settings menu
            {
                item.Checked = item == selectedItem; // Check the selected item and uncheck others
            }
        }


        private void xinputMenuItem_Click(object sender, EventArgs e)
        {
            useDirectInput = false; // Set flag to use XInput
            UpdateMenuSelection((ToolStripMenuItem)sender); // Update the menu selection
            InitController(); // Reinitialize the controller to use XInput
        }

        private void directInputMenuItem_Click(object sender, EventArgs e)
        {
            useDirectInput = true; // Set flag to use DirectInput
            UpdateMenuSelection((ToolStripMenuItem)sender); // Update the menu selection
            InitController(); // Reinitialize the controller to use DirectInput

        }

        private void connectedControllerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
