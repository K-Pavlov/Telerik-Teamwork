namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Hero : Unit, IDrawObject
    {
        private const int turnRadius = 50;
        private float heroSpeed;
        private Vector2 target, direction;
        private Animation heroAnimation;

        public Hero(string name, int health, int damageMin, int damageMax, Vector2 position)
            : base(name, health, damageMin, position)
        {
            this.DamageMax = damageMax;

            this.Image = ScreenManager.Instance.screenManagerContent.Load<Texture2D>("heroAnimation");
            this.heroAnimation = new Animation(position, new Vector2(5, 4));
            this.heroAnimation.Image = this.Image;
            this.heroSpeed = 1.4f;
        }

        public int DamageMax { get; set; }

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
