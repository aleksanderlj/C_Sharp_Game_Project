using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using VaporWaves.Shooter;

namespace VaporWaves.Scene
{
    class HighscoreScene : IScene
    {
        SpriteFont font;
        public SceneManager SceneManager { get; set; }
        private XmlSerializer _serializer;
        private HighScoreTable _highScoreTable;
        private String _storagePath;
        private HighScoreRow newRow;

        public HighscoreScene(int newScore)
        {
            newRow = new HighScoreRow();
            newRow.Score = newScore;
            newRow.New = true;
        }

        public void Initialize()
        {
            _storagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VaporWaves");
            Directory.CreateDirectory(_storagePath);
            _serializer = new XmlSerializer(typeof(HighScoreTable));
            _highScoreTable = load();
            if (newRow.New)
            {
                _highScoreTable.HighScores.Add(newRow);
                _highScoreTable.HighScores = _highScoreTable.HighScores.OrderByDescending(x => x.Score).ToList();
            }
            save(_highScoreTable);
        }

        public void LoadContent()
        {
            TextureManager.LoadContent(SceneManager);
            font = TextureManager.BaseFont;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            SceneManager.GraphicsDevice.Clear(Color.Black);
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            List<HighScoreRow> rows = _highScoreTable.HighScores;
            spriteBatch.Begin();

            Vector2 basePosition = new Vector2((view.Width / 2) - (font.MeasureString("1. $0000").X / 2), 200);

            spriteBatch.DrawString(font, "Highscores", basePosition - new Vector2(0, font.MeasureString("1. $0000").Y + 5), Color.Red);

            for (int i = 0; i < 10; i++)
            {
                Vector2 offset = new Vector2(0, i * font.MeasureString("1. $0000").Y);
                if (i < rows.Count)
                {
                    Color color = rows[i].New ? Color.Yellow : Color.White;
                    spriteBatch.DrawString(font, (i+1).ToString() + ". $" + rows[i].Score, basePosition + offset, color);
                } else
                {
                    spriteBatch.DrawString(font, (i+1).ToString() + ". ----", basePosition + offset, Color.White);
                }
            }

            spriteBatch.DrawString(font, "F5 to restart", basePosition + new Vector2(0, (10 * font.MeasureString("1. $0000")).Y + 20), Color.CornflowerBlue);

            spriteBatch.End();
        }

        private void save(HighScoreTable highScoreTable)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(_storagePath, "highscore.sav")))
            {
                _serializer.Serialize(sw, highScoreTable);
            }
        }

        private HighScoreTable load()
        {
            HighScoreTable hst;
            if (File.Exists(Path.Combine(_storagePath, "highscore.sav")))
            {
                using (StreamReader sr = new StreamReader(Path.Combine(_storagePath, "highscore.sav")))
                {
                    hst = (HighScoreTable)_serializer.Deserialize(sr);
                }
            } else
            {
                hst = new HighScoreTable();
                hst.HighScores = new List<HighScoreRow>();
            }
            return hst;
        }
    }

    [Serializable]
    public struct HighScoreTable
    {
        public List<HighScoreRow> HighScores { get; set; }
    }

    [Serializable]
    public struct HighScoreRow
    {
        public int Score { get; set; }
        [XmlIgnore]
        public bool New { get; set; }
    }
}
