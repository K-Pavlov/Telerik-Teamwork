namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        private static ScreenManager instance;

        public ContentManager screenManagerContent;
        private Stack<BaseScreen> screenStack = new Stack<BaseScreen>();
        private BaseScreen currentScreen = new TitleScreen();

        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        private ScreenManager()
        {
        }

        static ScreenManager()
        {
            ScreenManager.instance = new ScreenManager();
        }

        public static ScreenManager Instance
        {
            get
            {
                return ScreenManager.instance;
            }
        }

        public Vector2 ScreenSize { get; set; }

        public void LoadScreen(BaseScreen screen)
        {
            this.screenStack.Push(screen);
            this.currentScreen.UnloadContent();
            this.currentScreen = screen;
            this.currentScreen.LoadContent(this.screenManagerContent);
        }

        public void UnloadScreen(BaseScreen screen)
        {
        }

        public void LoadContent(ContentManager content)
        {
            this.screenManagerContent = new ContentManager(content.ServiceProvider, "Content");
            this.currentScreen.LoadContent(this.screenManagerContent);
        }

        public void UnloadContent()
        {
            this.screenManagerContent.Unload();
        }

        public void Update(GameTime gameTime)
        {
            this.currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentScreen.Draw(spriteBatch);
        }
    }
}
