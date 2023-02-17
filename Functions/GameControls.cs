using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using VRC;
using VRC.Core;
using Moonlight_Client.SDK;

namespace Moonlight_Client.Functions
{
    internal class GameControls
    {
        internal static DiscordRpc.EventHandlers eventHandlers;

        public static void KillGame()
        {
            Process.GetCurrentProcess().Kill();
        }

        public static void RestartGame()
        {
            Process.Start("VRChat.exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void UnCapGame()
        {
            Application.targetFrameRate = 1000;
        }

        public static void CapGame()
        {
            Application.targetFrameRate = 90;
        }

        public static void SlowMo()
        {
            Time.timeScale = 0.2f;
        }

        public static void NormalTime()
        {
            Time.timeScale = 1f;
        }

        public static void LOGOUT()
        {
            APIUser.Logout();
        }

        public static void ClearConsole()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[+]-------------------[+]");
            Console.WriteLine("[+] M O O N L I G H T [+]");
            Console.WriteLine("[+]    C L I E N T    [+]");
            Console.WriteLine("[+]-------------------[+]");
            MelonLoader.MelonLogger.Msg("Cleared Console!", ConsoleColor.Green);
        }
        
        public static void debuglog()
        {

        }

        public static void Fullscreen()
        {
            Screen.SetResolution(int.MaxValue, int.MaxValue, true);
        }

        public static void Windowed()
        {
            Screen.SetResolution(1920, 1080, false);
        }

        public static void StopRPC()
        {
            DiscordRpc.Shutdown();
        }

        public static void StartRPC()
        {
            DiscordRpc.Initialize("973594227453861908", ref eventHandlers, true, "");
        }

        public static void FriendSalute()
        {
            Process.Start("https://vrchat.com/home/user/usr_d2ff31fe-ad0a-478c-9583-0932958caa15");
        }

        /*
        public static int Widdth = -5000;
        public static int Heightt = 1920;

        public static void WideScreenON()
        {
            Camera.main.aspect = Widdth / Heightt;
        }

        public static void WideScreenOFF()
        {
            Camera.current.ResetAspect();
        }
        */
    }
}
