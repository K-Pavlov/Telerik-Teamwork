namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class Shield : Item
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

        protected double defense;
        public double Defense
        {
            get { return this.defense; }
            set
            {
                this.defense = value;
            }
        }

        protected double block;
        public double Block
        {
            get { return this.block; }
            set
            {
                this.block = value;
            }
        }

        protected bool special;
        public bool Special
        {
            get { return this.special; }
            set { this.special = value; }
        }

        public Shield()
        {
            this.special = true;
        }
        public Shield(string pathToImage, Vector2 position, bool isUsed, int damage, double defense, double block)
        {
            //this.texture2DPath = pathToImage;
            //this.position = position;
            this.isUsed = isUsed;
            this.damage = damage;
            this.defense = defense;
            this.block = block;
        }

    }
}
