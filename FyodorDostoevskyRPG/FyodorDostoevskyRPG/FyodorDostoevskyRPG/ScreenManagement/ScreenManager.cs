namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        // Fields
        private static ScreenManager instance;

        public ContentManager screenManagerContent;
        private Stack<BaseScreen> screenStack = new Stack<BaseScreen>();
        private BaseScreen currentScreen = new TitleScreen();

        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        // Constructors
        private ScreenManager()
        {
        }

        static ScreenManager()
        {
            ScreenManager.instance = new ScreenManager();
        }

        // Properties
        /// <summary>
        /// Access to the screen manager
        /// </summary>
        public static ScreenManager Instance
        {
            get
            {
                return ScreenManager.instance;
            }
        }

        /// <summary>
        /// Gets or sets the size of the screen
        /// </summary>
        public Vector2 ScreenSize { get; set; }

        // Methods
        /// <summary>
        /// Loads a new screen to be displayed
        /// </summary>
        public void LoadScreen(BaseScreen screen)
        {
            this.screenStack.Push(screen);
            //this.currentScreen.UnloadContent();
            this.currentScreen = screen;
            this.currentScreen.LoadContent(this.screenManagerContent);
        }

        /// <summary>
        /// Unloads the current screen and displays the previous
        /// </summary>
        public void UnloadScreen()
        {
            if (this.screenStack.Count > 1)
            {
                this.screenStack.Pop();
                this.currentScreen = this.screenStack.Peek();
            }
        }

        /// <summary>
        /// Loads the content in the current screen
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            this.screenManagerContent = new ContentManager(content.ServiceProvider, "Content");
            this.currentScreen.LoadContent(this.screenManagerContent);
        }

        /// <summary>
        /// Unloads the content of the current screen
        /// </summary>
        public void UnloadContent()
        {
            this.screenManagerContent.Unload();
        }

        /// <summary>
        /// Updates the current screen
        /// </summary>
        public void Update(GameTime gameTime)
        {
            this.currentScreen.Update(gameTime);
        }

        /// <summary>
        /// Draw the current screen
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentScreen.Draw(spriteBatch);
        }
    }
}
