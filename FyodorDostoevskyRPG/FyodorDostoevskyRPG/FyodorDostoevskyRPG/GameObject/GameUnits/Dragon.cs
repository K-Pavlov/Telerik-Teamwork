namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Dragon : Monster, IDrawObject
    {
        public Dragon(string name, int health, int damage, Vector2 position, bool ranged)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("dragonImage"), 
            position, name, health, damage, ranged)
        {
        }
    }
}
