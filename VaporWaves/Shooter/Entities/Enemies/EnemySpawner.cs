using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace VaporWaves.Shooter.Entities.Enemies
{
    class EnemySpawner
    {
        private int _difficulty;
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;

                double grunt = GruntFrequency;

                for (int i = 0; i < value; i++)
                {
                    grunt *= 0.9;
                }

                _gruntTimer = new Timer(grunt);
            }
        }
        private const double GruntFrequency = 5;
        private Timer _gruntTimer;
        public EnemySpawner(int difficulty)
        {
            Difficulty = difficulty;
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
