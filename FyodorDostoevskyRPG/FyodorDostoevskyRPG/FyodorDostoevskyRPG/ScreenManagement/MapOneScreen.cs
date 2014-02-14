namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.GameObject.GameUnits;

    internal class MapOneScreen : BaseScreen
    {
        private Hero braveHero;
        private Dragon[] dragonOnThisMap;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.dragonOnThisMap = new Dragon[5]
            {
                new Dragon("Pesho", 100, 10, new Vector2(340, 200), true),
                new Dragon("Gosho", 100, 10, new Vector2(200, 400), true),
                new Dragon("Tosho", 100, 10, new Vector2(600, 200), true),
                new Dragon("Mosho", 100, 10, new Vector2(550, 500), true),
                new Dragon("Shosho", 100, 10, new Vector2(400, 350), true) };
            braveHero = new Hero("DragonSlayer", 500, 10, 14, new Vector2(10, 10));
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void HandleInput()
        {
            this.braveHero.HandleInput();
        }

        public override void Update(GameTime gameTime)
        {
            this.braveHero.HandleInput();
            this.braveHero.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var dragon in this.dragonOnThisMap)
            {
                dragon.Draw(spriteBatch);
            }
            this.braveHero.Draw(spriteBatch);
        }
    }
}
