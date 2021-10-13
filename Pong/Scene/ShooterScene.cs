using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Shooter;
using Pong.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Scene
{
    class ShooterScene : IScene
    {
        Texture2D blankTexture;

        PlayerShip player;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            player = new PlayerShip();
            player.Hitbox = new Rectangle(view.Width/10, view.Height/2, 100, 50);
        }

        public void LoadContent()
        {
            blankTexture = new Texture2D(SceneManager.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
        }

        public void UnloadContent()
        {
            blankTexture.Dispose();
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            spriteBatch.Begin();

            spriteBatch.Draw(blankTexture, player.Hitbox, Color.DarkRed);

            spriteBatch.End();
        }
    }
}
