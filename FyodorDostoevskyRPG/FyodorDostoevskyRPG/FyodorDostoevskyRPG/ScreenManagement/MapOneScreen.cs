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
        private Rectangle fireRect;

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            this.mapTexture = this.baseScreenContentManager.Load<Texture2D>("map-one");
            this.braveHero = new Hero(new Vector2(10, 310), "DragonSlayer");

            this.monstersOnThisMap = new List<Monster>()
            {
                new Dragon("Pesho", new Vector2(300, 250), true),
                new Dragon("Gosho", new Vector2(210, 500), true),
                new Golem("Gosho", new Vector2(130, 480), true),
                new Dragon("Tosho", new Vector2(700, 240), true),
                new Golem("Tosho", new Vector2(670, 380), true),
                new Golem("Mosho", new Vector2(660, 490), true),
                new Golem("Shosho", new Vector2(400, 310), true), 
                new Dragon("Doncho", new Vector2(330, 400), true),
                new Golem("Misho", new Vector2(280, 100), true),
                new Golem("Tisho", new Vector2(350, 90), true),
                new Dragon("Zoro", new Vector2(700, 140), true),
                new Dragon("Batman", new Vector2(150, 1), true)
            };

            this.chests = new List<Chest>
            {
                new Chest(new Vector2(8,9)),
                new Chest(new Vector2(160,550)),
                new Chest(new Vector2(310,325)),
                new Chest(new Vector2(270,25)),
                new Chest(new Vector2(750,533))
            };

            this.fireRect = new Rectangle(500, 60, 100, 100);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.Escape))
            {
                FyodorsAdventure.ShouldExit = true;
            }

            this.braveHero.HandleInput();
            this.braveHero.Update(gameTime);

            if (this.monstersOnThisMap.Count == 0)
            {
                Sounds.PlayWinCampaign();
                ScreenManager.Instance.LoadScreen(new GameWinScreen());
            }

            foreach (var monster in monstersOnThisMap)
            {
                if (braveHero.Rectangle.Intersects(monster.Rectangle))
                {
                    this.monstersOnThisMap.Remove(monster);
                    Sounds.StopMapMusic();
                    Sounds.StartBattleMusic();
                    ScreenManager.Instance.LoadScreen(new BattleScreen(braveHero, monster));
                    break;
                }
            }

            if (braveHero.Rectangle.Intersects(fireRect))
            {
                this.braveHero.Heal();
            }

            foreach(var chest in chests)
            {
                if (braveHero.Rectangle.Intersects(chest.Rectangle))
                {
                    if (chest.ChestStatus == ChestState.Closed)
                    {
                        this.braveHero.UpdateItem(chest.RandomItem());
                    }
                }
            }
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
