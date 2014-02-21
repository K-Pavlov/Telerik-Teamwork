namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class AboutScreen : BaseScreen, IScreen
    {
        // Fields
        private Texture2D credits;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.credits = this.baseScreenContentManager.Load<Texture2D>("Credits");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.Escape))
            {
                ScreenManager.Instance.UnloadScreen();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.credits, Vector2.Zero, Color.White);
        }
    }
}
