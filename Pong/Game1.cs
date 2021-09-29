using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Game1 : Game
    {
        private Scene.IScene _scene;

        SpriteFont scoreFont;

        Texture2D ballTexture;
        Texture2D paddleTexture;
        Texture2D dummyTexture;

        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            System.Diagnostics.Debug.WriteLine("Initializing...");
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            System.Diagnostics.Debug.WriteLine("Loading content...");
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            scoreFont = Content.Load<SpriteFont>("Score");
            ballTexture = Content.Load<Texture2D>("ball");

            Color[] paddleData = new Color[paddleWidth * paddleHeight];
            for (int n = 0; n < paddleData.Length; n++) paddleData[n] = Color.White;
            paddleTexture = new Texture2D(GraphicsDevice, paddleWidth, paddleHeight);
            paddleTexture.SetData(paddleData);

            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _scene.Update(gameTime);
            updateHitboxes();

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            // TODO: Add your drawing code here
            _scene.Draw(gameTime, SpriteBatch);
            SpriteBatch.Begin();

            SpriteBatch.DrawString(scoreFont, $"{player1Score}", new Vector2(Graphics.PreferredBackBufferWidth / 2 - 25, 50), Color.White);
            SpriteBatch.DrawString(scoreFont, $"{player2Score}", new Vector2(Graphics.PreferredBackBufferWidth / 2 + 25, 50), Color.White);

            SpriteBatch.Draw(
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
            
            SpriteBatch.Draw(paddleTexture,
                player1Position,
                null,
                Color.Blue,
                0f,
                new Vector2(paddleTexture.Width / 2, paddleTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );

            SpriteBatch.Draw(paddleTexture,
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

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        void updateHitboxes()
        {
            player1Hitbox = Utility.createHitbox(player1Position, paddleTexture);
            player2Hitbox = Utility.createHitbox(player2Position, paddleTexture);
            ballHitbox = Utility.createHitbox(ballPosition, ballTexture);
        }
    }
}
