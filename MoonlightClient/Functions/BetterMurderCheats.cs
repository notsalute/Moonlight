using Moonlight_Client.Nocturnal.Wrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Core;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

namespace Moonlight_Client.Functions
{
    internal class BetterMurderCheats
    {

        public static void Getknife()
        {
            if (Extentions.MurderWorld())
            {
                List<GameObject> Knifes = new List<GameObject>()
            {
                GameObject.Find("Game Logic").transform.Find("Weapons/Knife (0)").gameObject,
                GameObject.Find("Game Logic").transform.Find("Weapons/Knife (1)").gameObject,
                GameObject.Find("Game Logic").transform.Find("Weapons/Knife (2)").gameObject,
                GameObject.Find("Game Logic").transform.Find("Weapons/Knife (3)").gameObject,
                GameObject.Find("Game Logic").transform.Find("Weapons/Knife (4)").gameObject,
                GameObject.Find("Game Logic").transform.Find("Weapons/Knife (5)").gameObject,

            };
                foreach (var gameObject in Knifes)
                {
                    Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, gameObject);
                    gameObject.transform.position = Extentions.LocalPlayer.GetVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);
                }
            }
        }

        public static void TpBOMBLOL()
        {
            if (Extentions.MurderWorld())
            {
                foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                {

                    if (gameObject.name.Contains("Frag"))
                    {
                        Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, gameObject);
                        gameObject.transform.position = Extentions.LocalPlayer.GetVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);
                    }
                }
            }
        }

        public static void Tpre()
        {
            if (Extentions.MurderWorld())
            {

                Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, GameObject.Find("/Game Logic").transform.Find("Weapons/Revolver").gameObject);
                GameObject.Find("/Game Logic").transform.Find("Weapons/Revolver").gameObject.transform.position = Extentions.LocalPlayer.GetVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);
            }

        }

        public static void Luger()
        {
            if (Extentions.MurderWorld())
            {

                Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, GameObject.Find("Game Logic").transform.Find("Luger").gameObject);
                GameObject.Find("Game Logic").transform.Find("Luger").gameObject.transform.position = Extentions.LocalPlayer.GetVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);

            }
        }

        public static void shotgun()
        {
            if (Extentions.MurderWorld())
            {



                Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, GameObject.Find("Game Logic").transform.Find("Shotgun").gameObject);
                GameObject.Find("Game Logic").transform.Find("Shotgun").gameObject.transform.position = Extentions.LocalPlayer.GetVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);
            }

        }

        public static void beartrap()
        {
            if (Extentions.MurderWorld())
            {
                foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                {

                    if (gameObject.name.Contains("Bear Trap"))
                    {
                        Networking.SetOwner(Extentions.LocalPlayer.field_Private_VRCPlayerApi_0, gameObject);
                        gameObject.transform.position = Extentions.LocalPlayer.GetVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);
                    }
                }
            }
        }

        public static void blindall()
        {
            if (Extentions.MurderWorld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {

                    udonEvent.SendCustomNetworkEvent(0, "OnLocalPlayerFlashbanged");
                    udonEvent.SendCustomNetworkEvent(0, "OnLocalPlayerBlinded");
                }
            }
        }

        public static void findclues()
        {
            if (Extentions.MurderWorld())
            {
                foreach (var udonEvent in GameObject.FindObjectsOfType<UdonBehaviour>())
                {

                    udonEvent.SendCustomNetworkEvent(0, "SyncCluesFinished");
                    udonEvent.SendCustomNetworkEvent(0, "OnPlayerUnlockedClues");
                    udonEvent.SendCustomNetworkEvent(0, "OnCollectClue");
                }
            }
        }

        public static void lightsout()
        {
            List<GameObject> marcel = new List<GameObject>()
            {
            GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (0)").gameObject,
                GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (1)").gameObject,
                    GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (2)").gameObject,
                    GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (3)").gameObject,

            };
            foreach (var gmj in marcel)
            {
                gmj.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SwitchDown");
            }
        }

        public static IEnumerator RapidFire()
        {
            GameObject revolver = GameObject.Find("Revolver");
            VRCHandGrasper[] hand = UnityEngine.Object.FindObjectsOfType<VRCHandGrasper>();
            UdonBehaviour revolverUdon = revolver.GetComponent<UdonBehaviour>();
            GameObject luger0 = GameObject.Find("Luger (0)");
            UdonBehaviour luger0Udon = luger0.GetComponent<UdonBehaviour>();
            GameObject shotgun = GameObject.Find("Shotgun (0)");
            UdonBehaviour shotgunUdon = shotgun.GetComponent<UdonBehaviour>();
            GameObject camera = GameObject.Find("FlashCamera");
            UdonBehaviour cameraUdon = camera.GetComponent<UdonBehaviour>();
            GameObject frag = GameObject.Find("Frag (0)");
            UdonBehaviour fragUdon = camera.GetComponent<UdonBehaviour>();

            bool stopperRight = false;   //these are the triggers/bumpers on the controller
            bool stopperLeft = false;
            for (; ; )
            {
                bool itemInHand = hand[0].field_Internal_VRC_Pickup_0 != null;          //this is the right hand
                if (itemInHand)
                {
                    bool revInHand = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Revolver") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                    if (revInHand)          //it detects when the trigger is pressed, then sending the udon event that fires the gun
                    {
                        revolverUdon.SendCustomEvent("Fire");
                        stopperRight = true;
                    }
                    else
                    {
                        bool lugerInHand = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Luger (0)") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                        if (lugerInHand)
                        {
                            luger0Udon.SendCustomEvent("Fire");
                            stopperRight = true;
                        }
                        else
                        {
                            bool shotgunInHand = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Shotgun (0)") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                            if (shotgunInHand)
                            {
                                shotgunUdon.SendCustomEvent("Fire");
                                stopperRight = true;
                            }
                            else
                            {
                                bool camInHand = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("FlashCamera") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                                if (camInHand)
                                {
                                    cameraUdon.SendCustomNetworkEvent(0, "SyncPhoto");
                                    stopperRight = true;
                                }
                                else
                                {
                                    bool fraginhand = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Frag (0)") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                                    if (camInHand)
                                    {
                                        fragUdon.SendCustomNetworkEvent(0, "Explode");
                                        stopperRight = true;
                                    }
                                    else
                                    {

                                        bool flag = hand[0].field_Internal_VRCInput_1.field_Public_Single_0 != 1f;
                                        if (flag)
                                        {
                                            stopperRight = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                bool itemInHandL = hand[1].field_Internal_VRC_Pickup_0 != null;           //this is the left hand
                if (itemInHandL)
                {
                    bool revInHandL = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Revolver") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                    if (revInHandL)
                    {
                        revolverUdon.SendCustomEvent("Fire");
                        stopperLeft = true;
                    }
                    else
                    {
                        bool lugerInHandL = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Luger (0)") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                        if (lugerInHandL)
                        {
                            luger0Udon.SendCustomEvent("Fire");
                            stopperLeft = true;
                        }
                        else
                        {
                            bool shotgunInHandL = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Shotgun (0)") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                            if (shotgunInHandL)
                            {
                                shotgunUdon.SendCustomEvent("Fire");
                                stopperLeft = true;
                            }
                            else
                            {
                                bool camInHandL = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("FlashCamera") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                                if (camInHandL)
                                {
                                    cameraUdon.SendCustomNetworkEvent(0, "SyncPhoto");
                                    stopperLeft = true;
                                }
                                else
                                {
                                    bool fraginhandl = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Frag (0)") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                                    if (fraginhandl)
                                    {
                                        fragUdon.SendCustomNetworkEvent(0, "Explode");
                                        stopperRight = true;
                                    }
                                    else
                                    {

                                        bool flag = hand[0].field_Internal_VRCInput_1.field_Public_Single_0 != 1f;
                                        if (flag)
                                        {
                                            stopperRight = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                yield return null;
            }
        }

        public static IEnumerator SelfGoldenGun()
        {
            VRCPickup revolver = GameObject.Find("Revolver").GetComponent<VRCPickup>();
            for (; ; )
            {
                bool flag = revolver.currentPlayer != null;
                if (flag)
                {
                    VRCPlayerApi playerVrcPlayerApi = revolver.currentPlayer;
                    bool flag2 = playerVrcPlayerApi.displayName.Equals(APIUser.CurrentUser.displayName) && GameObject.Find("geo (patron)") == null;
                    if (flag2)
                    {
                        UdonBehaviour[] revolverEvent = GameObject.Find("Revolver").GetComponents<UdonBehaviour>();
                        revolverEvent[0].SendCustomNetworkEvent(0, "PatronSkin");
                        revolverEvent = null;
                    }
                    yield return null;
                    playerVrcPlayerApi = null;
                }
                yield return null;
            }
        }


    }
}
