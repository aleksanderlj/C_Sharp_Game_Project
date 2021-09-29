using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Scene
{
    interface IScene
    {
        public SceneManager SceneManager { get; set; }
        void Initialize();
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
