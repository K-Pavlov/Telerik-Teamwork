namespace FyodorDostoevskyRPG.ScreenManagement
{
    using System;
    using System.Collections.Generic;
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
        private List<Monster> monstersOnThisMap;
        private List<Chest> chests;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            this.mapTexture = this.baseScreenContentManager.Load<Texture2D>("map-one");
            this.braveHero = new Hero(new Vector2(10, 310), "DragonSlayer", 100, 10, 14);

            this.monstersOnThisMap = new List<Monster>()
            {
                new Dragon("Pesho", 100, 10, new Vector2(300, 250), true),
                new Dragon("Gosho", 100, 10, new Vector2(210, 500), true),
                new Golem("Gosho", 100, 10, new Vector2(130, 480), true),
                new Dragon("Tosho", 100, 10, new Vector2(700, 240), true),
                new Golem("Tosho", 100, 10, new Vector2(670, 380), true),
                new Golem("Mosho", 100, 10, new Vector2(660, 490), true),
                new Golem("Shosho", 100, 10, new Vector2(400, 310), true), 
                new Dragon("Doncho", 100, 10, new Vector2(330, 400), true),
                new Golem("Misho", 100, 10, new Vector2(280, 100), true),
                new Golem("Tisho", 100, 10, new Vector2(350, 90), true),
                new Dragon("Zoro", 100, 10, new Vector2(700, 140), true),
                new Dragon("Batman", 100, 10, new Vector2(150, 1), true)
            };

            this.chests = new List<Chest>
            {
                new Chest(new Vector2(8,9)),
                new Chest(new Vector2(160,550)),
                new Chest(new Vector2(310,325)),
                new Chest(new Vector2(270,25)),
                new Chest(new Vector2(750,533))
            };
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
                    this.monstersOnThisMap.Remove(monster);
                    ScreenManager.Instance.LoadScreen(new BattleScreen(braveHero,monster));
                    break;
                }
            }

            foreach(var chest in chests)
            {
                if ((braveHero.Position.X > chest.Position.X - 20 && braveHero.Position.X < chest.Position.X + chest.Image.Width) &&
                    (braveHero.Position.Y > chest.Position.Y && braveHero.Position.Y < chest.Position.Y + chest.Image.Height))
                {
                    if (chest.ChestStatus == ChestState.Closed)
                    {
                        this.braveHero.UpdateItem(chest.RandomItem());
                    }
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

            foreach (var chest in chests)
            {
                chest.Draw(spriteBatch);
            }
            
            this.braveHero.Draw(spriteBatch);
        }
    }
}
