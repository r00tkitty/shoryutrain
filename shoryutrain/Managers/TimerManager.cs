using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoryutrain.Managers
{
    internal class TimerManager
    {
        private System.Windows.Forms.Timer inputPollTimer;

        public event EventHandler TimerTick;

        public TimerManager(int fps)
        {
            inputPollTimer = new System.Windows.Forms.Timer();
            inputPollTimer.Interval = CalculateTimerInterval(fps);
            inputPollTimer.Tick += InputPollTimer_Tick;
        }

        public void Start() => inputPollTimer.Start();

        public void Stop() => inputPollTimer.Stop();

        private void InputPollTimer_Tick(object sender, EventArgs e)
        {
            TimerTick?.Invoke(sender, e);
        }

        private int CalculateTimerInterval(int fps)
        {
            return (int)Math.Round(1000.0 / fps);
        }

    }
}
