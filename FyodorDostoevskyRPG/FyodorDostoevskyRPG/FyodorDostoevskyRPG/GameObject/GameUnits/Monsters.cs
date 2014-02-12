namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    class Monsters : Unit, IDrawObject
    {
        protected bool ranged;

        public bool Ranged
        {
            get 
            { 
                return this.ranged; 
            }
            set 
            { 
                this.ranged = value; 
            }
        }
    }

}
//Предлагам да си направим един генератор, за генериране броят на гадините по картата (например фиксирано число), тяхното местоположение (random generatior), техните статове (кръв, атака, и тн. отнвово с random generatior)
//за да има произволност в играта.