namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using Microsoft.Xna.Framework;

    public abstract class Monster : Unit, IDrawObject
    {
        // Constructor
        protected Monster(string name, int health, int damage, Vector2 position, bool ranged)
            :base(name, health, damage, position)
        {
            this.Ranged = ranged;
        }

        // Properties
        public bool Ranged { get; private set; }

        //protected bool ranged;

        //public bool Ranged
        //{
        //    get 
        //    { 
        //        return this.ranged; 
        //    }
        //    set 
        //    { 
        //        this.ranged = value; 
        //    }
        //}
    }

}
//Предлагам да си направим един генератор, за генериране броят на гадините по картата (например фиксирано число),
//тяхното местоположение (random generatior), техните статове (кръв, атака, и тн. отнвово с random generatior)
//за да има произволност в играта.