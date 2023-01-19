using Moonlight_Client.Core;
using MelonLoader;
using Modules;
using Moonlight_Client.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Moonlight_Client.Discord;
using UnhollowerRuntimeLib;
using Moonlight_Client.Functions;
using Moonlight_Client.SDK;
using VRC.Core;
using System.Reflection;
using Moonlight_Client.Core.Auth;

[assembly: MelonInfo(typeof(Moonlight_Client.Main), "Moonlight Revamped", "1.0", "notsalute And Zilla", "Credits to Snow and HyperV for the help ")]
[assembly: MelonColor(ConsoleColor.Magenta)]
[assembly: MelonGame("VRChat", "VRChat")]


namespace Moonlight_Client
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Loading Stuff...");
            MelonCoroutines.Start(TitleAnim.ChangeTitle());
            Console.Title = $"|| Moonlight Client ||";
            Files.ModFiles.Initialize();
            MelonCoroutines.Start(WaitForUser());
            MelonLogger.Msg("Done!");
            MelonLogger.Msg("Initializing Client..");
            MelonCoroutines.Start(WaitForQM());
            MelonCoroutines.Start(WaitForSM());
            
            ClassInjector.RegisterTypeInIl2Cpp<NameplatesMono>();
            Patches.Initialize();
            var original = typeof(APIUser).GetProperty(nameof(APIUser.allowAvatarCopying)).GetSetMethod();
            var method = typeof(Main).GetMethod(nameof(Main.Hook), BindingFlags.NonPublic | BindingFlags.Static);
            var patch = new HarmonyLib.HarmonyMethod(method);
            HarmonyInstance.Patch(original, patch);

            MelonLogger.Msg("Done!");
        }

        internal IEnumerator WaitForUser()
        {
            while (APIUser.CurrentUser?.id == null) yield return null;
            UserAuth.Initialize(); //Start Auth
            MelonLogger.Msg($"Logged in as: {APIUser.CurrentUser.displayName}"); //Print User
            yield break;
        }


        private static void Hook(ref bool __0) => __0 = true;
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex == 1)
            {
                MelonCoroutines.Start(Moonlight_Client.Modules.LoadingMusic.LoadingScreen());
            }
            if (buildIndex == 2)
            {
                MelonCoroutines.Start(Moonlight_Client.Modules.LoadingMusic.ChangeLoadingScreen());
            }

        }



        public override void OnUpdate()
        {
            Movements.HandleFly();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (buildIndex == -1)
            {
                WaitForWorld().Start();
                WaitForPlayer().Start();

            }
        }

        private IEnumerator WaitForQM()
        {
            while (Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() == null) yield return null;
            UI.QuickMenuInit();
            yield break;
        }

        private static IEnumerator WaitForSM()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;

            yield break;
        }

        private static IEnumerator WaitForWorld()
        {
            while (RoomManager.field_Internal_Static_ApiWorld_0 == null) yield return null;
            while (RoomManager.field_Internal_Static_ApiWorldInstance_0 == null) yield return null;

        }

        private static IEnumerator WaitForPlayer()
        {
            while (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null) yield return null;
            while (VRCPlayer.field_Internal_Static_VRCPlayer_0._player == null) yield return null;

        }
    }
}

