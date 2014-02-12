namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class Weapon : Item
    {
        protected int damage;
        public int Damage
        {
            get { return this.damage; }
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

        protected double crit;
        public double Crit
        {
            get { return this.crit; }
            set 
            {
                this.crit = value; 
            }
        }

        protected bool special;
        public bool Special
        {
            get { return this.special; }
            set { this.special = value; }
        }
        
    }
}
