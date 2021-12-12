﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Scene;

namespace Pong.Shooter
{
    class TextureManager
    {
        public static SpriteFont BaseFont { get; set; }
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
