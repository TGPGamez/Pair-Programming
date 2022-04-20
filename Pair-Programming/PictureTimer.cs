using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Pair_Programming
{
    /// <summary>
    /// Custom timer to count
    /// and execute event every x time
    /// </summary>
    public class PictureTimer
    {
        public Timer Timer { get; set; }
        public int CurrentSeconds { get; set; }

        public PictureTimer()
        {
            Timer = new Timer(5000);
            Timer.Elapsed += OnTimedEvent;
            CurrentSeconds = 0;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Pictures_Manager.TimerSetBackgrund();
        }

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
        }
    }
}
