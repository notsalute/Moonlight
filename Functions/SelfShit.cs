using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.DataModel;
using VRC;
using VRC.Core;
using UnityEngine;
using Moonlight_Client.SDK;
using MelonLoader;
using Moonlight_Client.IK;
using RootMotion.FinalIK;
using Moonlight_Client.IKHandler;
using UnhollowerRuntimeLib;
using System.Net;

namespace Moonlight_Client.Functions
{
    internal class SelfShit
    {
        private static string backupID;

        public static void HideSelfOn()
        {
            backupID = PlayerWrapper.LocalVRCPlayer().GetAPIAvatar().id;
            PlayerWrapper.LocalPlayer().SetHide(true);
        }

        public static void HideSelfOff()
        {
            PlayerWrapper.ChangeAvatar(backupID);
            PlayerWrapper.LocalPlayer().SetHide(false);
        }

        public static void AVIID()
        {
            MelonLogger.Msg("[NOTICE] Make sure to have an avatar ID copied to your clipboard!");

            if (Modules.SendToClip.GetClipboard().StartsWith("avtr")) 
            {
                PlayerWrapper.ChangeAvatar(Modules.SendToClip.GetClipboard());
                MelonLogger.Msg("Changed Avatar By ID");
            }
            else
            {
                MelonLogger.Msg("[ERROR] Failed to send ID");
            }
        }

        public static void DefaultAVI()
        {
            PlayerWrapper.ChangeAvatar("avtr_c38a1615-5bf5-42b4-84eb-a8b6c37cbd11");
        }

        public static void AssetKill()
        {
            backupID = APIUser.CurrentUser.avatarId;
            PlayerWrapper.LocalVRCPlayer().SetHide(true);
            PlayerWrapper.ChangeAvatar("avtr_c8052a0b-45a5-4870-87cc-e2d1c0e3bc80");
        }

        public static void AssetKillOff()
        {
            PlayerWrapper.ChangeAvatar(backupID);
            PlayerWrapper.LocalVRCPlayer().SetHide(false);
        }

        public static void StopQuestAssetKill()
        {
            PlayerWrapper.ChangeAvatar(backupID);
            PlayerWrapper.LocalVRCPlayer().SetHide(false);
        }

        public static void StartQuestAssetKill()
        {
            backupID = APIUser.CurrentUser.avatarId;
            PlayerWrapper.LocalVRCPlayer().SetHide(true);
            PlayerWrapper.ChangeAvatar("avtr_91f29847-dff8-4940-bbce-7489558ef9e7");
        }

        public static void TPOSE()
        {
            Animator animator = Player.prop_Player_0._vrcplayer.field_Internal_Animator_0;
            animator.enabled = !animator.enabled;
        }

        public static void DwnVRCA()
        {
            Task.Run(delegate
            {
                WebClient webClient = new WebClient
                {
                    Headers =
                    {
                        "User-Agent: Other"
                    }
                };
                webClient.DownloadFileAsync(new Uri(PlayerWrapper.LocalVRCPlayer().GetAPIAvatar().assetUrl), "MoonlightClient/VRCAS/" + PlayerWrapper.LocalVRCPlayer().GetAPIAvatar().name);
                MelonLogger.Msg("[VRCAS] Downloaded VRCA Completed");
                MelonLogger.Msg($"[ASSETURL] {PlayerWrapper.LocalVRCPlayer().GetAPIAvatar().assetUrl}");
                MelonLogger.Msg("Copy the URL above to download manually if it doesn't work!");
            });
        }
    }
}
