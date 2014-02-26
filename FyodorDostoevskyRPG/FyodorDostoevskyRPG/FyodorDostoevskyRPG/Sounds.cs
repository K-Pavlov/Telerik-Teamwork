namespace FyodorDostoevskyRPG
{
    using System;

    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    using FyodorDostoevskyRPG.ScreenManagement;

    public static class Sounds
    {
        public static int ResumeTime = 0;

        public static SoundEffect BoundaryBounceSound = ScreenManager.Instance.ScreenManagerContent.Load<SoundEffect>("Sounds/bounce");
        public static SoundEffect Step = ScreenManager.Instance.ScreenManagerContent.Load<SoundEffect>("Sounds/step");
        public static SoundEffect Heal = ScreenManager.Instance.ScreenManagerContent.Load<SoundEffect>("Sounds/heal");

        public static Song MainSong = ScreenManager.Instance.ScreenManagerContent.Load<Song>("Sounds/MAINMENU");
        public static Song ExitSong = ScreenManager.Instance.ScreenManagerContent.Load<Song>("Sounds/exitSong");
        public static Song MapScreen = ScreenManager.Instance.ScreenManagerContent.Load<Song>("Sounds/mapScreen");
        public static Song CombatMusic = ScreenManager.Instance.ScreenManagerContent.Load<Song>("Sounds/combat");
        public static Song LoseCombat = ScreenManager.Instance.ScreenManagerContent.Load<Song>("Sounds/LoseCombat");
        public static Song WinCombat = ScreenManager.Instance.ScreenManagerContent.Load<Song>("Sounds/WinBattle");

        /////////////////////////////////////////////////////////
        public static void StartMainMusic()
        {
            MediaPlayer.Play(Sounds.MainSong);
        }
        public static void StopMainMusic()
        {
            MediaPlayer.Stop();
        }
        /////////////////////////////////////////////////////////
        public static void StartExitMusic()
        {
            MediaPlayer.Play(Sounds.ExitSong);
        }
        /////////////////////////////////////////////////////////
        public static void StartMapMusic()
        {
            MediaPlayer.Play(Sounds.MapScreen);
        }
        public static void StopMapMusic()
        {
            MediaPlayer.Pause();
        }
        /////////////////////////////////////////////////////////
        public static void StartBattleMusic()
        {
            MediaPlayer.Play(Sounds.CombatMusic);
        }
        public static void StopBattleMusic()
        {
            MediaPlayer.Stop();
        }
        /////////////////////////////////////////////////////////
        public static void PlayStep()
        {
            Step.Play();
        }
        /////////////////////////////////////////////////////////
        public static void PlayLostCampaign()
        {
            MediaPlayer.Play(Sounds.LoseCombat);
        }
        public static void PlayWinCampaign()
        {
            MediaPlayer.Play(Sounds.WinCombat);
        }
        /////////////////////////////////////////////////////////
        public static void PlayHeal()
        {
            Heal.Play();
        }
    }
}
