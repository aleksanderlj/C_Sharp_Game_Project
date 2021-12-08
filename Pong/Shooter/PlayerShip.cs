using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter
{
    class PlayerShip : Entity 
    {
        private float speed = 65.0f;

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
    }
}
