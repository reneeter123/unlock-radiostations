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
            int nowRadioStationsNum;
            int maxRadioStationsNum;

            do
            {
                var radioStations = Enum.GetValues(typeof(RadioStation));
                foreach (var value in radioStations)
                {
                    var radioStationName = Function.Call<string>(Hash.GET_RADIO_STATION_NAME, (int)value);
                    Function.Call(Hash._LOCK_RADIO_STATION, radioStationName, false);
                }

                nowRadioStationsNum = Function.Call<int>(Hash.GET_NUM_UNLOCKED_RADIO_STATIONS);
                maxRadioStationsNum = Enum.GetNames(typeof(RadioStation)).Length;
            }
            while (nowRadioStationsNum == maxRadioStationsNum);
        }
    }
}