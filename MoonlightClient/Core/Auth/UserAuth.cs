using AuthGG;
using Il2CppSystem.Diagnostics;
using Il2CppSystem.Xml;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Moonlight_Client.Core.Auth
{
    internal class UserAuth
    {
        public static void Initialize()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, "Loading Moonlight auth...");
            OnProgramStart.Initialize("APPNAME", "AccountID", "PROGRAMSECRET", "VERSION"); //Put your Authgg stuff in here
            MelonLogger.Msg(ConsoleColor.Green, "Loaded");

            MelonLogger.Msg(ConsoleColor.Magenta, "[x]---------------------------------------------------[x]");
            MelonLogger.Msg("Welcome to Moonlight!");
            MelonLogger.Msg("Before you can use Moonlight you will need to create a Moonlight Account and login.");
            MelonLogger.Msg("Make sure to read the RULES before using Moonlight");
            MelonLogger.Msg("Choose an option below: ");
            MelonLogger.Msg("[1] Login [2] Register");
            MelonLogger.Msg(ConsoleColor.Magenta, "[x]---------------------------------------------------[x]");
            MelonLogger.Msg("Your Option:");

            int youroption = int.Parse(Console.ReadLine());

            if(youroption == 1)
            {
                MelonLogger.Msg("Starting login...");
                AuthManager.Login();
            }
            if (youroption == 2)
            {
                MelonLogger.Msg("Starting register...");
                AuthManager.Register();
            }
            if (youroption == 3 || youroption > 2 || youroption < 1 || youroption == 0)
            {
                MelonLogger.Msg(ConsoleColor.DarkRed, "Choose a valid option!!");
                MelonLogger.Msg(ConsoleColor.Yellow, "Closing in 4.5s");
                Thread.Sleep(4500);
                Process.GetCurrentProcess().Kill();
            }
            if(Console.ReadLine() != youroption.ToString())
            {
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
