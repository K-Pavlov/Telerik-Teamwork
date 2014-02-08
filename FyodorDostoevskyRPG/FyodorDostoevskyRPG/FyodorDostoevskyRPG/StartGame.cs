using System;

namespace FyodorDostoevskyRPG
{
    static class StartGame
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FyodorsAdventure game = new FyodorsAdventure())
            {
                game.Run();
            }
        }
    }
}

