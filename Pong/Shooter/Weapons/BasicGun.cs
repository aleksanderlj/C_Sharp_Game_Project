using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Shooter.Entities;
using System;
using System.Collections.Generic;

namespace Pong.Shooter.Weapons
{
    class BasicGun : Weapon
    {
        private static Texture2D projectileTexture; // Static, so shared amongst all weapons of the same type

        public BasicGun()
        {
            Cooldown = 0.5;
        }

        public static void LoadContent(GraphicsDevice graphicsDevice)
        {
            projectileTexture = new Texture2D(graphicsDevice, 1, 1);
            projectileTexture.SetData(new Color[] { Color.White });
        }

        public static void UnloadContent()
        {
            projectileTexture.Dispose();
        }
        public override List<Projectile> Shoot(GameTime gameTime, Vector2 position)
        {
            List<Projectile> projectiles = new List<Projectile>();

            if (IsReady(gameTime.TotalGameTime.TotalSeconds))
            {
                Projectile bullet = new Projectile();
                bullet.Texture = projectileTexture;
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
