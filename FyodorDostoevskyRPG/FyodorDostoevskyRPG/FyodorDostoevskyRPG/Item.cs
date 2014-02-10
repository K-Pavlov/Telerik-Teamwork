namespace FyodorDostoevskyRPG
{
    using System;
    using FyodorDostoevskyRPG.ScreenManagement;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class Item
    {
        protected Vector2 position;
        public Vector2 Position
        {
            get
            { return this.position; }
            set
            {
                if ((value.X < 0) || (value.X > 800) || (value.Y < 0) || (value.Y > 600))
                {
                    throw new ArgumentOutOfRangeException("Coordinates out of screen! (800x600)");
                }
                this.position.X = value.X;
                this.position.Y = value.Y;
            }
        }
        //####################Is this how it's done?#####################\\
        //Only gets the image
        protected Texture2D image;
        public Texture2D Image
        {
            get { return this.image; }
        }

        //Path sets the Texture2D image to the image 
        protected string texture2DPath;
        public string Texture2DPath
        {
            get { return this.texture2DPath; }
            set 
            { 
                this.texture2DPath = value;
                ContentManager content = new ContentManager(ScreenManager.Instance.screenManagerContent.ServiceProvider, "Content");
                if (texture2DPath != string.Empty)
                {
                    this.image = content.Load<Texture2D>(texture2DPath);
                }
            }
        }
                
        protected bool isUsed;
        public bool IsUsed
        {
            get { return this.isUsed; }
            set { this.isUsed = value; }
        }
        
    }
}
