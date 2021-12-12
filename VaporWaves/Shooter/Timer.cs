using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Shooter
{
    class Timer
    {
        public double Period { get; set; }
        public double Remaining { get; set; }
        private double _lastTime = 0;

        public Timer(double period)
        {
            Period = period;
        }

        public bool TimeIsUp(GameTime gameTime)
        {
            double time = gameTime.TotalGameTime.TotalSeconds;
            Remaining -= time - _lastTime;
            _lastTime = time;
            if (Remaining < 0.0)
            {
                Reset();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            Remaining = Period;
        }
    }
}
