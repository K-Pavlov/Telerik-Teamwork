namespace FyodorDostoevskyRPG.GameObject
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;    

    public abstract class ObjectRPG : IDrawObject
    {
        // Fields
        private Vector2 position;
        private Texture2D image;

        // Properties
        public Vector2 Position
        {
            get { return this.position; }
            protected set
            {
                if ((value.X < 0) || (value.X > 800) || (value.Y < 0) || (value.Y > 600))
                {
                    throw new ArgumentOutOfRangeException("Coordinates out of screen! (800x600)");
                }

                this.position = value;
            }
        }

        public Texture2D Image
        {
            get { return this.image; }
            protected set { this.image = value; }
        }

        // Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.position, Color.White);
        }
    }
}
