using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using SharpDX.DirectInput; // DirectInput support
using SharpDX.XInput; // XInput support

namespace shoryutrain
{
    public partial class streetFighterControl : UserControl
    {
        // Arrays to hold references to buttons for both tables
        private Button[] keyboardButtonsMain;
        private Button[] controllerButtonsMain;

        private Button[] keyboardButtonsMacro;
        private Button[] controllerButtonsMacro;

        // Define button names for both tables
        private readonly string[] buttonNamesMain =
        {
            "LK", "MK", "HK", "LP", "MP", "HP",
            "LP+LK", "MP+MK", "HP+HK"
        };

        private readonly string[] buttonNamesMacro =
        {
            "LP+MP", "LP+HP", "MP+HP",
            "LK+MK", "LK+HK", "MK+HK",
            "LP+MP+HP", "LK+MK+HK", "LP+MP+HP+LK+MK+HK"
        };

        // Dictionaries to store the current key bindings
        private Dictionary<string, Keys> keyboardBindings; // Keyboard bindings
        private Dictionary<string, string> directInputBindings; // DirectInput controller bindings
        private Dictionary<string, string> xinputBindings; // XInput controller bindings

        // To track the button currently being configured
        private Button activeButton = null;

        // DirectInput objects
        private DirectInput directInput;
        private Joystick directInputJoystick;

        // XInput objects
        private Controller xinputController;

        public streetFighterControl()
        {
            InitializeComponent(); // Initialize components created by the designer
            InitializeButtons();  // Call method to initialize buttons and labels

            // Initialize dictionaries to store the key bindings
            keyboardBindings = new Dictionary<string, Keys>();
            directInputBindings = new Dictionary<string, string>();
            xinputBindings = new Dictionary<string, string>();

            // Initialize DirectInput
            directInput = new DirectInput();
            directInputJoystick = new Joystick(directInput, Guid.Empty); // Use a specific GUID for the desired joystick

            // Initialize XInput
            xinputController = new Controller(UserIndex.One); // Use a specific user index for the desired controller
        }

        // Method to initialize buttons for both tables
        private void InitializeButtons()
        {
            // Initialize the button arrays for the main table
            keyboardButtonsMain = new Button[buttonNamesMain.Length];
            controllerButtonsMain = new Button[buttonNamesMain.Length];

            // Initialize the button arrays for the macro table
            keyboardButtonsMacro = new Button[buttonNamesMacro.Length];
            controllerButtonsMacro = new Button[buttonNamesMacro.Length];

            // Populate the main keybind table (sfKeybindTableMain)
            for (int i = 0; i < buttonNamesMain.Length; i++)
            {
                // Initialize controller button
                controllerButtonsMain[i] = new Button();
                controllerButtonsMain[i].Text = "(None)"; // Default text when no key is bound
                controllerButtonsMain[i].Click += Button_Click; // Assign click event handler

                // Initialize keyboard button
                keyboardButtonsMain[i] = new Button();
                keyboardButtonsMain[i].Text = "(None)"; // Default text when no key is bound
                keyboardButtonsMain[i].Click += Button_Click; // Assign click event handler

                // Add controller button and keyboard button to the main TableLayoutPanel
                sfKeybindTableMain.Controls.Add(controllerButtonsMain[i], 1, i); // Add controller button to the second column
                sfKeybindTableMain.Controls.Add(keyboardButtonsMain[i], 2, i); // Add keyboard button to the third column
            }

            // Populate the macro keybind table (sfKeybindTableMacro)
            for (int i = 0; i < buttonNamesMacro.Length; i++)
            {
                // Initialize controller button
                controllerButtonsMacro[i] = new Button();
                controllerButtonsMacro[i].Text = "(None)"; // Default text when no key is bound
                controllerButtonsMacro[i].Click += Button_Click; // Assign click event handler

                // Initialize keyboard button
                keyboardButtonsMacro[i] = new Button();
                keyboardButtonsMacro[i].Text = "(None)"; // Default text when no key is bound
                keyboardButtonsMacro[i].Click += Button_Click; // Assign click event handler

                // Add controller button and keyboard button to the macro TableLayoutPanel
                sfKeybindTableMacro.Controls.Add(controllerButtonsMacro[i], 1, i); // Add controller button to the second column
                sfKeybindTableMacro.Controls.Add(keyboardButtonsMacro[i], 2, i); // Add keyboard button to the third column
            }
        }

        // Event handler for button clicks
        private void Button_Click(object sender, EventArgs e)
        {
            // Cast the sender object to a Button
            Button button = sender as Button;
            if (button != null)
            {
                // Store the button being configured
                activeButton = button;
                // Display that the button is waiting for input
                button.Text = "Input bind...";

                // Subscribe to the form's key down event to capture keyboard input
                this.ParentForm.PreviewKeyDown += ParentForm_PreviewKeyDown;
                this.ParentForm.KeyDown += ParentForm_KeyDown;

                // Subscribe to DirectInput and XInput events
                // Note: Implement event handlers or polling for DirectInput and XInput here
            }
        }

        // Handle DirectInput input (This might require a polling mechanism or event handling)
        private void PollDirectInput()
        {
            if (directInputJoystick != null)
            {
                // Poll the DirectInput joystick
                directInputJoystick.Acquire();
                var state = directInputJoystick.GetCurrentState();

                // TODO: Handle DirectInput joystick state
                // Map the state to your bindings and update the UI accordingly
            }
        }

        // Handle XInput input
        private void PollXInput()
        {
            if (xinputController != null)
            {
                var state = xinputController.GetState();
                var gamepad = state.Gamepad;
                Debug.WriteLine(gamepad);

                // Example: Map XInput gamepad buttons to your bindings
                // TODO: Handle XInput gamepad state and update bindings accordingly
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

        // Define the ParentForm_KeyDown method to handle key down events
        private void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Prevent the parent form from handling the key down event
            e.Handled = true;
        }

        // TODO: Implement similar event handlers for DirectInput and XInput if needed
    }
}
