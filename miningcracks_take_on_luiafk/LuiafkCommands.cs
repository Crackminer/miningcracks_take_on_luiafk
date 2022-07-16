using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.NPCs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkCommands : ModCommand
	{
		private delegate void LuiCommand(Player p, LuiafkPlayer luiP, string[] args);

		private static readonly Dictionary<string, LuiCommand> commands = new Dictionary<string, LuiCommand>
		{
			{ "nodrill", NoDrill },
			{ "noclip", NoClip },
			{ "respawn", Respawn },
			{ "hitbox", Hitbox },
			{ "dummy", Dummy },
			{ "despawn", Despawn },
			{ "add", AddTelePoint },
			{ "remove", RemoveTelePoint },
			{ "list", ListTelePoints },
			{ "tele", Tele },
			{ "slash", Slash },
			{ "revenge", Revenge },
			{ "invasions", Invasions },
			{ "expert", Expert },
			{ "hardmode", HardMode },
			{ "stress", Stress },
			{ "stresslock", StressLock },
			{ "calamityextras", CalamityExtras },
			{ "blossom", Blossom },
			{ "coord", TileCoords },
			{ "oldchar", OldChar },
			{ "newchar", NewChar },
			{ "goodmove", GoodMove },
			{ "towndudes", TownDudes },
			{ "dd2", DD2 },
			{ "ammo", AmmoToggle },
			{ "anytile", AnyTile }
		};

		private static readonly string[] calFields = new string[8] { "extraAccessoryML", "mFruit", "bOrange", "eBerry", "dFruit", "pHeart", "eCore", "cShard" };

		private static readonly Color red = new Color(255, 0, 0);

		private static readonly Color orange = new Color(255, 85, 0);

		private static readonly Color green = new Color(72, 198, 0);

		private static int[] bombs;

		public override CommandType Type => CommandType.Chat;

		public override string Command => "luiafk";

		public override string Description => "Use /luiafk respawn x, where x is a number, to set respawn time in seconds, -1 will set to default. Bosses will despawn when respawn time is faster than default.\nUse /luiafk dummy to toggle improved target dummy's hitbox being displayed.\nUse /luiafk dummy x, where x is a number, to change the dummy's defense.\nUse /luiafk slash to toggle the / key opening the chatbox with \"/luiafk \" already input.\nUse /luiafk dd2 to toggle instant and default time between waves for the DD2 event.\nUse /luiafk dd2 x, where x is a number, to set wave time to that number of seconds.\nUse /luiafk ammo to toggle infinite ammo/thrown items when stack size is over a certain size.";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if (args.Length != 0 && commands.TryGetValue(args[0], out var value))
			{
				LuiafkPlayer modPlayer = caller.Player.GetModPlayer<LuiafkPlayer>();
				value(caller.Player, modPlayer, args);
			}
			else
			{
				Error("a valid command");
			}
		}

		private static void NoClip(Player p, LuiafkPlayer luiP, string[] args)
		{
						luiP.noClip = !luiP.noClip;
			Main.NewText(string.Format("No Clip: [C/48C600:{0}].", luiP.noClip ? "On" : "Off"), Color.Orange);
		}

		private static void NoDrill(Player p, LuiafkPlayer luiP, string[] args)
		{
						luiP.noDrill = !luiP.noDrill;
			Main.NewText(string.Format("No Drill: [C/48C600:{0}].", luiP.noDrill ? "On" : "Off"), Color.Orange);
		}

		private static void Respawn(Player p, LuiafkPlayer luiP, string[] args)
		{
			int result = 0;
			if (args.Length > 1 && int.TryParse(args[1], out result))
			{
				bool result2 = false;
				luiP.respawnTimer = result;
				if (args.Length > 2 && bool.TryParse(args[2], out result2))
				{
					luiP.despawnNPCsOnRespawn = result2;
				}
				if (result >= 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Respawn time set to: [C/48C600:");
					defaultInterpolatedStringHandler.AppendFormatted(result);
					defaultInterpolatedStringHandler.AppendLiteral("] seconds.");
					Main.NewText(defaultInterpolatedStringHandler.ToStringAndClear(), orange);
					Main.NewText(string.Format("Bosses [C/48C600:will{0}] despawn when you die.", luiP.despawnNPCsOnRespawn ? "" : " not"), orange);
				}
				else
				{
					Main.NewText("Respawn time back to default. Bosses will not despawn when you die.", orange);
				}
			}
			else
			{
				Error("a number (in seconds) after /respawn");
			}
		}

		private static void Hitbox(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (args.Contains("all"))
			{
				HitboxAll(luiP, args);
				return;
			}
			bool flag = false;
			if (args.Contains("item"))
			{
				luiP.uiDrawItemHitbox = !luiP.uiDrawItemHitbox;
				flag = true;
				Main.NewText(string.Format("Hitboxes for Items [C/48C600:are{0}] being drawn.", luiP.uiDrawItemHitbox ? "" : " not"), orange);
			}
			if (args.Contains("weapon"))
			{
				luiP.uiDrawWeaponHitbox = !luiP.uiDrawWeaponHitbox;
				flag = true;
				Main.NewText(string.Format("Hitboxes for Weapons [C/48C600:are{0}] being drawn.", luiP.uiDrawItemHitbox ? "" : " not"), orange);
			}
			if (args.Contains("npc"))
			{
				luiP.uiDrawNPCHitbox = !luiP.uiDrawNPCHitbox;
				flag = true;
				Main.NewText(string.Format("Hitboxes for NPCs [C/48C600:are{0}] being drawn.", luiP.uiDrawItemHitbox ? "" : " not"), orange);
			}
			if (args.Contains("proj"))
			{
				luiP.uiDrawProjHitbox = !luiP.uiDrawProjHitbox;
				flag = true;
				Main.NewText(string.Format("Hitboxes for Projectiles [C/48C600:are{0}] being drawn.", luiP.uiDrawItemHitbox ? "" : " not"), orange);
			}
			if (args.Contains("player"))
			{
				luiP.uiDrawPlayerHitbox = !luiP.uiDrawPlayerHitbox;
				flag = true;
				Main.NewText(string.Format("Hitboxes for Players [C/48C600:are{0}] being drawn.", luiP.uiDrawItemHitbox ? "" : " not"), orange);
			}
			if (!flag)
			{
				Error("[C/48C600:/luiafk hitbox] followed by one or multiple hitbox types ([C/48C600:item], [C/48C600:weapon], [C/48C600:npc], and [C/48C600:proj]), [C/48C600:all on], or [C/48C600:all off]");
			}
		}

		private static void HitboxAll(LuiafkPlayer luiP, string[] args)
		{
			if (args.Contains("on"))
			{
				luiP.uiDrawAllHitbox = true;
			}
			else
			{
				if (!args.Contains("off"))
				{
					Error("[C/48C600:/luiafk hitbox] followed by [C/48C600:all on] or [C/48C600:all off]");
					return;
				}
				luiP.uiDrawAllHitbox = false;
			}
			luiP.uiDrawItemHitbox = (luiP.uiDrawWeaponHitbox = (luiP.uiDrawProjHitbox = (luiP.uiDrawNPCHitbox = (luiP.uiDrawPlayerHitbox = luiP.uiDrawAllHitbox))));
			Main.NewText(string.Format("All hitboxes [C/48C600:are{0}] being drawn.", luiP.uiDrawAllHitbox ? "" : " not"), orange);
		}

		private static void Dummy(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (args.Length > 1)
			{
				if (int.TryParse(args[1], out var result))
				{
					Deeps.defense = result;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Target Dummy defense set to: [C/48C600:");
					defaultInterpolatedStringHandler.AppendFormatted(result);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					Main.NewText(defaultInterpolatedStringHandler.ToStringAndClear(), orange);
				}
				else
				{
					Error("a number after /dummy if you're trying to change the defense, or nothing to show the hitbox");
				}
			}
			else
			{
				luiP.uiDrawDummyHitbox = !luiP.uiDrawDummyHitbox;
				Main.NewText(string.Format("Target Dummy hitbox: [C/48C600:{0}].", luiP.uiDrawDummyHitbox ? "On" : "Off"), orange);
			}
		}

		private static void Despawn(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				MiscMethods.AnyBoss(despawn: true);
			}
			else
			{
				MiscMethods.DespawnPacket();
			}
		}

		private static void AddTelePoint(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (args.Length > 1)
			{
				if (Main.netMode == 1)
				{
					AddTelePointPacket(args[1], p);
				}
				else
				{
					LuiafkWorld.AddTelePoint(args[1], p.whoAmI);
				}
			}
			else
			{
				Error("a location name after add");
			}
		}

		private static void AddTelePointPacket(string name, Player p)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(25);
			((BinaryWriter)packet).Write(name);
			packet.Send();
		}

		private static void RemoveTelePoint(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (args.Length > 1)
			{
				if (Main.netMode == 1)
				{
					RemoveTelePointPacket(args[1], p);
				}
				else
				{
					LuiafkWorld.RemoveTelePoint(args[1]);
				}
			}
			else
			{
				Error("a saved location name after remove, you can check your saved locations by using [C/48C600:/luiafk list]");
			}
		}

		private static void RemoveTelePointPacket(string name, Player p)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(26);
			((BinaryWriter)packet).Write(name);
			packet.Send();
		}

		private static void ListTelePoints(Player p, LuiafkPlayer luiP, string[] args)
		{
									string text = LuiafkWorld.ListTelePoints();
			if (text != null)
			{
				Main.NewText(text, orange);
			}
			else
			{
				Main.NewText("No locations have been saved. Use [C/48C600:/luiafk add name] to store your current location.", red);
			}
		}

		private static void Tele(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (args.Length < 2 || !LuiafkWorld.Teleport(args[1]))
			{
				Error("the name of a saved location, add locations using [C/48C600:/luiafk add name], check your saved locations by using [C/48C600:/luiafk list]");
			}
		}

		private static void Slash(Player p, LuiafkPlayer luiP, string[] args)
		{
						luiP.forwardSlash = !luiP.forwardSlash;
			Main.NewText(string.Format("Forward slash [C/48C600:will{0}] open the chat box.", luiP.forwardSlash ? "" : " not"), orange);
		}

		private static void Revenge(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				HandleRevenge();
			}
			else
			{
				RevengePacket();
			}
		}

		private static void RevengePacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(16);
			packet.Send();
		}

		internal static void HandleRevenge()
		{
			if (LuiafkMod.CalamityLoaded)
			{
				ModSystem modSystem = LuiafkMod.CalamityMod.Find<ModSystem>("CalamityWorld");
				FieldInfo field = modSystem.GetType().GetField("revenge");
				field.SetValue(modSystem, !(bool)field.GetValue(modSystem));
				MiscMethods.WriteText(string.Format("Revengeance is [C/48C600:{0}].", ((bool)field.GetValue(modSystem)) ? "enabled" : "disabled"), orange);
				NetMessage.SendData(7);
			}
			else
			{
				MiscMethods.WriteText("Error: Calamity isn't enabled.", red);
			}
		}

		private static void Invasions(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				HandleInvasions();
			}
			else
			{
				InvasionsPacket();
			}
		}

		private static void InvasionsPacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(17);
			packet.Send();
		}

		internal static void HandleInvasions()
		{
			LuiafkWorld.invasionsDisabled = !LuiafkWorld.invasionsDisabled;
			MiscMethods.WriteText(string.Format("Invasions are [C/48C600:{0}].", (!LuiafkWorld.invasionsDisabled) ? "enabled" : "disabled"), orange);
		}

		private static void HardMode(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				HandleHardMode();
			}
			else
			{
				HardModePacket();
			}
		}

		private static void HardModePacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(19);
			packet.Send();
		}

		internal static void HandleHardMode()
		{
			Main.hardMode = !Main.hardMode;
			MiscMethods.WriteText(string.Format("HardMode is [C/48C600:{0}].", Main.hardMode ? "enabled" : "disabled"), orange);
			NetMessage.SendData(7);
		}

		private static void Expert(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				HandleExpert();
			}
			else
			{
				ExpertPacket();
			}
		}

		private static void ExpertPacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(18);
			packet.Send();
		}

		internal static void HandleExpert()
		{
			MiscMethods.WriteText(string.Format("Expert is [C/48C600:{0}].", Main.expertMode ? "enabled" : "disabled"), orange);
			NetMessage.SendData(7);
		}

		private static void Stress(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (LuiafkMod.CalamityLoaded)
			{
				if (args.Length > 1 && int.TryParse(args[1], out var result) && result >= 0 && result <= 10000)
				{
					MiscMethods.StressChange(p, result);
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
					defaultInterpolatedStringHandler.AppendLiteral("You now have: [C/48C600:");
					defaultInterpolatedStringHandler.AppendFormatted(result);
					defaultInterpolatedStringHandler.AppendLiteral("] stress.");
					Main.NewText(defaultInterpolatedStringHandler.ToStringAndClear(), orange);
				}
				else
				{
					Error("an amount of stress between 0 and 10000");
				}
			}
			else
			{
				Main.NewText("Error: Calamity isn't enabled.", red);
			}
		}

		private static void StressLock(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (LuiafkMod.CalamityLoaded)
			{
				if (args.Length > 1)
				{
					int result = -1;
					if (int.TryParse(args[1], out result) && result >= 0 && result <= 10000)
					{
						luiP.stressLock = true;
						luiP.stressLockNum = result;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Stress is locked to: [C/48C600:");
						defaultInterpolatedStringHandler.AppendFormatted(result);
						defaultInterpolatedStringHandler.AppendLiteral("].");
						Main.NewText(defaultInterpolatedStringHandler.ToStringAndClear(), orange);
						return;
					}
					if (args[1] == "off")
					{
						luiP.stressLock = false;
						Main.NewText("Stress lock is [C/48C600:off].", orange);
						return;
					}
				}
				Error("an amount of stress between 0 and 10000, or [C/48C600:off] to disable stress lock");
			}
			else
			{
				Main.NewText("Error: Calamity isn't enabled.", red);
			}
		}

		private static void CalamityExtras(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (LuiafkMod.CalamityLoaded)
			{
				if (args.Length > 1 && bool.TryParse(args[1], out var result))
				{
					ModPlayer modPlayer = p.GetModPlayer<ModPlayer>();
					Type type = modPlayer.GetType();
					string[] array = calFields;
					foreach (string name in array)
					{
						type.GetField(name).SetValue(modPlayer, result);
					}
					Main.NewText(string.Format("Calamity's extra accessory and extra health/mana are [C/48C600:{0}].", result ? "enabled" : "disabled"), orange);
				}
				else
				{
					Error("[C/48C600: true] or [C/48C600: false] to enable or disable extras");
				}
			}
			else
			{
				Main.NewText("Error: Calamity isn't enabled.", red);
			}
		}

		private static void Blossom(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				HandleBlossom();
			}
			else
			{
				BlossomPacket();
			}
		}

		private static void BlossomPacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(20);
			packet.Send();
		}

		internal static void HandleBlossom()
		{
			Main.dayTime = true;
			Main.time = 40500.0;
			NetMessage.SendData(7);
			MiscMethods.WriteText("Fireblossom is ready!", orange);
		}

		private static void TileCoords(Player p, LuiafkPlayer luiP, string[] args)
		{
			luiP.mouseTileCoords = !luiP.mouseTileCoords;
			Main.NewText(string.Format("Tile coordinates for your mouse [C/48C600:will{0}] be drawn.", luiP.mouseTileCoords ? "" : " not"), orange);
		}

		private static void OldChar(Player p, LuiafkPlayer luiP, string[] args)
		{
			luiP.noDrill = true;
			luiP.noClip = true;
			luiP.respawnTimer = 0;
			luiP.goodMove = true;
			luiP.position = luiP.Player.position;
			luiP.forwardSlash = true;
			if (Main.netMode == 1)
			{
				luiP.TogglesPacket(server: false);
			}
			Main.NewText("NoDrill, NoClip, GoodMove, Slash, and Instant Respawn Enabled.", orange);
		}

		private static void NewChar(Player p, LuiafkPlayer luiP, string[] args)
		{
			p.statLifeMax = 500;
			p.statManaMax = 200;
			p.extraAccessory = true;
			if (LuiafkMod.CalamityLoaded)
			{
				CalamityExtras(p, luiP, new string[2] { "", "true" });
			}
			OldChar(p, luiP, args);
			NetMessage.SendData(4, -1, -1, null, p.whoAmI);
			Main.NewText("Base health and mana are maxed, Demon Heart has been used.", orange);
		}

		private static void GoodMove(Player p, LuiafkPlayer luiP, string[] args)
		{
			luiP.goodMove = !luiP.goodMove;
			if (luiP.goodMove)
			{
				luiP.position = luiP.Player.position;
			}
			if (Main.netMode == 1)
			{
				luiP.TogglesPacket(server: false);
			}
			Main.NewText(string.Format("Drill mount without being mounted is: [C/48C600:{0}].", luiP.goodMove ? "enabled" : "disabled"), orange);
		}

		private static void TownDudes(Player p, LuiafkPlayer luiP, string[] args)
		{
			if (Main.netMode == 0)
			{
				HandleTownDudes();
			}
			else
			{
				TownDudesPacket();
			}
		}

		private static void TownDudesPacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(22);
			packet.Send();
		}

		internal static void HandleTownDudes()
		{
			bool nurseHP = false;
			bool dealerGun = false;
			bool demoBombs = false;
			bool normalDye = false;
			bool strangeDye = false;
			int playerCoins = Conditions(ref nurseHP, ref dealerGun, ref demoBombs, ref normalDye, ref strangeDye);
			List<int> npcs = NumTownNPCs();
			SpawnVanilla(playerCoins, npcs, nurseHP, dealerGun, demoBombs, normalDye, strangeDye);
			SpawnModded(playerCoins, npcs);
			MiscMethods.WriteText("Available Town NPCs have respawned!", orange);
		}

		internal static void InitBombs()
		{
			int[] obj = new int[18]
			{
				166, 0, 235, 0, 3115, 0, 167, 0, 2896, 0,
				3547, 0, 168, 0, 2586, 0, 3116, 0
			};
			obj[1] = LuiafkMod.Instance.Find<ModItem>("UnlimitedBomb").Type;
			obj[3] = LuiafkMod.Instance.Find<ModItem>("UnlimitedStickyBomb").Type;
			obj[5] = LuiafkMod.Instance.Find<ModItem>("UnlimitedBouncyBomb").Type;
			obj[7] = LuiafkMod.Instance.Find<ModItem>("UnlimitedDynamite").Type;
			obj[9] = LuiafkMod.Instance.Find<ModItem>("UnlimitedStickyDynamite").Type;
			obj[11] = LuiafkMod.Instance.Find<ModItem>("UnlimitedBouncyDynamite").Type;
			obj[13] = LuiafkMod.Instance.Find<ModItem>("UnlimitedGrenade").Type;
			obj[15] = LuiafkMod.Instance.Find<ModItem>("UnlimitedStickyGrenade").Type;
			obj[17] = LuiafkMod.Instance.Find<ModItem>("UnlimitedBouncyGrenade").Type;
			bombs = obj;
		}

		internal static void UnloadBombs()
		{
			bombs = null;
		}

		private static int Conditions(ref bool nurseHP, ref bool dealerGun, ref bool demoBombs, ref bool normalDye, ref bool strangeDye)
		{
			int num = 0;
			for (int i = 0; i < 255; i++)
			{
				Player player = Main.player[i];
				if (!player.active)
				{
					continue;
				}
				if (player.statLifeMax / 20 > 5)
				{
					nurseHP = true;
				}
				for (int j = 0; j < 58; j++)
				{
					Item item = player.inventory[j];
					if (item.stack <= 0)
					{
						continue;
					}
					if (num < 2000000000 && item.type >= 71 && item.type <= 74)
					{
						num += (int)((double)item.stack * Math.Pow(100.0, item.type - 71));
					}
					if (item.ammo == AmmoID.Bullet || item.useAmmo == AmmoID.Bullet)
					{
						dealerGun = true;
					}
					if (bombs.Contains(item.type))
					{
						demoBombs = true;
					}
					if (item.dye > 0 || (item.type >= 1107 && item.type <= 1120) || (item.type >= 3385 && item.type <= 3388))
					{
						if (item.type >= 3385 && item.type <= 3388)
						{
							strangeDye = true;
						}
						normalDye = true;
					}
				}
			}
			if (num >= 0)
			{
				return num;
			}
			return int.MaxValue;
		}

		private static List<int> NumTownNPCs()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].townNPC && Main.npc[i].active)
				{
					list.Add(Main.npc[i].type);
				}
			}
			return list;
		}

		private static bool SpawnSomething(int type)
		{
			return NPC.NewNPC(new EntitySource_SpawnNPC(), Main.spawnTileX << 4, Main.spawnTileY << 4, type) != 200;
		}

		private static void SpawnVanilla(int playerCoins, List<int> npcs, bool nurseHP, bool dealerGun, bool demoBombs, bool normalDye, bool strangeDye)
		{
			if (!npcs.Contains(22) && SpawnSomething(22))
			{
				npcs.Add(22);
			}
			if (!npcs.Contains(17) && playerCoins > 4999 && SpawnSomething(17))
			{
				npcs.Add(17);
			}
			if (!npcs.Contains(18) && npcs.Contains(17) && nurseHP && SpawnSomething(18))
			{
				npcs.Add(18);
			}
			if (!npcs.Contains(19) && dealerGun && SpawnSomething(19))
			{
				npcs.Add(19);
			}
			if (!npcs.Contains(20) && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && SpawnSomething(20))
			{
				npcs.Add(20);
			}
			if (!npcs.Contains(38) && npcs.Contains(17) && demoBombs && SpawnSomething(38))
			{
				npcs.Add(38);
			}
			if (!npcs.Contains(353) && NPC.savedStylist && SpawnSomething(353))
			{
				npcs.Add(353);
			}
			if (!npcs.Contains(369) && NPC.savedAngler && SpawnSomething(369))
			{
				npcs.Add(369);
			}
			if (!npcs.Contains(54) && NPC.downedBoss3 && SpawnSomething(54))
			{
				npcs.Add(54);
			}
			if (!npcs.Contains(107) && NPC.savedGoblin && SpawnSomething(107))
			{
				npcs.Add(107);
			}
			if (!npcs.Contains(441) && NPC.savedTaxCollector && SpawnSomething(441))
			{
				npcs.Add(441);
			}
			if (!npcs.Contains(108) && NPC.savedWizard && SpawnSomething(108))
			{
				npcs.Add(108);
			}
			if (!npcs.Contains(124) && NPC.savedMech && SpawnSomething(124))
			{
				npcs.Add(124);
			}
			if (!npcs.Contains(142) && NPC.downedFrost && Main.xMas && SpawnSomething(142))
			{
				npcs.Add(142);
			}
			if (!npcs.Contains(178) && NPC.downedMechBossAny && SpawnSomething(178))
			{
				npcs.Add(178);
			}
			if (!npcs.Contains(207) && normalDye && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || strangeDye) && SpawnSomething(207))
			{
				npcs.Add(207);
			}
			if (!npcs.Contains(228) && NPC.downedQueenBee && SpawnSomething(228))
			{
				npcs.Add(228);
			}
			if (!npcs.Contains(229) && NPC.downedPirates && SpawnSomething(229))
			{
				npcs.Add(229);
			}
			if (!npcs.Contains(160) && Main.hardMode && SpawnSomething(160))
			{
				npcs.Add(160);
			}
			if (!npcs.Contains(209) && Main.hardMode && NPC.downedPlantBoss && SpawnSomething(209))
			{
				npcs.Add(209);
			}
			if (!npcs.Contains(227) && npcs.Count >= 8 && SpawnSomething(227))
			{
				npcs.Add(227);
			}
			if (!npcs.Contains(208) && npcs.Count >= 14 && SpawnSomething(208))
			{
				npcs.Add(208);
			}
			if (!npcs.Contains(550) && NPC.savedBartender && SpawnSomething(550))
			{
				npcs.Add(550);
			}
		}

		private static void SpawnModded(int playerCoins, List<int> npcs)
		{
			NPC nPC = new NPC();
			for (int i = 580; i < TextureAssets.Npc.Length; i++)
			{
				nPC.SetDefaults(i);
				if (nPC.townNPC && NPC.TypeToDefaultHeadIndex(nPC.type) >= 0 && !npcs.Contains(nPC.type) && nPC.ModNPC.CanTownNPCSpawn(npcs.Count, playerCoins) && SpawnSomething(nPC.type))
				{
					npcs.Add(nPC.type);
				}
			}
		}

		private static void DD2(Player p, LuiafkPlayer luiP, string[] args)
		{
			int result = -1;
			if (args.Length > 1)
			{
				if (!int.TryParse(args[1], out result))
				{
					Error("the time, in seconds, you'd like the wave delay to be");
					return;
				}
				if (result < 0 || result > 29)
				{
					Error("a number between 0 and 29");
					return;
				}
			}
			if (Main.netMode == 0)
			{
				HandleDD2(result);
			}
			else
			{
				DD2Packet(result);
			}
		}

		private static void DD2Packet(int time)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(23);
			((BinaryWriter)packet).Write(time);
			packet.Send();
		}

		internal static void HandleDD2(int time)
		{
			if (time < 0)
			{
				if (LuiafkWorld.dd2Modified)
				{
					LuiafkWorld.dd2Time = 1800;
				}
				else
				{
					LuiafkWorld.dd2Time = 1;
				}
				LuiafkWorld.dd2Modified = !LuiafkWorld.dd2Modified;
			}
			else
			{
				LuiafkWorld.dd2Modified = true;
				if (time > 0)
				{
					LuiafkWorld.dd2Time = time * 60;
				}
				else
				{
					LuiafkWorld.dd2Time = 1;
				}
			}
			MiscMethods.WriteText(string.Format("DD2 wave break is set to: [C/48C600:{0}].", LuiafkWorld.dd2Modified ? (LuiafkWorld.dd2Time / 60 + " seconds") : "default"), orange);
		}

		private static void AmmoToggle(Player p, LuiafkPlayer luiP, string[] args)
		{
						luiP.infiniteAmmoDisabled = !luiP.infiniteAmmoDisabled;
			Main.NewText(string.Format("Infinite ammo is: [C/48C600:{0}].", luiP.infiniteAmmoDisabled ? "Disabled" : "Enabled"), orange);
		}

		private static void AnyTile(Player p, LuiafkPlayer luiP, string[] args)
		{
						luiP.craftWithAnyTile = !luiP.craftWithAnyTile;
			Main.NewText(string.Format("Full crafting with any tile is: [C/48C600:{0}].", luiP.craftWithAnyTile ? "Enabled" : "Disabled"), orange);
		}

		private static void Error(string error)
		{
						Main.NewText("Error: Please input " + error + ".", red);
		}
	}
}
