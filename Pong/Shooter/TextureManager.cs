using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Shooter
{
    class TextureManager
    {
        public static Texture2D Player { get; set; }
        public static Texture2D Grunt { get; set; }
        public static Texture2D BasicGunProjectile { get; set; }
        public static Texture2D GruntGunProjectile { get; set; }
        public static void LoadContent(GraphicsDevice graphicsDevice)
        {
            Texture2D blankTexture = new Texture2D(graphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });

            Player = blankTexture;
            Grunt = blankTexture;
            BasicGunProjectile = blankTexture;
            GruntGunProjectile = blankTexture;
        }

        public static void UnloadContent()
        {
            Player.Dispose();
            Grunt.Dispose();
            BasicGunProjectile.Dispose();
            GruntGunProjectile.Dispose();
        }
    }
}
