namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Sword : Weapon, IDrawObject, ISpecial<int>
    {
        Random random = new Random();
        public Sword(Vector2 position, int dmg, double crit)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("karitnka"), 
            position, dmg, crit)
        {
        }

        public int ActivateSpecial()
        {
            return this.Damage + random.Next(1, 11);
        }

    }
}
