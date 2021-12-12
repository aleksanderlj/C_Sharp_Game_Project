using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using VaporWaves.Scene;

namespace VaporWaves.Shooter
{
    class TextureManager
    {
        public static SpriteFont BaseFont { get; set; }
        public static SpriteFont BaseFontSmall { get; set; }
        public static Texture2D Title { get; set; }
        public static Texture2D Player { get; set; }
        public static Texture2D Grunt { get; set; }
        public static Texture2D BasicGunProjectile { get; set; }
        public static Texture2D GruntGunProjectile { get; set; }
        public static void LoadContent(SceneManager sceneManager)
        {
            ContentManager content = sceneManager.Game.Content;

            Texture2D blankTexture = new Texture2D(sceneManager.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });

            BaseFont = content.Load<SpriteFont>("BaseFont");
            BaseFontSmall = content.Load<SpriteFont>("BaseFontSmall");
            Title = content.Load<Texture2D>("title");
            Player = content.Load<Texture2D>("player");
            Grunt = content.Load<Texture2D>("grunt");
            BasicGunProjectile = blankTexture;
            GruntGunProjectile = blankTexture;
        }

        public static void UnloadContent()
        {
            Title.Dispose();
            Player.Dispose();
            Grunt.Dispose();
            BasicGunProjectile.Dispose();
            GruntGunProjectile.Dispose();
        }
    }
}
