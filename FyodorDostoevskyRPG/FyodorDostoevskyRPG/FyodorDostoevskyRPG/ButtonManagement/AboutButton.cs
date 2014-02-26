namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.ScreenManagement;

    public class AboutButton : Button, IButton
    {
        // Constructor
        public AboutButton(Vector2 pos)
            : base(ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("Buttons/aboutUP"),
                   ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("Buttons/aboutOVER"),
                   ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("Buttons/aboutDOWN"), pos)
        {
        }
    }
}
