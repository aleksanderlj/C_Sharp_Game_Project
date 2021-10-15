using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter
{
    class PlayerShip
    {
        public Rectangle Hitbox { get; set; }
        private double speed = 200.0;

        public void MoveUp(GameTime gameTime)
        {
            Hitbox = new Rectangle(Hitbox.X, Hitbox.Y - (int)(speed * gameTime.ElapsedGameTime.TotalSeconds), Hitbox.Width, Hitbox.Height);
        }

        public void MoveDown(GameTime gameTime)
        {
            Hitbox = new Rectangle(Hitbox.X, Hitbox.Y + (int)(speed * gameTime.ElapsedGameTime.TotalSeconds), Hitbox.Width, Hitbox.Height);
        }

        public void MoveLeft(GameTime gameTime)
        {
            Hitbox = new Rectangle(Hitbox.X - (int)(speed * gameTime.ElapsedGameTime.TotalSeconds), Hitbox.Y, Hitbox.Width, Hitbox.Height);
        }

        public void MoveRight(GameTime gameTime)
        {
            Hitbox = new Rectangle(Hitbox.X + (int)(speed * gameTime.ElapsedGameTime.TotalSeconds), Hitbox.Y, Hitbox.Width, Hitbox.Height);
        }
    }
}
