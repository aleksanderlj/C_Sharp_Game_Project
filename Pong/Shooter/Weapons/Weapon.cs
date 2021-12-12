using Microsoft.Xna.Framework;
using Pong.Shooter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter.Weapons
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
