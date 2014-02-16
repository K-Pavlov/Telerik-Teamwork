namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class StartButton : Button
    {
        public StartButton(Vector2 pos)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("some-button"), pos)
        {
        }
    }
}
