using System;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Fishing
{
	internal static class CatchFish
	{
		private static Player chestPlayer;

		private static Player p;

		private static Projectile proj;

		private static int chest;

		private static bool harvest;

		private static int drop;

		private static bool junk;

		private static bool tierSix;

		private static bool tierFive;

		private static bool tierFour;

		private static bool tierThree;

		private static bool tierTwo;

		private static bool lava;

		private static bool honey;

		private static int todaysQuest;

		private static int poolSize;

		private static int bigPool;

		private static int amount;

		private static int height;

		private static int posX;

		private static int posY;

		private static int rodType;

		private static int rodSlot;

		private static int baitPower;

		private static int baitSlot;

		private static int tackleBox;

		private static int crateChance;

		private static float skill;

		private static int bobLocationX;

		private static int bobLocationY;

		internal static void Init()
		{
			chestPlayer = new Player();
		}

		internal static void Unload()
		{
			chestPlayer = null;
		}

		internal static void FishStuff(ref bool full, int currentChest = -1, Projectile projectile = null)
		{
			chest = currentChest;
			proj = projectile;
			harvest = ((chest != -1) ? true : false);
			p = (harvest ? chestPlayer : Main.player[projectile.owner]);
			if (!harvest)
			{
				bobLocationX = (int)(projectile.Center.X / 16f);
				bobLocationY = (int)(projectile.Center.Y / 16f);
			}
			else
			{
				posX = Main.chest[chest].x;
				posY = Main.chest[chest].y;
				p.position = new Vector2((float)(posX << 4), (float)(posY << 4));
				if (!FindWater())
				{
					return;
				}
			}
			GetHeight();
			if (harvest)
			{
				GetBiomes();
			}
			int num = ((!harvest) ? 1 : 3);
			for (int i = 0; i < num; i++)
			{
				if (!PoolSizeAndFinalSkill())
				{
					break;
				}
				if ((float)Main.rand.Next(100) <= (skill + 75f) / 2f)
				{
					GetTiers();
					GetQuest();
					GetDrop(ref full);
				}
			}
		}

		private static bool FindWater()
		{
			for (int i = posX - 5; i < posX + 7; i++)
			{
				for (int j = posY; j < posY + 12; j++)
				{
					if (TileChecks.InGameWorld(i, j))
					{
						TileChecks.TileSafe(i, j);
						if (Main.tile[i, j].LiquidAmount > 0)
						{
							bobLocationX = i;
							bobLocationY = j;
							return true;
						}
					}
				}
			}
			return false;
		}

		private static void GetQuest()
		{
			todaysQuest = Main.anglerQuestItemNetIDs[Main.anglerQuest];
			if (!harvest)
			{
				if (p.HasItem(todaysQuest) || Main.anglerQuestFinished)
				{
					todaysQuest = -1;
				}
			}
			else if (Main.netMode == 0 && (Main.anglerQuestFinished || Main.chest[chest].item.HasAtleastOne(todaysQuest)))
			{
				todaysQuest = -1;
			}
			else
			{
				if (Main.netMode != 2)
				{
					return;
				}
				int num = 0;
				Player[] player = Main.player;
				foreach (Player player2 in player)
				{
					if (player2.active && !Main.anglerWhoFinishedToday.Contains(player2.name))
					{
						num++;
					}
				}
				if (Main.chest[chest].item.HasAtleastAmount(num, todaysQuest))
				{
					todaysQuest = -1;
				}
			}
		}

		private static void GetBiomes()
		{
			int num = Math.Max(40, posX - 30);
			int num2 = Math.Min(Main.maxTilesX - 40, posX + 32);
			int num3 = Math.Max(40, posY - 30);
			int num4 = Math.Min(Main.maxTilesY - 40, posY + 32);
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 0;
			int num13 = 0;
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					Tile tileSafely = Framing.GetTileSafely(i, j);
					if (tileSafely.HasTile && tileSafely.TileType != 0 && tileSafely.TileType != 1 && tileSafely.TileType != 59 && tileSafely.TileType < 470)
					{
						if (tileSafely.TileType == 53 || tileSafely.TileType == 112 || tileSafely.TileType == 116 || tileSafely.TileType == 234 || (tileSafely.TileType >= 396 && tileSafely.TileType <= 403))
						{
							num13++;
						}
						if (tileSafely.TileType >= 70 && tileSafely.TileType <= 72)
						{
							num5++;
						}
						else if (tileSafely.TileType == 41 || tileSafely.TileType == 43 || tileSafely.TileType == 44)
						{
							num9++;
						}
						else if ((tileSafely.TileType >= 60 && tileSafely.TileType <= 62) || tileSafely.TileType == 74 || tileSafely.TileType == 226)
						{
							num10++;
						}
						else if (tileSafely.TileType == 109 || tileSafely.TileType == 110 || tileSafely.TileType == 113 || tileSafely.TileType == 117 || tileSafely.TileType == 116 || tileSafely.TileType == 402 || tileSafely.TileType == 403)
						{
							num8++;
						}
						else if ((tileSafely.TileType >= 23 && tileSafely.TileType <= 25) || tileSafely.TileType == 32 || tileSafely.TileType == 112 || tileSafely.TileType == 398 || tileSafely.TileType == 400)
						{
							num6++;
						}
						else if (tileSafely.TileType == 199 || tileSafely.TileType == 203 || tileSafely.TileType == 401 || tileSafely.TileType == 399 || tileSafely.TileType == 234 || tileSafely.TileType == 352)
						{
							num7++;
						}
						else if (tileSafely.TileType == 147 || tileSafely.TileType == 148 || tileSafely.TileType == 161 || tileSafely.TileType == 162)
						{
							num11++;
						}
						else if (tileSafely.TileType == 164)
						{
							num11++;
							num8++;
						}
						else if (tileSafely.TileType == 163)
						{
							num11++;
							num6++;
						}
						else if (tileSafely.TileType == 200)
						{
							num11++;
							num7++;
						}
						else if (tileSafely.TileType == 37)
						{
							num12++;
						}
					}
				}
			}
			p.ZoneDesert = num13 > 1000;
			p.ZoneMeteor = num12 > 49;
			p.ZoneGlowshroom = num5 > 199;
			p.ZoneCorrupt = num6 > 199;
			p.ZoneCrimson = num7 > 199;
			p.ZoneHallow = num8 > 99;
			p.ZoneDungeon = num9 > 249 && (double)posY > Main.worldSurface * 16.0 && Main.wallDungeon[Main.tile[posX, posY].WallType];
			p.ZoneJungle = num10 > 79;
			p.ZoneSnow = num11 > 299;
			p.ZoneUnderworldHeight = posY > Main.maxTilesY - 200;
			p.ZoneRockLayerHeight = posY <= Main.maxTilesY - 200 && (double)posY > Main.rockLayer;
			p.ZoneDirtLayerHeight = (double)posY <= Main.rockLayer && (double)posY > Main.worldSurface;
			p.ZoneOverworldHeight = (double)posY <= Main.worldSurface && (double)posY > Main.worldSurface * 0.3499999940395355;
			p.ZoneSkyHeight = (double)posY <= Main.worldSurface * 0.3499999940395355;
			p.ZoneBeach = p.ZoneOverworldHeight && (posX < 380 || posX > Main.maxTilesX - 380);
			p.ZoneRain = Main.raining && (double)posY <= Main.worldSurface;
			p.ZoneSandstorm = (double)posY <= Main.worldSurface && p.ZoneDesert && !p.ZoneBeach && Sandstorm.Happening;
			p.ZoneUndergroundDesert = WallID.Sets.Conversion.Sandstone[Main.tile[posX, posY].WallType] || WallID.Sets.Conversion.HardenedSand[Main.tile[posX, posY].WallType];
		}

		private static bool PoolSizeAndFinalSkill()
		{
			lava = false;
			honey = false;
			int num = bobLocationX;
			int i = bobLocationX;
			while (num > 10 && !WorldGen.SolidTile(num, bobLocationY) && Main.tile[num, bobLocationY].LiquidAmount > 0)
			{
				num--;
			}
			for (; i < Main.maxTilesX - 10 && !WorldGen.SolidTile(i, bobLocationY) && Main.tile[i, bobLocationY].LiquidAmount > 0; i++)
			{
			}
			poolSize = 0;
			for (int j = num; j <= i; j++)
			{
				int num2 = bobLocationY;
				while (num2 < Main.maxTilesY - 10 && !WorldGen.SolidTile(j, num2) && Main.tile[j, num2].LiquidAmount > 0)
				{
					poolSize++;
					num2++;
					if (Main.tile[j, num2].LiquidType == 1)
					{
						lava = true;
					}
					else if (Main.tile[j, num2].LiquidType == 2)
					{
						honey = true;
					}
				}
			}
			if (honey)
			{
				poolSize = (int)((double)poolSize * 1.5);
			}
			if (poolSize < 75)
			{
				if (!harvest)
				{
					p.displayedFishingInfo = Language.GetTextValue("GameUI.NotEnoughWater");
				}
				return false;
			}
			if (harvest)
			{
				GetChestSkill();
			}
			else
			{
				skill = GetProjSkill();
			}
			if (skill == 0f)
			{
				return false;
			}
			if (!harvest)
			{
				p.displayedFishingInfo = Language.GetTextValue("GameUI.FishingPower", skill);
				if (skill < 0f)
				{
					if (skill == -1f)
					{
						p.displayedFishingInfo = Language.GetTextValue("GameUI.FishingWarning");
						if ((bobLocationX < 380 || bobLocationX > Main.maxTilesX - 380) && poolSize > 1000 && !NPC.AnyNPCs(370))
						{
							proj.ai[1] = Main.rand.Next(-180, -60) - 100;
							proj.localAI[1] = skill;
							proj.netUpdate = true;
						}
					}
					return false;
				}
			}
			bigPool = 300;
			float num3 = Main.maxTilesX / 4200;
			num3 *= num3;
			float num4 = (float)((double)((float)bobLocationY - (60f + 10f * num3)) / (Main.worldSurface / 6.0));
			if ((double)num4 < 0.25)
			{
				num4 = 0.25f;
			}
			if (num4 > 1f)
			{
				num4 = 1f;
			}
			bigPool = (int)((float)bigPool * num4);
			float num5 = (float)poolSize / (float)bigPool;
			if (num5 < 1f)
			{
				skill = (int)(skill * num5);
			}
			if (!harvest)
			{
				num5 = 1f - num5;
				if (poolSize < bigPool)
				{
					p.displayedFishingInfo = Language.GetTextValue("GameUI.FullFishingPower", skill, 0.0 - Math.Round(num5 * 100f));
				}
			}
			return true;
		}

		private static void GetSkill()
		{
			if (Main.raining)
			{
				skill = (int)(skill * 1.2f);
			}
			if (Main.cloudBGAlpha > 0f)
			{
				skill = (int)(skill * 1.1f);
			}
			if (Main.dayTime && (Main.time < 5400.0 || Main.time > 48600.0))
			{
				skill = (int)(skill * 1.3f);
			}
			else if (Main.dayTime && Main.time > 16200.0 && Main.time < 37800.0)
			{
				skill = (int)(skill * 0.8f);
			}
			else if (!Main.dayTime && Main.time > 6480.0 && Main.time < 25920.0)
			{
				skill = (int)(skill * 0.8f);
			}
			if (Main.moonPhase == 0)
			{
				skill = (int)(skill * 1.1f);
			}
			else if (Main.moonPhase == 1 || Main.moonPhase == 7)
			{
				skill = (int)(skill * 1.05f);
			}
			else if (Main.moonPhase == 3 || Main.moonPhase == 5)
			{
				skill = (int)(skill * 0.95f);
			}
			else if (Main.moonPhase == 4)
			{
				skill = (int)(skill * 0.9f);
			}
		}

		internal static float GetProjSkill(bool myPlayer = false)
		{
			skill = 0f;
			Player player = (myPlayer ? Main.player[Main.myPlayer] : p);
			rodType = player.inventory[player.selectedItem].type;
			int selectedItem = player.selectedItem;
			for (int i = 0; i < 58; i++)
			{
				if (player.inventory[i].type == 2673)
				{
					return -1f;
				}
			}
			skill = player.fishingSkill;
			GetSkill();
			crateChance = (player.cratePotion ? 20 : 10);
			PlayerLoader.GetFishingLevel(player, player.inventory[selectedItem], player.inventory[selectedItem], ref skill);
			return skill;
		}

		private static void GetChestSkill()
		{
			skill = 0f;
			rodSlot = -1;
			rodType = 0;
			baitSlot = -1;
			baitPower = 0;
			for (int i = 0; i < 40; i++)
			{
				if (Main.chest[chest].item[i].ModItem is FishingRod)
				{
					skill = ((FishingRod)Main.chest[chest].item[i].ModItem).Skill;
					rodSlot = i;
					rodType = Main.chest[chest].item[i].type;
					break;
				}
			}
			if (rodSlot < 0)
			{
				for (int j = 0; j < 40; j++)
				{
					if (Main.chest[chest].item[j].fishingPole > 0)
					{
						skill = Main.chest[chest].item[j].fishingPole;
						rodSlot = j;
						rodType = Main.chest[chest].item[j].type;
						break;
					}
				}
				if (rodSlot >= 0)
				{
					for (int k = 0; k < 40; k++)
					{
						if (Main.chest[chest].item[k].bait > 0)
						{
							baitPower = Main.chest[chest].item[k].bait;
							baitSlot = k;
							break;
						}
					}
				}
				if (rodSlot < 0 || baitSlot < 0)
				{
					skill = 0f;
					return;
				}
			}
			skill += baitPower;
			SkillFromItems();
			GetSkill();
			p.fishingSkill = (int)skill;
			PlayerLoader.GetFishingLevel(p, Main.chest[chest].item[rodSlot], (baitPower > 0) ? Main.chest[chest].item[baitSlot] : Main.chest[chest].item[rodSlot], ref skill);
		}

		private static void SkillFromItems()
		{
			tackleBox = 0;
			crateChance = 10;
			if (Main.chest[chest].item.HasAtleastOne(2367))
			{
				skill += 5f;
			}
			if (Main.chest[chest].item.HasAtleastOne(2368))
			{
				skill += 5f;
			}
			if (Main.chest[chest].item.HasAtleastOne(2369))
			{
				skill += 5f;
			}
			if (Main.chest[chest].item.HasAtleastOne(LuiafkMod.Instance.Find<ModItem>("UnlimitedFishing").Type, LuiafkMod.Instance.Find<ModItem>("UnlimitedEverything").Type))
			{
				crateChance = 20;
				skill += 15f;
			}
			else
			{
				if (Main.chest[chest].item.HasAtleastOne(LuiafkMod.Instance.Find<ModItem>("UnlimitedCrates").Type))
				{
					crateChance = 20;
				}
				if (Main.chest[chest].item.HasAtleastOne(LuiafkMod.Instance.Find<ModItem>("UnlimitedFishingPotion").Type))
				{
					skill += 15f;
				}
			}
			if (Main.chest[chest].item.HasAtleastOne(2374))
			{
				skill += 10f;
			}
			if (Main.chest[chest].item.HasAtleastOne(2375))
			{
				tackleBox++;
			}
			if (Main.chest[chest].item.HasAtleastOne(3721))
			{
				skill += 10f;
				tackleBox++;
			}
			p.cratePotion = crateChance == 20;
		}

		private static void GetHeight()
		{
			if ((double)bobLocationY < Main.worldSurface * 0.5)
			{
				height = 0;
			}
			else if ((double)bobLocationY < Main.worldSurface)
			{
				height = 1;
			}
			else if ((double)bobLocationY < Main.rockLayer)
			{
				height = 2;
			}
			else if (bobLocationY < Main.maxTilesY - 300)
			{
				height = 3;
			}
			else
			{
				height = 4;
			}
		}

		private static void GetTiers()
		{
			tierTwo = Main.rand.NextBool((int)Math.Max(150f / skill, 2f));
			tierThree = Main.rand.NextBool((int)Math.Max(300f / skill, 3f));
			tierFour = Main.rand.NextBool((int)Math.Max(1050f / skill, 4f));
			tierFive = Main.rand.NextBool((int)Math.Max(2250f / skill, 5f));
			tierSix = Main.rand.NextBool((int)Math.Max(4500f / skill, 6f));
		}

		private static void GetDrop(ref bool full)
		{
			junk = false;
			drop = 0;
			amount = 1;
			if (lava)
			{
				Lava();
			}
			else if (honey)
			{
				Honey();
			}
			else if ((float)Main.rand.Next(50) > skill && (float)Main.rand.Next(50) > skill && poolSize < bigPool)
			{
				NoSkill();
			}
			else if (Main.rand.Next(100) < crateChance)
			{
				Crates();
			}
			else if (!Specials())
			{
				bool flag = p.ZoneCorrupt;
				if (p.ZoneCorrupt && p.ZoneCrimson)
				{
					flag = Main.rand.NextBool(2);
				}
				if (flag)
				{
					Corruption();
				}
				else if (p.ZoneCrimson)
				{
					Crimson();
				}
				else if (p.ZoneHallow)
				{
					Hallow();
				}
				if (drop == 0 && p.ZoneSnow)
				{
					Snow();
				}
				if (drop == 0 && p.ZoneJungle)
				{
					Jungle();
				}
				if (drop == 0 && p.ZoneGlowshroom && tierThree && todaysQuest == 2475)
				{
					MushroomQuest();
				}
				if (drop == 0 && height <= 1 && (bobLocationX < 380 || bobLocationX > Main.maxTilesX - 380) && poolSize > 1000)
				{
					Ocean();
				}
				if (drop == 0)
				{
					MiscStuff();
				}
			}
			if (drop == 0)
			{
				return;
			}
			AdvancedPopupRequest sonar = default(AdvancedPopupRequest);
			Vector2 sonarPosition = default(Vector2);
			FishingAttempt fishingAttempt = default(FishingAttempt);
			fishingAttempt.playerFishingConditions = new PlayerFishingConditions
			{
				LevelMultipliers = skill,
				FinalFishingLevel = (int)Math.Pow(baitPower, 2.0) / 20
			};
			fishingAttempt.CanFishInLava = true;
			fishingAttempt.waterTilesCount = poolSize;
			fishingAttempt.questFish = todaysQuest;
			fishingAttempt.heightLevel = height;
			fishingAttempt.atmo = 0f;
			fishingAttempt.bobberType = 8;
			fishingAttempt.chumsInWater = 5;
			fishingAttempt.common = true;
			fishingAttempt.crate = true;
			fishingAttempt.fishingLevel = 0;
			fishingAttempt.inHoney = true;
			fishingAttempt.inLava = true;
			fishingAttempt.legendary = true;
			fishingAttempt.rare = true;
			fishingAttempt.rolledEnemySpawn = 0;
			fishingAttempt.rolledItemDrop = 0;
			fishingAttempt.uncommon = true;
			fishingAttempt.veryrare = true;
			fishingAttempt.waterNeededToFish = 0;
			fishingAttempt.waterQuality = 0f;
			fishingAttempt.X = 0;
			fishingAttempt.Y = 0;
			FishingAttempt attempt = fishingAttempt;
			int enemySpawn = 0;
			if (harvest)
			{
				PlayerLoader.CatchFish(p, attempt, ref drop, ref enemySpawn, ref sonar, ref sonarPosition);
				if (drop == 3196 || drop == 3197)
				{
					BombOrDaggerFish();
				}
				if (Harvesting.PutInChest(chest, drop, amount) > 0)
				{
					full = true;
				}
				else if (baitSlot != -1 && baitPower > 0)
				{
					int num = baitPower / 5;
					if (Main.rand.NextBool(num + tackleBox))
					{
						Main.chest[chest].item[baitSlot].stack--;
					}
					if (Main.chest[chest].item[baitSlot].stack <= 0)
					{
						Main.chest[chest].item[baitSlot] = new Item();
					}
				}
				return;
			}
			PlayerLoader.CatchFish(p, attempt, ref drop, ref enemySpawn, ref sonar, ref sonarPosition);
			if (drop > 0)
			{
				if (p.sonarPotion)
				{
					Item item = new Item();
					item.SetDefaults(drop);
					item.position = proj.position;
					PopupText.NewText(PopupTextContext.SonarAlert, item, 1, noStack: true);
				}
				proj.ai[1] = (float)Main.rand.Next(-240, -90) - skill;
				proj.localAI[1] = drop;
				proj.netUpdate = true;
			}
		}

		private static void BombOrDaggerFish()
		{
			int minValue;
			int num;
			int num2;
			if (drop == 3196)
			{
				minValue = (int)(skill / 20f + 3f) / 2;
				num = (int)(skill / 10f + 6f) / 2;
				num2 = 1;
			}
			else
			{
				minValue = (int)(skill / 4f + 15f) / 2;
				num = (int)(skill / 2f + 30f) / 2;
				num2 = 4;
			}
			if ((float)Main.rand.Next(50) < skill)
			{
				num += num2;
			}
			if ((float)Main.rand.Next(100) < skill)
			{
				num += num2;
			}
			if ((float)Main.rand.Next(150) < skill)
			{
				num += num2;
			}
			if ((float)Main.rand.Next(200) < skill)
			{
				num += num2;
			}
			amount = Main.rand.Next(minValue, num + 1);
		}

		private static void Lava()
		{
			if (ItemID.Sets.CanFishInLava[rodType])
			{
				if (tierSix)
				{
					drop = 2331;
				}
				else if (tierFive)
				{
					drop = 2312;
				}
				else if (tierFour)
				{
					drop = 2315;
				}
			}
		}

		private static void Honey()
		{
			if (tierFour || (tierThree && Main.rand.NextBool(2)))
			{
				drop = 2314;
			}
			else if (tierThree && todaysQuest == 2451)
			{
				drop = 2451;
			}
		}

		private static void NoSkill()
		{
			drop = Main.rand.Next(2337, 2340);
			junk = true;
		}

		private static void Crates()
		{
			if (!Main.hardMode)
            {
				if (tierFive || tierSix)
				{
					drop = 2336;
				}
				else if (tierFour && p.ZoneCorrupt && (!p.ZoneCrimson || Main.rand.NextBool(2)))
				{
					drop = 3203;
				}
				else if (tierFour && p.ZoneCrimson)
				{
					drop = 3204;
				}
				else if (tierFour && p.ZoneHallow)
				{
					drop = 3207;
				}
				else if (tierFour && p.ZoneDungeon)
				{
					drop = 3205;
				}
				else if (tierFour && p.ZoneJungle)
				{
					drop = 3208;
				}
				else if (tierFour && height == 0)
				{
					drop = 3206;
				}
				else if (tierThree)
				{
					drop = 2335;
				}
				else if (tierFour && p.ZoneDesert)
                {
					drop = 4407;
                }
				else if (tierFour && p.ZoneBeach)
				{
					drop = 5002;
				}
				else if (tierFour && p.ZoneSnow)
				{
					drop = 4405;
				}
				else if (tierFour && p.ZoneUnderworldHeight)
				{
					drop = 4877;
				}
				else
				{
					drop = 2334;
				}
			}
			else
            {
				if (tierFive || tierSix)
				{
					drop = 3981;
				}
				else if (tierFour && p.ZoneCorrupt)
				{
					drop = 3982;
				}
				else if (tierFour && p.ZoneCrimson)
				{
					drop = 3983;
				}
				else if (tierFour && p.ZoneHallow)
				{
					drop = 3986;
				}
				else if (tierFour && p.ZoneDungeon)
				{
					drop = 3984;
				}
				else if (tierFour && p.ZoneJungle)
				{
					drop = 3987;
				}
				else if (tierFour && p.ZoneSkyHeight)
				{
					drop = 3985;
				}
				else if (tierThree)
				{
					drop = 3980;
				}
				else if (tierFour && p.ZoneDesert)
				{
					drop = 4408;
				}
				else if (tierFour && p.ZoneBeach)
				{
					drop = 5003;
				}
				else if (tierFour && p.ZoneSnow)
				{
					drop = 4406;
				}
				else if (tierFour && p.ZoneUnderworldHeight)
				{
					drop = 4878;
				}
				else
				{
					drop = 3979;
				}
			}
		}

		private static bool Specials()
		{
			if (tierSix && Main.rand.NextBool(5))
			{
				drop = 2423;
			}
			else if (tierSix && Main.rand.NextBool(5))
			{
				drop = 3225;
			}
			else if (tierSix && Main.rand.NextBool(10))
			{
				drop = 2420;
			}
			else if (!tierSix && !tierFive && tierThree && Main.rand.NextBool(5))
			{
				drop = 3196;
			}
			return drop != 0;
		}

		private static void Corruption()
		{
			if (tierSix && Main.hardMode && p.ZoneSnow && height == 3 && !Main.rand.NextBool(3))
			{
				drop = 2429;
			}
			else if (tierSix && Main.hardMode && Main.rand.NextBool(2))
			{
				drop = 3210;
			}
			else if (tierFour)
			{
				drop = 2330;
			}
			else if (tierThree && todaysQuest == 2454)
			{
				drop = 2454;
			}
			else if (tierThree && todaysQuest == 2485)
			{
				drop = 2485;
			}
			else if (tierThree && todaysQuest == 2457)
			{
				drop = 2457;
			}
			else if (tierThree)
			{
				drop = 2318;
			}
		}

		private static void Crimson()
		{
			if (tierSix && Main.hardMode && p.ZoneSnow && height == 3 && !Main.rand.NextBool(3))
			{
				drop = 2429;
			}
			else if (tierSix && Main.hardMode && Main.rand.NextBool(2))
			{
				drop = 3211;
			}
			else if (tierThree && todaysQuest == 2477)
			{
				drop = 2477;
			}
			else if (tierThree && todaysQuest == 2463)
			{
				drop = 2463;
			}
			else if (tierThree)
			{
				drop = 2319;
			}
			else if (tierTwo)
			{
				drop = 2305;
			}
		}

		private static void Hallow()
		{
			if (tierSix && Main.hardMode && p.ZoneSnow && height == 3 && !Main.rand.NextBool(3))
			{
				drop = 2429;
			}
			else if (tierSix && Main.hardMode && Main.rand.NextBool(2))
			{
				drop = 3209;
			}
			else if (height > 1 && tierFive)
			{
				drop = 2317;
			}
			else if (height > 1 && tierFour && todaysQuest == 2465)
			{
				drop = 2465;
			}
			else if (height < 2 && tierFour && todaysQuest == 2468)
			{
				drop = 2468;
			}
			else if (tierFour)
			{
				drop = 2310;
			}
			else if (tierThree && todaysQuest == 2471)
			{
				drop = 2471;
			}
			else if (tierThree)
			{
				drop = 2307;
			}
		}

		private static void Snow()
		{
			if (height < 2 && tierThree && todaysQuest == 2467)
			{
				drop = 2467;
			}
			else if (height == 1 && tierThree && todaysQuest == 2470)
			{
				drop = 2470;
			}
			else if (height >= 2 && tierThree && todaysQuest == 2484)
			{
				drop = 2484;
			}
			else if (height > 1 && tierThree && todaysQuest == 2466)
			{
				drop = 2466;
			}
			else if ((tierTwo && Main.rand.NextBool(12)) || (tierThree && Main.rand.NextBool(6)))
			{
				drop = 3197;
			}
			else if (tierThree)
			{
				drop = 2306;
			}
			else if (tierTwo)
			{
				drop = 2299;
			}
			else if (height > 1 && Main.rand.NextBool(3))
			{
				drop = 2309;
			}
		}

		private static void Jungle()
		{
			if (height == 1 && tierThree && todaysQuest == 2452)
			{
				drop = 2452;
			}
			else if (height == 1 && tierThree && todaysQuest == 2483)
			{
				drop = 2483;
			}
			else if (height == 1 && tierThree && todaysQuest == 2488)
			{
				drop = 2488;
			}
			else if (height >= 1 && tierThree && todaysQuest == 2486)
			{
				drop = 2486;
			}
			else if (height > 1 && tierThree)
			{
				drop = 2311;
			}
			else if (tierThree)
			{
				drop = 2313;
			}
			else if (tierTwo)
			{
				drop = 2302;
			}
		}

		private static void MushroomQuest()
		{
			drop = 2475;
		}

		private static void Ocean()
		{
			if (tierFive && Main.rand.NextBool(2))
			{
				drop = 2341;
			}
			else if (tierFive)
			{
				drop = 2342;
			}
			else if (tierFour && Main.rand.NextBool(5))
			{
				drop = 2438;
			}
			else if (tierFour && Main.rand.NextBool(2))
			{
				drop = 2332;
			}
			else if (tierThree && todaysQuest == 2480)
			{
				drop = 2480;
			}
			else if (tierThree && todaysQuest == 2481)
			{
				drop = 2481;
			}
			else if (tierThree)
			{
				drop = 2316;
			}
			else if (tierTwo && Main.rand.NextBool(2))
			{
				drop = 2301;
			}
			else if (tierTwo)
			{
				drop = 2300;
			}
			else
			{
				drop = 2297;
			}
		}

		private static void MiscStuff()
		{
			if (height < 2 && tierThree && todaysQuest == 2461)
			{
				drop = 2461;
			}
			else if (height == 0 && tierThree && todaysQuest == 2453)
			{
				drop = 2453;
			}
			else if (height == 0 && tierThree && todaysQuest == 2473)
			{
				drop = 2473;
			}
			else if (height == 0 && tierThree && todaysQuest == 2476)
			{
				drop = 2476;
			}
			else if (height < 2 && tierThree && todaysQuest == 2458)
			{
				drop = 2458;
			}
			else if (height < 2 && tierThree && todaysQuest == 2459)
			{
				drop = 2459;
			}
			else if (height == 0 && tierThree)
			{
				drop = 2304;
			}
			else if (height > 0 && height < 3 && tierThree && todaysQuest == 2455)
			{
				drop = 2455;
			}
			else if (height == 1 && tierThree && todaysQuest == 2479)
			{
				drop = 2479;
			}
			else if (height == 1 && tierThree && todaysQuest == 2456)
			{
				drop = 2456;
			}
			else if (height == 1 && tierThree && todaysQuest == 2474)
			{
				drop = 2474;
			}
			else if (height > 1 && tierFour && Main.rand.NextBool(5))
			{
				if (Main.hardMode && Main.rand.NextBool(2))
				{
					drop = 2437;
				}
				else
				{
					drop = 2436;
				}
			}
			else if (height > 1 && tierSix)
			{
				drop = 2308;
			}
			else if (height > 1 && tierFive && Main.rand.NextBool(2))
			{
				drop = 2320;
			}
			else if (height > 1 && tierFour)
			{
				drop = 2321;
			}
			else if (height > 1 && tierThree && todaysQuest == 2478)
			{
				drop = 2478;
			}
			else if (height > 1 && tierThree && todaysQuest == 2450)
			{
				drop = 2450;
			}
			else if (height > 1 && tierThree && todaysQuest == 2464)
			{
				drop = 2464;
			}
			else if (height > 1 && tierThree && todaysQuest == 2469)
			{
				drop = 2469;
			}
			else if (height > 2 && tierThree && todaysQuest == 2462)
			{
				drop = 2462;
			}
			else if (height > 2 && tierThree && todaysQuest == 2482)
			{
				drop = 2482;
			}
			else if (height > 2 && tierThree && todaysQuest == 2472)
			{
				drop = 2472;
			}
			else if (height > 2 && tierThree && todaysQuest == 2460)
			{
				drop = 2460;
			}
			else if (height > 1 && tierThree && !Main.rand.NextBool(4))
			{
				drop = 2303;
			}
			else if (height > 1 && (tierThree || tierTwo || Main.rand.NextBool(4)))
			{
				if (Main.rand.NextBool(4))
				{
					drop = 2303;
				}
				else
				{
					drop = 2309;
				}
			}
			else if (tierThree && todaysQuest == 2487)
			{
				drop = 2487;
			}
			else if (poolSize > 1000 && tierTwo)
			{
				drop = 2298;
			}
			else
			{
				drop = 2290;
			}
		}
	}
}
