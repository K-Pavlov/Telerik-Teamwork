namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using FyodorDostoevskyRPG.GameObject.GameUnits;
    using FyodorDostoevskyRPG.GameObject.GameItems;    

    internal class MapOneScreen : BaseScreen, IScreen
    {
        // Fields
        private Texture2D mapTexture;
        private Hero braveHero;
        private Monster[] monstersOnThisMap;


        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            this.mapTexture = this.baseScreenContentManager.Load<Texture2D>("map-one");
            this.braveHero = new Hero(new Vector2(10, 310), "DragonSlayer", 500, 10, 14);

            this.monstersOnThisMap = new Monster[5]
            {
                new Dragon("Pesho", 100, 10, new Vector2(340, 200), true),
                new Golem("Gosho", 100, 10, new Vector2(200, 400), true),
                new Dragon("Tosho", 100, 10, new Vector2(600, 200), true),
                new Golem("Mosho", 100, 10, new Vector2(550, 500), true),
                new Dragon("Shosho", 100, 10, new Vector2(400, 350), true) };            
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.Escape))
            {
                FyodorsAdventure.ShouldExit = true;
            }

            this.braveHero.HandleInput();

            foreach (var monster in monstersOnThisMap)
            {
                if ((braveHero.Position.X > monster.Position.X - 20 && braveHero.Position.X < monster.Position.X + monster.Image.Width) &&
                   (braveHero.Position.Y > monster.Position.Y && braveHero.Position.Y < monster.Position.Y + monster.Image.Height))
                {
                    ScreenManager.Instance.LoadScreen(new BattleScreen(monster));
                }
            }

            this.braveHero.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.mapTexture, Vector2.Zero, Color.White);

            foreach (var dragon in this.monstersOnThisMap)
            {
                dragon.Draw(spriteBatch);
            }
            this.braveHero.Draw(spriteBatch);
        }
    }
}
