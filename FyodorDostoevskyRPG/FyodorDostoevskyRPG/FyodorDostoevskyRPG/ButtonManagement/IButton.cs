namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IButton
    {
        event EventHandler Click;

        Texture2D BtnImageUp { get; }
        Texture2D BtnImageOver { get; }
        Texture2D BtnImageDown { get; }

        Vector2 BtnPosition { get; }
        Rectangle BtnRectangle { get; }
        ButtonStatus ButtonState { get; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
