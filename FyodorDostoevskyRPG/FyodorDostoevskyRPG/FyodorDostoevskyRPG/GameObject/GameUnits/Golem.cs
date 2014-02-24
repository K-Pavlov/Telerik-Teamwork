namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Golem : Monster, IDrawObject
    {
        private static Random random = new Random();
        public Golem(string name, Vector2 position, bool ranged)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("stoneGolem"), 
            position, name, random.Next(30, 50), 10, ranged)
        {
        }
    }
}