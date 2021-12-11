using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter.Entities
{
    abstract class Entity
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; } // TODO Should be used instead of speed
        public Vector2 Dampening { get; set; }
        private int _width;
        private int _height;
        public Rectangle Hitbox // TODO Hitbox can be either square or circular?
        { 
            get
            { return new Rectangle((int)Position.X, (int)Position.Y, _width, _height); }
            set
            {
                _width = value.Width;
                _height = value.Height;
            }
        }

        public Entity()
        {
            Texture = null;
            Color = Color.Pink;
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Dampening = Vector2.Zero;
            _width = 1;
            _height = 1;
        }

        public Entity(Texture2D texture, Color color)
        {
            Texture = texture;
            Color = color;
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Dampening = Vector2.Zero;
            if (texture != null)
            {
                _width = texture.Width;
                _height = texture.Height;
            } else
            {
                _width = 1;
                _height = 1;
            }
        }

        public Entity(Texture2D texture, Color color, Vector2 position) : this(texture, color)
        {
            Position = position;
        }

        protected Entity(Texture2D texture, Color color, Vector2 position, Vector2 dampening) : this(texture, color, position)
        {
            Dampening = dampening;
        }

        public void UpdateMovement(GameTime gameTime)
        {
            // Position + (Velocity * elapsedTime)
            Position = Vector2.Add(
                Position,
                Vector2.Multiply(
                    Velocity, new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds, (float)gameTime.ElapsedGameTime.TotalSeconds)));

            // Velocity * Dampening
            Velocity = Vector2.Multiply(Velocity, Dampening);


            // Elapsed game time
            // Both in PLayership.move and updatemovement?
            // Dampening * elapsed time?
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Hitbox, Color);
        }

    }
}
