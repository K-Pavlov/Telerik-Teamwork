namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;

    public abstract class Item : ObjectRPG, IDrawObject
    {
        protected bool isUsed;
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
