namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System.Xml.Serialization;
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
        Vector2 origin;
        ContentManager content;
        RenderTarget2D renderTarget;
        SpriteFont font;

        public Images()
        {
            Path =Text= string.Empty;
            FontName = "Fonts/WideLatin";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
        }

        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.screenManagerContent.ServiceProvider, "Content");
            if (Path != string.Empty)
            {
                Texture = content.Load<Texture2D>(Path);
            }
            font = content.Load<SpriteFont>(FontName);

            Vector2 sizes = Vector2.Zero;

            if (Texture != null)
            {
                sizes.X += Texture.Width;
                sizes.X += font.MeasureString(Text).X;
            }

            if (Texture != null)
            {
                sizes.Y = System.Math.Max(Texture.Height, font.MeasureString(Text).Y);
            }
            else
            {
                sizes.Y = font.MeasureString(Text).Y;
            }

            if (SourceRect == Rectangle.Empty)
            {
                SourceRect = new Rectangle(0, 0, (int)sizes.X, (int)sizes.Y);
            }

            renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice,(int) sizes.X,(int) sizes.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);

            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (Texture!=null)
            {
                ScreenManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);

            }
            ScreenManager.Instance.SpriteBatch.DrawString(font, Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            Texture = renderTarget;
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        
        }

        public void UnLoadContent()
        {
            content.Unload();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(Texture, Position + origin, SourceRect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
