namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Images
    {
        public float Alpha;
        public string Text, FontName, Path;
        public Vector2 Position, Scale;
        public Rectangle SourceRect;

        public Texture2D Texture;
        private Vector2 origin;
        private ContentManager content;
        private RenderTarget2D renderTarget;
        private SpriteFont font;

        public Images()
        {
            this.Path = this.Text = string.Empty;
            this.FontName = "Fonts/WideLatin";
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f;
            this.SourceRect = Rectangle.Empty;
        }

        public void LoadContent()
        {
            this.content = new ContentManager(ScreenManager.Instance.screenManagerContent.ServiceProvider, "Content");
            if (Path != string.Empty)
            {
                this.Texture = content.Load<Texture2D>(Path);
            }
            this.font = content.Load<SpriteFont>(FontName);

            var sizes = Vector2.Zero;

            if (Texture != null)
            {
                sizes.X += this.Texture.Width;
                sizes.X += this.font.MeasureString(Text).X;
            }

            if (Texture != null)
            {
                sizes.Y = System.Math.Max(this.Texture.Height, this.font.MeasureString(Text).Y);
            }
            else
            {
                sizes.Y = this.font.MeasureString(Text).Y;
            }

            if (this.SourceRect == Rectangle.Empty)
            {
                this.SourceRect = new Rectangle(0, 0, (int)sizes.X, (int)sizes.Y);
            }

            this.renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)sizes.X, (int)sizes.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);

            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (Texture != null)
            {
                ScreenManager.Instance.SpriteBatch.Draw(this.Texture, Vector2.Zero, Color.White);
            }
            ScreenManager.Instance.SpriteBatch.DrawString(this.font, this.Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            this.Texture = this.renderTarget;
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        }

        public void UnLoadContent()
        {
            this.content.Unload();
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.origin = new Vector2(this.SourceRect.Width / 2, this.SourceRect.Height / 2);
            spriteBatch.Draw(this.Texture, this.Position + this.origin, this.SourceRect, Color.White * Alpha, 0.0f, this.origin, this.Scale, SpriteEffects.None, 0.0f);
        }
    }
}
