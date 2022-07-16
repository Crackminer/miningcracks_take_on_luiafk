using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using miningcracks_take_on_luiafk.Images.Items.AutoBuilders;
using miningcracks_take_on_luiafk.Images.Items.Fishing;
using miningcracks_take_on_luiafk.Images.Items.Misc;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using miningcracks_take_on_luiafk.Images.Items.Solutions;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkMod : Mod
	{
		private delegate object CallFunc(object[] args);

		private Dictionary<string, CallFunc> callFuncs;

		internal static readonly Color UIOnColor = new Color(255, 255, 255);

		internal static readonly Color UIOffColor = new Color(100, 100, 100);

		internal static LuiafkMod Instance { get; private set; }

		internal static ModKeybind LuiafkRecall { get; private set; }

		internal static ModKeybind LuiafkRecallBack { get; private set; }

		internal static ModKeybind LuiafkSettings { get; private set; }

		internal static int[] AllBosses { get; private set; }

		internal static int[] NotTaggedBoss { get; private set; }

		internal static int[] TileList { get; private set; }

		internal static Mod CalamityMod { get; private set; }

		internal static Mod ThoriumMod { get; private set; }

		internal static Mod FargoMod { get; private set; }

		internal static bool CalamityLoaded { get; private set; }

		internal static bool ThoriumLoaded { get; private set; }

		internal static bool FargoLoaded { get; private set; }

		internal static List<int> throwingtypes = new();

		public override void Load()
		{
			Instance = this;
			if (Main.rand == null)
			{
				if (!Main.dedServ)
				{
					Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
				}
				else
				{
					Main.rand = new UnifiedRandom();
				}
			}
			LuiafkRecall = KeybindLoader.RegisterKeybind(this, "Luiafk Recall", (Keys)103);
			LuiafkRecallBack = KeybindLoader.RegisterKeybind(this, "Luiafk Recall Back", (Keys)104);
			LuiafkSettings = KeybindLoader.RegisterKeybind(this, "Luiafk Settings", (Keys)100);
			InitCallFuncs();
			Harvesting.Load();
			if (!Main.dedServ)
			{
				Textures.Load();
				UILearning.MyLoad();
			}
			loadthrowingtypes();
		}

		public override void Unload()
		{
			AllBosses = null;
			NotTaggedBoss = null;
			LuiafkRecall = null;
			LuiafkRecallBack = null;
			LuiafkSettings = null;
			Harvesting.Unload();
			UnloadLoadedMods();
			LuiafkCommands.UnloadBombs();
			CatchFish.Unload();
			if (!Main.dedServ)
			{
				Textures.Unload();
			}
			Instance = null;
			throwingtypes = null;
		}

		public override void PostSetupContent()
		{
			LoadedMods();
		}

		public override void PostAddRecipes()
		{
			TileList = Enumerable.Range(0, TileLoader.TileCount).ToArray();
			NPC nPC = new NPC();
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < TextureAssets.Npc.Length; i++)
			{
				nPC.SetDefaults_ForNetId(i, -1f);
				if (!nPC.boss && (nPC.type == 135 || nPC.type == 136 || nPC.type == 551 || nPC.type == 14 || nPC.type == 13 || nPC.type == 15 || (nPC.type > 245 && nPC.type <= 249) || nPC.GetFullNetName().Equals("Ravager")))
				{
					list.Add(i);
					list2.Add(i);
				}
				if (nPC.boss && !list.Contains(nPC.type))
				{
					list.Add(i);
				}
			}
			AllBosses = list.ToArray();
			NotTaggedBoss = list2.ToArray();
			LuiafkCommands.InitBombs();
			LuiafkPlayer.InitCoatings();
			CatchFish.Init();
		}

		private static void LoadedMods()
		{
			ModLoader.TryGetMod("CalamityMod", out var result);
			CalamityLoaded = result != null;
			ModLoader.TryGetMod("ThoriumMod", out var result2);
			ThoriumLoaded = result2 != null;
			ModLoader.TryGetMod("Fargowiltas", out var result3);
			FargoLoaded = result3 != null;
		}

		private void InitCallFuncs()
		{
			callFuncs = new Dictionary<string, CallFunc> { { "plantharvest", PlantHarvest } };
		}

		private static void UnloadLoadedMods()
		{
			CalamityLoaded = false;
			ThoriumLoaded = false;
			FargoLoaded = false;
			CalamityMod = null;
			ThoriumMod = null;
			FargoMod = null;
		}

		private static void loadthrowingtypes()
		{
			int[] types =
			{
				ItemID.ThrowingKnife,
				ItemID.Grenade,
				ItemID.BouncyGrenade,
				ItemID.StickyGrenade,
				ItemID.Bomb,
				ItemID.BouncyBomb,
				ItemID.StickyBomb,
				ItemID.Dynamite,
				ItemID.BouncyDynamite,
				ItemID.StickyDynamite,
				ItemID.SpikyBall,
				ItemID.Beenade,
				ItemID.RottenEgg,
				ItemID.StarAnise,
				ItemID.PartyGirlGrenade,
				ItemID.PoisonedKnife,
				ItemID.BoneJavelin,
				ItemID.Javelin,
				ItemID.Shuriken,
				ItemID.MolotovCocktail,
				ItemID.FrostDaggerfish,
				ItemID.BoneDagger
			};
			foreach (int x in types)
			{
				throwingtypes.Add(x);
			}
		}

		private object PlantHarvest(object[] args)
		{
			if ((args.Length == 4 && args[1] is int && args[2] is int && (args[3] is int || args[3] is short)) || (args.Length == 5 && args[1] is int && args[2] is int && (args[3] is int || args[3] is short) && args[4] is Func<int>))
			{
				PlantHarvesting.modHerbs.Add(new Tuple<int, int, int, Func<int>>((int)args[1], (int)args[2], (args[3] is int) ? ((int)args[3]) : ((short)args[3]), (args.Length == 5) ? ((Func<int>)args[4]) : new Func<int>(PlantHarvesting.Amount)));
				return true;
			}
			if ((args.Length == 3 && args[1] is int && args[2] is Func<int, int, Point>) || (args.Length == 4 && args[1] is int && args[2] is Func<int, int, Point> && (args[3] is Action<Tile, int, int> || args[3] == null)))
			{
				PlantHarvesting.modHerbsFuncs.Add(new Tuple<int, Func<int, int, Point>, Harvesting.TileUpdate>((int)args[1], (Func<int, int, Point>)args[2], (args.Length == 3 || args[3] == null) ? null : new Harvesting.TileUpdate(((Action<Tile, int, int>)args[3]).Invoke)));
				return true;
			}
			return false;
		}

		public override object Call(params object[] args)
		{
			if (args.Length != 0 && args[0] is string && callFuncs.TryGetValue((string)args[0], out var value))
			{
				return value(args);
			}
			return false;
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			switch (reader.ReadInt32())
			{
			case 0:
				Main.player[reader.ReadInt32()].GetModPlayer<LuiafkPlayer>().HandleToggles(reader);
				break;
			case 1:
				Hellevator.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean());
				break;
			case 2:
				SubwayBuilder.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean());
				break;
			case 3:
				SkyPlatformBuilder.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean());
				break;
			case 4:
				SubAndSky.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean(), reader.ReadBoolean(), reader.ReadBoolean(), reader.ReadBoolean());
				break;
			case 5:
				FishingBuilder.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean());
				break;
			case 6:
				PrisonBuilder.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean());
				break;
			case 7:
				FishingBiomeBuilder.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean(), reader.ReadBoolean());
				break;
			case 8:
				Fishing.HandleFishron(reader.ReadInt32());
				break;
			case 9:
				UnlimitedMultiSolution.HandleConvert(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
				break;
			case 10:
				ArenaBuilder.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadBoolean(), reader.ReadBoolean());
				break;
			case 11:
				GroundFiller.HandleBuilding(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
				break;
			case 12:
				Main.player[reader.ReadInt32()].GetModPlayer<LuiafkPlayer>().HandleMovePacket(reader);
				break;
			case 13:
				Drilling.HandleBeamPacket(reader);
				break;
			case 14:
				MiscMethods.AnyBoss(despawn: true);
				break;
			case 15:
				DeepsSummon.SummonDeeps(Main.player[reader.ReadInt32()], reader.ReadVector2(), reader.ReadBoolean());
				break;
			case 16:
				LuiafkCommands.HandleRevenge();
				break;
			case 17:
				LuiafkCommands.HandleInvasions();
				break;
			case 19:
				LuiafkCommands.HandleHardMode();
				break;
			case 18:
				LuiafkCommands.HandleExpert();
				break;
			case 20:
				LuiafkCommands.HandleBlossom();
				break;
			case 21:
				Harvesting.HandleHarvesting(reader.ReadInt32(), reader.ReadInt32());
				break;
			case 22:
				LuiafkCommands.HandleTownDudes();
				break;
			case 23:
				LuiafkCommands.HandleDD2(reader.ReadInt32());
				break;
			case 24:
				Liquids.HandleBox(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
				break;
			case 25:
				LuiafkWorld.AddTelePoint(reader.ReadString(), whoAmI);
				break;
			case 26:
				LuiafkWorld.RemoveTelePoint(reader.ReadString());
				break;
			case 27:
				LuiafkWorld.UpdateTelePoints(reader, whoAmI);
				break;
			}
		}

		public override void AddRecipeGroups()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			List<int> list6 = new List<int>();
			List<int> list7 = new List<int>();
			List<int> list8 = new List<int>();
			List<int> list9 = new List<int>();
			List<int> list10 = new List<int>();
			List<int> list11 = new List<int>();
			for (int i = 0; i < TextureAssets.Item.Length; i++)
			{
				Item item = new Item();
				item.SetDefaults(i);
				if (item.bait > 0)
				{
					list.Add(item.type);
					if (item.bait <= 19)
					{
						continue;
					}
					list2.Add(item.type);
					if (item.bait > 29)
					{
						list3.Add(item.type);
						if (item.bait > 49)
						{
							list4.Add(item.type);
						}
					}
				}
				else if (item.axe >= 11)
				{
					list11.Add(item.type);
				}
				else if (item.buffType == 26 || item.buffType == 206 || item.buffType == 207)
				{
					list5.Add(item.type);
				}
				else
				{
					if (!item.consumable || item.createTile < 0 || (item.ModItem != null && item.ModItem.Mod == this))
					{
						continue;
					}
					if (TileID.Sets.BasicChest[item.createTile])
					{
						list10.Add(item.type);
						continue;
					}
					if (TileID.Sets.RoomNeeds.CountsAsChair.Contains(item.createTile))
					{
						list7.Add(item.type);
					}
					if (TileID.Sets.RoomNeeds.CountsAsDoor.Contains(item.createTile))
					{
						list6.Add(item.type);
					}
					if (TileID.Sets.RoomNeeds.CountsAsTable.Contains(item.createTile))
					{
						list8.Add(item.type);
					}
					if (TileID.Sets.RoomNeeds.CountsAsTorch.Contains(item.createTile))
					{
						list9.Add(item.type);
					}
				}
			}
			RecipeGroup.RegisterGroup("Luiafk:WellFed", new RecipeGroup(() => "Any Buff Food", list5.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:AnyBait", new RecipeGroup(() => "Any Bait", list.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:TwentyBait", new RecipeGroup(() => "Any 20% Or Above Bait", list2.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:ThirtyBait", new RecipeGroup(() => "Any 30% Or Above Bait", list3.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:FiftyBait", new RecipeGroup(() => "Any 50% Bait", list4.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:Chairs", new RecipeGroup(() => "Any Chair", list7.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:Doors", new RecipeGroup(() => "Any Door", list6.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:Tables", new RecipeGroup(() => "Any Table", list8.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:LightSource", new RecipeGroup(() => "Any Light Source", list9.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:Chests", new RecipeGroup(() => "Any Chest", list10.ToArray()));
			RecipeGroup.RegisterGroup("Luiafk:Axes", new RecipeGroup(() => "Any 55%+ Axe", list11.ToArray()));
			RecipeGroup rec = new RecipeGroup(() => "Any Pressure Plate", 852, 543, 542, 541, 1151, 529, 3632, 3630, 3626, 3631, 853, 3707, 4261);
			RecipeGroup.RegisterGroup("Luiafk:PressurePlate", rec);
			rec = new RecipeGroup(() => "Any Gem", 182, 181, 180, 179, 178, 177);
			RecipeGroup.RegisterGroup("Luiafk:Gems", rec);
			rec = new RecipeGroup(() => "Ultimate Liquid Manipulator or Pool Builder\nNot consumed on crafting", Find<ModItem>("UltimateBucket").Type, Find<ModItem>("FishingBuilder").Type);
			RecipeGroup.RegisterGroup("Luiafk:Buckets", rec);
			rec = new RecipeGroup(() => "Staff of Regrowth or Plant Harvester\nNot consumed on crafting", Find<ModItem>("PlantHarvester").Type, 213);
			RecipeGroup.RegisterGroup("Luiafk:Regrowth", rec);
			rec = new RecipeGroup(() => "Adamantite or Titanium Bars", 391, 1198);
			RecipeGroup.RegisterGroup("Luiafk:AdamTitanBar", rec);
			rec = new RecipeGroup(() => "Copper or Tin Bars", 20, 703);
			RecipeGroup.RegisterGroup("Luiafk:CopperTinBar", rec);
			rec = new RecipeGroup(() => "Gold or Platinum Bars", 19, 706);
			RecipeGroup.RegisterGroup("Luiafk:PlatGoldBar", rec);
			rec = new RecipeGroup(() => "Ice or Snow Block", 664, 593);
			RecipeGroup.RegisterGroup("Luiafk:IceSnowBlock", rec);
			rec = new RecipeGroup(() => "Life Crystal or Heart Lantern", 29, 1859);
			RecipeGroup.RegisterGroup("Luiafk:LifeCrystal", rec);
			rec = new RecipeGroup(() => "Fallen Star or Star in a Bottle", 75, 1431);
			RecipeGroup.RegisterGroup("Luiafk:FallenStar", rec);
			rec = new RecipeGroup(() => "Any Torch", 8, 427, 3004, 4384, 4385, 4386, 523, 433, 4383, 429, 4387, 974, 1333, 4388, 1245, 3114, 430, 3045, 428, 342, 2274, 431, 432);
			RecipeGroup.RegisterGroup("Luiafk:Torches", rec);
			rec = new RecipeGroup(() => "Any Streamer", 3739, 3740, 3741);
			RecipeGroup.RegisterGroup("Luiafk:Streamer", rec);
			rec = new RecipeGroup(() => "Web or Silk Rope", 3078, 3077);
			RecipeGroup.RegisterGroup("Luiafk:WebSilkRope", rec);
			rec = new RecipeGroup(() => "Rope or Vine Rope", 965, 2996);
			RecipeGroup.RegisterGroup("Luiafk:RopeVine", rec);
			rec = new RecipeGroup(() => "Ale or Sake", 353, 2266);
			RecipeGroup.RegisterGroup("Luiafk:Tipsy", rec);
			rec = new RecipeGroup(() => "Flask of Ichor or Cursed Flames", 1356, 1353);
			RecipeGroup.RegisterGroup("Luiafk:EvilFlask", rec);
			rec = new RecipeGroup(() => "Silt, Shlush, or Desert Fossil", 424, 1103, 3347);
			RecipeGroup.RegisterGroup("Luiafk:Extractinator", rec);
			rec = new RecipeGroup(() => "Vile or Vicious Mushroom", 60, 2887);
			RecipeGroup.RegisterGroup("Luiafk:EvilMushroom", rec);
			rec = new RecipeGroup(() => "Vile or Vicious Powder", 67, 2886);
			RecipeGroup.RegisterGroup("Luiafk:EvilPowder", rec);
			rec = new RecipeGroup(() => "Gold or Platinum Watch", 17, 709);
			RecipeGroup.RegisterGroup("Luiafk:GoldWatch", rec);
			rec = new RecipeGroup(() => "Any Sand Block", 169, 1246, 370, 408);
			RecipeGroup.RegisterGroup("Luiafk:SandBlock", rec);
			rec = new RecipeGroup(() => "Any Flare", 931, 1614);
			RecipeGroup.RegisterGroup("Luiafk:Flare", rec);
			rec = new RecipeGroup(() => "Crimtane or Demonite Bar", 1257, 57);
			RecipeGroup.RegisterGroup("Luiafk:EvilBar", rec);
			rec = new RecipeGroup(() => "Crimtane or Demonite Ore", 880, 56);
			RecipeGroup.RegisterGroup("Luiafk:EvilOre", rec);
			rec = new RecipeGroup(() => "Tissue Sample or Shadow Scale", 1329, 86);
			RecipeGroup.RegisterGroup("Luiafk:EvilOreMat", rec);
			rec = new RecipeGroup(() => "Crimstone or Ebonstone", 836, 61);
			RecipeGroup.RegisterGroup("Luiafk:EvilStoneBlock", rec);
			rec = new RecipeGroup(() => "Any Dungeon Brick", 134, 137, 139);
			RecipeGroup.RegisterGroup("Luiafk:DungeonBrick", rec);
			rec = new RecipeGroup(() => "Any Lunar Pickaxe", 2781, 2776, 2786, 3466);
			RecipeGroup.RegisterGroup("Luiafk:LunarPick", rec);
			rec = new RecipeGroup(() => "Any Lunar Hamaxe", 3524, 3523, 3522, 3525);
			RecipeGroup.RegisterGroup("Luiafk:LunarHamaxe", rec);
		}

		public void SingleRecipe(int resulttype, int craftingtype, int amount, int tiletype)
		{
			Recipe.Create(resulttype).AddIngredient(craftingtype, amount).AddTile(tiletype)
				.Register();
		}

		public override void AddRecipes()
		{
			SingleRecipe(96, 800, 1, 16);
			SingleRecipe(800, 96, 1, 16);
			SingleRecipe(115, 3062, 1, 18);
			SingleRecipe(3062, 115, 1, 18);
			SingleRecipe(111, 1290, 1, 114);
			SingleRecipe(1290, 111, 1, 114);
			SingleRecipe(64, 1256, 1, 16);
			SingleRecipe(1256, 64, 1, 16);
			SingleRecipe(162, 802, 1, 16);
			SingleRecipe(802, 162, 1, 16);
			SingleRecipe(3223, 3224, 1, 114);
			SingleRecipe(3224, 3223, 1, 114);
			SingleRecipe(522, 1332, 1, 18);
			SingleRecipe(1332, 522, 1, 18);
			SingleRecipe(68, 1330, 1, 18);
			SingleRecipe(1330, 68, 1, 18);
			SingleRecipe(57, 1257, 1, 16);
			SingleRecipe(1257, 57, 1, 16);
			SingleRecipe(1329, 86, 1, 16);
			SingleRecipe(86, 1329, 1, 16);
			SingleRecipe(69, 1330, 1, 18);
			SingleRecipe(1330, 69, 1, 18);
			SingleRecipe(61, 836, 1, 18);
			SingleRecipe(836, 61, 1, 18);
			SingleRecipe(370, 1246, 1, 18);
			SingleRecipe(1246, 370, 1, 18);
			SingleRecipe(56, 880, 1, 17);
			SingleRecipe(880, 56, 1, 17);
			SingleRecipe(833, 835, 1, 18);
			SingleRecipe(835, 833, 1, 18);
			SingleRecipe(3275, 3274, 1, 18);
			SingleRecipe(3274, 3275, 1, 18);
			SingleRecipe(3277, 3276, 1, 18);
			SingleRecipe(3276, 3277, 1, 18);
			SingleRecipe(2887, 60, 1, 18);
			SingleRecipe(60, 2887, 1, 18);
			SingleRecipe(67, 2886, 1, 18);
			SingleRecipe(2886, 67, 1, 18);
			SingleRecipe(75, 1431, 1, 18);
			SingleRecipe(29, 1859, 1, 18);
			Recipe recipe = Recipe.Create(857);
			recipe.AddIngredient(169, 100);
			recipe.AddIngredient(3347, 20);
			recipe.AddIngredient(320, 5);
			recipe.AddIngredient(31);
			recipe.AddTile(114);
			recipe.Register();
			Recipe recipe2 = Recipe.Create(987);
			recipe2.AddIngredient(593, 100);
			recipe2.AddIngredient(664, 100);
			recipe2.AddIngredient(320, 5);
			recipe2.AddIngredient(31);
			recipe2.AddTile(114);
			recipe2.Register();
			Recipe recipe3 = Recipe.Create(1571);
			recipe3.AddIngredient(1534);
			recipe3.AddIngredient(1141);
			recipe3.AddIngredient(1508, 5);
			recipe3.Register();
			Recipe recipe4 = Recipe.Create(1569);
			recipe4.AddIngredient(1535);
			recipe4.AddIngredient(1141);
			recipe4.AddIngredient(1508, 5);
			recipe4.Register();
			Recipe recipe5 = Recipe.Create(1260);
			recipe5.AddIngredient(1536);
			recipe5.AddIngredient(1141);
			recipe5.AddIngredient(1508, 5);
			recipe5.Register();
			Recipe recipe6 = Recipe.Create(1572);
			recipe6.AddIngredient(1537);
			recipe6.AddIngredient(1141);
			recipe6.AddIngredient(1508, 5);
			recipe6.Register();
			Recipe recipe7 = Recipe.Create(1156);
			recipe7.AddIngredient(1533);
			recipe7.AddIngredient(1141);
			recipe7.AddIngredient(1508, 5);
			recipe7.Register();
			Recipe recipe8 = Recipe.Create(3198);
			recipe8.AddRecipeGroup("IronBar", 10);
			recipe8.AddRecipeGroup("Wood", 50);
			recipe8.AddIngredient(173, 30);
			recipe8.AddIngredient(207, 5);
			recipe8.AddTile(16);
			recipe8.Register();
		}
	}
}
