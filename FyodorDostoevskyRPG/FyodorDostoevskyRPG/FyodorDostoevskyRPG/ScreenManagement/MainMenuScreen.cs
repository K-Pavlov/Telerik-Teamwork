namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MainMenuScreen : BaseScreen
    {
        private KeyboardState currentKey, previousKey;
        private Texture2D logo;

        // Start button
        private Texture2D startGameButton;
        private Vector2 startButtonPosition = new Vector2(150, 100);
        private Color startButtonColor = new Color(255, 255, 255);


        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.logo = this.baseScreenContentManager.Load<Texture2D>("MainMenuImage");
            this.startGameButton = this.baseScreenContentManager.Load<Texture2D>("some-button");
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
                ScreenManager.Instance.LoadScreen(new MapOneScreen());
            }

            Vector2 mousePosition = InputManager.Instance.MousePosition;
            if ((mousePosition.X > startButtonPosition.X && mousePosition.Y > startButtonPosition.Y)
                && (mousePosition.X < startGameButton.Width + startButtonPosition.X
                && mousePosition.Y < startGameButton.Height + startButtonPosition.Y))
            {
                startButtonColor = new Color(300, 0, 0);
                if (InputManager.Instance.MouseLeftButtonPressed())
                {
                    {
                        ScreenManager.Instance.LoadScreen(new MapOneScreen());
                    }
                }
            }
            else
            {
                startButtonColor = new Color(255, 255, 255); ;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(startGameButton, startButtonPosition, startButtonColor);
        }
    }
}
