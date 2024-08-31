using SharpDX.DirectInput;
using SharpDX.XInput;
using System;

namespace shoryutrain.Managers
{
    public class InputManager
    {
        public event Action<int, int, bool, bool, bool, bool> OnInputChanged;
        private DirectInput directInput;
        private Joystick joystick;
        private Controller xinputController;
        private string inputMethod;
        private int calibrationX = 0;
        private int calibrationY = 0;

        public InputManager(string inputMethod)
        {
            this.inputMethod = inputMethod;
            InitController();
        }

        private void InitController()
        {
            try
            {
                switch (inputMethod)
                {
                    case "DirectInput":
                        InitializeDirectInputController();
                        break;
                    case "XInput":
                        InitializeXInputController();
                        break;
                    default:
                        throw new NotSupportedException($"Input method {inputMethod} is not supported.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while initializing the controller: {ex.Message}");
            }
        }

        private void InitializeDirectInputController()
        {
            directInput = new DirectInput();
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
                break;
            }

            if (joystickGuid == Guid.Empty)
            {
                throw new InvalidOperationException("No DirectInput controller detected.");
            }

            joystick = new Joystick(directInput, joystickGuid);
            joystick.Acquire();
            xinputController = null;
        }

        private void InitializeXInputController()
        {
            xinputController = new Controller(UserIndex.One);

            if (!xinputController.IsConnected)
            {
                throw new InvalidOperationException("No XInput controller detected.");
            }

            joystick = null;
        }

        public void PollInput()
        {
            if (inputMethod == "DirectInput")
            {
                if (joystick == null) return;

                joystick.Poll();
                var state = joystick.GetCurrentState();

                int x = state.X - calibrationX;
                int y = -(state.Y - calibrationY); // Invert Y axis
                // DPad handling (placeholder)
                bool dpadUp = false, dpadDown = false, dpadLeft = false, dpadRight = false;

                OnInputChanged?.Invoke(x, y, dpadDown, dpadUp, dpadRight, dpadLeft);
            }
            else if (inputMethod == "XInput")
            {
                if (xinputController == null || !xinputController.IsConnected) return;

                var state = xinputController.GetState();
                int x = state.Gamepad.LeftThumbX;
                int y = state.Gamepad.LeftThumbY;
                var buttons = state.Gamepad.Buttons;

                bool dpadUp = (buttons & GamepadButtonFlags.DPadUp) == GamepadButtonFlags.DPadUp;
                bool dpadDown = (buttons & GamepadButtonFlags.DPadDown) == GamepadButtonFlags.DPadDown;
                bool dpadRight = (buttons & GamepadButtonFlags.DPadRight) == GamepadButtonFlags.DPadRight;
                bool dpadLeft = (buttons & GamepadButtonFlags.DPadLeft) == GamepadButtonFlags.DPadLeft;

                OnInputChanged?.Invoke(x, y, dpadDown, dpadUp, dpadRight, dpadLeft);
            }
        }

        public void CalibrateNeutral()
        {
            if (joystick != null)
            {
                joystick.Poll();
                var state = joystick.GetCurrentState();
                calibrationX = state.X;
                calibrationY = state.Y;
            }
            else
            {
                throw new InvalidOperationException("Joystick is not initialized.");
            }
        }
    }
}
