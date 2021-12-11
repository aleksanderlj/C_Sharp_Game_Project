using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter
{
    class Weapons
    {
        public delegate List<Projectile> ShootAction(Vector2 position);

        private static Texture2D bulletTexture;

        public static void LoadContent(GraphicsDevice graphicsDevice)
        {
            bulletTexture = new Texture2D(graphicsDevice, 1, 1);
            bulletTexture.SetData(new Color[] { Color.White });
        }

        public static void UnloadContent()
        {
            bulletTexture.Dispose();
        }

        public static List<Projectile> BasicGun(Vector2 position)
        {
            List<Projectile> projectiles = new List<Projectile>();

            Projectile bullet = new Projectile();
            bullet.Texture = bulletTexture;
            bullet.Color = Color.Green;
            bullet.Position = position;
            bullet.Velocity = new Vector2(1000, 0);
            bullet.Dampening = Vector2.One;
            bullet.Hitbox = new Rectangle(0, 0, 5, 5);
            projectiles.Add(bullet);

            return projectiles;
        }
    }
}
