namespace FyodorDostoevskyRPG.ScreenManagement
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using FyodorDostoevskyRPG.GameObject;
    using FyodorDostoevskyRPG.GameObject.GameUnits;

    class BattleScreen : BaseScreen, IScreen
    {
        // Fields
        private Texture2D battleImage, healtImage, healthBackground;

        private Vector2 battlePosition;

        private Hero hero;
        private Monster monster;

        private int heroStartHealth, monsterStartHealt;
        private Rectangle heroHealthBar, monsterHealthBar, heroHealthBackgroundRect, monsterHealthBackgroundRect;

        private SpriteFont font;

        // Constructor
        public BattleScreen(Hero hero, Monster monster)
        {
            this.monster = monster;
            this.hero = hero;

            this.monsterStartHealt = monster.Health;
            this.heroStartHealth = hero.Health;
        }

        // Methods
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.LoadContent(content);

            if (monster is Dragon)
            {
                this.battleImage = this.baseScreenContentManager.Load<Texture2D>("battleDragon");
            }
            else if (monster is Golem)
            {
                this.battleImage = this.baseScreenContentManager.Load<Texture2D>("battleGolem");
            }

            this.battlePosition = new Vector2(0, 75);

            this.healtImage = this.baseScreenContentManager.Load<Texture2D>("healthbar");
            this.healthBackground = this.baseScreenContentManager.Load<Texture2D>("healthbar-background");

            this.heroHealthBackgroundRect = new Rectangle(10, 10, this.hero.MaxHealth, 25);
            this.monsterHealthBackgroundRect = new Rectangle(500, 10, this.monsterStartHealt, 25);

            this.font = this.baseScreenContentManager.Load<SpriteFont>("Fonts/WideLatin");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.KeyPressed(Keys.Space))
            {
                BattleLogic.HeroAttack(hero, monster);
            }

            if (!monster.IsAlive)
            {
                ScreenManager.Instance.UnloadScreen();
            }
            else if (!hero.IsAlive)
            {
                FyodorsAdventure.ShouldExit = true;
            }

            this.heroHealthBar = new Rectangle(10, 10, this.hero.Health, 25);
            this.monsterHealthBar = new Rectangle(500, 10, this.monster.Health, 25);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.healthBackground, this.heroHealthBackgroundRect, Color.White);
            spriteBatch.Draw(this.healthBackground, this.monsterHealthBackgroundRect, Color.White);
            spriteBatch.Draw(this.healtImage, this.heroHealthBar, Color.White);
            spriteBatch.Draw(this.healtImage, this.monsterHealthBar, Color.White);

            spriteBatch.DrawString(this.font, this.hero.Name, new Vector2(10, 40), Color.White);
            spriteBatch.DrawString(this.font, this.monster.Name, new Vector2(500, 40), Color.White);

            spriteBatch.Draw(this.battleImage, this.battlePosition, Color.White);

            spriteBatch.DrawString(this.font, "Press <Space> to attack!", new Vector2(300, 550), Color.White);
        }
    }
}
