using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Shooter;
using Pong.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Scene
{
    class ShooterScene : IScene
    {
        private Texture2D blankTexture;

        private PlayerShip player;
        private List<Projectile> projectiles;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            projectiles = new List<Projectile>();
            player = new PlayerShip();
            player.Position = new Vector2(view.Width / 10, view.Height / 2);
            player.Hitbox = new Rectangle(0, 0, 100, 50);
            player.Color = Color.DarkGoldenrod;
            player.Dampening = new Vector2(0.90f, 0.90f);
            player.AddWeapon(new Weapons.ShootAction(Weapons.BasicGun));
        }

        public void LoadContent()
        {
            blankTexture = new Texture2D(SceneManager.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
            Weapons.LoadContent(SceneManager.GraphicsDevice);

            player.Texture = blankTexture;
        }

        public void UnloadContent()
        {
            blankTexture.Dispose();
            Weapons.UnloadContent();
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
                projectiles.AddRange(player.Shoot());
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

            spriteBatch.End();
        }
    }
}
