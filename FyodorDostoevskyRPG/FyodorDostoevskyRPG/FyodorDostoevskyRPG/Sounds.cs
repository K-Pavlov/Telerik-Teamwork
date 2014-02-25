namespace FyodorDostoevskyRPG
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    using FyodorDostoevskyRPG.ScreenManagement;

    public static class Sounds
    {
        public static int resumeTime = 0;

        public static SoundEffect boundaryBounceSound = ScreenManager.Instance.screenManagerContent.Load<SoundEffect>("Sounds/bounce");
        public static SoundEffect step = ScreenManager.Instance.screenManagerContent.Load<SoundEffect>("Sounds/step");
        public static SoundEffect heal = ScreenManager.Instance.screenManagerContent.Load<SoundEffect>("Sounds/heal");

        public static Song mainSong = ScreenManager.Instance.screenManagerContent.Load<Song>("Sounds/MAINMENU");
        public static Song exitSong = ScreenManager.Instance.screenManagerContent.Load<Song>("Sounds/exitSong");
        public static Song mapScreen = ScreenManager.Instance.screenManagerContent.Load<Song>("Sounds/mapScreen");
        public static Song combatMusic = ScreenManager.Instance.screenManagerContent.Load<Song>("Sounds/combat");
        public static Song loseCombat = ScreenManager.Instance.screenManagerContent.Load<Song>("Sounds/LoseCombat");
        public static Song winCombat = ScreenManager.Instance.screenManagerContent.Load<Song>("Sounds/WinBattle");

        /////////////////////////////////////////////////////////
        public static void StartMainMusic()
        {
            MediaPlayer.Play(Sounds.mainSong);
        }
        public static void StopMainMusic()
        {
            MediaPlayer.Stop();
        }
        /////////////////////////////////////////////////////////
        public static void StartExitMusic()
        {
            MediaPlayer.Play(Sounds.exitSong);
        }
        /////////////////////////////////////////////////////////
        public static void StartMapMusic()
        {
            MediaPlayer.Play(Sounds.mapScreen);
        }
        public static void StopMapMusic()
        {
            MediaPlayer.Pause();
        }
        /////////////////////////////////////////////////////////
        public static void StartBattleMusic()
        {
            MediaPlayer.Play(Sounds.combatMusic);
        }
        public static void StopBattleMusic()
        {
            MediaPlayer.Stop();
        }
        /////////////////////////////////////////////////////////
        public static void PlayStep()
        {
            step.Play();
        }
        /////////////////////////////////////////////////////////
        public static void PlayLostCampaign()
        {
            MediaPlayer.Play(Sounds.loseCombat);
        }
        public static void PlayWinCampaign()
        {
            MediaPlayer.Play(Sounds.winCombat);
        }
        /////////////////////////////////////////////////////////
        public static void PlayHeal()
        {
            heal.Play();
        }
    }
}
