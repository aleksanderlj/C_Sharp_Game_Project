using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VaporWaves.Shooter;
using System.Collections.Generic;

namespace VaporWaves.Scene
{
    class SceneManager : DrawableGameComponent
    {
        public static SpriteBatch SpriteBatch; // Shared SpriteBatch for scenes
        private Game game;
        private List<IScene> scenes = new List<IScene>();
        private List<IScene> scenesToUpdate = new List<IScene>();

        public SceneManager(Game game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadContent(this);

            // Only the very first scenes have content loaded here. The rest has their content loaded in AddScene();
            foreach(IScene scene in scenes)
            {
                scene.LoadContent();
            }
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            TextureManager.UnloadContent();
            foreach (IScene scene in scenes)
            {
                scene.UnloadContent();
            }
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // Creates separate update list since a scene may add or remove scenes to the master list in an update
            scenesToUpdate.Clear();
            scenesToUpdate.AddRange(scenes);

            // TODO Order of Update depending on focus
            foreach (IScene scene in scenesToUpdate)
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
            scene.LoadContent();
            scenes.Add(scene);
        }

        public void RemoveScene(IScene scene)
        {
            scene.UnloadContent();
            scenes.Remove(scene);
        }

        public void RemoveAllScenes()
        {
            foreach (IScene scene in scenes)
            {
                scene.UnloadContent();
            }
            scenes.Clear();
        }

        public void ExitGame()
        {
            game.Exit();
        }
    }
}
