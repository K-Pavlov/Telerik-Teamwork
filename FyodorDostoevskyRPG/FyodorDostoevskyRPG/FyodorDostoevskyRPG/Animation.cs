namespace FyodorDostoevskyRPG
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Animation
    {
        // Fields
        static int frameCounter = 0;
        private int frameCount;
        private int switchFrame;
        private int spriteCol;
        private Vector2 amountOfFrames;
        private Texture2D image;
        private Rectangle currentSprite;
        private Vector2 position;

        // Constructor
        /// <summary>
        /// Creates a new animation
        /// </summary>
        /// <param name="position">The position of the animation</param>
        /// <param name="rowNcol">The number of rows and columns of the animation spritesheet</param>
        public Animation(Vector2 position, Vector2 rowNcol)
        {
            this.IsActive = false;
            this.switchFrame = 100;
            this.Position = position;
            this.amountOfFrames = rowNcol;
        }

        // Properties
        /// <summary>
        /// Sets the animation image
        /// </summary>
        public Texture2D Image
        {
            set
            {
                this.image = value;
            }
        }

        /// <summary>
        /// Gets or sets the animation position
        /// </summary>
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
                    Sounds.BoundaryBounceSound.Play();
                }
                else if (value.X >= 760)
                {
                    this.position.X = 750;
                    this.position.Y = value.Y;
                    Sounds.BoundaryBounceSound.Play();
                }
                else if (value.Y <= -10)
                {
                    this.position.X = value.X;
                    this.position.Y = 3;
                    Sounds.BoundaryBounceSound.Play();
                }
                else if (value.Y >= 540)
                {
                    this.position.X = value.X;
                    this.position.Y = 530;
                    Sounds.BoundaryBounceSound.Play();
                }
                else
                {
                    this.position = value;
                }

            }
        }

        /// <summary>
        /// Gets or sets the row of the animation spritesheet
        /// </summary>
        public int SpriteRow { get; set; }

        /// <summary>
        /// Gets the sprite width
        /// </summary>
        public int FrameWidth
        {
            get
            {
                return this.image.Width / (int)this.amountOfFrames.X;
            }
        }

        /// <summary>
        /// Gets the sprite height
        /// </summary>
        public int FrameHeight
        {
            get
            {
                return this.image.Height / (int)this.amountOfFrames.Y;
            }
        }

        /// <summary>
        /// Gets or sets the state of the animation
        /// </summary>
        public bool IsActive { get; set; }

        // Methods
        /// <summary>
        /// Updates the animation sprite and position
        /// </summary>
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
                frameCounter++;
                if (frameCounter == 4)
                {
                    Sounds.Step.Play();
                    frameCounter = 0;
                }

                this.frameCount = 0;
                this.spriteCol += this.FrameWidth;

                if (this.spriteCol >= this.image.Width)
                {
                    this.spriteCol = 0;
                }
            }

            this.currentSprite = new Rectangle(this.spriteCol, this.SpriteRow * this.FrameHeight, this.FrameWidth, this.FrameHeight);
        }

        /// <summary>
        /// Draws the animation
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.Position, this.currentSprite, Color.White);
        }
    }
}
