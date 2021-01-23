using GTA;
using GTA.Native;
using System.Collections.Generic;

namespace Unlock_Radio_Stations
{
    public class Main : Script
    {
        // Settings
        private List<string> unlockedRadioStations = new List<string>();

        public Main()
        {
            GetSettings();
            UnlockRadioStations();
        }

        private void GetSettings()
        {
            // Get the ini configuration
            var ini = ScriptSettings.Load(@"scripts\unlock-all-radiostations.ini");

            var stations = ini.GetValue<string>("Settings", "UnlockedRadioStations", "").Split(',');
            unlockedRadioStations.AddRange(stations);
        }

        private void UnlockRadioStations()
        {
            foreach (var value in unlockedRadioStations)
                Function.Call(Hash._LOCK_RADIO_STATION, value, false);
        }
    }
}