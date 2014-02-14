namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;

    internal class Flail : Weapon, IDrawObject
    {
        public Flail()
        {
            this.special = true;
        }
        public Flail(string pathToImage, Vector2 position, bool isUsed, int damage, double crit)
        {
            this.isUsed = isUsed;
            this.damage = damage;
            this.crit = crit;
        }
    }
}
