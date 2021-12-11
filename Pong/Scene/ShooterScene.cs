using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Shooter;
using Pong.Shooter.Entities;
using Pong.Shooter.Entities.Enemies;
using Pong.Shooter.Weapons;
using Pong.Utility;
using System.Collections.Generic;

namespace Pong.Scene
{
    class ShooterScene : IScene
    {
        private PlayerShip player;
        private List<Projectile> projectiles;
        private List<Enemy> enemies;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();
            player = new PlayerShip();
            player.Initialize(view);
        }

        public void LoadContent()
        {
            TextureManager.LoadContent(SceneManager.GraphicsDevice);
            player.Texture = TextureManager.Player;
            enemies.Add(new Grunt(SceneManager.GraphicsDevice.Viewport));
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

            foreach (Enemy e in enemies)
            {
                e.UpdateMovement(gameTime);
                projectiles.AddRange(e.Shoot(gameTime));
            }

            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                Projectile p = projectiles[i];
                if (p.Origin == Origin.Hostile && p.Hitbox.Intersects(player.Hitbox))
                {
                    projectiles.RemoveAt(i);
                    continue;
                } else if (p.Origin == Origin.Friendly)
                {
                    Enemy e = enemies.Find(e => p.Hitbox.Intersects(e.Hitbox));
                    if(e != null)
                    {
                        enemies.Remove(e);
                        projectiles.RemoveAt(i);
                        continue;
                    }
                }
                p.UpdateMovement(gameTime);
            }

            cleanup();
        }

        public void Draw(GameTime gameTime)
        {
            SceneManager.GraphicsDevice.Clear(Color.Black);
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }

            foreach (Projectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }

            DrawUtility.drawBorder(spriteBatch, player.Hitbox, Color.Red, 2); //Debug

            spriteBatch.End();
        }

        private void cleanup()
        {
            projectiles.RemoveAll(p => isOutOfBounds(p.Position));
        }

        private bool isOutOfBounds(Vector2 position)
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            return position.X < view.Bounds.Left    ||
                position.X > view.Bounds.Right      ||
                position.Y > view.Bounds.Bottom     ||
                position.X < view.Bounds.Top;
        }
    }
}
