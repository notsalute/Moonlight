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
        }
    }
}