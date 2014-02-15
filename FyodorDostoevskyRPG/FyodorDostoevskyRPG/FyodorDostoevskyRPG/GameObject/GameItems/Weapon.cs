namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public abstract class Weapon : Item
    {
        protected int damage;
        protected double crit;
        protected bool special;

        public Weapon(Texture2D image, Vector2 position, int dmg, double crit, bool special)
            : base(image, position)
        {
            /////////
        }

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
