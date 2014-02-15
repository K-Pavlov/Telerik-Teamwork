namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Sword : Weapon, IDrawObject
    {
        public Sword(Vector2 position, int dmg, double crit, bool special)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("karitnka"), 
            position, dmg, crit, special)
        {
            //this.special = true;
        }
        //public Sword(string pathToImage, Vector2 position, bool isUsed , int damage, double crit)
        //{
        //    this.Position = position;
        //    this.isUsed = isUsed;
        //    this.damage = damage;
        //    this.crit = crit;
        //}
    }
}
