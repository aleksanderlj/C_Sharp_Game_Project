using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporWaves.Scene
{
    class PongScene : IScene
    {
        Texture2D ballTexture;
        Texture2D paddleTexture;
        Texture2D dummyTexture;
        SpriteFont scoreFont;

        float ballSpeed;
        Rectangle ballHitbox;
        int ballXAngle;
        int ballYAngle;

        int paddleWidth = 20;
        int paddleHeight = 100;
        float paddleSpeed;

        int player1Score = 0;
        int player2Score = 0;
        Vector2 player1Position;
        Rectangle player1Hitbox;
        Vector2 player2Position;
        Rectangle player2Hitbox;

        Vector2 ballPosition;

        public SceneManager SceneManager { get; set; }

        public PongScene()
        {
        }

        public void Initialize()
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;

            ballPosition = new Vector2(view.Width / 2, view.Height / 2);
            ballSpeed = 200f;
            ballXAngle = 1;
            ballYAngle = 1;

            paddleSpeed = 200f;

            player1Position = new Vector2(paddleWidth / 2, view.Height / 2);
            player2Position = new Vector2(view.Width - (paddleWidth / 2), view.Height / 2);
        }

        public void LoadContent()
        {
            ContentManager content = SceneManager.Game.Content;
            scoreFont = content.Load<SpriteFont>("BaseFont");
            ballTexture = content.Load<Texture2D>("ball");

            Color[] paddleData = new Color[paddleWidth * paddleHeight];
            for (int n = 0; n < paddleData.Length; n++) paddleData[n] = Color.White;
            paddleTexture = new Texture2D(SceneManager.GraphicsDevice, paddleWidth, paddleHeight);
            paddleTexture.SetData(paddleData);

            dummyTexture = new Texture2D(SceneManager.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
        }

        public void UnloadContent()
        {
            // Unload any content created outside the ContentManager
            paddleTexture.Dispose();
            dummyTexture.Dispose();
        }

        public void Update(GameTime gameTime)
        {
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                //ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                player2Position.Y -= paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                //ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                player2Position.Y += paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                //ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //player2Position.X -= paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                //ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //player2Position.X += paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.W))
            {
                player1Position.Y -= paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                player1Position.Y += paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                //player1Position.X -= paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.D))
            {
                //player1Position.X += paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (player1Position.Y > view.Height - paddleTexture.Height / 2)
                player1Position.Y = view.Height - paddleTexture.Height / 2;
            else if (player1Position.Y < 0 + paddleTexture.Height / 2)
                player1Position.Y = paddleTexture.Height / 2;

            if (player2Position.Y > view.Height - paddleTexture.Height / 2)
                player2Position.Y = view.Height - paddleTexture.Height / 2;
            else if (player2Position.Y < 0 + paddleTexture.Height / 2)
                player2Position.Y = paddleTexture.Height / 2;

            if (ballHitbox.Intersects(player1Hitbox))
            {
                ballXAngle = -1;
            }
            else if (ballHitbox.Intersects(player2Hitbox))
            {
                ballXAngle = 1;
            }

            if (ballPosition.X > view.Width - ballTexture.Width / 2)
            {
                ballPosition = new Vector2(view.Width / 2, view.Height / 2);
                player2Score++;
            }
            else if (ballPosition.X < 0 + ballTexture.Width / 2)
            {
                ballPosition = new Vector2(view.Width / 2, view.Height / 2);
                player1Score++;
            }

            if (ballPosition.Y > view.Height - ballTexture.Height / 2)
                ballYAngle = 1;
            else if (ballPosition.Y < 0 + ballTexture.Height / 2)
                ballYAngle = -1;


            ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * ballXAngle;
            ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * ballYAngle;

            updateHitboxes();

            //System.Diagnostics.Debug.WriteLine($"Ball Position: {ballPosition.X}, {ballPosition.Y}");

        }
        public void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = SceneManager.SpriteBatch;
            Viewport view = SceneManager.GraphicsDevice.Viewport;
            spriteBatch.Begin();

            spriteBatch.DrawString(scoreFont, $"{player1Score}", new Vector2(view.Width / 2 - 25, 50), Color.White);
            spriteBatch.DrawString(scoreFont, $"{player2Score}", new Vector2(view.Width / 2 + 25, 50), Color.White);

            spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            spriteBatch.Draw(paddleTexture,
                player1Position,
                null,
                Color.Blue,
                0f,
                new Vector2(paddleTexture.Width / 2, paddleTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );

            spriteBatch.Draw(paddleTexture,
                player2Position,
                null,
                Color.Red,
                0f,
                new Vector2(paddleTexture.Width / 2, paddleTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );

            //_spriteBatch.Draw(dummyTexture, Utility.createHitbox(player1Position, paddleTexture), Color.DarkRed);
            //_spriteBatch.Draw(dummyTexture, Utility.createHitbox(ballPosition, ballTexture), Color.DarkRed);

            spriteBatch.End();
        }

        void updateHitboxes()
        {
            player1Hitbox = UpdateUtility.createHitbox(player1Position, paddleTexture);
            player2Hitbox = UpdateUtility.createHitbox(player2Position, paddleTexture);
            ballHitbox = UpdateUtility.createHitbox(ballPosition, ballTexture);
        }
    }
}
