namespace FyodorDostoevskyRPG.ScreenManagement
{    
    using System.Collections.Generic;
    
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        private static ScreenManager instance;

        private ContentManager screenManagerContent;
        private Stack<BaseScreen> screenStack = new Stack<BaseScreen>();
        private BaseScreen currentScreen = new TitleScreen();
        private Vector2 screenSize;

        #region Constructors
        // private za da ne moje da se instancira poveche ot vednuj
        private ScreenManager() { }
        static ScreenManager()
        {
            ScreenManager.instance = new ScreenManager();
        }
        #endregion

        #region Properties
        // za dostypvane na instanciqta i goleminata na segashniq ekran
        public static ScreenManager Instance
        {
            get { return ScreenManager.instance; }
        }

        public Vector2 ScreenSize
        {
            get { return this.screenSize; }
            set { this.screenSize = value; }
        }
        #endregion

        // Methods
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
