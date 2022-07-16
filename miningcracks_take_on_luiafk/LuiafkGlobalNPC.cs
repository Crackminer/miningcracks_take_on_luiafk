using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkGlobalNPC : GlobalNPC
	{
		public override void OnKill(NPC npc)
		{
			switch (npc.type)
			{
			case 113:
				if (Main.rand.NextBool(5))
				{
					Item.NewItem(new EntitySource_Loot(npc), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("LootMagnet").Type);
				}
				break;
			case 370:
				Item.NewItem(new EntitySource_Loot(npc), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("ManaEssence").Type);
				break;
			case 398:
				Item.NewItem(new EntitySource_Loot(npc), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicEssence").Type);
				break;
			case 4:
				if (Main.rand.NextBool(10))
				{
					Item.NewItem(new EntitySource_Loot(npc), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("UnlimitedMerchantKiller").Type);
				}
				break;
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			switch (type)
			{
			case 178:
				if (Main.bloodMoon || Main.eclipse)
				{
					if (WorldGen.crimson)
					{
						shop.item[nextSlot].SetDefaults(782);
						nextSlot++;
					}
					else
					{
						shop.item[nextSlot].SetDefaults(784);
						nextSlot++;
					}
				}
				if (!WorldGen.crimson)
				{
					shop.item[nextSlot].SetDefaults(2193);
					nextSlot++;
				}
				if (Main.player[Main.myPlayer].ZoneJungle)
				{
					shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("DarkGreenSolution").Type);
					nextSlot++;
				}
				return;
			case 20:
				if (Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						shop.item[nextSlot].SetDefaults(59);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(67);
						nextSlot++;
					}
					else
					{
						shop.item[nextSlot].SetDefaults(2171);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2886);
						nextSlot++;
					}
					return;
				}
				break;
			}
			if (type == 19 && NPC.AnyNPCs(108))
			{
				shop.item[nextSlot].SetDefaults(2177);
				nextSlot++;
				return;
			}
			switch (type)
			{
			case 368:
				shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("MoneyCollector").Type);
				nextSlot++;
				break;
			case 17:
				if (NPC.downedSlimeKing)
				{
					shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("DeepsSummon").Type);
					nextSlot++;
				}
				if (NPC.downedQueenBee)
				{
					shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("MobileMerchant").Type);
					nextSlot++;
				}
				break;
			}
		}

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (Main.dedServ || Main.netMode == 2)
            {
				//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Got called in general"), Color.White);
				if ((modPlayer.buffs[2] || modPlayer.buffs[1]) && (modPlayer.uiBuffs & PotToggles.UltBattler) != 0)
				{
					//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("I got here! battler"), Color.White);
					spawnRate = 1;
					maxSpawns = 500;
					return;
				}
				if ((modPlayer.buffs[3] || modPlayer.buffs[1]) && (modPlayer.uiBuffs & PotToggles.UltPeaceful) != 0)
				{
					//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("I got here! peaceful"), Color.White);
					spawnRate = (int)((float)spawnRate * 5f);
					maxSpawns = (int)((float)maxSpawns / 5f);
					return;
				}
				if (modPlayer.buffs[48] || modPlayer.buffs[59])
				{
					//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("I got here! water"), Color.White);
					spawnRate = (int)((float)spawnRate * 0.75f);
					maxSpawns = (int)((float)maxSpawns * 1.5f);
				}
				if (modPlayer.buffs[17] || modPlayer.buffs[59])
				{
					//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("I got here! battle"), Color.White);
					spawnRate = (int)((float)spawnRate * 0.5f);
					maxSpawns = (int)((float)maxSpawns * 2f);
				}
				if (modPlayer.buffs[47] || modPlayer.buffs[70])
				{
					//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("I got here! peace"), Color.White);
					spawnRate = (int)((float)spawnRate * 1.3f);
					maxSpawns = (int)((float)maxSpawns * 0.7f);
				}
				if (modPlayer.buffs[9] || modPlayer.buffs[70])
				{
					//ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("I got here! calm"), Color.White);
					spawnRate = (int)((float)spawnRate * 1.3f);
					maxSpawns = (int)((float)maxSpawns * 0.7f);
				}
				return;
			}
			//Main.NewText("Got called in general");
			if ((modPlayer.buffs[2] || modPlayer.buffs[1]) && (modPlayer.uiBuffs & PotToggles.UltBattler) != 0)
			{
				//Main.NewText("I got here! battler");
				spawnRate = 1;
				maxSpawns = 500;
				return;
			}
			if ((modPlayer.buffs[3] || modPlayer.buffs[1]) && (modPlayer.uiBuffs & PotToggles.UltPeaceful) != 0)
			{
				//Main.NewText("I got here! peaceful");
				spawnRate = (int)((float)spawnRate * 5f);
				maxSpawns = (int)((float)maxSpawns / 5f);
				return;
			}
			if (modPlayer.buffs[48] || modPlayer.buffs[59])
			{
				//Main.NewText("I got here! water");
				spawnRate = (int)((float)spawnRate * 0.75f);
				maxSpawns = (int)((float)maxSpawns * 1.5f);
			}
			if (modPlayer.buffs[17] || modPlayer.buffs[59])
			{
				//Main.NewText("I got here! battle");
				spawnRate = (int)((float)spawnRate * 0.5f);
				maxSpawns = (int)((float)maxSpawns * 2f);
			}
			if (modPlayer.buffs[47] || modPlayer.buffs[70])
			{
				//Main.NewText("I got here! peace");
				spawnRate = (int)((float)spawnRate * 1.3f);
				maxSpawns = (int)((float)maxSpawns * 0.7f);
			}
			if (modPlayer.buffs[9] || modPlayer.buffs[70])
			{
				//Main.NewText("I got here! calm");
				spawnRate = (int)((float)spawnRate * 1.3f);
				maxSpawns = (int)((float)maxSpawns * 0.7f);
			}
		}
	}
}
