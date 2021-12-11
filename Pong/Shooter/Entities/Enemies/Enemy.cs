﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Shooter.Entities.Enemies
{
    abstract class Enemy : Entity
    {
        public abstract List<Projectile> Shoot(GameTime gameTime);
    }
}