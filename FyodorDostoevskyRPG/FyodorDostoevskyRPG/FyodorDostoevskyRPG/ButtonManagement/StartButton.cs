namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.ScreenManagement;

    public class StartButton : Button, IButton
    {
        // Constructor
        public StartButton(Vector2 pos)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/startUP"),
                   ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/startOVER"),
                   ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/startDOWN"), pos)
        {
        }
    }
}
