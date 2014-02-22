using FyodorDostoevskyRPG.GameObject;
using FyodorDostoevskyRPG.GameObject.GameUnits;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace FyodorDostoevskyRPG.ScreenManagement
{
    class BattleScreen : BaseScreen
    {
        private Texture2D heroImage = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("bigHero");
        private Texture2D monsterImage;

        private Vector2 heroPosition = new Vector2(50, 50);
        private Vector2 monsterPosition;

        private Hero hero;
        private Monster monster;

        public BattleScreen(Hero hero, Monster monster)
        {
            if (monster is Dragon)
            {
                monsterImage = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("bigHero");
            }
            else if (monster is Golem)
            {
                monsterImage = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("bigMonster");
            }
            this.monster = monster;
            this.hero = hero;
            monsterPosition = new Vector2(750 - monsterImage.Width, 50);
        }


        public override void Update(GameTime gameTime)
        {
            BattleLogic.HeroAttack(hero, monster);
            if (!monster.IsAlive)
            {
                ScreenManager.Instance.UnloadScreen();
            }
            else if (!hero.IsAlive)
            {
                FyodorsAdventure.ShouldExit = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(monsterImage,monsterPosition,Color.White);
            spriteBatch.Draw(heroImage, heroPosition, Color.White);
        }
    }
}
