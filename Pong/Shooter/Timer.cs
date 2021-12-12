using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter
{
    class Timer
    {
        public double Period { get; set; }
        private double _countdown;
        private double _lastTime = 0;

        public Timer(double period)
        {
            Period = period;
        }

        public bool TimeIsUp(GameTime gameTime)
        {
            double time = gameTime.TotalGameTime.TotalSeconds;
            _countdown -= time - _lastTime;
            _lastTime = time;
            if (_countdown < 0.0)
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
            _countdown = Period;
        }
    }
}
