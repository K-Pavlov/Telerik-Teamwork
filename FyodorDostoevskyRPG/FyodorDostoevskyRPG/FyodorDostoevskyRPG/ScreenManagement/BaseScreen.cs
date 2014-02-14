namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class BaseScreen
    {
        protected ContentManager baseScreenContentManager;

        public virtual void LoadContent(ContentManager content)
        {
            this.baseScreenContentManager = new ContentManager(content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            this.baseScreenContentManager.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
