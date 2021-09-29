using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Scene
{
    class SceneManager : DrawableGameComponent
    {
        public SpriteBatch SpriteBatch { get; set; } // Shared SpriteBatch for scenes
        private List<IScene> scenes = new List<IScene>();

        public SceneManager(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            foreach(IScene scene in scenes)
            {
                scene.LoadContent();
            }
            base.LoadContent();
        }

        protected override void UnloadContent()
        {

            foreach (IScene scene in scenes)
            {
                scene.UnloadContent();
            }
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO Order of Update depending on focus
            foreach (IScene scene in scenes)
            {
                scene.Update(gameTime);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // TODO Order of Draw depending on focus
            foreach (IScene scene in scenes)
            {
                scene.Draw(gameTime);
            }
            base.Draw(gameTime);
        }

        public void AddScene(IScene scene)
        {
            scene.SceneManager = this;
            scene.Initialize();
            scenes.Add(scene);
        }

        public void RemoveScene(IScene scene)
        {
            scene.UnloadContent();
            scenes.Remove(scene);
        }
    }
}
