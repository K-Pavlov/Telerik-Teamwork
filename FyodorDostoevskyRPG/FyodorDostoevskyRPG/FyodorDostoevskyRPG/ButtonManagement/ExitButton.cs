namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.ScreenManagement;

    class ExitButton : Button, IButton
    {
        // Constructor
        public ExitButton(Vector2 pos)
            : base(ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("Buttons/exitUP"),
                   ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("Buttons/exitOVER"),
                   ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("Buttons/exitDOWN"), pos)
        {
        }
    }
}
