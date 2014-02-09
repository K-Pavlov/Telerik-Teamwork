namespace FyodorDostoevskyRPG
{
    using System;
    class Monsters : Unit
    {
        protected bool ranged;

        public bool Ranged
        {
            get 
            { 
                return ranged; 
            }
            set 
            { 
                ranged = value; 
            }
        }
    }

}
//Предлагам да си направим един генератор, за генериране броят на гадините по картата (например фиксирано число), тяхното местоположение (random generatior), техните статове (кръв, атака, и тн. отнвово с random generatior)
//за да има произволност в играта.