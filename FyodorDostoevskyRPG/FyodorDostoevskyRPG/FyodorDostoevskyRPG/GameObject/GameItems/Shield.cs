namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Shield : Item, IDrawObject
    {
        protected double defense;
        private static Random random;
        public Shield(Vector2 position, double defense)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("shield"), position)
        {
            this.Defense = defense;
            random = new Random();
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

        public bool ActivateSpecial()
        {
            if (random.Next(1, 101) <= 10)
            {
                this.Defense *= 2;
                return true;
            }
            return false;
        }

        public void DeactivateSpecial()
        {
            this.Defense /= 2;
        }
    }
}
