namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Golem : Monster, IDrawObject
    {
        private static Random random = new Random();
        private const int GolemDamage = 10;

        /// <summary>
        /// Creates a golem
        /// </summary>
        /// <param name="name">The name of the golem</param>
        /// <param name="position">The position of the golem</param>
        /// <param name="ranged">True for ranged, false for melee</param>
        public Golem(string name, Vector2 position, bool ranged)
            : base(ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("stoneGolem"), 
            position, name, random.Next(30, 50), Golem.GolemDamage, ranged)
        {
        }
    }
}