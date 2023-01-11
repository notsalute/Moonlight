using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using VRC.UI.Elements.Menus;

namespace Moonlight_Client
{
    public static class Utils
    {
        public static VRCPlayer LocalPlayer
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }

        public static APIUser CurrentUser
        {
            get
            {
                return APIUser.CurrentUser;
            }
        }

        public static VRCUiManager VRCUiManager
        {
            get
            {
                return VRCUiManager.prop_VRCUiManager_0;
            }
        }

        public static VRCUiPopupManager VRCUiPopupManager
        {
            get
            {
                return VRCUiPopupManager.prop_VRCUiPopupManager_0;
            }
        }

        public static Il2CppSystem.Collections.Generic.List<Player> GetPlayers
        {
            get
            {
                return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
            }
        }

        /*
        public static PageWorldInfo GetPageWorldInfo
        {
            get
            {
                return GameObject.Find("UserInterface/MenuContent/Screens/WorldInfo").GetComponent<PageWorldInfo>();
            }
        }
        */

        public static PageAvatar GetPageAvatar
        {
            get
            {
                return GameObject.Find("UserInterface/MenuContent/Screens/Avatar").GetComponent<PageAvatar>();
            }
        }

        public static ApiWorld GetApiWorld
        {
            get
            {
                return RoomManager.field_Internal_Static_ApiWorld_0;
            }
        }

        public static ApiWorldInstance GetApiWorldInstance
        {
            get
            {
                return RoomManager.field_Internal_Static_ApiWorldInstance_0;
            }
        }

        public static bool IsInRoom()
        {
            return GetApiWorld != null && GetApiWorldInstance != null;
        }

        public static VRCPlayer GetQMSelectedUser()
        {
            var a = UnityEngine.Object.FindObjectOfType<SelectedUserMenuQM>().field_Private_IUser_0;
            return GetPlayerByUserID(a.prop_String_0)._vrcplayer;
        }

        public static Player GetPlayerByUserID(string userID)
        {
            foreach (var plr in GetPlayers)
            {
                if (plr.field_Private_APIUser_0.id == userID)
                {
                    return plr;
                }
            }
            return null;
        }

        public static Player GetPlayerByActorID(int actorID)
        {
            foreach (var plr in GetPlayers)
            {
                if (plr.field_Private_VRCPlayerApi_0.playerId == actorID)
                {
                    return plr;
                }
            }
            return null;
        }

        public static bool SelfIsInVR()
        {
            return XRDevice.isPresent ||
                Environment.CommandLine.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Any(text => text.ToLower() == "--no-vr");
        }

        public static Player GetMaster()
        {
            foreach (var plr in GetPlayers)
            {
                if (plr.prop_VRCPlayerApi_0.isMaster)
                {
                    return plr;
                }
            }
            return null; // There is always a master so no need to worry about it returning null.
        }

        public static string GetJoinID()
        {
            return GetApiWorldInstance.id;
        }

        public static void JoinRoom(string fullID)
        {
            Networking.GoToRoom(fullID);
        }

        public static void JoinRoom(string worldID, string instanceID) => JoinRoom($"{worldID}:{instanceID}");

        public static APIUser GetAPIUser(this Player source) { return source.field_Private_APIUser_0; }
        public static VRCPlayer GetVRCPlayer(this Player source) { return source._vrcplayer; }
        public static VRCPlayerApi GetVRCPlayerApi(this Player source) { return source.field_Private_VRCPlayerApi_0; }
        public static PlayerNet GetPlayerNet(this Player source) { return source._playerNet; }
        public static ApiAvatar GetMainAvatar(this Player source) { return source.prop_ApiAvatar_0; }
        public static ApiAvatar GetFallbackAvatar(this Player source) { return source._vrcplayer.prop_ApiAvatar_1; }
        public static Photon.Realtime.Player GetPhotonPlayer(this Player source) { return source.field_Private_Player_0; }
        public static string GetTrustRank(this APIUser Instance)
        {
            if (Instance.hasModerationPowers || Instance.tags.Contains("admin_moderator"))
                return "Moderation User";
            if (Instance.hasSuperPowers || Instance.tags.Contains("admin_"))
                return "Admin User";
            // These ranks were removed
            /*if (Instance.tags.Contains("system_legend") && Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return "Legend";
            if (Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return "Veteran";*/
            if (Instance.hasVeteranTrustLevel)
                return "Trusted";
            if (Instance.hasTrustedTrustLevel)
                return "Known";
            if (Instance.hasKnownTrustLevel)
                return "User";
            if (Instance.hasBasicTrustLevel || Instance.isNewUser)
                return "New User";
            if (Instance.hasNegativeTrustLevel || Instance.tags.Contains("system_probable_troll"))
                return "NegativeTrust";
            return Instance.hasVeryNegativeTrustLevel ? "VeryNegativeTrust" : "Visitor";
        }
    }
}
