namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    public interface IActions
    {
        void IsAlive(int health);
        void DisplayHealth(int health);
        void TakeDamage(int damage);
        void Attack(int damage);
    }
}
