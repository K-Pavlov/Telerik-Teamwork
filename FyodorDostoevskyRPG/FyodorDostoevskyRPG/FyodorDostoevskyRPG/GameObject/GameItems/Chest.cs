namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class Chest : Item
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

        public Chest()
        {
            this.special = true;
        }
        public Chest(string pathToImage, Vector2 position, bool isUsed, int damage, double crit)
        {
            this.texture2DPath = pathToImage;
            this.position = position;
            this.isUsed = isUsed;
            this.damage = damage;
            this.crit = crit;
        }

    }
}
