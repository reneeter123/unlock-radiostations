using GTA;
using GTA.Native;
using System;

namespace Unlock_Radio_Stations
{
    public class Main : Script
    {
        public Main()
        {
            // Unlock Radio Stations
            var radioStations = Enum.GetValues(typeof(RadioStation));
            foreach (var value in radioStations)
            {
                var radioStationName = Function.Call<string>(Hash.GET_RADIO_STATION_NAME, (int)value);
                Function.Call(Hash._LOCK_RADIO_STATION, radioStationName, false);
            }
        }
    }
}