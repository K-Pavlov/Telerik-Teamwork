namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.ScreenManagement;

    class Dragon : Monsters, IDrawObject
    {

        public Dragon(string name, int health, int damage, Vector2 position, bool ranged)
        { 
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.position = position;
            this.image = ScreenManager.Instance.screenManagerContent.Load<Texture2D>("dragonImage");
            this.ranged = ranged;
            this.isAlive = true;
        }
    }
}
