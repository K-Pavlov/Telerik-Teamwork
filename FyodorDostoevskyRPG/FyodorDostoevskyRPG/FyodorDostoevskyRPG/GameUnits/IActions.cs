using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FyodorDostoevskyRPG.GameUnits
{
    public interface IActions
    {
        void IsAlive(int health);
        void DisplayHealth(int health);
        void TakeDamage(int damage);
        void Attack(int damage);
    }
}
