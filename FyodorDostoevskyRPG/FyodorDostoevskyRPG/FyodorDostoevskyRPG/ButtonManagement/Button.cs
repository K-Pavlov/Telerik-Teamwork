namespace FyodorDostoevskyRPG.ButtonManagement
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Audio;

    public abstract class Button : IButton
    {
        // Fields
        public event EventHandler Hover;
        public event EventHandler Click;

        private readonly SoundEffect mouseClickSound;

        // Constructor
        protected Button(Texture2D imageUp, Texture2D imageOver, Texture2D imageDown, Vector2 pos)
        {
            this.mouseClickSound = ScreenManagement.ScreenManager.Instance.ScreenManagerContent.Load<SoundEffect>("Sounds/mouse-click"); 

            this.BtnImageUp = imageUp;
            this.BtnImageOver = imageOver;
            this.BtnImageDown = imageDown;

            this.BtnPosition = pos;
            this.BtnRectangle = new Rectangle((int)pos.X, (int)pos.Y, imageUp.Width, imageUp.Height);
        }

        // Properties
        public Texture2D BtnImageUp { get; private set; }
        public Texture2D BtnImageOver { get; private set; }
        public Texture2D BtnImageDown { get; private set; }


        public Vector2 BtnPosition { get; private set; }
        public Rectangle BtnRectangle { get; private set; }
        public ButtonStatus ButtonState { get; private set; }

        // Methods
        public void Update()
        {
            if (this.BtnRectangle.Intersects(InputManager.Instance.MouseRectanle))
            {
                this.ButtonState = ButtonStatus.Over;
                if (InputManager.Instance.MouseLeftButtonDown())
                {
                    this.ButtonState = ButtonStatus.Down;
                }
                else if (InputManager.Instance.MouseLeftButtonPressedInverted() && this.Click != null)
                {
                    this.mouseClickSound.Play();
                    this.Click(this, new EventArgs());
                }
            }
            else
            {
                this.ButtonState = ButtonStatus.Up;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (this.ButtonState)
            {
                case ButtonStatus.Up:
                    spriteBatch.Draw(this.BtnImageUp, this.BtnRectangle, Color.White);
                    break;
                case ButtonStatus.Over:
                    spriteBatch.Draw(this.BtnImageOver, this.BtnRectangle, Color.White);
                    break;
                case ButtonStatus.Down:
                    spriteBatch.Draw(this.BtnImageDown, this.BtnRectangle, Color.White);
                    break;
            }
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
