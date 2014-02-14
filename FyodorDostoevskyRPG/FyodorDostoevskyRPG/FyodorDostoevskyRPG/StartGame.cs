using System;

namespace FyodorDostoevskyRPG
{
    internal static class StartGame
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            using (var game = new FyodorsAdventure())
            {
                game.Run();
            }
        }
    }
}

