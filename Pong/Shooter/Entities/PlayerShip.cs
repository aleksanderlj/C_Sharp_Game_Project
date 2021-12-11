using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Shooter.Weapons;
using System.Collections.Generic;

namespace Pong.Shooter.Entities
{
    class PlayerShip : Entity 
    {
        private float speed = 65.0f;
        private List<Weapon> weapons = new List<Weapon>();

        public void Initialize(Viewport view)
        {
            Position = new Vector2(view.Width / 10, view.Height / 2);
            Hitbox = new Rectangle(0, 0, 100, 50);
            Color = Color.DarkGoldenrod;
            Dampening = new Vector2(0.90f, 0.90f);
            AddWeapon(new BasicGun());
        }

        public void MoveUp(GameTime gameTime)
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y - speed);
        }

        public void MoveDown(GameTime gameTime)
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y + speed);
        }

        public void MoveLeft(GameTime gameTime)
        {
            Velocity = new Vector2(Velocity.X - speed, Velocity.Y);
        }

        public void MoveRight(GameTime gameTime)
        {
            Velocity = new Vector2(Velocity.X + speed, Velocity.Y);
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public List<Projectile> Shoot(GameTime gameTime)
        {
            List<Projectile> projectiles = new List<Projectile>();
            Vector2 bulletOrigin = new Vector2(Hitbox.Right, Hitbox.Center.Y);
            foreach(Weapon w in weapons)
            {
                projectiles.AddRange(w.Shoot(gameTime, bulletOrigin));
            }
            return projectiles;
        }
    }
}
