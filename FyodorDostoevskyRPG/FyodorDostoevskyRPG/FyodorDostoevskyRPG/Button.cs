namespace FyodorDostoevskyRPG
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Button
    {
        // Fields
        public event EventHandler Hover;
        public event EventHandler Click;

        // Constructor
        protected Button(Texture2D image, Vector2 pos)
        {
            this.Image = image;
            this.Position = pos;
        }

        // Properties
        public Texture2D Image { get; private set; }
        public Vector2 Position { get; private set; }

        // Methods
        protected virtual void OnHover(EventArgs e)
        {
            if (this.Hover != null)
            {
                this.Hover(this, e);
            }
        }

        protected virtual void OnClick(EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }
}
