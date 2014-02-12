﻿namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class Sword : Weapon, IDrawObject
    {
        public Sword()
        {
            this.special = true;
        }
        public Sword(string pathToImage, Vector2 position, bool isUsed , int damage, double crit)
        {
            this.texture2DPath = pathToImage;
            this.position = position;
            this.isUsed = isUsed;
            this.damage = damage;
            this.crit = crit;
        }
    }
}