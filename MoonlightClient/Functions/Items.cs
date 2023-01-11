using Moonlight_Client.Nocturnal.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;

namespace Moonlight_Client.Functions
{
    class items
    {
        public static bool rotates = false;
        public static bool Respawnloopopt = false;
        public static bool ownererp = false;

        public static VRC_Pickup[] array = null;

        public static void bringpickups(VRC.Player player)
        {
            for (int i = 0; i < array.Length; i++)
            {

                if (array[i].gameObject)
                {
                    Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, array[i].gameObject);
                    Transform transform = array[i].transform;
                    transform.transform.position = player.transform.position + new Vector3(0f, 0.1f, 0f);
                }
            }
        }


        public static void respawnpickups()
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (Networking.GetOwner(array[i].gameObject) != Networking.LocalPlayer)
                    Networking.SetOwner(Networking.LocalPlayer, array[i].gameObject);
                array[i].transform.localPosition = new Vector3(-999f, -999f, -999f);
            }
        }

        public static bool ownertr = false;

        public static void objectowner()
        {


            for (int i = 0; i < array.Length; i++)
            {

                if (array[i].gameObject && Networking.GetOwner(array[i].gameObject) != Networking.LocalPlayer)
                {

                    Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, array[i].gameObject);
                }

            }


        }


        public static bool isspamhead = false;

        public static void rotateobjse()
        {

            for (int i = 0; i < array.Length; i++)
            {

                if (array[i].gameObject)
                {

                    Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, array[i].gameObject);
                    array[i].transform.transform.Rotate(1f, 1f, 1f);

                }

            }

        }
    }
}
