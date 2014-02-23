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
        private const int turnRadius = 50;
        private Weapon weapon;
        private Shield shield;
        private float heroSpeed;
        private Vector2 target, direction;
        private Animation heroAnimation;
        private DateTime lastHealed;

        public int DamageMax { get; set; }

        // Constructor
        public Hero(Vector2 position, string name, int health, int damageMin, int damageMax)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("heroAnimation"), position, name, health, damageMin)
        {
            this.DamageMax = damageMax;
            this.heroAnimation = new Animation(position, new Vector2(5, 4));
            this.heroAnimation.Image = this.Image;
            this.heroSpeed = 1.4f;

            this.MaxHealth = health;
            this.Weapon = new Sword(Vector2.Zero, 5, 10);
            this.Shield = new Shield(Vector2.Zero, 5);
            this.lastHealed = DateTime.Now;
        }

        // Properties
        public int MaxHealth { get; private set; }

        public Weapon Weapon
        {
            get { return this.weapon; }
            set { this.weapon = value; }
        }

        public Shield Shield
        {
            get { return this.shield; }
            set { this.shield = value; }
        }

        // Methods
        public void HandleInput()
        {
            if (InputManager.Instance.MouseLeftButtonDown())
            {
                this.heroAnimation.IsActive = true;
                this.target = InputManager.Instance.MousePosition;
                this.direction = this.target - this.heroAnimation.Position;
                this.direction.Normalize();

                if (this.heroAnimation.Position.Y < this.target.Y &&
                    Math.Abs(this.heroAnimation.Position.X - this.target.X) < Hero.turnRadius)
                {
                    this.heroAnimation.SpriteRow = 0;
                }
                else
                {
                    if (this.heroAnimation.Position.Y > this.target.Y &&
                    Math.Abs(this.heroAnimation.Position.X - this.target.X) < Hero.turnRadius)
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

        public void Update(GameTime gameTime)
        {
            if (this.heroAnimation.IsActive)
            {
                this.heroAnimation.Position += this.direction * this.heroSpeed;
                this.Position = this.heroAnimation.Position;
            }

            this.heroAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.heroAnimation.Draw(spriteBatch);
        }

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

        public void Heal()
        {
            if ((DateTime.Now).CompareTo(lastHealed.AddSeconds(20)) > 0 && (this.Health + 10 < this.MaxHealth))
            {
                this.Health += 10;
                lastHealed = DateTime.Now;
            }
        }
    }
}
