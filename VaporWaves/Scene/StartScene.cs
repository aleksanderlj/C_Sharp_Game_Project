using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VaporWaves.Menu;
using VaporWaves.Shooter;
using VaporWaves.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Scene
{
    class StartScene : IScene
    {
        SpriteFont font;
        SpriteFont fontSmall;
        ListMenu startMenu;
        KeyboardState lastKeyState;

        public SceneManager SceneManager { get; set; }

        public void Initialize()
        {
            this.startMenu = new ListMenu();
            this.startMenu.AddOption(new MenuOption("Start game", new MenuOption.Action(() => SceneManager.AddScene(new ShooterScene()))));
            this.startMenu.AddOption(new MenuOption("Highscore", new MenuOption.Action(() => SceneManager.AddScene(new HighscoreScene()))));
            this.startMenu.AddOption(new MenuOption("Pong?", new MenuOption.Action(() => SceneManager.AddScene(new PongScene()))));
            this.startMenu.AddOption(new MenuOption("Quit", new MenuOption.Action(() => SceneManager.ExitGame())));
        }
        public void LoadContent()
        {
            font = TextureManager.BaseFont;
            fontSmall = TextureManager.BaseFontSmall;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Enter) || kstate.IsKeyDown(Keys.Space))
            {
                startMenu.Choose();
                SceneManager.RemoveScene(this);
            }
            if (kstate.IsKeyDown(Keys.Down) && kstate != lastKeyState)
            {
                startMenu.Down();
            }
            if (kstate.IsKeyDown(Keys.Up) && kstate != lastKeyState)
            {
                startMenu.Up();
            }
            lastKeyState = kstate;
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            SceneManager.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.Title, Vector2.Zero, Color.White);

            /*
            String title = "Press enter to begin...";
            Vector2 size = font.MeasureString(title);
            spriteBatch.DrawString(font, title, new Vector2(view.Width / 2 - size.X / 2, view.Height / 2 - size.Y / 2), Color.White);
            */

            drawMenu(startMenu, new Vector2(view.Width / 2, view.Height / 2));
            spriteBatch.DrawString(fontSmall, "By Aleksander L. J.", new Vector2(0, view.Bounds.Bottom - fontSmall.MeasureString("W").Y), Color.White);

            spriteBatch.End();
        }

        private void drawMenu(ListMenu menu, Vector2 position)
        {
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            for (int i = 0; i < menu.Options.Count; i++)
            {
                String text = menu.Options[i].Text;
                Vector2 relativePosition = new Vector2(
                    position.X - (font.MeasureString(text).X / 2),
                    position.Y + (i * font.MeasureString("W").Y));
                spriteBatch.DrawString(font, text, relativePosition, Color.White);

                if(menu.Index == i)
                {
                    Vector2 textSize = font.MeasureString(menu.Options[i].Text);
                    Rectangle border = new Rectangle((int)relativePosition.X, (int)relativePosition.Y, (int)textSize.X, (int)textSize.Y);
                    DrawUtility.drawBorder(spriteBatch, border, Color.Yellow, 2);
                }
            }
        }
    }
}
