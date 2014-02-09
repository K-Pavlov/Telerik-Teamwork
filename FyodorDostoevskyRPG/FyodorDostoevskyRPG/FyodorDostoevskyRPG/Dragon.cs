namespace FyodorDostoevskyRPG
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    class Dragon: Monsters
    {
        public Dragon(string name, int health, int damage, Vector2 position, Texture2D image, bool ranged)
        { 
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.position = position;
            this.image = image;
            this.ranged = ranged;
            this.isAlive = true;
        }
    }
}
