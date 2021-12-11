using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Shooter;
using Pong.Shooter.Entities;
using Pong.Shooter.Weapons;
using Pong.Utility;
using System.Collections.Generic;

namespace Pong.Scene
{
    class ShooterScene : IScene
    {
        private PlayerShip player;
        private List<Projectile> projectiles;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            projectiles = new List<Projectile>();
            player = new PlayerShip();
            player.Initialize(view);
        }

        public void LoadContent()
        {
            TextureManager.LoadContent(SceneManager.GraphicsDevice);
            player.Texture = TextureManager.Player;
        }

        public void UnloadContent()
        {
            TextureManager.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                player.MoveUp(gameTime);
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                player.MoveDown(gameTime);
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                player.MoveRight(gameTime);
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                player.MoveLeft(gameTime);
            }
            if (kstate.IsKeyDown(Keys.Space))
            {
                projectiles.AddRange(player.Shoot(gameTime));
            }

            player.UpdateMovement(gameTime);

            foreach (Projectile p in projectiles)
            {
                p.UpdateMovement(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            foreach(Projectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }

            DrawUtility.drawBorder(spriteBatch, player.Hitbox, Color.Red, 2); //Debug

            spriteBatch.End();
        }
    }
}
