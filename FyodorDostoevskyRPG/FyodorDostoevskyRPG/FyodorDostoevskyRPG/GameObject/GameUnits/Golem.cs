namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Golem : Monster, IDrawObject
    {
        public Golem(string name, int health, int damage, Vector2 position, bool ranged)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("stoneGolem"), 
            position, name, health, damage, ranged)
        {
        }
    }
}