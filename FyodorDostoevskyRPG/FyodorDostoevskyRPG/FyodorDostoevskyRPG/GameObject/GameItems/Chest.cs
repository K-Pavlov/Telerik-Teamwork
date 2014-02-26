namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.ScreenManagement;

    internal class Chest : Item
    {
        // Fields
        private static Random random = new Random();
        private Texture2D OpenedChest { get; set; }
        public ChestState ChestStatus { get; set; }
        
        // Constructor
        /// <summary>
        /// Create a new chest
        /// </summary>
        /// <param name="position">The position of the chest</param>
        public Chest(Vector2 position)
            :base(ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("ChestClosed"), position) 
        {
            ChestStatus = ChestState.Closed;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Image.Width, this.Image.Height);
            }
        }

        // Methods
        /// <summary>
        /// Returns a random item
        /// </summary>
        public Item RandomItem()
        {
            int whatToGet = random.Next(1, 10);
            ChestStatus = ChestState.Opened;
            if (whatToGet >= 1 && whatToGet <= 3)
            {
                OpenedChest = ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("sword");
                return new Sword(new Vector2(this.Position.X,this.Position.Y), 3, 4);
            }
             else if (whatToGet >= 4 && whatToGet <= 6)
            {
                OpenedChest = ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("flail");
                return new Flail(new Vector2(this.Position.X, this.Position.Y), 4, 5);
            }
            else
            {
                OpenedChest = ScreenManagement.ScreenManager.Instance.ScreenManagerContent.Load<Texture2D>("shield");
                return new Shield(new Vector2(this.Position.X, this.Position.Y), 2);
            }
        }

        /// <summary>
        /// Draws the chest
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (ChestStatus)
            {
                case ChestState.Closed:
                    spriteBatch.Draw(this.Image, this.Position, Color.White);
                    break;
                case ChestState.Opened:
                    spriteBatch.Draw(this.OpenedChest, this.Position, Color.White);
                    break;
            }
        }

    }
}
