namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.ScreenManagement;

    class ExitButton : Button
    {
        // Constructor
        public ExitButton(Vector2 pos)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/exitUP"),
                   ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/exitOVER"),
                   ScreenManager.Instance.screenManagerContent.Load<Texture2D>("Buttons/exitDOWN"), pos)
        {
        }
    }
}
