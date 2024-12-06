using System;
using Overworld.Models;

namespace Overworld.Services
{
    public class TimePeriodService
    {
        private TimePeriod _currentTimePeriod;
        
        public event Action<string> TimePeriodForwarded = delegate { };

        public TimePeriodService(TimePeriod timePeriod)
        {
            _currentTimePeriod = timePeriod;
        }
        
        public void ForwardTimePeriod()
        {
            var newTimePeriodInt = (int)_currentTimePeriod + 1;
            _currentTimePeriod = newTimePeriodInt > 3 ? TimePeriod.Morning : (TimePeriod)newTimePeriodInt;
        }
        
        private void UpdateTimePeriodScene()
        {
            switch((int)_currentTimePeriod)
            {
                case 0: 
                    TimePeriodForwarded.Invoke("OverworldMorning");
                    break;
                case 1: 
                    //TimePeriodForwarded.Invoke("OverworldMidday");
                    break;            
                case 2: 
                    TimePeriodForwarded.Invoke("OverworldNight"); // OverworldAfternoon
                    break;
                case 3: 
                    //TimePeriodForwarded.Invoke("OverworldNight");
                    break;
            }   
        }
    }
}
