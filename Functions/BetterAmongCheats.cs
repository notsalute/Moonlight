using Moonlight_Client.Nocturnal.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.Udon;

namespace Moonlight_Client.Functions
{
    internal class BetterAmongCheats
    {
        public static void GiveImpos()
        {
            if (Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {
                    udonEvent.SendCustomNetworkEvent(0, "SyncAssignM");
                }
            }
        }

        public static void Skipvotes()
        {
            if (Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {

                    udonEvent.SendCustomNetworkEvent(0, "Btn_SkipVoting");
                }
            }
        }

        public static void FinishVotes()
        {

            if (Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {

                    udonEvent.SendCustomNetworkEvent(0, "SyncCloseVoting");
                }
            }

        }

        public static void ejecteveryone()
        {
            if (Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {
                    udonEvent.SendCustomNetworkEvent(0, "SyncVotedOut");
                }
            }
        }

        public static void sabotageeverything()
        {
            if (Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {

                    udonEvent.SendCustomNetworkEvent(0, "SyncDoSabotageComms");
                    udonEvent.SendCustomNetworkEvent(0, "SyncDoSabotageReactor");
                    udonEvent.SendCustomNetworkEvent(0, "SyncDoSabotageOxygen");
                    udonEvent.SendCustomNetworkEvent(0, "SyncDoSabotageLights");

                }
            }
        }
        
        public static void RepairAll()
        {
            if (Extentions.Amongunsworld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {

                    udonEvent.SendCustomNetworkEvent(0, "SyncRepairComms");
                    udonEvent.SendCustomNetworkEvent(0, "SyncRepairReactor");
                    udonEvent.SendCustomNetworkEvent(0, "SyncRepairOxygen");
                    udonEvent.SendCustomNetworkEvent(0, "SyncRepairLights");

                }
            }
        }

        public static void LogImpostor()
        {
            {
                foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                {

                    if (gameObject.name.Contains("Player Entry") && gameObject.GetComponentInChildren<Text>().text != "PlayerName" && gameObject.GetComponent<Image>().color.r > 0f)
                    {
                        MelonLoader.MelonLogger.Msg(gameObject.GetComponentInChildren<Text>().text + " is the imposter (Very SUS!!!)");
                    }
                }
            }
        }
    }
}
