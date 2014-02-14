namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;

    public abstract class Unit : ObjectRPG, IDrawObject, IActions
    {
        private string name;
        private int health;
        private int damage;

        protected Unit(string name, int health, int damage, Vector2 position)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Position = position;
            this.IsAlive = true;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The unit cannot be nameless!");
                }
                name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ArgumentNullException("Health value has be a positive integer number");
                }
                this.health = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ArgumentNullException("Damage value has be a positive integer number");
                }
                this.damage = value;
            }
        }

        public bool IsAlive { get; private set; }



        public void DisplayHealth(int health)
        {
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }

        public void Attack(int damage)
        {
        }
    }
}
