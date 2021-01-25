using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Unlock_Radio_Stations
{
    public class Main : Script
    {
        public Main()
        {
            // Get the ini configuration
            var ini = ScriptSettings.Load(@"scripts\unlock-radiostations.ini");
            var unlockedTrackList = ini.GetValue<string>("Settings", "UnlockedTrackList", "").Split(',');

            // Unlock Radio Stations
            var radioStationNames = new List<string>();

            var radioStations = Enum.GetValues(typeof(RadioStation));
            foreach (var value in radioStations)
            {
                var radioStationName = Function.Call<string>(Hash.GET_RADIO_STATION_NAME, (int)value);
                radioStationNames.Add(radioStationName);
                Function.Call(Hash._LOCK_RADIO_STATION, radioStationName, false);
            }

            // Unlock Tracklist
            var tuple = radioStationNames.Zip(unlockedTrackList, Tuple.Create);
            foreach (var value in tuple)
                Function.Call(Hash.UNLOCK_RADIO_STATION_TRACK_LIST, value.Item1, value.Item2);
        }
    }
}