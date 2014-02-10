﻿namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class TitleScreen : BaseScreen
    {
        // Fields
        private KeyboardState currentKey, previousKey;
        private Texture2D logo;
        public Images Image;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            // link to download the image: http://reggiocomics.files.wordpress.com/2010/04/2324.jpg
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