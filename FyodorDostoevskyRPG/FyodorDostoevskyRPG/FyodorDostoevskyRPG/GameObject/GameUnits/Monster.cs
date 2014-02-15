namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Monster : Unit, IDrawObject
    {
        protected Monster(Texture2D image, Vector2 position, string name, int health, int damage, bool ranged)
            : base(image, position, name, health, damage)
        {
            this.Ranged = ranged;
        }

        public bool Ranged { get; private set; }
    }
}


