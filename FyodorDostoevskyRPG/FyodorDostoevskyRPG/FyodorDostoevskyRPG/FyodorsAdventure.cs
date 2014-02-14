namespace FyodorDostoevskyRPG
{
    using FyodorDostoevskyRPG.ScreenManagement;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class FyodorsAdventure : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        private Texture2D customCursor;

        public FyodorsAdventure()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";
            this.IsMouseVisible = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;


            this.customCursor = Content.Load<Texture2D>("mouseCursor");
            ScreenManager.Instance.LoadContent(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            InputManager.Instance.Update();
            ScreenManager.Instance.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            this.spriteBatch.Begin();
            ScreenManager.Instance.Draw(this.spriteBatch);
            this.spriteBatch.Draw(this.customCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            this.spriteBatch.End();
        }
    }
}
