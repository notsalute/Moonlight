using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Moonlight_Client.Modules
{
    class LoggerUtill
    {
        private static List<string> DebugLogs = new List<string>();
        private static int duplicateCount = 1;
        private static string lastMsg = "";

        public static void DisplayLogo()
        {
            Console.Title = "M O O N L I G H T";
            Console.Clear();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[+]-------------------[+]");
            Console.WriteLine("[+] M O O N L I G H T [+]");
            Console.WriteLine("[+]    C L I E N T    [+]");
            Console.WriteLine("[+]-------------------[+]");
        }

        public static void LogDebug(string message)
        {
            if (message == lastMsg)
            {
                DebugLogs.RemoveAt(DebugLogs.Count - 1);
                duplicateCount++;
                DebugLogs.Add($"<color=white><b>[<color=magenta>Moonlight</color>] [<color=#ff00ffff>{DateTime.Now.ToString("hh:mm tt")}</color>] {message} <color=red><i>x{duplicateCount}</i></color></b></color>");
            }
            else
            {
                lastMsg = message;
                duplicateCount = 1;
                DebugLogs.Add($"<color=white><b>[<color=magenta>Moonlight</color>] [<color=#ff00ffff>{DateTime.Now.ToString("hh:mm tt")}</color>] {message}</b></color>");
                if (DebugLogs.Count == 25)
                {
                    DebugLogs.RemoveAt(0);
                }
            }
        }

        public static void Log(string msg, ConsoleColor color = ConsoleColor.White, bool debug = false)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Moonlight");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(DateTime.Now.ToString("hh:mm"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            if (debug)
                LogDebug(msg);
        }
    }
}
