using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using VRC.Core;
using Moonlight_Client.SDK;
using VRC;

namespace Moonlight_Client.Discord
{
    internal static class DiscordManager
    {
        internal static DiscordRpc.RichPresence presence;
        internal static DiscordRpc.EventHandlers eventHandlers;

        internal static void InitRPC()
        {
            eventHandlers = default;
            eventHandlers.errorCallback = delegate (int code, string message) { };
            presence.state = $"Initializing...";
            //presence.details = $"World: null";
            presence.largeImageKey = "moonlogo";
            presence.largeImageText = "Moonlight";
            presence.smallImageKey = "moonplanet";
            presence.smallImageText = "Hello :)";
            presence.partySize = 0;
            presence.partyMax = 0;
            presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            presence.partyId = Guid.NewGuid().ToString();
            //presence.spectateSecret = "NoLol";
            try
            {
                DiscordRpc.Initialize("973594227453861908", ref eventHandlers, true, "");
                DiscordRpc.UpdatePresence(ref presence);
            }
            catch 
            { 
                //nothing lmao
            }
        }

        internal static void UpdateWorld()
        {
            var world = RoomManager.field_Internal_Static_ApiWorld_0;
            var instance = RoomManager.field_Internal_Static_ApiWorldInstance_0;
            switch (instance.type)
            {
                default:
                    presence.state = "Changing Worlds...";
                    presence.partyId = Guid.NewGuid().ToString();
                    presence.partyMax = 1;
                    presence.partySize = 1;
                    break;

                case InstanceAccessType.Public:
                    presence.state = $"[Public] {world.name}";
                    break;

                case InstanceAccessType.FriendsOfGuests:
                    presence.state = $"[Friends+] {world.name}";
                    break;

                case InstanceAccessType.FriendsOnly:
                    presence.state = $"[Friends] {world.name}";
                    break;

                case InstanceAccessType.InvitePlus:
                    presence.state = $"[Invite+] {world.name}";
                    break;

                case InstanceAccessType.InviteOnly:
                    presence.state = $"[Invite] {world.name}";
                    break;
            }

            presence.partyId = instance.id;
            presence.partyMax = world.capacity;
            presence.partySize = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
            DiscordRpc.UpdatePresence(ref presence);
        }

        internal static void UpdatePlayerCount()
        {
            presence.partySize = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
            DiscordRpc.UpdatePresence(ref presence);
        }
    }
}