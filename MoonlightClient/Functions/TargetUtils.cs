using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Core;
using VRC.UI;

namespace Moonlight_Client.Functions
{
    internal class TargetUtils
    {
        public static string AvatarID = $"";
        public static void FCloning()
        {
            PageAvatar page = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
            page.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0.id = AvatarID;
            page.ChangeToSelectedAvatar();
        }
    }
}
