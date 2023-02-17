using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
using VRC.Networking;
using VRC.Udon;
using VRC.Core;
using VRC;

namespace Moonlight_Client.SDK
{
    class WorldWrapper
    {
        public static VRC_Pickup[] vrc_Pickups;
        public static UdonBehaviour[] udonBehaviours;
        public static VRC_Trigger[] vrc_Triggers;
        public static string GetInstance() => CurrentWorldInstance().instanceId;
        public static string GetID() => CurrentWorld().id;
        public static string GetLocation() => PlayerWrapper.LocalPlayer().GetAPIUser().location;
        public static ApiWorld CurrentWorld() => RoomManager.field_Internal_Static_ApiWorld_0;
        public static ApiWorldInstance CurrentWorldInstance() => RoomManager.field_Internal_Static_ApiWorldInstance_0;

        public static string MoonLightHome() => "wrld_ca244621-3055-463d-9eda-07b9ce70680f:43906";

        public static void Init()
        {
            vrc_Pickups = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            udonBehaviours = UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
            vrc_Triggers = UnityEngine.Object.FindObjectsOfType<VRC_Trigger>();
            PlayerWrapper.PlayersActorID = new Dictionary<int, VRC.Player>();
            //for (int i = 0; i < Main.Instance.onWorldInitEventArray.Length; i++)
                //Main.Instance.onWorldInitEventArray[i].OnWorldInit();
        }

        /*
        public static Player GetPlayerByUserID(string userID)
        {
            return WorldUtils.GetPlayers().FirstOrDefault(p => p.prop_APIUser_0.id == userID);
        }

        public static IEnumerable<Player> GetPlayers()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        }
        */
    }
}