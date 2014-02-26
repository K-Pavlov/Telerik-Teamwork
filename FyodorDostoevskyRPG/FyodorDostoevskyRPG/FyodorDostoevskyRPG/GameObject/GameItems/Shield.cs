namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    public class Shield : SpecialAbilityItem, ISpecial, IDrawObject
    {
        protected double defense;
        private static Random random = new Random();

        /// <summary>
        /// Create a shield
        /// </summary>
        /// <param name="position">The position of the shield</param>
        /// <param name="defense">The defense of the shield</param>
        public Shield(Vector2 position, double defense)
            : base(ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("shield"), position)
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

        public override bool ActivateSpecial()
        {
            if (random.Next(1, 101) <= 10)
            {
                this.Defense *= 2;
                return true;
            }
            return false;
        }

        public override void DeactivateSpecial()
        {
            this.Defense /= 2;
        }
    }
}
