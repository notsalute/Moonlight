using HarmonyLib;
using Moonlight_Client.Discord;
using Moonlight_Client.Modules;
using System;
using System.Reflection;
using VRC;
using MelonLoader;
using VRC.Core;
using Moonlight_Client.SDK;

namespace Moonlight_Client.Core
{
    public static class Patches
    {
        private static HarmonyLib.Harmony Instance = new HarmonyLib.Harmony(Guid.NewGuid().ToString());

        internal static bool QMOpen;

        private static HarmonyMethod GetPatch(string name) 
        {
            return new HarmonyMethod(typeof(Patches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        public static void Initialize()
        {
            Instance.Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.Method_Public_Void_Player_0)), GetPatch(nameof(PlayerJoinedPatch)));
            Instance.Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.Method_Public_Void_Player_1)), GetPatch(nameof(PlayerLeftPatch)));
            Instance.Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftRoom)), GetPatch(nameof(LeftRoomPatch)));
            Instance.Patch(typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.OnEnable)), GetPatch(nameof(QmOpen)));
            Instance.Patch(typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.OnDisable)), GetPatch(nameof(QmClose)));
        }

        private static void QmClose() {
            QMOpen = false;
        }

        private static void QmOpen() {
            QMOpen = true;
        }

        private static void PlayerJoinedPatch(Player __0)
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
            DiscordManager.UpdatePlayerCount();
            MelonLogger.Msg($"[PlayerJoin]: {__0.field_Private_APIUser_0.displayName}");
            MelonLogger.Msg($"[PlayerJoin]: {__0.field_Private_APIUser_0.id}");
            __0.transform.Find("Player Nameplate/Canvas/Nameplate").gameObject.AddComponent<NameplatesMono>().player = __0;
        }

        private static void PlayerLeftPatch(Player __0) 
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
            MelonLogger.Msg($"[PlayerLeft]: {__0.field_Private_APIUser_0.displayName}");
            MelonLogger.Msg($"[PlayerLeft]: {__0.field_Private_APIUser_0.id}");
            DiscordManager.UpdatePlayerCount();
        }

        private static void LeftRoomPatch() 
        {
            DiscordManager.UpdateWorld();
        }
    }
}
