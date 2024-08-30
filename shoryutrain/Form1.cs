using SharpDX.DirectInput; //DirectInput support
using SharpDX.XInput; //XInput support
using System; // General shit
using System.Diagnostics; // Debug shit
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader; // more debug shit
using System.Drawing.Text; // Draw shit
using System.Windows.Forms; // UI

namespace shoryutrain // Application namespace
{
    public partial class Form1 : Form // Define the Form1 class that inherits from Form, making it a Windows Form
    {
        private int Deadzone = Properties.Settings.Default.Deadzone; // Define a deadzone constant value
        private DirectInput directInput; // Make DirectInput object to handle DirectInput
        private Joystick joystick;  // Joystick for DirectInput joystick info
        private Controller xinputController; // Controller object for XInput
        private System.Windows.Forms.Timer inputPollTimer; // Timer to poll inputs
        private string inputMethod = Properties.Settings.Default.InputMethod; // Default to XInput


        //DirectInput un-fucking
        private int calibrationX = 0;
        private int calibrationY = 0;
        public Form1()
        {

            InitializeComponent();
            InitController();
            InitializeTimer();
        }
        private void LoadSettings()
        {
            // Use the setting to configure the form or application
            string inputMethod = Properties.Settings.Default.InputMethod;
            // Update UI or other components as needed
        }
        private void InitController()
        {
            try
            {
                switch (inputMethod)
                {
                    case "DirectInput":
                        InitializeDirectInputController();
                        Debug.WriteLine("DirectInput is the default now");
                        break;
                    case "XInput":
                        Debug.WriteLine("XInput is the default now");
                        InitializeXInputController();
                        break;
                    default:
                        throw new NotSupportedException($"Input method {inputMethod} is not supported.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the controller: {ex.Message}");
            }
        }


        private void InitializeDirectInputController() // initialize DirectInput controller
        {
            directInput = new DirectInput(); // Initialize DirectInput
            var joystickGuid = Guid.Empty; // Initialize GUID for joystick

            foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)) // Enumerate (list) all connected gamepads
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
            joystick.Acquire(); // Get access to the joystick as an input device
            xinputController = null; // make sure the motherfucker doesnt think it's XInput anyway, this happened before. 
        }

        private void InitializeXInputController()
        {
            xinputController = new Controller(UserIndex.One); // Initialize the first XInput controller

            if (xinputController.IsConnected)
            {
                string controllerName = GetXInputControllerName(); //For some dumb reason XInput does not have a way to fetch the hardware name of the controller, so we have to get DirectInput to do it for us.
                connectedControllerName.Text = "Connected controller: " + controllerName; // Set textbox text to the name of the connected controller
            }
            else
            {
                MessageBox.Show("There is no Xinput controller detected." + Environment.NewLine + "Try using DirectInput"); // advise people to use directinput if XInput detection goes wah wah wah
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
            inputPollTimer.Interval = CalculateTimerInterval(60); // I don't want any offset. calcluate the exact numer of ms per frame on 60fps
            inputPollTimer.Tick += InputPollTimer_Tick; // Add the event handler for the Tick event
            inputPollTimer.Start(); // Start the timer
        }
        private int CalculateTimerInterval(int fps) // calculate the interval by dividing a second (1000ms) by 60 (frames per second)
        {
            return (int)Math.Round(1000.0 / fps);
        }


        private void InputPollTimer_Tick(object sender, EventArgs e) // every tick, do (x)
        {
            try
            {
                if (inputMethod == "DirectInput") //if directinput is used
                {
                    if (joystick == null)
                    {
                        return; // Exit if joystick is not initialized
                    }

                    joystick.Poll(); // Poll the joystick for its current state
                    var state = joystick.GetCurrentState(); // Get the current state of the joystick

                    /* DirectInput likes to fuck itself up when its in a neutral position, 
                     * so if you press the N button while someone is not touching it, 
                     it sets a value that serves as a "Calibration value". 
                     Said calibration value gets subtracted from the offset value that is
                     DirectInput reading X and Y.*/
                    int x = state.X - calibrationX;
                    int invertY = state.Y - calibrationY;
                    int y = -invertY; // Y is for some reason inverted. might add an option for this later too
                    /*
                     I need to figure out a way to map the DPAD of an DirectInput controller accurately.
                     Since the bitfield value for controller input values differ across various manufacturers 
                    (for some controllers 0b010000000 can be DPad up, for other it could be the A button)
                     i need to find a way to get this accurately mapped. will probably prompt this before the app initializes.
                    will keep all of them flagged as false for now
                     */

                    bool dpadUp = false;
                    bool dpadDown = false;
                    bool dpadLeft = false;
                    bool dpadRight = false;

                    /*Debug.WriteLine($"DirectInput - X: {x}, Y: {y}");*/ //i have no idea what the fuck is going on with DirectInput and why it's outputting max X and Y values.



                    ResetButtonColors(); // Reset the colors of all buttons to their default

                    UpdateButtonColors(x, y, dpadDown, dpadUp, dpadRight, dpadLeft); // Update button colors based on controller state
                }
                else if (inputMethod == "XInput")
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

                    //Debug.WriteLine($"XInput - X: {x}, Y: {y}");


                    ResetButtonColors(); // Reset the colors of all buttons to their default

                    UpdateButtonColors(x, y, dpadDown, dpadUp, dpadRight, dpadLeft); // Update button colors based on controller state
                }
            }
            catch (Exception ex) //what
            {
                MessageBox.Show($"An error occurred while polling the controller: {ex.Message}"); // Show error message if polling fails
            }
        }
        private void directInputNeutralSetter_Click(object sender, EventArgs e)
        {
            // Show a message box to prompt the user to leave the stick in neutral position
            var result = MessageBox.Show("To calibrate the stick, put the stick in a neutral position." + Environment.NewLine + "Do not touch the stick." + Environment.NewLine + "Press \"OK\" when ready.",
                                         "Stick Calibration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {

                if (joystick != null) // Ensure the joystick is initialized
                {
                    joystick.Poll(); // Poll the joystick for its current state
                    var state = joystick.GetCurrentState(); // Get the current state of the joystick

                    // Set calibration values to the current X and Y, but negative
                    calibrationX = state.X;
                    calibrationY = state.Y;

                    MessageBox.Show($"Neutral position set: X = {calibrationX}, Y = {calibrationY}");
                }
                else
                {
                    MessageBox.Show("Joystick is not initialized.");
                }
            }
        }

