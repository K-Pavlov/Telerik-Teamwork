namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Sword : Weapon, IDrawObject
    {
        public Sword(Vector2 position, int dmg, double crit, bool special)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("karitnka"), 
            position, dmg, crit, special)
        {
        }
    }
}
