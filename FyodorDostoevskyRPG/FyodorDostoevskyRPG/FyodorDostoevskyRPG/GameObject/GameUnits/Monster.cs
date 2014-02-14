namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using Microsoft.Xna.Framework;

    public abstract class Monster : Unit, IDrawObject
    {
        protected Monster(string name, int health, int damage, Vector2 position, bool ranged)
            : base(name, health, damage, position)
        {
            this.Ranged = ranged;
        }

        public bool Ranged { get; private set; }
    }
}


