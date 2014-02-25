namespace FyodorDostoevskyRPG.GameObject.GameUnits
{
    public interface IActions
    {
        bool IsAlive { get; }

        void TakeDamage(int damage);
        void Die();
    }
}
