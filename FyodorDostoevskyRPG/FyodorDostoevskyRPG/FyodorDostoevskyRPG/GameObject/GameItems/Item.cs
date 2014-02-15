namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public abstract class Item : ObjectRPG, IDrawObject
    {
        protected bool isUsed;

        protected Item(Texture2D image, Vector2 position)
            : base(image, position)
        {
        }
        
        public bool IsUsed
        {
            get
            {
                return this.isUsed;
            }
            set
            {
                this.isUsed = value;
            }
        }
    }
}
