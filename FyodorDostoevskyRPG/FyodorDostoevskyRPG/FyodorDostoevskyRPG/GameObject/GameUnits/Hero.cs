namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FyodorDostoevskyRPG.GameObject.GameItems;
    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Hero : Unit, IDrawObject
    {
        private const int turnRadius = 50;
        private Weapon weapon1;
        private Shield shield1;
        private float heroSpeed;
        private Vector2 target, direction;
        private Animation heroAnimation;

        public int DamageMax { get; set; }

        public Weapon Weapon1
        {
            get { return this.weapon1; }
            set { this.weapon1 = value; }
        }

        public Shield Shield1
        {
            get { return this.shield1; }
            set { this.shield1 = value; }
        }
        
        public Hero(Vector2 position, string name, int health, int damageMin, int damageMax)
            : base(ScreenManager.Instance.screenManagerContent.Load<Texture2D>("heroAnimation"), position, name, health, damageMin)
        {
            this.DamageMax = damageMax;
            this.heroAnimation = new Animation(position, new Vector2(5, 4));
            this.heroAnimation.Image = this.Image;
            this.heroSpeed = 1.4f;
        }

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
    }
}
