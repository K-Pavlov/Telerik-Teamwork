namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using FyodorDostoevskyRPG.GameUnits;

    class MapOneScreen : BaseScreen
    {
        Dragon[] dragonOnThisMap;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            this.dragonOnThisMap = new Dragon[5]
            {
                new Dragon("Pesho", 100, 10, new Vector2(340, 200), true),
                new Dragon("Gosho", 100, 10, new Vector2(200, 400), true),
                new Dragon("Tosho", 100, 10, new Vector2(600, 200), true),
                new Dragon("Mosho", 100, 10, new Vector2(550, 500), true),
                new Dragon("Shosho", 100, 10, new Vector2(400, 350), true),
            };
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        // tuk tryabwa da doidat proverkite dali nashiqt geroi e stupil wurhu neshto
        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var dragon in this.dragonOnThisMap)
            {
                spriteBatch.Draw(dragon.Image, dragon.Position, Color.White);
            }
        }
    }
}
