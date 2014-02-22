namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Sword : Weapon, IDrawObject
    {
        private static int attackCount;
        Random random = new Random();
        public Sword(Vector2 position, int dmg, double crit)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("sword"), 
            position, dmg, crit)
        {
            attackCount = 1;
        }

        public override bool ActivateSpecial()
        {
            if (attackCount == 3)
            {
                this.Damage += this.Damage / 2;
                attackCount = 1;
                return true;
            }
            attackCount++;
            return false;
        }

        public override void DeactivateSpecial()
        {
            this.Damage -= this.Damage / 2;
        }
    }
}
