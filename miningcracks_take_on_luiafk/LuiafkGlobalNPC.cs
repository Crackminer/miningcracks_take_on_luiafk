using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
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
			LuiafkPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<LuiafkPlayer>();
			if ((modPlayer.buffs.Contains("Ultimate Battler") || modPlayer.buffs.Contains("Everything")) && (modPlayer.uiBuffs & PotToggles.UltBattler) != 0)
			{
				spawnRate = 1;
				maxSpawns = 500;
				return;
			}
			if ((modPlayer.buffs.Contains("UltimatePeaceful") || modPlayer.buffs.Contains("Everything")) && (modPlayer.uiBuffs & PotToggles.UltPeaceful) != 0)
			{
				spawnRate = (int)((float)spawnRate * 5f);
				maxSpawns = (int)((float)maxSpawns / 5f);
				return;
			}
			if (modPlayer.buffs.Contains("WaterCandle") || modPlayer.buffs.Contains("Battler") || modPlayer.buffs.Contains("UltimatePeaceful") || modPlayer.buffs.Contains("Everything"))
			{
				spawnRate = (int)((float)spawnRate * 0.75f);
				maxSpawns = (int)((float)maxSpawns * 1.5f);
			}
			if (modPlayer.buffs.Contains("Battle") || modPlayer.buffs.Contains("Battler") || modPlayer.buffs.Contains("UltimatePeaceful") || modPlayer.buffs.Contains("Everything"))
			{
				spawnRate = (int)((float)spawnRate * 0.5f);
				maxSpawns = (int)((float)maxSpawns * 2f);
			}
			if (modPlayer.buffs.Contains("PeaceCandle") || modPlayer.buffs.Contains("Peaceful") || modPlayer.buffs.Contains("UltimatePeaceful") || modPlayer.buffs.Contains("Everything"))
			{
				spawnRate = (int)((float)spawnRate * 1.3f);
				maxSpawns = (int)((float)maxSpawns * 0.7f);
			}
			if (modPlayer.buffs.Contains("Calming") || modPlayer.buffs.Contains("Peaceful") || modPlayer.buffs.Contains("UltimatePeaceful") || modPlayer.buffs.Contains("Everything"))
			{
				spawnRate = (int)((float)spawnRate * 1.3f);
				maxSpawns = (int)((float)maxSpawns * 0.7f);
			}
		}
	}
}
