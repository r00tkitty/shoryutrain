using shoryutrain.Managers;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace shoryutrain
{
    public partial class Form1 : Form
    {
        private InputManager inputManager;
        private System.Windows.Forms.Timer inputPollTimer;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            inputManager = new InputManager(SettingsManager.InputMethod);
            inputManager.OnInputChanged += UpdateButtonColors;

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            inputPollTimer = new System.Windows.Forms.Timer();
            inputPollTimer.Interval = CalculateTimerInterval(60);
            inputPollTimer.Tick += InputPollTimer_Tick;
            inputPollTimer.Start();
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

        private void UpdateButtonColors(int x, int y, bool dpadDown, bool dpadUp, bool dpadRight, bool dpadLeft)
        {
            ResetButtonColors();

            int Deadzone = SettingsManager.Deadzone;

            if (y > Deadzone || dpadUp)
            {
                if (x < -Deadzone || dpadLeft)
                {
                    buttonUpLeft.BackColor = Color.Black;
                    buttonUpLeft.ForeColor = Color.White;
                }
                else if (x > Deadzone || dpadRight)
                {
                    buttonUpRight.BackColor = Color.Black;
                    buttonUpRight.ForeColor = Color.White;
                }
                else
                {
                    buttonUp.BackColor = Color.Black;
                    buttonUp.ForeColor = Color.White;
                }
            }
            else if (y < -Deadzone || dpadDown)
            {
                if (x < -Deadzone || dpadLeft)
                {
                    buttonDownLeft.BackColor = Color.Black;
                    buttonDownLeft.ForeColor = Color.White;
                }
                else if (x > Deadzone || dpadRight)
                {
                    buttonDownRight.BackColor = Color.Black;
                    buttonDownRight.ForeColor = Color.White;
                }
                else
                {
                    buttonDown.BackColor = Color.Black;
                    buttonDown.ForeColor = Color.White;
                }
            }
            else
            {
                if (x < -Deadzone || dpadLeft)
                {
                    buttonLeft.BackColor = Color.Black;
                    buttonLeft.ForeColor = Color.White;
                }
                else if (x > Deadzone || dpadRight)
                {
                    buttonRight.BackColor = Color.Black;
                    buttonRight.ForeColor = Color.White;
                }
                else
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

        private int CalculateTimerInterval(int fps)
        {
            return 1000 / fps;
        }
    }
}
