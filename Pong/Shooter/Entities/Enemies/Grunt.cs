using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Shooter.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter.Entities.Enemies
{
    class Grunt : Enemy
    {
        Weapon weapon;
        public Grunt(Viewport view)
        {
            int width = 60;
            int height = 50;
            Random rnd = new Random();

            weapon = new GruntGun();
            Position = new Vector2(view.Width + width, rnd.Next(50, view.Height - (height + 50)));
            Hitbox = new Rectangle(0, 0, width, height);
            Color = Color.DarkGoldenrod;
            Velocity = new Vector2(rnd.Next(-2000, -1000), rnd.Next(-200, 200));
            Dampening = new Vector2(0.90f, 0.90f);
            Texture = TextureManager.Grunt;
        }

        public override List<Projectile> Shoot(GameTime gameTime)
        {
            Vector2 bulletOrigin = new Vector2(Hitbox.Left, Hitbox.Center.Y);
            return weapon.Shoot(gameTime, bulletOrigin);
        }

        public class GruntGun : Weapon
        {
            public GruntGun()
            {
                Cooldown = 1.5;
            }

            public override List<Projectile> Shoot(GameTime gameTime, Vector2 position)
            {
                List<Projectile> projectiles = new List<Projectile>();

                if (IsReady(gameTime.TotalGameTime.TotalSeconds))
                {
                    Projectile bullet = new Projectile(Origin.Hostile);
                    bullet.Texture = TextureManager.GruntGunProjectile;
                    bullet.Color = Color.Red;
                    bullet.Position = position;
                    bullet.Velocity = new Vector2(-500, 0);
                    bullet.Dampening = Vector2.One;
                    bullet.Hitbox = new Rectangle(0, 0, 5, 5);
                    projectiles.Add(bullet);
                }

                return projectiles;
            }
        }
    }
}
