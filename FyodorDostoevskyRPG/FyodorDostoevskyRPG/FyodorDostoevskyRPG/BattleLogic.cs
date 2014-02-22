namespace FyodorDostoevskyRPG
{
    using System;
    using System.Threading;

    using FyodorDostoevskyRPG.GameObject.GameUnits;
    using FyodorDostoevskyRPG.GameObject.GameItems;

    public static class BattleLogic
    {
        private static bool activated;
        private static Random randomGenerator;
        static BattleLogic()
        {
            randomGenerator = new Random();
            
        }
        public static void HeroAttack(Hero hero, Monster monster)
        {
            activated = hero.Weapon.ActivateSpecial();            
            monster.TakeDamage(
            randomGenerator.Next(
                hero.Damage + hero.Weapon.Damage, hero.DamageMax + hero.Weapon.Damage + 1));
            if (activated)
            {
                hero.Weapon.DeactivateSpecial();
            }
            if (monster.Health <= 0)
            {
                monster.Die();
            }
            if (!(activated && hero.Weapon is Flail))
            {
                //Thread.Sleep(1000);
                MonsterAttack(hero, monster);
            }
        }

        private static void MonsterAttack(Hero hero, Monster monster)
        {
            activated = hero.Shield.ActivateSpecial();            
            hero.TakeDamage(monster.Damage - (int)hero.Shield.Defense);            
            if (activated)
            {
                hero.Shield.DeactivateSpecial();
            }
            if (hero.Health <= 0)
            {
                hero.Die();
            }
            //Thread.Sleep(1000);
        }

    }
}
