using AuthGG;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonlight_Client.Core.Auth
{
    internal class AuthManager
    {
        public static void Login()
        {
            MelonLogger.Msg(ConsoleColor.Magenta, "You will now be logging into your Moonlight Account:");
            MelonLogger.Msg("Please enter your Username:");
            string Uname = Console.ReadLine();
            MelonLogger.Msg("Please enter your Password:");
            string Pword = Console.ReadLine();
            MelonLogger.Msg(ConsoleColor.Yellow, "Attempting to login...");
            if (API.Login(Uname, Pword))
            {
                MelonLogger.Msg(ConsoleColor.Green, $"Successfully Logged into {Uname}");
                MelonLogger.Msg(ConsoleColor.Green, "Welcome back <3");
            }
            else
            {
                MelonLogger.Msg(ConsoleColor.DarkRed, $"User: {Uname} doesn't exist!");
                MelonLogger.Msg(ConsoleColor.DarkRed, $"Closing game in 10s");
                Thread.Sleep(10000);
                Process.GetCurrentProcess().Kill();
                Thread.Sleep(-1); //Just incase
            }
        }

        public static void Register()
        {
            MelonLogger.Msg(ConsoleColor.Magenta, "You will now be registering a Moonlight Account:");
            MelonLogger.Msg("Please enter your Username (DO NOT USE FANCY CHARACTERS):");
            string Uname = Console.ReadLine();
            MelonLogger.Msg("Please enter your Password (USE A STRONG PASSWORD):");
            string Pwrod = Console.ReadLine();
            MelonLogger.Msg("Please enter your Email (MUST BE A VALID EMAIL):");
            string Eml = Console.ReadLine();
            MelonLogger.Msg("Please enter your License Key:");
            string Lic = Console.ReadLine();
            MelonLogger.Msg(ConsoleColor.Yellow, "Attempting to register...");
            if (API.Register(Uname, Pwrod, Eml, Lic))
            {
                MelonLogger.Msg(ConsoleColor.Green, $"Successfully registered the account: {Uname}");
                MelonLogger.Msg(ConsoleColor.Green, "Welcome to moonlight!");
            }
            else
            {
                MelonLogger.Msg(ConsoleColor.DarkRed, $"FAILED to create account");
                MelonLogger.Msg(ConsoleColor.DarkRed, $"Make sure that you have a valid Email and License Key");
                MelonLogger.Msg(ConsoleColor.DarkRed, $"Closing game in 10s");
                Thread.Sleep(10000);
                Process.GetCurrentProcess().Kill();
                Thread.Sleep(-1); //Just incase
            }
        }
    }
}
