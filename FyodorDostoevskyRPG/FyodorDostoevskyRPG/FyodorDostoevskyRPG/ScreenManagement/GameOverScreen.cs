namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class GameOverScreen : BaseScreen, IScreen
    {
        private Texture2D gameOverImage;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.gameOverImage = this.baseScreenContentManager.Load<Texture2D>("gameOver");
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
            spriteBatch.Draw(this.gameOverImage, Vector2.Zero, Color.White);
        }
    }
}
