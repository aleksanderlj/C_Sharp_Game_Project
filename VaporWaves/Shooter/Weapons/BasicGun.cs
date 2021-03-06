using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VaporWaves.Shooter.Entities;
using System;
using System.Collections.Generic;

namespace VaporWaves.Shooter.Weapons
{
    class BasicGun : Weapon
    {
        private const double BaseCooldown = 0.5;
        public BasicGun() : base(cooldown: BaseCooldown) { }
        public override List<Projectile> Shoot(GameTime gameTime, Vector2 position)
        {
            List<Projectile> projectiles = new List<Projectile>();

            if (IsReady(gameTime))
            {
                Projectile bullet = new Projectile(Origin.Friendly);
                bullet.Texture = TextureManager.BasicGunProjectile;
                bullet.Color = Color.GreenYellow;
                bullet.Position = position;
                bullet.Velocity = new Vector2(1000, 0);
                bullet.Dampening = Vector2.One;
                bullet.Hitbox = new Rectangle(0, 0, 12, 8);
                projectiles.Add(bullet);
            }

            return projectiles;
        }
    }
}
