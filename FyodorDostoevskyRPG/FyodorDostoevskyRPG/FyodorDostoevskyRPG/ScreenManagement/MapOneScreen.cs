namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using FyodorDostoevskyRPG.GameObject.GameUnits;
    using FyodorDostoevskyRPG.GameObject.GameItems;

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
            braveHero = new Hero(new Vector2(10, 10), "DragonSlayer", 500, 10, 14);
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
            foreach (var dragon in dragonOnThisMap)
            {
                if ((braveHero.Position.X > dragon.Position.X - 20 && braveHero.Position.X < dragon.Position.X + dragon.Image.Width) &&
                   (braveHero.Position.Y > dragon.Position.Y && braveHero.Position.Y < dragon.Position.Y + dragon.Image.Height))
                {
                    ScreenManager.Instance.LoadScreen(new BattleScreen(dragon));
                }
            }
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
