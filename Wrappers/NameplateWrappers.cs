using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC;

namespace Moonlight_Client.Wrappers
{
    public static class NameplateWrappers
    {
        public static short GetPing(this VRC.Player Instance)
        {
            return Instance.GetPlayerNet().field_Private_Int16_0;
        }

        public static int GetFrames(this VRC.Player Instance)
        {
            return (Instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / (float)Instance.GetPlayerNet().prop_Byte_0) : 0);
        }

        public static string GetFramesColord(this Player player)
        {
            float frames = player.GetFrames();
            if (frames > 80f)
            {
                return "<color=green>" + frames.ToString() + "</color>";
            }
            if (frames > 30f)
            {
                return "<color=yellow>" + frames.ToString() + "</color>";
            }
            return "<color=red>" + frames.ToString() + "</color>";
        }

        public static string GetPingColord(this Player player)
        {
            short ping = player.GetPing();
            if (ping > 150)
            {
                return "<color=red>" + ping.ToString() + "</color>";
            }
            if (ping > 75)
            {
                return "<color=yellow>" + ping.ToString() + "</color>";
            }
            return "<color=green>" + ping.ToString() + "</color>";
        }

        public static bool ClientDetect(this Player player)
        {
            return player.GetFrames() > 90f || player.GetFrames() < 1f || player.GetPing() > 665 || player.GetPing() < 0;
        }

        public static string GetPlatform(this Player player)
        {
            if (player.prop_APIUser_0.IsOnMobile)
            {
                return "<color=green>Poor</color>";
            }
            if (player.GetVRCPlayerApi().IsUserInVR())
            {
                return "<color=#CD00FF>VR</color>";
            }
            return "<color=#0B00FB>PC</color>";
        }

        public static bool GetIsMaster(this Player Instance)
        {
            return Instance.GetVRCPlayerApi().isMaster;
        }
    }
}
