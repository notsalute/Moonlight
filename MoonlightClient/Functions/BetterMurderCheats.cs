using Moonlight_Client.Nocturnal.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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


	}
}
