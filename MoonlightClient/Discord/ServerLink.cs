using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonlight_Client.Discord
{
    internal class ServerLink
    {
        public static string DiscordStatusActive = "<color=#04eb00>Not Banned</color>";

        public static string DiscordStatusInactive = "<color=#ff0000>Banned</color>";

        public static void DiscordJoin()
        {
            System.Diagnostics.Process.Start("https://discord.gg/Moonlightvrc");
        }
    }
}
