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

        public BattleScreen(IDrawObject unit)
        {
            if (unit is Dragon)
            {
                monsterImage = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("bigHero");
            }
            else if (unit is Golem)
            {
                monsterImage = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("bigMonster");
            }

            monsterPosition = new Vector2(750 - monsterImage.Width, 50);
        }


        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(monsterImage,monsterPosition,Color.White);
            spriteBatch.Draw(heroImage, heroPosition, Color.White);
        }
    }
}
