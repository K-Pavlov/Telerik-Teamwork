namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Shield : Item, IDrawObject, ISpecial<double>
    {
        protected double defense;
        protected bool special;

        public Shield(Vector2 position, double defense, double block)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("karitnka"), position)
        {
            this.Defense = defense;
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

        public double ActivateSpecial()
        {
            return 0;
        }
    }
}
