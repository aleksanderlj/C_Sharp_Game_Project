using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Shooter;
using Pong.Shooter.Entities;
using Pong.Shooter.Entities.Enemies;
using Pong.Shooter.Weapons;
using Pong.Utility;
using System;
using System.Collections.Generic;

namespace Pong.Scene
{
    class ShooterScene : IScene
    {
        SpriteFont font;

        private PlayerShip player;
        private List<Projectile> projectiles;
        private List<Enemy> enemies;
        private EnemySpawner enemySpawner;
        private int cash;
        private Timer levelTime;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();
            enemySpawner = new EnemySpawner(0);
            player = new PlayerShip();
            player.Initialize();
            cash = 0;
            levelTime = new Timer(15);
        }

        public void LoadContent()
        {
            TextureManager.LoadContent(SceneManager);
            player.Texture = TextureManager.Player;
            font = TextureManager.BaseFont;
        }

        public void UnloadContent()
        {
            TextureManager.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if (levelTime.TimeIsUp(gameTime))
            {
                enemySpawner.Difficulty += 1;
            }

            // Player behavior
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

            // Enemy behavior
            foreach (Enemy e in enemies)
            {
                e.UpdateMovement(gameTime);
                projectiles.AddRange(e.Shoot(gameTime));
            }
            enemies.AddRange(enemySpawner.Spawn(gameTime));

            // Projectile behavior
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                Projectile p = projectiles[i];
                if (p.Origin == Origin.Hostile && p.Hitbox.Intersects(player.Hitbox))
                {
                    projectiles.RemoveAt(i);
                    SceneManager.AddScene(new HighscoreScene(cash));
                    SceneManager.RemoveScene(this);
                    continue;
                } else if (p.Origin == Origin.Friendly)
                {
                    Enemy e = enemies.Find(e => p.Hitbox.Intersects(e.Hitbox));
                    if(e != null)
                    {
                        enemies.Remove(e);
                        projectiles.RemoveAt(i);
                        cash += e.Score;
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
            Viewport view = SceneManager.GraphicsDevice.Viewport;
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

            //DrawUtility.drawBorder(spriteBatch, player.Hitbox, Color.Red, 2); //Debug
            Vector2 levelPosition = new Vector2((view.Width / 2) - (font.MeasureString("Level " + enemySpawner.Difficulty).X / 2), 20);
            Vector2 timerPosition = new Vector2(levelPosition.X, levelPosition.Y + font.MeasureString(((int)levelTime.Remaining).ToString()).Y);
            spriteBatch.DrawString(font, "$" + cash.ToString(), new Vector2(20, 20), Color.White);
            spriteBatch.DrawString(font, "Level " + enemySpawner.Difficulty, levelPosition, Color.White);
            spriteBatch.DrawString(font, "Time: " + ((int)levelTime.Remaining).ToString(), timerPosition, Color.White);

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
