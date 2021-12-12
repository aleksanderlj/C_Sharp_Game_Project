using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Pong.Shooter.Entities.Enemies
{
    class EnemySpawner
    {
        public int Difficulty { get; set; }
        private const double GruntFrequency = 5;
        private Timer _gruntTimer;
        public EnemySpawner()
        {
            _gruntTimer = new Timer(GruntFrequency);
        }
        public List<Enemy> Spawn(GameTime gameTime)
        {
            List<Enemy> enemies = new List<Enemy>();

            if (_gruntTimer.TimeIsUp(gameTime))
            {
                enemies.Add(new Grunt());
            }

            return enemies;
        }
    }
}
