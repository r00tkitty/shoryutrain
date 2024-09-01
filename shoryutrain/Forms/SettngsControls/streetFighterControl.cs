using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput; // DirectInput support
using SharpDX.XInput; // XInput support

namespace shoryutrain
{

    public partial class streetFighterControl: UserControl
    {
        //arrays to hold references to both tables
        private Button[] keyboardButtonsMain;
        private Button[] controllerButtonsMain;

        private Button[] keyboardButtonsMacro;
        private Button[] controllerButtonsMacro;

        private readonly String[] buttonNamesMain =
        {
            "LK", "MK", "HK", "LP", "MP", "HP",
            "LP+LK", "MP+MK", "HP+HK"
        };

        private readonly String[] buttonNamesMacro =
        {
            "LP+MP", "LP+HP", "MP+HP",
            "LK+MK", "LK+HK", "MK+HK",
            "LP+MP+HP", "LK+MK+HK", "LP+MP+HP+LK+MK+HK"
        };

        private Dictionary<string, Keys> keyboardBindings;
        private Dictionary<string, string> controllerBindings;

        private Button activeButton = null;

        private DirectInput directInput;
        private Joystick directInputJoystick;

        private Controller xInputController;


        public streetFighterControl()
        {

            InitializeComponent(); //initialize designer shit
            InitializeButtons(); //initialize buttons

            keyboardBindings = new Dictionary<string, Keys>();
            controllerBindings = new Dictionary<string, string>();


            directInput = new DirectInput();

            xInputController = new Controller(UserIndex.One);

            string inputMethod = Properties.Settings.Default.InputMethod;

            switch(inputMethod)
            {
                case "XInput": // If XInput is selected in settings
                    InitializeXInput();
                    break;

                case "DirectInput": // If DirectInput is selected in settings
                    InitializeDirectInput();
                    break;

                default: // If neither of the settings are selected
                    MessageBox.Show("what");
                    break;

            }
        }

        private void InitializeButtons()
        {
            // initialize array
            keyboardButtonsMain = new Button[buttonNamesMain.Length];
            controllerButtonsMain = new Button[buttonNamesMain.Length];
            //initialize array again
            keyboardButtonsMacro = new Button[buttonNamesMacro.Length];
            controllerButtonsMacro = new Button[buttonNamesMacro.Length];

            for (int i = 0; i < buttonNamesMain.Length; i++)
            {
                controllerButtonsMain[i] = new Button();
                controllerButtonsMain[i].Text = "(None)";
                controllerButtonsMain[i].Click += ControllerButton_Click;
                controllerButtonsMain[i].Tag = buttonNamesMain[i];

                keyboardButtonsMain[i] = new Button();
                keyboardButtonsMain[i].Text = "(None)";
                keyboardButtonsMain[i].Click += KeyboardButton_Click;
                keyboardButtonsMain[i].Tag = buttonNamesMain[i];
                

                sfKeybindTableMain.Controls.Add(controllerButtonsMain[i], 1, i);
                sfKeybindTableMain.Controls.Add(keyboardButtonsMain[i], 2, i);
            }

            for (int i = 0; i < buttonNamesMacro.Length; i++)
            {
                controllerButtonsMacro[i] = new Button();
                controllerButtonsMacro[i].Text = "(None)";
                controllerButtonsMacro[i].Click += ControllerButton_Click;
                controllerButtonsMacro[i].Tag = buttonNamesMacro[i];

                keyboardButtonsMacro[i] = new Button();
                keyboardButtonsMacro[i].Text = "(None)";
                keyboardButtonsMacro[i].Click += KeyboardButton_Click;
                keyboardButtonsMacro[i].Tag = buttonNamesMacro[i];



                sfKeybindTableMacro.Controls.Add(controllerButtonsMacro[i], 1, i);
                sfKeybindTableMacro.Controls.Add(keyboardButtonsMacro[i], 2, i);
            }

        }

        // Initialize DirectInput and find connected devices
        private void InitializeDirectInput()
        {
            try
            {
                // Check for connected joysticks
                foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    // Initialize the joystick using the deviceInstance
                    directInputJoystick = new Joystick(directInput, deviceInstance.InstanceGuid);
                    directInputJoystick.Acquire(); // Acquire control over the joystick
                    Debug.WriteLine("Joystick connected: " + deviceInstance.InstanceName);
                    break; // Use the first joystick found
                }

                // If no joystick was found, check for gamepads
                if (directInputJoystick == null)
                {
                    foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                    {
                        // Initialize the gamepad using the deviceInstance
                        directInputJoystick = new Joystick(directInput, deviceInstance.InstanceGuid);
                        directInputJoystick.Acquire(); // Acquire control over the gamepad
                        Debug.WriteLine("Gamepad connected: " + deviceInstance.InstanceName);
                        break; // Use the first gamepad found
                    }
                }

                // If no device is found, handle accordingly
                if (directInputJoystick == null)
                {
                    Debug.WriteLine("No DirectInput devices found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error initializing DirectInput: " + ex.Message);
            }
        }

