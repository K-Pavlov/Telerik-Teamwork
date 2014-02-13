namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    class Hero : Unit, IDrawObject
    {
        // Fields
        //private int damageMin;
        private const int turnRadius = 50;

        private int damageMax;
        private float heroSpeed;
        private Vector2 target, direction;
        private Animation heroAnimation;

        //остава Weapon да се добави
        // Constructor
        public Hero(string name, int health, int damageMin, int damageMax, Vector2 position)
            :base(name, health, damageMin, position)
        {
            this.DamageMax = damageMax;

            this.Image = ScreenManager.Instance.screenManagerContent.Load<Texture2D>("heroAnimation");
            this.heroAnimation = new Animation(position, new Vector2(5,4));
            this.heroAnimation.Image = this.Image;
            this.heroSpeed = 1.4f;

            //this.name = name;
            //this.health = health;
            //this.damageMin = damageMin;
            //this.damageMin = damageMax;
            //this.position = position;
            //this.image = image;
            //this.isAlive = true;
        }

        // Properties
        //Tuk moje da se zima prosto damage ot bazowiq klas
        //public int DamageMin
        //{
        //    get 
        //    { 
        //        return damageMin; 
        //    }
        //    set 
        //    { 
        //        damageMin = value; 
        //    }
        //}

        public int DamageMax
        {
            get
            {
                return damageMax;
            }
            set
            {
                damageMax = value;
            }
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

                //proverqvame koi red ot animaciqta da risuwame
                if (this.heroAnimation.Position.Y < this.target.Y && 
                    Math.Abs(this.heroAnimation.Position.X - this.target.X) < Hero.turnRadius)
                {
                    this.heroAnimation.SpriteRow = 0;
                }
                else if (this.heroAnimation.Position.Y > this.target.Y &&
                    Math.Abs(this.heroAnimation.Position.X - this.target.X) < Hero.turnRadius)
                {
                    this.heroAnimation.SpriteRow = 1;
                }
                else if (this.heroAnimation.Position.X < this.target.X)
                    this.heroAnimation.SpriteRow = 2;
                else
                    this.heroAnimation.SpriteRow = 3;
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
