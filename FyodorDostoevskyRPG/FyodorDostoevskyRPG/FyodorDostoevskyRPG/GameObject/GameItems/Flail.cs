namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Flail : Weapon, ISpecial, IDrawObject
    {
        private static int SpecialChance { get; set; }
        private static Random random = new Random();

        /// <summary>
        /// Create a flail
        /// </summary>
        /// <param name="position">The position of the flail</param>
        /// <param name="dmg">The damage of the flail</param>
        /// <param name="crit">The critical damage of the flail</param>
        public Flail(Vector2 position, int damage, double crit)
            : base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("flail"),
            position, damage, crit)
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
