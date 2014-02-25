namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    public class Sword : Weapon, IDrawObject
    {
        private static int attackCount = 1;

        /// <summary>
        /// Create a sword
        /// </summary>
        /// <param name="position">The position of the sword</param>
        /// <param name="dmg">The damage of the sword</param>
        /// <param name="crit">The critical damage of the sword</param>
        public Sword(Vector2 position, int damage, double crit)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("sword"), 
            position, damage, crit)
        {
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
