using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VaporWaves.Scene;
using VaporWaves.Shooter.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Shooter.Entities.Enemies
{
    class Grunt : Enemy
    {
        Weapon weapon;
        public Grunt()
        {
            Viewport view = SceneManager.SpriteBatch.GraphicsDevice.Viewport;
            int width = 70;
            int height = 60;
            Random rnd = new Random();

            Score = 100;
            weapon = new GruntGun();
            Position = new Vector2(view.Width + width, rnd.Next(50, view.Height - (height + 50)));
            Hitbox = new Rectangle(0, 0, width, height);
            Color = Color.White;
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
            private const double BaseCooldown = 1.5;
            public GruntGun() : base(cooldown: BaseCooldown) { }

            public override List<Projectile> Shoot(GameTime gameTime, Vector2 position)
            {
                List<Projectile> projectiles = new List<Projectile>();

                if (IsReady(gameTime))
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
