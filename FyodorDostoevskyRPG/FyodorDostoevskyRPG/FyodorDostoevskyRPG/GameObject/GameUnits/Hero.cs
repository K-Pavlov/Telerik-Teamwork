namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.GameObject.GameItems;
    using FyodorDostoevskyRPG.ScreenManagement;

    public class Hero : Unit, IDrawObject
    {
        // Fields
        private const int TurnRadius = 50;
        private Weapon weapon;
        private Shield shield;
        private float heroSpeed;
        private Vector2 target, direction;
        private Animation heroAnimation;
        private DateTime lastHealed;
        private static Random random;

        private const int HeroHealth = 100;
        private const int HeroMinDamage = 5;
        private const int HeroMaxDamage = 8;


        // Constructor
        /// <summary>
        /// Create a hero
        /// </summary>
        /// <param name="position">The hero position</param>
        /// <param name="name">The hero name</param>
        public Hero(Vector2 position, string name)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("heroAnimation"), position, name, Hero.HeroHealth, Hero.HeroMinDamage)
        {
            this.DamageMax = Hero.HeroMaxDamage;
            this.heroAnimation = new Animation(position, new Vector2(5, 4));
            this.heroAnimation.Image = this.Image;
            this.heroSpeed = 1.4f;

            this.Weapon = new Sword(Vector2.Zero, 1, 2);
            this.Shield = new Shield(Vector2.Zero, 1 );
            this.lastHealed = DateTime.Now;
            random = new Random();
        }

        // Properties
        /// <summary>
        /// Gets the max hero damage
        /// </summary>
        public int DamageMax { get; private set; }

        /// <summary>
        /// Gets the hero weapon
        /// </summary>
        public Weapon Weapon
        {
            get { return this.weapon; }
            private set { this.weapon = value; }
        }

        /// <summary>
        /// Gets the hero shield
        /// </summary>
        public Shield Shield
        {
            get { return this.shield; }
            private set { this.shield = value; }
        }

        /// <summary>
        /// Gets the rectangle around the hero
        /// </summary>
        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, 64, 64);
            }
        }

        // Methods
        /// <summary>
        /// Handles the input for moving the hero
        /// </summary>
        public void HandleInput()
        {
            if (InputManager.Instance.MouseLeftButtonDown())
            {
                this.heroAnimation.IsActive = true;
                this.target = InputManager.Instance.MousePosition;
                this.direction = this.target - this.heroAnimation.Position;
                this.direction.Normalize();

                if (this.heroAnimation.Position.Y < this.target.Y &&
                    Math.Abs(this.heroAnimation.Position.X - this.target.X) < Hero.TurnRadius)
                {
                    this.heroAnimation.SpriteRow = 0;
                }
                else
                {
                    if (this.heroAnimation.Position.Y > this.target.Y &&
                    Math.Abs(this.heroAnimation.Position.X - this.target.X) < Hero.TurnRadius)
                    {
                        this.heroAnimation.SpriteRow = 1;
                    }
                    else
                    {
                        if (this.heroAnimation.Position.X < this.target.X)
                        {
                            this.heroAnimation.SpriteRow = 2;
                        }
                        else
                        {
                            this.heroAnimation.SpriteRow = 3;
                        }
                    }
                }
            }
            else
            {
                this.heroAnimation.IsActive = false;
            }
        }

        /// <summary>
        /// Updates the hero position and animation
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (this.heroAnimation.IsActive)
            {
                this.heroAnimation.Position += this.direction * this.heroSpeed;
                this.Position = this.heroAnimation.Position;
            }

            this.heroAnimation.Update(gameTime);
        }

        /// <summary>
        /// Draws the hero onto the screen
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.heroAnimation.Draw(spriteBatch);
        }

        /// <summary>
        /// Updates the current hero items
        /// </summary>
        /// <param name="item">Shield or weapon</param>
        public void UpdateItem(Item item)
        {
            if (item is Weapon)
            {
                this.Weapon = item as Weapon;
            }
            else
            {
                this.Shield = item as Shield;
            }
        }

        /// <summary>
        /// Heals the hero
        /// </summary>
        public void Heal()
        {
            if ((DateTime.Now).CompareTo(lastHealed.AddSeconds(3)) > 0 && (this.Health < this.FullHeath))
            {
                this.Health += 10;
                Sounds.PlayHeal();
                lastHealed = DateTime.Now;

                if (this.Health > this.FullHeath)
                {
                    this.Health = this.FullHeath;
                }
            }
        }
    }
}
