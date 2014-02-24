namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Dragon : Monster, IDrawObject
    {
        private static Random random = new Random();
        public Dragon(string name, Vector2 position, bool ranged)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("dragonImage"), 
            position, name, random.Next(70,80), 6, ranged)
        {
        }
    }
}
