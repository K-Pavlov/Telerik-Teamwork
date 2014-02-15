namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Shield : Item, IDrawObject
    {
        protected double defense;
        protected double block;
        protected bool special;

        public Shield(Vector2 position, double defense, double block, bool special)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("karitnka"), position)
        {
            this.Defense = defense;
            this.Block = block;
            this.Special = special;
        }

        public double Defense
        {
            get
            {
                return this.defense;
            }
            set
            {
                this.defense = value;
            }
        }

        public double Block
        {
            get
            {
                return this.block;
            }
            set
            {
                this.block = value;
            }
        }

        public bool Special
        {
            get
            {
                return this.special;
            }
            set
            {
                this.special = value;
            }
        }
    }
}
