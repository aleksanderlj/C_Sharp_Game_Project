using VaporWaves.Shooter.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Shooter.Entities
{
    class Projectile : Entity
    {
        public Origin Origin { get; set; }
        public Projectile(Origin origin)
        {
            Origin = origin;
        }
    }
}
