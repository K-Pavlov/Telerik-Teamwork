namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class GameWinScreen : BaseScreen, IScreen
    {
        private Texture2D gameWingImage;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.gameWingImage = this.baseScreenContentManager.Load<Texture2D>("win");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.Escape))
            {
                FyodorsAdventure.ShouldExit = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.gameWingImage, Vector2.Zero, Color.White);
        }
    }
}
