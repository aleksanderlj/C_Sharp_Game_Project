using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Shooter.Entities;
using System;
using System.Collections.Generic;

namespace Pong.Shooter.Weapons
{
    class BasicGun : Weapon
    {
        public BasicGun()
        {
            Cooldown = 0.5;
        }
        public override List<Projectile> Shoot(GameTime gameTime, Vector2 position)
        {
            List<Projectile> projectiles = new List<Projectile>();

            if (IsReady(gameTime.TotalGameTime.TotalSeconds))
            {
                Projectile bullet = new Projectile();
                bullet.Texture = TextureManager.BasicGunProjectile;
                bullet.Color = Color.Green;
                bullet.Position = position;
                bullet.Velocity = new Vector2(1000, 0);
                bullet.Dampening = Vector2.One;
                bullet.Hitbox = new Rectangle(0, 0, 5, 5);
                projectiles.Add(bullet);
            }

            return projectiles;
        }
    }
}
