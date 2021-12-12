using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VaporWaves.Scene;
using System;

namespace VaporWaves
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
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();
            sceneManager.AddScene(new StartScene());
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
            if (Keyboard.GetState().IsKeyDown(Keys.F5))
                reset();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        private void reset()
        {
            sceneManager.RemoveAllScenes();
            sceneManager.AddScene(new StartScene());
        }

    }
}
