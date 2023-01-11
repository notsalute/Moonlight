using Moonlight_Client.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using MelonLoader;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using UnhollowerBaseLib.Attributes;
using System.Collections;
using Moonlight_Client.Nocturnal.Wrappers;
using System.Net;

namespace Moonlight_Client.Functions
{
    internal class WorldOpt
    {

        private static void Sendmurdergmj(string udonevent)
        {
            GameObject.Find("/Game Logic").GetComponent<VRC.Udon.UdonBehaviour>().SendCustomNetworkEvent(0, udonevent);
        }

        public static void WorldID()
        {
            if (WorldWrapper.GetLocation() != "")
                Modules.SendToClip.SetClipboard("[+] MOONLIGHT CLIENT [+]\n" + WorldWrapper.GetLocation() + "\n[+] MOONLIGHT CLIENT [+]");
            MelonLogger.Msg($"World ID: {WorldWrapper.GetLocation()} copied to clipboard.", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"MOONLIGHT >> World ID: {WorldWrapper.GetLocation()} copied to clipboard.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void JoinWorldID()
        {
            VRCFlowManager.prop_VRCFlowManager_0.Method_Public_Void_String_String_WorldTransitionInfo_Action_1_String_Boolean_0(Modules.SendToClip.GetClipboard());
        }

        public static void RejoinWorld()
        {
            VRCFlowManager.prop_VRCFlowManager_0.Method_Public_Void_String_String_WorldTransitionInfo_Action_1_String_Boolean_0(WorldWrapper.GetLocation());
        }

        public static void KillAll()
        {
            foreach (GameObject item in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (item.name.Contains("Game Logic"))
                {
                    item.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "KillLocalPlayer");
                }
            }
        }

        public static void forcestartMurd()
        {
            if (Nocturnal.Wrappers.Extentions.MurderWorld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {
                    udonEvent.SendCustomNetworkEvent(0, "SyncStartGame");
                }
            }
        }

        public static void forcestartAmong()
        {
            if (Nocturnal.Wrappers.Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {
                    udonEvent.SendCustomNetworkEvent(0, "Btn_Start");
                }
            }
        }

        public static void forceendAmong()
        {
            if (Nocturnal.Wrappers.Extentions.Amongunsworld())
            {
                Sendmurdergmj("SyncAbort");
            }
        }

        public static void forceendMurd()
        {
            if (Nocturnal.Wrappers.Extentions.MurderWorld())
            {
                Sendmurdergmj("SyncAbort");
            }
        }

        public static void BystanderWin()
        {
            if (Nocturnal.Wrappers.Extentions.MurderWorld())
            {
                Sendmurdergmj("SyncVictoryB");
            }
        }

        public static void MurderWin()
        {
            if (Nocturnal.Wrappers.Extentions.MurderWorld())
            {

                Sendmurdergmj("SyncVictoryM");

            }
        }

        public static void InfPortals()
        {
            foreach (PortalInternal p in GameObject.FindObjectsOfType<PortalInternal>())
            {
                if (p.field_Private_Int32_0 == VRC.Player.prop_Player_0.prop_Int32_0)
                {
                    var i = p.gameObject.AddComponent<InfinitePortal>();
                    MelonCoroutines.Start(i.SetTimer());
                }
            }
        }

        public static void DestroyPortals()
        {
            foreach (PortalInternal p in GameObject.FindObjectsOfType<PortalInternal>())
            {
                if (p.field_Private_Int32_0 != -1)
                    GameObject.DestroyImmediate(p.gameObject);
            }

        }


        public class InfinitePortal : MonoBehaviour
        {
            [HideFromIl2Cpp]
            public IEnumerator SetTimer()
            {
                while (true)
                {
                    transform.GetComponent<PortalInternal>().SetTimerRPC(float.MinValue, VRC.Player.prop_Player_0);
                    yield return null;
                }
            }
            public InfinitePortal(IntPtr ptr) : base(ptr)
            {
                //Don't delete, it's necessary
            }
        }

        public static void DownloadVRCW()
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

                webClient.DownloadFileAsync(new Uri(WorldWrapper.CurrentWorld().assetUrl), "MoonlightClient/VRCWS/" + WorldWrapper.CurrentWorld().name);
                MelonLogger.Msg("[VRCWS] Downloaded VRCW Completed");
                MelonLogger.Msg($"[ASSETURL] {WorldWrapper.CurrentWorld().assetUrl}");
                MelonLogger.Msg("Copy the URL above to download manually if it doesn't work!");
            });
        }

        //ESP stuff
        public static void NoEspNigga()
        {
            HighlightsFX.field_Private_Static_HighlightsFX_0.enabled = false;
        }
        public static void ESPAAA()
        {
            HighlightsFX.field_Private_Static_HighlightsFX_0.enabled = true;

            if (Extentions.IsInWorld() && Extentions.LocalPlayer != null)
            {

                try
                {
                    foreach (Player gameObject in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {

                        if (gameObject.transform.Find("SelectRegion"))
                        {

                            {
                                var Renderer = gameObject.transform.Find("SelectRegion").GetComponent<Renderer>();
                                HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(Renderer, gameObject);
                            }

                        }
                    }
                }
                catch
                {
                    MelonLogger.Msg("Failed to start ESP On Players");
                }

            }
        }
    }
}
