using Microsoft.Xna.Framework;
using VaporWaves.Shooter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Shooter.Weapons
{
    abstract class Weapon
    {
        private Timer _cooldown;
        public Weapon(double cooldown)
        {
            _cooldown = new Timer(cooldown);
        }
        public abstract List<Projectile> Shoot(GameTime gameTime, Vector2 position);
        protected bool IsReady(GameTime gameTime)
        {
            return _cooldown.TimeIsUp(gameTime);
        }
    }
}
