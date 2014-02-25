namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    public abstract class Weapon : SpecialAbilityItem, ISpecial
    {
        protected int damage;
        protected double crit;

        protected Weapon(Texture2D image, Vector2 position, int dmg, double crit)
            : base(image, position)
        {
            this.Damage = dmg;
            this.Crit = crit;
        }

        /// <summary>
        /// Gets or sets the damage of the weapon
        /// </summary>
        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Can't be negative");
                }
                else
                {
                    this.damage = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the critical damage of the weapon
        /// </summary>
        public double Crit
        {
            get
            {
                return this.crit;
            }
            set
            {
                this.crit = value;
            }
        }
    }
}