        private void UpdateButtonColors(int x, int y, bool dpadDown, bool dpadUp, bool dpadRight, bool dpadLeft)
        {

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
            // Initialize the menu based on the saved settings
            string savedInputMethod = Properties.Settings.Default.InputMethod;

            // Ensure that MainMenuStrip.Items[0] is a ToolStripMenuItem
            if (MainMenuStrip.Items[1] is ToolStripMenuItem settingsMenuItem)
            {
                // Find the menu item that matches the saved input method
                ToolStripMenuItem selectedItem = settingsMenuItem.DropDownItems
                    .OfType<ToolStripMenuItem>()
                    .FirstOrDefault(item => item.Text == savedInputMethod);

                if (selectedItem != null)
                {
                    UpdateMenuSelection(selectedItem);
                }
                else
                {
                    // Default to XInput if no matching input method is found
                    ToolStripMenuItem defaultItem = settingsMenuItem.DropDownItems
                        .OfType<ToolStripMenuItem>()
                        .FirstOrDefault(item => item.Text == "XInput");

                    if (defaultItem != null)
                    {
                        UpdateMenuSelection(defaultItem);
                    }
                }
            }
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
            // Check if MainMenuStrip is properly initialized
            if (MainMenuStrip != null && MainMenuStrip.Items.Count > 1)
            {
                // Ensure we're accessing the correct column (second column, index 1)
                if (MainMenuStrip.Items[1] is ToolStripMenuItem menuItem)
                {
                    // Debug: Log the number of items in the menu
                    Debug.WriteLine($"Updating Menu: Total items count in second column = {menuItem.DropDownItems.Count}");

                    // Iterate through the drop-down items
                    foreach (ToolStripMenuItem item in menuItem.DropDownItems)
                    {
                        // Log each item's text and whether it matches the selected item
                        Debug.WriteLine($"Item: {item.Text}, Selected: {item == selectedItem}");

                        // Update the check state based on the selected item
                        item.Checked = item == selectedItem;
                    }
                }
                else
                {
                    Debug.WriteLine("The second item in MainMenuStrip is not a ToolStripMenuItem.");
                }
            }
            else
            {
                Debug.WriteLine("MainMenuStrip or its items are null or not properly initialized.");
            }
        }




        private void xinputMenuItem_Click(object sender, EventArgs e)
        {
            inputMethod = "XInput";
            UpdateMenuSelection((ToolStripMenuItem)sender);
            InitController();
            // Set a new value for the input method
            Properties.Settings.Default.InputMethod = "XInput";

            // Save the changes
            Properties.Settings.Default.Save();
        }

        private void directInputMenuItem_Click(object sender, EventArgs e)
        {
            inputMethod = "DirectInput";
            UpdateMenuSelection((ToolStripMenuItem)sender);
            InitController();
            // Set a new value for the input method
            Properties.Settings.Default.InputMethod = "DirectInput";

            // Save the changes
            Properties.Settings.Default.Save();
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
