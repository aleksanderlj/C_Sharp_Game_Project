using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Shooter.Entities.Enemies
{
    abstract class Enemy : Entity
    {
        public int Score { get; set; }
        public abstract List<Projectile> Shoot(GameTime gameTime);
    }
}
