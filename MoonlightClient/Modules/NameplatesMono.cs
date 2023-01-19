using Moonlight_Client.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using VRC;

namespace Moonlight_Client.Modules
{
	class NameplatesMono : MonoBehaviour
	{
		public NameplatesMono(IntPtr ptr) : base(ptr)
		{
		}

		private void Start()
		{
			stats = GameObject.Instantiate<Transform>(base.gameObject.transform.Find("Contents/Quick Stats"), base.gameObject.transform.Find("Contents"));
			stats.transform.localScale = new Vector3(1f, 1f, 2f);
			stats.parent = base.gameObject.transform.Find("Contents");
			stats.gameObject.SetActive(true);
			statsText = this.stats.Find("Trust Text").GetComponent<TextMeshProUGUI>();
			statsText.color = Color.white;
			stats.Find("Trust Icon").gameObject.SetActive(false);
			stats.Find("Performance Icon").gameObject.SetActive(false);
			stats.Find("Performance Text").gameObject.SetActive(false);
			stats.Find("Friend Anchor Stats").gameObject.SetActive(false);
			frames = player._playerNet.field_Private_Byte_0;
			ping = player._playerNet.field_Private_Byte_1;
			UserID = player.prop_APIUser_0.id;
		}

		private void Update()
		{
			if (frames == player._playerNet.field_Private_Byte_0 && ping == player._playerNet.field_Private_Byte_1)
			{
				noUpdateCount++;
			}
			else
			{
				noUpdateCount = 0;
			}
			if (IsQuickMenuOpen)
			{
				stats.localPosition = new Vector3(0f, 62f, 0f);
			}
			else
			{
				stats.localPosition = new Vector3(0f, 42f, 0f);
			}
			frames = player._playerNet.field_Private_Byte_0;
			ping = player._playerNet.field_Private_Byte_1;
			string text = "<color=green>Alive</color>";
			string text2 = this.CustomRank(this.UserID);
			if (noUpdateCount > 200)
			{
				text = "<color=yellow>Lagging</color>";
			}
			if (noUpdateCount > 500)
			{
				text = "<color=red>Clapped</color>";
			}
			statsText.text = string.Concat(new string[]
			{
				text2,
				" [",
				player.GetPlatform(),
				"] |",
				player.GetIsMaster() ? " | [<color=#00F7FB>HOST</color>] |" : "",
				" [",
				text,
				"] | [FPS: ",
				player.GetFramesColord(),
				"] | [Ping: ",
				player.GetPingColord(),
				"]  ",
				player.ClientDetect() ? "| [<color=red>ClientUser</color>]" : ""
			});
		}

		private string CustomRank(string id)
		{
			string result;
			if (id == "usr_c82981d9-24d4-40b3-91f1-ce445302a07a")
			{
				result = "[<color=#8F9CE6>SHYClient Dev</color>] |";
			}
			else
			{
				result = "";
			}
			return result;
		}

		public Player player;

		private byte frames;

		private byte ping;

		private int noUpdateCount;

		private TextMeshProUGUI statsText;

		//private ImageThreeSlice background;

		private string UserID = "";

		private Transform stats;

		public bool IsQuickMenuOpen = false;

}
	
}
