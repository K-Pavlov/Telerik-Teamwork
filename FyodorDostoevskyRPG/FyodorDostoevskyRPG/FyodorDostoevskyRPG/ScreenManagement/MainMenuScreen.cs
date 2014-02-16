namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MainMenuScreen : BaseScreen
    {
        // Fields
        private Texture2D mainMenuBackground;

        private Texture2D startButtonImage;        
        private Vector2 startButtonPosition;
        private Rectangle startButtonRect;
        private Color startButtonColor;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.mainMenuBackground = this.baseScreenContentManager.Load<Texture2D>("MainMenuImage");

            this.startButtonImage = this.baseScreenContentManager.Load<Texture2D>("some-button");
            this.startButtonPosition = new Vector2(150, 100);
            this.startButtonRect = new Rectangle((int)this.startButtonPosition.X, (int)this.startButtonPosition.Y, this.startButtonImage.Width, this.startButtonImage.Height);
            this.startButtonColor = new Color(255, 255, 255);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.startButtonRect.Intersects(InputManager.Instance.MouseRectanle))
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
            spriteBatch.Draw(mainMenuBackground, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(startButtonImage, startButtonPosition, startButtonColor);
        }
    }
}
