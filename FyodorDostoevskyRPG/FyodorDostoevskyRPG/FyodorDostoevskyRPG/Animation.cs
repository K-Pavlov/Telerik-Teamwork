namespace FyodorDostoevskyRPG
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Animation
    {
        private int frameCount;
        private int switchFrame;
        private int spriteCol;
        private Vector2 amountOfFrames;
        private Texture2D image;
        private Rectangle currentSprite;
        private Vector2 position;

        public Texture2D Image
        {
            set
            {
                this.image = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value.X <= -10)
                {
                    this.position.X = 3;
                    this.position.Y = value.Y;
                }
                else if (value.X >= 760)
                {
                    this.position.X = 750;
                    this.position.Y = value.Y;
                }
                else if (value.Y <= -10)
                {
                    this.position.X = value.X;
                    this.position.Y = 3;
                }
                else if (value.Y >= 540)
                {
                    this.position.X = value.X;
                    this.position.Y = 530;
                }
                else
                {
                    this.position = value;
                }

            }
        }

        public int SpriteRow { get; set; }

        public int FrameWidth
        {
            get
            {
                return this.image.Width / (int)this.amountOfFrames.X;
            }
        }

        public int FrameHeight
        {
            get
            {
                return this.image.Height / (int)this.amountOfFrames.Y;
            }
        }

        public bool IsActive { get; set; }

        public Animation(Vector2 position, Vector2 rowNcol)
        {
            this.IsActive = false;
            this.switchFrame = 100;
            this.Position = position;
            this.amountOfFrames = rowNcol;
        }

        public void Update(GameTime gameTime)
        {
            if (this.IsActive)
            {
                this.frameCount += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                this.frameCount = 0;
            }
            if (this.frameCount >= this.switchFrame)
            {
                this.frameCount = 0;
                this.spriteCol += this.FrameWidth;

                if (this.spriteCol >= this.image.Width)
                {
                    this.spriteCol = 0;
                }
            }

            this.currentSprite = new Rectangle(this.spriteCol, this.SpriteRow * this.FrameHeight, this.FrameWidth, this.FrameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.Position, this.currentSprite, Color.White);
        }
    }
}
