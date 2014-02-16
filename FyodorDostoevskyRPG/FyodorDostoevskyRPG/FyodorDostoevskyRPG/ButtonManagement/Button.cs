namespace FyodorDostoevskyRPG.ButtonManagement
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
            this.BtnImage = image;
            this.BtnPosition = pos;
            this.BtnRectangle = new Rectangle((int)pos.X, (int)pos.Y, image.Width, image.Height);
            this.BtnColor = Color.White;
        }

        // Properties
        public Texture2D BtnImage { get; private set; }
        public Vector2 BtnPosition { get; private set; }
        public Rectangle BtnRectangle { get; private set; }
        public Color BtnColor { get; private set; }

        // Methods
        public void Update()
        {
            if (this.BtnRectangle.Intersects(InputManager.Instance.MouseRectanle))
            {
                this.BtnColor = Color.Red;
                if (InputManager.Instance.MouseLeftButtonDown())
                {
                    this.BtnColor = Color.DarkRed;
                }
                else if (InputManager.Instance.MouseLeftButtonPressedInverted() && this.Click != null)
                {
                    this.Click(this, new EventArgs());
                }
            }
            else
            {
                this.BtnColor = Color.White;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.BtnImage, this.BtnRectangle, this.BtnColor);
        }

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
