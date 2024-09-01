using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoryutrain.Managers
{
    public static class SettingsManager
    {
        public static int Deadzone 
        {
            get => Properties.Settings.Default.Deadzone;
            set
            {
                Properties.Settings.Default.Deadzone = value;
                Properties.Settings.Default.Save();
            }

        }

        public static string InputMethod
        {
            get => Properties.Settings.Default.InputMethod;
            set
            {
                Properties.Settings.Default.InputMethod = value;
                Properties.Settings.Default.Save();
            }

        }
    }
}
