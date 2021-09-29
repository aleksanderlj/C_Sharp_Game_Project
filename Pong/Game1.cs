using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Scene;
using System;

namespace Pong
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics;
        SceneManager sceneManager;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // By adding sceneManager to Components, it's Update and Draw is called when this class' Update and Draw are.
            sceneManager = new SceneManager(this);
            Components.Add(sceneManager);
        }

        protected override void Initialize()
        {
            //System.Diagnostics.Debug.WriteLine("Initializing...");
            sceneManager.AddScene(new PongScene());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //System.Diagnostics.Debug.WriteLine("Loading content...");

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

    }
}
