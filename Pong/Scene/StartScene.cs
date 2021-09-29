using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Scene
{
    class StartScene : IScene
    {
        SpriteFont font;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            
        }
        public void LoadContent()
        {
            ContentManager content = SceneManager.Game.Content;
            font = content.Load<SpriteFont>("Score");
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Enter))
            {
                SceneManager.AddScene(new PongScene());
                SceneManager.RemoveScene(this);
            }
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            Viewport view = SceneManager.GraphicsDevice.Viewport;

            spriteBatch.Begin();

            String title = "Press enter to begin...";
            Vector2 size = font.MeasureString(title);
            spriteBatch.DrawString(font, title, new Vector2(view.Width / 2 - size.X / 2, view.Height / 2 - size.Y / 2), Color.White);

            spriteBatch.End();
        }
    }
}
