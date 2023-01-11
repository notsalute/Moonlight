using MelonLoader;
using System.IO;
using System.Net;
using UnityEngine;

namespace Moonlight_Client.Files
{
    internal static class ModFiles
    {
        internal static string ModFolder = Directory.GetParent(Application.dataPath) + "\\MoonlightClient";
        internal static string MLModsFolder = Directory.GetParent(Application.dataPath) + "\\Mods";
        internal static string MLPluginsFolder = Directory.GetParent(Application.dataPath) + "\\Plugins";
        internal static string VRChatFolder = Directory.GetParent(Application.dataPath).FullName;

        internal static string MiscFolder = ModFolder + "\\Misc";
        internal static string VRCAFolder = ModFolder + "\\VRCAS";
        internal static string VRCWFolder = ModFolder + "\\VRCWS";

        internal static void Initialize()
        {
            int createdFolders = 0;
            if (!Directory.Exists(ModFolder))
            {
                Directory.CreateDirectory(ModFolder);
                createdFolders++;
            }

            if (!Directory.Exists(MiscFolder))
            {
                Directory.CreateDirectory(MiscFolder);
                createdFolders++;
            }

            if (!Directory.Exists(VRCAFolder))
            {
                Directory.CreateDirectory(VRCAFolder);
                createdFolders++;
            }

            if (!Directory.Exists(VRCWFolder))
            {
                Directory.CreateDirectory(VRCWFolder);
                createdFolders++;
            }

            if (createdFolders != 0)
            {
                MelonLogger.Msg($"Created {createdFolders} Folders!");

                if (!File.Exists($"{MelonUtils.GameDirectory}\\MoonlightClient\\theme.ogg"))
                {
                    MelonLogger.Msg("Installed Custom Loading Song");
                    var wc = new WebClient();
                    wc.DownloadFile("https://up.hvl.gg/2538b9/bigErUJA08.ogg", $"{MelonUtils.GameDirectory}\\MoonlightClient\\Music.ogg");




                }

        }
    }
    }
}