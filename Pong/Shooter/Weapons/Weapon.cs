using Microsoft.Xna.Framework;
using Pong.Shooter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter.Weapons
{
    abstract class Weapon
    {
        protected double Cooldown;
        private double _countdown;
        private double _lastTime = 0;
        public abstract List<Projectile> Shoot(GameTime gameTime, Vector2 position);
        protected bool IsReady(double time)
        {
            _countdown -= time - _lastTime;
            _lastTime = time;
            if(_countdown < 0.0)
            {
                _countdown = Cooldown;
                return true;
            } else
            {
                return false;
            }
        }
    }
}
