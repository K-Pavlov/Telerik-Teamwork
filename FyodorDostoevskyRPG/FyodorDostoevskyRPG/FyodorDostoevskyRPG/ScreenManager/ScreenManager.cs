namespace FyodorDostoevskyRPG.ScreenManager
{
    using System.Collections.Generic;

    public enum ScreenState
    {
        Active,
        Hidden,
        ShutDown
    }

    public class ScreenManager
    {
        private static ScreenManager instance;
        private static Stack<BaseScreen> screens;

        // Constructors -> private za da ne moje da se instancira 
        // poveche ot vednuj
        private ScreenManager() { }
        static ScreenManager()
        {
            ScreenManager.instance = new ScreenManager();
        }

        // Properties -> za dostypvane na instanciqta
        public static ScreenManager Instance
        {
            get { return ScreenManager.instance; }
        }

        // Methods
        public static void LoadScreen(BaseScreen screen)
        {

        }

        public static void UnloadScreen(BaseScreen screen)
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
