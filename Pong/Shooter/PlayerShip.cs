using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static Pong.Shooter.Weapons;

namespace Pong.Shooter
{
    class PlayerShip : Entity 
    {
        private float speed = 65.0f;
        private List<ShootAction> weapons = new List<ShootAction>();

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

        public void AddWeapon(ShootAction weapon)
        {
            weapons.Add(weapon);
        }

        public List<Projectile> Shoot()
        {
            List<Projectile> projectiles = new List<Projectile>();
            foreach(ShootAction action in weapons)
            {
                projectiles.AddRange(action(Position));
            }
            return projectiles;
        }
    }
}
