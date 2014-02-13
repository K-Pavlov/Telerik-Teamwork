namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    class Dragon : Monster, IDrawObject
    {
        // Constructor
        public Dragon(string name, int health, int damage, Vector2 position, bool ranged)
            :base(name, health, damage, position, ranged)
        { 
            this.Image = ScreenManager.Instance.screenManagerContent.Load<Texture2D>("dragonImage");
            //this.name = name;
            //this.health = health;
            //this.damage = damage;
            //this.position = position;
            //this.ranged = ranged;
        }
    }
}
