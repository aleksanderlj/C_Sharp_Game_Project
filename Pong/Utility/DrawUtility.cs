using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Utility
{
    static class DrawUtility
    {
        static Texture2D borderTexture; //TODO bad programming, needs to be disposable
        public static void drawBorder(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth)
        {
            if (borderTexture == null)
            {
                borderTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                borderTexture.SetData(new Color[] { Color.White });
            }
            spriteBatch.Draw(borderTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(borderTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(borderTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(borderTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }
    }
}
