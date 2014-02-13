namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    public interface IActions
    {
        bool IsAlive { get; }

        void DisplayHealth(int health);
        void TakeDamage(int damage);
        void Attack(int damage);
    }
}
