using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Scene
{
    class PongScene : DrawableGameComponent
    {
        private readonly Game _game;

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

        public PongScene(Game game)
            : base(game)
        {
            this._game = game;

            ballPosition = new Vector2(game.Graphics.PreferredBackBufferWidth / 2, game.Graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 200f;
            ballXAngle = 1;
            ballYAngle = 1;

            paddleSpeed = 200f;

            player1Position = new Vector2(paddleWidth / 2, game.Graphics.PreferredBackBufferHeight / 2);
            player2Position = new Vector2(game.Graphics.PreferredBackBufferWidth - (paddleWidth / 2), game.Graphics.PreferredBackBufferHeight / 2);
        }
        public void Update(GameTime gameTime)
        {
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

            if (player1Position.Y > _graphics.PreferredBackBufferHeight - paddleTexture.Height / 2)
                player1Position.Y = _graphics.PreferredBackBufferHeight - paddleTexture.Height / 2;
            else if (player1Position.Y < 0 + paddleTexture.Height / 2)
                player1Position.Y = paddleTexture.Height / 2;

            if (player2Position.Y > _graphics.PreferredBackBufferHeight - paddleTexture.Height / 2)
                player2Position.Y = _graphics.PreferredBackBufferHeight - paddleTexture.Height / 2;
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


            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
            {
                ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
                player2Score++;
            }
            else if (ballPosition.X < 0 + ballTexture.Width / 2)
            {
                ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
                player1Score++;
            }

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                ballYAngle = 1;
            else if (ballPosition.Y < 0 + ballTexture.Height / 2)
                ballYAngle = -1;


            ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * ballXAngle;
            ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * ballYAngle;

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
