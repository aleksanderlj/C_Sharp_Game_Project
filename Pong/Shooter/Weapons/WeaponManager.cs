using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter.Weapons
{
    class WeaponManager
    {
        public static void LoadContent(GraphicsDevice graphicsDevice)
        {
            BasicGun.LoadContent(graphicsDevice);
        }

        public static void UnloadContent()
        {
            BasicGun.UnloadContent();
        }
    }
}
