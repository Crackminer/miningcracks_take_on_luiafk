using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkWorld : ModSystem
	{
		private static int harvestChest = 0;

		internal static bool checkForBoss = false;

		internal static bool lightSwitch = true;

		internal static bool invasionsDisabled = false;

		internal static bool dd2Modified = false;

		internal static int dd2Time = 1800;

		internal static bool loaded = false;

		private static Dictionary<string, Vector2> telePoints;

		internal static bool AnyBoss { get; private set; } = false;


		public override void OnWorldLoad()
		{
			harvestChest = 0;
			invasionsDisabled = false;
			lightSwitch = true;
			dd2Modified = false;
			telePoints = new Dictionary<string, Vector2>();
		}

		public override void PreUpdateWorld()
		{
			UpdateTravellingMerchant();
			UpdateAnyBoss();
			UpdateEvents();
			UpdateHarvestingChests();
			if (!loaded)
			{
				Harvesting.SearchHarvestersOnLoad();
				loaded = true;
			}
		}

        public override void OnWorldUnload()
        {
			loaded = false;
        }

        public override void SaveWorldData(TagCompound tag)
		{
			TagCompound tagCompound = new TagCompound
			{
				{ "lightSwitch", lightSwitch },
				{ "invasionsDisabled", invasionsDisabled },
				{ "dd2Modified", dd2Modified },
				{ "dd2Time", dd2Time }
			};
			SaveTelePoints(tagCompound);
			tag = tagCompound;
		}

		public override void LoadWorldData(TagCompound tag)
		{
			lightSwitch = tag.Get<bool>("lightSwitch");
			invasionsDisabled = tag.Get<bool>("invasionsDisabled");
			dd2Modified = tag.Get<bool>("dd2Modified");
			dd2Time = tag.Get<int>("dd2Time");
			LoadTelePoints(tag);
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte bitsByte = default(BitsByte);
			bitsByte[0] = lightSwitch;
			writer.Write(bitsByte[0]);
		}

		public override void NetReceive(BinaryReader reader)
		{
			lightSwitch = BitsByte.DecomposeBitsBytesChain(reader).First()[0];
		}

		private void UpdateTravellingMerchant()
		{
			if (Main.time == 0.0 && Main.dayTime)
			{
				Chest.SetupTravelShop();
				if (Main.netMode == 2)
				{
					NetMessage.SendTravelShop(-1);
				}
			}
		}

		private void UpdateAnyBoss()
		{
			AnyBoss = false;
			if (checkForBoss)
			{
				AnyBoss = MiscMethods.AnyBoss(despawn: false);
				checkForBoss = false;
			}
		}

		private void UpdateEvents()
		{
			if (DD2Event.Ongoing && dd2Modified && DD2Event.TimeLeftBetweenWaves > dd2Time)
			{
				DD2Event.TimeLeftBetweenWaves = dd2Time;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(116, -1, -1, null, DD2Event.TimeLeftBetweenWaves);
				}
			}
			if (invasionsDisabled)
			{
				Main.invasionType = 0;
			}
		}

		private void UpdateHarvestingChests()
		{
			if (harvestChest == 0)
			{
				Harvesting.Init();
			}
			if (harvestChest > 3600)
			{
				Harvesting.UpdateChests();
				harvestChest = 0;
			}
			harvestChest++;
		}

		private void SaveTelePoints(TagCompound tag)
		{
			if (telePoints != null)
            {
				tag.Add("location", telePoints.Keys.ToList());
				tag.Add("coords", telePoints.Values.ToList());
			}
		}

		private void LoadTelePoints(TagCompound tag)
		{
						if (tag.ContainsKey("location"))
			{
				List<string> list = tag.Get<List<string>>("location");
				List<Vector2> list2 = tag.Get<List<Vector2>>("coords");
				for (int i = 0; i < list.Count; i++)
				{
					telePoints.Add(list[i], list2[i]);
				}
			}
		}

		internal static Vector2 GetSingleCoord(string locationName)
		{
			if (!telePoints.TryGetValue(locationName.ToLower(), out var value))
			{
				return default(Vector2);
			}
			return value;
		}

		internal static void AddTelePoint(string locationName, int player)
		{
			locationName = locationName.ToLower();
			if (telePoints.ContainsKey(locationName))
			{
				MiscMethods.WriteText("A location is already saved under the name [C/48C600:" + locationName + "], please choose another name!");
				return;
			}
			telePoints.Add(locationName, Main.player[player].position);
			MiscMethods.WriteText("[C/48C600:" + locationName + "] added to saved locations!");
			if (Main.netMode == 2)
			{
				SendClientTelePoints();
			}
		}

		internal static void RemoveTelePoint(string locationName)
		{
			locationName = locationName.ToLower();
			if (!telePoints.ContainsKey(locationName))
			{
				MiscMethods.WriteText("No locations called [C/48C600:" + locationName + "] are saved!");
				return;
			}
			telePoints.Remove(locationName);
			MiscMethods.WriteText("[C/48C600:" + locationName + "] removed from saved locations!");
			if (Main.netMode == 2)
			{
				SendClientTelePoints();
			}
		}

		private static void SendClientTelePoints(int toClient = -1)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(27);
			((BinaryWriter)packet).Write(telePoints.Count);
			foreach (KeyValuePair<string, Vector2> telePoint in telePoints)
			{
				((BinaryWriter)packet).Write(telePoint.Key);
				((BinaryWriter)packet).Write(telePoint.Value.X);
				((BinaryWriter)packet).Write(telePoint.Value.Y);
			}
			packet.Send(toClient);
		}

		internal static void RequestTelePoints()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(27);
			packet.Send();
		}

		internal static void UpdateTelePoints(BinaryReader reader, int toClient)
		{
			if (Main.netMode == 2)
			{
				SendClientTelePoints(toClient);
				return;
			}
			telePoints.Clear();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				telePoints.Add(reader.ReadString(), new Vector2(reader.ReadSingle(), reader.ReadSingle()));
			}
		}

		internal static string ListTelePoints()
		{
			if (telePoints.Count > 0)
			{
				string text = "The following locations have been saved:";
				int num = 0;
				{
					foreach (KeyValuePair<string, Vector2> telePoint in telePoints)
					{
						text += string.Format(" [C/48C600:{0}]{1}", telePoint.Key, (num++ == telePoints.Count - 1) ? "." : ",");
					}
					return text;
				}
			}
			return null;
		}

		internal static bool Teleport(string locationName)
		{
			if (telePoints.TryGetValue(locationName, out var value))
			{
				NetMessage.SendData(65, -1, -1, null, 0, Main.myPlayer, value.X, value.Y);
				Main.player[Main.myPlayer].Teleport(value);
				Main.NewText((object)("Teleporting to: [C/48C600:" + locationName + "]"), (Color?)new Color(255, 85, 0));
				return true;
			}
			return false;
		}
	}
}
