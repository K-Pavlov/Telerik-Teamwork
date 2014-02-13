namespace FyodorDostoevskyRPG
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class Animation
    {
        // Fields
        private int frameCount;
        private int switchFrame;
        private bool isActive;

        private int spriteRow; // za da znaem na koi red i koq kolona ot animaciqta sme
        private int spriteCol; // syotvetno risuwame tazi chast ot kartinkata (0-pyrwi red; 1-vtori red....)

        private Vector2 position, amountOfFrames;
        private Texture2D image;
        private Rectangle currentSprite;

        // Properties
        #region Properties        
        public Texture2D Image
        {
            set { this.image = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public int SpriteRow
        {
            get { return this.spriteRow; }
            set { this.spriteRow = value; }
        }

        public int FrameWidth
        {
            get { return this.image.Width / (int)this.amountOfFrames.X; }
        }

        public int FrameHeight
        {
            get { return this.image.Height / (int)this.amountOfFrames.Y; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
        #endregion

        // Constructor
        public Animation(Vector2 position, Vector2 rowNcol)
        {
            this.isActive = false;
            this.switchFrame = 100;
            this.position = position;
            this.amountOfFrames = rowNcol;
        }

        // Methods
        public void Update(GameTime gameTime)
        {
            if (this.isActive)
                this.frameCount += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            else
                this.frameCount = 0;

            if (this.frameCount >= this.switchFrame)
            {
                this.frameCount = 0;
                this.spriteCol += this.FrameWidth;

                if (this.spriteCol >= this.image.Width)
                {
                    this.spriteCol = 0;
                }
            }

            this.currentSprite = new Rectangle(this.spriteCol, this.spriteRow * this.FrameHeight, this.FrameWidth, this.FrameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.Position, this.currentSprite, Color.White);
        }
    }
}
