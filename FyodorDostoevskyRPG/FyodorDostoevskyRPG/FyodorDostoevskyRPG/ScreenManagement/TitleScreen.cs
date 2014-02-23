namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class TitleScreen : BaseScreen, IScreen
    {
        private KeyboardState currentKey, previousKey;
        private Texture2D logo;
        public Images Image;

        public override void LoadContent(ContentManager content)
        {
            Sounds.StartMainMusic();
            base.LoadContent(content);
            this.logo = this.baseScreenContentManager.Load<Texture2D>("TitleImage");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.previousKey = this.currentKey;
            this.currentKey = Keyboard.GetState();

            if (this.previousKey.IsKeyDown(Keys.Space) && this.currentKey.IsKeyUp(Keys.Space))
            {
                ScreenManager.Instance.LoadScreen(new MainMenuScreen());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo, new Vector2(0, 0), Color.White);
        }
    }
}
