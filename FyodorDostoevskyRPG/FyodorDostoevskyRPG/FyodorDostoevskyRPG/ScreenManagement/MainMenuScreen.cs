namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ButtonManagement;

    public class MainMenuScreen : BaseScreen
    {
        // Fields
        private Texture2D mainMenuBackground;
        private StartButton startBtn;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.mainMenuBackground = this.baseScreenContentManager.Load<Texture2D>("MainMenuImage");

            this.startBtn = new StartButton(new Vector2(150, 100));
            this.startBtn.Click += strBtn_Click;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.startBtn.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mainMenuBackground, new Vector2(0, 0), Color.White);
            this.startBtn.Draw(spriteBatch);
        }

        // Event handler
        void strBtn_Click(object sender, System.EventArgs e)
        {
            if (sender is StartButton)
            {
                ScreenManager.Instance.LoadScreen(new MapOneScreen());
            }            
        }
    }
}
