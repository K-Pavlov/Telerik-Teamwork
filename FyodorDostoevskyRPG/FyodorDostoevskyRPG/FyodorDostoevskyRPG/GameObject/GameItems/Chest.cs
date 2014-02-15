namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Chest : Item
    {
        Random random = new Random();
        public Chest(Vector2 position)
            :base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("karitnka"), position) 
        {            
        }

        public Item RandomItem()
        {
            int whatToGet = random.Next(1, 4);
            if (whatToGet == 1)
            {
                return new Sword(new Vector2(this.Position.X,this.Position.Y), 20, 40);
            }
            else if (whatToGet == 2)
            {
                return new Flail(new Vector2(this.Position.X, this.Position.Y), 25, 50);
            }
            else
            {
                return new Shield(new Vector2(this.Position.X, this.Position.Y), 10, 3);
            }
        }
    }
}
