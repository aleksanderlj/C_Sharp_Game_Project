using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves
{
    static class UpdateUtility
    {
        public static Rectangle createHitbox(Vector2 position, Texture2D texture)
        {
            return new Rectangle(
                (int)(position.X - texture.Width / 2),
                (int)(position.Y - texture.Height / 2),
                texture.Width,
                texture.Height
                );
        }
    }
}
