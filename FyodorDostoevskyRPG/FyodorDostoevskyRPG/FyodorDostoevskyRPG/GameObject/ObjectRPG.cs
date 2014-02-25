namespace FyodorDostoevskyRPG.GameObject
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class ObjectRPG : IDrawObject
    {
        private Vector2 position;

        // Constructor
        protected ObjectRPG(Texture2D image, Vector2 position)
        {
            this.Image = image;
            this.Position = position;
        }

        /// <summary>
        /// Gets the position of the object
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            protected set
            {
                this.position = value;
            }
        }

        /// <summary>
        /// Gets the image of the object
        /// </summary>
        public Texture2D Image { get; protected set; }

        /// <summary>
        /// Draws the object on the screen
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.position, Color.White);
        }
    }
}
