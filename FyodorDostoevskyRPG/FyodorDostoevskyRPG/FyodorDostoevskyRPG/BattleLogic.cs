namespace FyodorDostoevskyRPG
{
    using System;

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
                Sounds.StopBattleMusic();
                Sounds.StartMapMusic();
            }
            BlessingOfTheBattle(hero);
            if (!(activated && hero.Weapon is Flail))
            {
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
                Sounds.StopBattleMusic();
                Sounds.StartMapMusic();
            }
            BlessingOfTheBattle(monster);
        }

        private static void BlessingOfTheBattle(Unit unit)
        {
            if (randomGenerator.Next(1, 101) < 10 && unit.Health < unit.FullHeath)
            {
                if (unit is Hero)
                {
                    if (unit.Health + 8 >= unit.FullHeath)
                    {
                        unit.Health = unit.FullHeath;
                        return;
                    }
                    unit.Health += 4;
                    return;
                }
                if (unit.Health + 5 >= unit.FullHeath)
                {
                    unit.Health = unit.FullHeath;
                    return;
                }
                unit.Health += 5;
            }
        }
    }
}
