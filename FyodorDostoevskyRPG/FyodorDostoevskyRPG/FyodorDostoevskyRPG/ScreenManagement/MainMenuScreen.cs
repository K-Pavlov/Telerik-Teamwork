namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MainMenuScreen : BaseScreen
    {
        // Fields
        private KeyboardState currentKey, previousKey;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
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
                ScreenManager.Instance.LoadScreen(new TitleScreen());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
