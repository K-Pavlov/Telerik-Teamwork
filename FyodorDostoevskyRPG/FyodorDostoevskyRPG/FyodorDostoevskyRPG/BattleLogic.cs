using FyodorDostoevskyRPG.GameObject.GameUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace FyodorDostoevskyRPG
{
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
            activated = hero.Weapon1.ActivateSpecial();            
            monster.TakeDamage(
            randomGenerator.Next(
                hero.Damage + hero.Weapon1.Damage, hero.DamageMax + hero.Weapon1.Damage + 1));
            if (activated)
            {
                hero.Weapon1.DeactivateSpecial();
            }
            if (monster.Health <= 0)
            {
                monster.Die();
            }
            if (!(activated && hero.Weapon1 is Flail))
            {
                //Thread.Sleep(1000);
                MonsterAttack(hero, monster);
            }
        }

        private static void MonsterAttack(Hero hero, Monster monster)
        {
            activated = hero.Shield1.ActivateSpecial();            
            hero.TakeDamage(monster.Damage - (int)hero.Shield1.Defense);            
            if (activated)
            {
                hero.Shield1.DeactivateSpecial();
            }
            if (hero.Health <= 0)
            {
                hero.Die();
            }
            //Thread.Sleep(1000);
        }

    }
}
