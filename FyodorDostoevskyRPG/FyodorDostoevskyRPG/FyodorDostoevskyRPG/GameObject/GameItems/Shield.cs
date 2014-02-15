namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Shield : Item, IDrawObject, ISpecial<double>
    {
        protected double defense;

        public Shield(Vector2 position, double defense)
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
            return this.Defense + 60;
        }
    }
}
