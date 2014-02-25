namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Unit : ObjectRPG, IDrawObject, IActions
    {
        // Fields
        private string name;
        private int health;
        private int damage;
        private int fullHealth;        

        // Constructor
        protected Unit(Texture2D image, Vector2 position, string name, int health, int damage)
            :base(image, position)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.IsAlive = true;
            this.FullHeath = health;
        }

        // Properties
        /// <summary>
        /// Gets or sets the name of the unit
        /// </summary>
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

        /// <summary>
        /// Gets or sets the current health of the unit
        /// </summary>
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        /// <summary>
        /// Gets the starting heath of the unit
        /// </summary>
        public int FullHeath
        {
            get
            {
                return this.fullHealth;
            }
            private set 
            {
                this.fullHealth = value; 
            }
        }

        /// <summary>
        /// Gets or sets the damage of the unit
        /// </summary>
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

        /// <summary>
        /// Checks if the unit is alive
        /// </summary>
        public bool IsAlive { get; private set; }

        /// <summary>
        /// Gets the rectangle around the unit
        /// </summary>
        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Image.Width, this.Image.Height);
            }
        }

        // Methods
        /// <summary>
        /// Kills the unit
        /// </summary>
        public void Die()
        {
            IsAlive = false;
        }

        /// <summary>
        /// Inflicts damage onto the unit
        /// </summary>
        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
