namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.ScreenManagement;

    public class AboutButton : Button
    {
        // Constructor
        public AboutButton(Vector2 pos)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/aboutUP"),
                   ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/aboutOVER"),
                   ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/aboutDOWN"), pos)
        {
        }
    }
}
