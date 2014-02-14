namespace FyodorDostoevskyRPG.GameObject
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class ObjectRPG : IDrawObject
    {
        private Vector2 position;

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            protected set
            {
                if ((value.X < 0) || (value.X > 800) || (value.Y < 0) || (value.Y > 600))
                {
                    throw new ArgumentOutOfRangeException("Coordinates out of screen! (800x600)");
                }

                this.position = value;
            }
        }

        public Texture2D Image { get; protected set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.position, Color.White);
        }
    }
}
