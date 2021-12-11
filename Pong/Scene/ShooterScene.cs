using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Shooter.Entities;
using Pong.Shooter.Weapons;
using Pong.Utility;
using System.Collections.Generic;

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
            player.AddWeapon(new BasicGun());
        }

        public void LoadContent()
        {
            blankTexture = new Texture2D(SceneManager.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
            WeaponManager.LoadContent(SceneManager.GraphicsDevice);

            player.Texture = blankTexture;
        }

        public void UnloadContent()
        {
            blankTexture.Dispose();
            WeaponManager.UnloadContent();
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
