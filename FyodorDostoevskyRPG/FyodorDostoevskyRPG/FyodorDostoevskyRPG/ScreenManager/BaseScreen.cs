namespace FyodorDostoevskyRPG.ScreenManager
{
    using Microsoft.Xna.Framework;

    public abstract class BaseScreen
    {
        // Fields
        private string name;
        private Vector2 position;
        private ScreenState state = ScreenState.Active;

        // Methods -> trqbva da se override ot vseki otdlen ekran
        protected virtual void HandleInput()
        {
        }

        protected virtual void Load()
        {
        }

        protected virtual void Unload()
        {
            state = ScreenState.ShutDown;
        }

        protected virtual void Update()
        {
        }

        protected virtual void Draw()
        {
        }
    }
}
