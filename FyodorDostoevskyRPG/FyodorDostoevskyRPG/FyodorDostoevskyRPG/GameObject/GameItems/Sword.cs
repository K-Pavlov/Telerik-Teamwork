namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;

    internal class Sword : Weapon, IDrawObject
    {
        public Sword()
        {
            this.special = true;
        }
        public Sword(string pathToImage, Vector2 position, bool isUsed , int damage, double crit)
        {
            this.Position = position;
            this.isUsed = isUsed;
            this.damage = damage;
            this.crit = crit;
        }
    }
}