        // Initialize XInput
        private void InitializeXInput()
        {
            // Optionally check if the XInput controller is connected
            if (!xInputController.IsConnected)
            {
                Debug.WriteLine("No XInput controllers connected.");
            }
        }

        // Event handler for controller button clicks
        private void ControllerButton_Click(object sender, EventArgs e)
        {
            // Logic to handle controller button remapping goes here
            // This will poll the correct input method based on the selected input method
            Button button = sender as Button;
            if (button != null)
            {
                activeButton = button;
                button.Text = "..."; // Show that we're waiting for input

                // Poll based on the selected input method
                switch (Properties.Settings.Default.InputMethod)
                {
                    case "XInput":
                        PollXInput();
                        break;

                    case "DirectInput":
                        PollDirectInput();
                        break;
                }
            }
        }
        // Event handler for keyboard button clicks
        private void KeyboardButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                activeButton = button;
                button.Text = "..."; // Show that we're waiting for input

                // Subscribe to the form's key down event to capture keyboard input
                this.ParentForm.PreviewKeyDown += ParentForm_PreviewKeyDown;
                this.ParentForm.KeyDown += ParentForm_KeyDown;
            }
        }
        // Handle keyboard input
        private void ParentForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // If keyboard input detected and a button is waiting for binding
            if (activeButton != null)
            {
                // Check if the key is already bound to another action
                if (keyboardBindings.ContainsValue(e.KeyCode))
                {
                    MessageBox.Show("This key is already bound to another action.");
                    return;
                }

                // Bind the key to the action represented by the activeButton
                string action = activeButton.Name; // Use the button's name to identify the action
                keyboardBindings[action] = e.KeyCode;

                // Update the button text with the bound key name
                activeButton.Text = e.KeyCode.ToString();

                // Unsubscribe from the events once the binding is complete
                this.ParentForm.PreviewKeyDown -= ParentForm_PreviewKeyDown;
                this.ParentForm.KeyDown -= ParentForm_KeyDown;

                activeButton = null; // Reset activeButton
            }
        }

        private void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle any other key down logic here if necessary
        }


        // Poll for XInput controller input
        private void PollXInput()
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 50; i++) // Poll for 5 seconds (50 times at 100ms intervals)
                {
                    if (xInputController.IsConnected)
                    {
                        var state = xInputController.GetState();
                        if (state.Gamepad.Buttons != GamepadButtonFlags.None)
                        {
                            // Example: check if the A button is pressed
                            if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                            {
                                // Bind the A button to the action represented by the activeButton
                                string action = activeButton.Tag.ToString();
                                controllerBindings[action] = "A";

                                // Update the button text with the bound button name
                                activeButton.Text = "A";
                                break; // Exit the loop once a button is bound
                            }
                            // Add similar checks for other buttons (B, X, Y, etc.)
                        }
                    }
                    await Task.Delay(100); // Wait for 100ms before polling again
                }
                ResetActiveButtonIfUnbound(); // Reset if no button was bound
            });
        }

        // Poll for DirectInput controller input
        private void PollDirectInput()
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 50; i++) // Poll for 5 seconds (50 times at 100ms intervals)
                {
                    if (directInputJoystick != null)
                    {
                        var state = directInputJoystick.GetCurrentState();
                        var buttons = state.Buttons;
                        for (int j = 0; j < buttons.Length; j++)
                        {
                            if (buttons[j]) // If button[j] is pressed
                            {
                                string action = activeButton.Tag.ToString();
                                controllerBindings[action] = $"Button{j + 1}";

                                // Update the button text with the bound button name
                                activeButton.Text = $"Button{j + 1}";
                                break; // Exit the loop once a button is bound
                            }
                        }
                    }
                    await Task.Delay(100); // Wait for 100ms before polling again
                }
                ResetActiveButtonIfUnbound(); // Reset if no button was bound
            });
        }

        // Reset the active button if no input was detected
        private void ResetActiveButtonIfUnbound()
        {
            if (activeButton != null && activeButton.Text == "...")
            {
                activeButton.Text = "(None)";
                activeButton = null;
            }
        }

    }
}