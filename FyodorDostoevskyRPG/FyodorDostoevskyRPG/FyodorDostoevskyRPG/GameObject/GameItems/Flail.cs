namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Flail : Weapon, IDrawObject
    {
        private static int SpecialChance { get; set; }
        Random random = new Random();
        public Flail(Vector2 position, int dmg, double crit)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("flail"),
            position, dmg, crit)
        {
        }

        public override bool ActivateSpecial()
        {
            SpecialChance = random.Next(1, 101);
            if (SpecialChance <= 10)
            {
                return true;
            }
            return false;
        }

        public override void DeactivateSpecial()
        {
        }
    }
}
