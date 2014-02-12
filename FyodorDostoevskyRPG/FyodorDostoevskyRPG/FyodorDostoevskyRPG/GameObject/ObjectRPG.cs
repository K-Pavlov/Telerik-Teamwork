﻿namespace FyodorDostoevskyRPG.GameObject
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;    

    public abstract class ObjectRPG : IDrawObject
    {
        protected Vector2 position;
        protected Texture2D image;

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if ((value.X < 0) || (value.X > 800) || (value.Y < 0) || (value.Y > 600))
                {
                    throw new ArgumentOutOfRangeException("Coordinates out of screen! (800x600)");
                }
                this.position.X = value.X;
                this.position.Y = value.Y;
            }
        }
        public Texture2D Image
        {
            get
            {
                return this.image;
            }
            
        }
        #region IDrawObject Members

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.position, Color.White);
        }

        #endregion
    }
}