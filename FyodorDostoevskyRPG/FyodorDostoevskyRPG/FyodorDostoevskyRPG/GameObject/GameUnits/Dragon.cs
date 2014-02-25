namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Dragon : Monster, IDrawObject
    {
        private static Random random = new Random();
        private const int DragonDamage = 6;

        /// <summary>
        /// Creates a dragon
        /// </summary>
        /// <param name="name">The name of the dragon</param>
        /// <param name="position">The position of the dragon</param>
        /// <param name="ranged">True for ranged, false for melee</param>
        public Dragon(string name, Vector2 position, bool ranged)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("dragonImage"), 
            position, name, random.Next(70,80), Dragon.DragonDamage, ranged)
        {
        }
    }
}
