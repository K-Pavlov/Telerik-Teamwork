﻿namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ButtonManagement;

    public class MainMenuScreen : BaseScreen, IScreen
    {
        // Fields
        private Texture2D mainMenuBackground;
        private StartButton startBtn;
        private AboutButton aboutBtn;
        private ExitButton exitBtn;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            this.mainMenuBackground = this.baseScreenContentManager.Load<Texture2D>("MainMenuImage");

            this.startBtn = new StartButton(new Vector2(150, 100));
            this.aboutBtn = new AboutButton(new Vector2(150, 150));
            this.exitBtn = new ExitButton(new Vector2(150, 200));
            this.startBtn.Click += Button_Click;
            this.aboutBtn.Click += Button_Click;
            this.exitBtn.Click += Button_Click;
        }

        public override void Update(GameTime gameTime)
        {
            this.startBtn.Update();
            this.aboutBtn.Update();
            this.exitBtn.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mainMenuBackground, new Vector2(0, 0), Color.White);
            this.startBtn.Draw(spriteBatch);
            this.aboutBtn.Draw(spriteBatch);
            this.exitBtn.Draw(spriteBatch);
        }

        // Event handler
        void Button_Click(object sender, System.EventArgs e)
        {
            if (sender is StartButton)
            {
                ScreenManager.Instance.LoadScreen(new MapOneScreen());
                Sounds.StopMainMusic();
                Sounds.StartMapMusic();
            }
            else if (sender is AboutButton)
            {
                ScreenManager.Instance.LoadScreen(new AboutScreen());
            }
            else if (sender is ExitButton)
            {
                Sounds.StartExitMusic();
                System.Threading.Thread.Sleep(6500);
                FyodorsAdventure.ShouldExit = true;
            }
        }
    }
}
