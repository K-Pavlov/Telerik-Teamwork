namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;

    internal class Shield : Item
    {
        protected int damage;
        protected double defense;
        protected double block;
        protected bool special;

        public Shield()
        {
            this.special = true;
        }

        public Shield(string pathToImage, Vector2 position, bool isUsed, int damage, double defense, double block)
        {
            this.isUsed = isUsed;
            this.damage = damage;
            this.defense = defense;
            this.block = block;
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
