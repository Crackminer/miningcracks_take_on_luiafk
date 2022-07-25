using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using miningcracks_take_on_luiafk.Images.Items.Misc;
using miningcracks_take_on_luiafk.Images.Items.MobileBanks;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI.Chat;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkPlayer : ModPlayer
	{
		private bool battlerCountdown;

		private bool oldSlash;

		private int settingSync;

		private int battlerCounter = 300;

		private int timer;

		private int currentTimer;

		internal int timerNeeded;

		internal int fillerMode;

		internal bool holdingFishingRod;

		internal bool stupidDeeps;

		internal bool moneyCollect;

		internal bool unlimitedMana;

		internal bool infiniteAmmoDisabled;

		internal bool craftWithAnyTile;

		internal int mobileMerchantDelete = -1;

		internal int deepsDelete = -1;

		internal bool chests;

		internal int piggy = -1;

		internal int safe = -1;

		internal int defenders = -1;

		internal Vector2 velocity;

		internal Vector2 position;

		internal bool noClip;

		internal bool noDrill;

		internal DrillMode drillMode;

		internal bool mouseTileCoords;

		internal int respawnTimer = -1;

		internal bool despawnNPCsOnRespawn = true;

		internal bool goodMove;

		internal bool forwardSlash;

		internal bool stressLock;

		internal int stressLockNum;

		private static int[] coatings;

		internal bool[] buffs = new bool[81];

		internal int[] uiMultiSolutionTileX;

		internal int[] uiMultiSolutionTileY;

		internal int uiMaterial;

		internal bool uiLight;

		internal bool uiObsidian;

		internal bool uiCampfire;

		internal int uiBiome;

		internal bool uiRope;

		internal bool uiPoolBuild;

		internal bool uiSubOrMinecart;

		internal BuildingRodModes uiComboMode;

		internal int uiComboExtras;

		internal bool uiHoikRodActive;

		internal bool uiHoikRodReverse;

		internal byte uiHoikRodGap;

		internal int uiHoikRodSelected;

		internal int uiMultiSolutionType;

		internal PaintType uiPaintMode;

		internal int uiPaintType;

		internal int uiBucketType;

		internal MultiToolMode uiWireMode;

		internal bool uiDrawItemHitbox;

		internal bool uiDrawWeaponHitbox;

		internal bool uiDrawProjHitbox;

		internal bool uiDrawNPCHitbox;

		internal bool uiDrawPlayerHitbox;

		internal bool uiDrawAllHitbox;

		internal bool uiDrawDummyHitbox;

		internal PotToggles uiBuffs;

		internal Point uiBuffPosition;

		internal static bool UpdateAdjTiles { get; set; }

		internal Vector2 RecallBackPos { get; private set; } = Vector2.Zero;


		internal bool Teleported { get; private set; }

		internal void TogglesPacket(bool server)
		{
			ModPacket packet = base.Mod.GetPacket();
			((BinaryWriter)packet).Write(0);
			((BinaryWriter)packet).Write(base.Player.whoAmI);
			((BinaryWriter)packet).Write((uint)uiBuffs);
			((BinaryWriter)packet).Write(goodMove);
			if (!server)
			{
				packet.Send();
			}
			else
			{
				packet.Send(-1, base.Player.whoAmI);
			}
		}

		internal void HandleToggles(BinaryReader reader)
		{
			uiBuffs = (PotToggles)reader.ReadUInt32();
			goodMove = reader.ReadBoolean();
			if (Main.netMode == 2)
			{
				TogglesPacket(server: true);
			}
		}

		public void StartBattlerCountdown()
		{
			if ((uiBuffs & PotToggles.UltBattler) != 0)
			{
				battlerCountdown = !battlerCountdown;
				if (battlerCountdown)
				{
					return;
				}
				if (Main.netMode != 2)
				{
					Main.NewText("Ultimate Battler countdown cancelled.", Color.Green);
				}
				battlerCounter = 300;
				return;
			}
			uiBuffs ^= PotToggles.UltBattler;
		}

		private void BattlerCountdown()
		{
			if (battlerCounter == 0)
			{
				uiBuffs ^= PotToggles.UltBattler;
				battlerCounter = 300;
				battlerCountdown = false;
				UILearning.set_battler();
				if (Main.netMode != 2)
				{
					Main.NewText("Ultimate Battler disabled.", Color.Green);
				}
				if (Main.netMode == 1)
				{
					TogglesPacket(server: false);
				}
			}
			else
			{
				if (battlerCounter % 60 == 0 && Main.netMode != 2)
				{
					Main.NewText("Ultimate Battler will be disabled in " + battlerCounter / 60 + " seconds.", Color.Red);
				}
				battlerCounter--;
			}
		}

		public override void PostItemCheck()
		{
			base.PostItemCheck();
			if (UILearning.LuiP == null) return;
			Item heldItem = UILearning.LuiP.Player.HeldItem;

			if (heldItem == null)
			{
				UILearning.RightInterface.SetState(null);
				UILearning.ComboInterface.SetState(null);
				return;
			}
			if (UILearning.RightInterface?.CurrentState != null)
			{
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<HoikRodUI>()) && heldItem.Name != "Hoiktuation Rod" && heldItem.Name != "Combo Rod")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<BuildingMaterialsUI>()) && heldItem.Name != "Prison Builder" && heldItem.Name != "Subway Builder")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<skyUI>()) && heldItem.Name != "Skybridge Builder")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<PaintToolUI>()) && heldItem.Name != "All-in-One Paint Tool" && heldItem.Name != "Combo Rod")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<MultiSolutionUI>()) && heldItem.Name != "Unlimited Multi Solution")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<UltimateBucketUI>()) && heldItem.Name != "Ultimate Liquid Manipulator" && heldItem.Name != "Combo Rod")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<WiringUI>()) && heldItem.Name != "Infinite Grand Design" && heldItem.Name != "Combo Rod")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<HouseUI>()) && heldItem.Name != "Unlimited House Enabler")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<SubAndSkyUI>()) && heldItem.Name != "Minecart or Platform Builder")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<PoolBuilderUI>()) && heldItem.Name != "Pool Builder")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<HellevatorUI>()) && heldItem.Name != "Auto Hellevator")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<FishingBiomeUI>()) && heldItem.Name != "Fishing Biome Builder")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<ArenaBuilderUI>()) && heldItem.Name != "Arena Platform Builder")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}
				/*if (UILearning.RightInterface.CurrentState.Equals(UILearning.RightClickUIs<MossUI>()) && heldItem.Name != "Mossificator")
				{
					UILearning.RightInterface.SetState(null);
					return;
				}*/
			}
			if (UILearning.ComboInterface?.CurrentState != null && UILearning.ComboInterface.CurrentState.Equals(UILearning.RightClickUIs<ComboRodUI>()) && heldItem.Name != "Combo Rod")
			{
				UILearning.ComboInterface.SetState(null);
			}
		}

		public void checkPotions(Item[] b)
        {
			foreach(Item i in b)
            {
				if(!i.IsAir)
                {
					switch(i.Name)
                    {
						case "Unlimited Buffs":
							buffs[0] = true; 
							buffs[1] = true;
							break;
						case "Ultimate Battler":
							buffs[0] = true;
							buffs[2] = true;
							break;
						case "Ultimate Peaceful":
							buffs[0] = true;
							buffs[3] = true;
							break;
						case "Unlimited Travel Potion":
							buffs[0] = true;
							buffs[4] = true;
							break;
						case "Unlimited Ammo Reservation Potion":
							buffs[0] = true;
							buffs[5] = true;
							break;
						case "Unlimited Archery Potion":
							buffs[0] = true;
							buffs[6] = true;
							break;
						case "Unlimited Battle Potion":
							buffs[0] = true;
							buffs[7] = true;
							break;
						case "Unlimited Builder Potion":
							buffs[0] = true;
							buffs[8] = true;
							break;
						case "Unlimited Calming Potion":
							buffs[0] = true;
							buffs[9] = true;
							break;
						case "Unlimited Crate Potion":
							buffs[0] = true;
							buffs[10] = true;
							break;
						case "Unlimited Aquatic Buffs":
							buffs[0] = true;
							buffs[11] = true;
							break;
						case "Unlimited Danger Sense Potion":
							buffs[0] = true;
							buffs[12] = true;
							break;
						case "Unlimited Endurance Potion":
							buffs[0] = true;
							buffs[13] = true;
							break;
						case "Unlimited Featherfall Potion":
							buffs[0] = true;
							buffs[14] = true;
							break;
						case "Unlimited Fishing Potion":
							buffs[0] = true;
							buffs[15] = true;
							break;
						case "Unlimited Flipper Potion":
							buffs[0] = true;
							buffs[16] = true;
							break;
						case "Unlimited Gravitation Potion":
							buffs[0] = true;
							buffs[17] = true;
							break;
						case "Unlimited Gills Potion":
							buffs[0] = true;
							buffs[18] = true;
							break;
						case "Unlimited Heartreach Potion":
							buffs[0] = true;
							buffs[19] = true;
							break;
						case "Unlimited Hunter Potion":
							buffs[0] = true;
							buffs[20] = true;
							break;
						case "Unlimited Ichor Flask":
							buffs[0] = true;
							buffs[21] = true;
							break;
						case "Unlimited Inferno Potion":
							buffs[0] = true;
							buffs[22] = true;
							break;
						case "Unlimited Invisibility Potion":
							buffs[0] = true;
							buffs[23] = true;
							break;
						case "Unlimited Ironskin Potion":
							buffs[0] = true;
							buffs[24] = true;
							break;
						case "Unlimited Lifeforce Potion":
							buffs[0] = true;
							buffs[25] = true;
							break;
						case "Unlimited Magic Power Potion":
							buffs[0] = true;
							buffs[26] = true;
							break;
						case "Unlimited Mana Regeneration Potion":
							buffs[0] = true;
							buffs[27] = true;
							break;
						case "Unlimited Mining Potion":
							buffs[0] = true;
							buffs[28] = true;
							break;
						case "Unlimited Night Owl Potion":
							buffs[0] = true;
							buffs[29] = true;
							break;
						case "Unlimited Obsidian Skin Potion":
							buffs[0] = true;
							buffs[30] = true;
							break;
						case "Unlimited Rage Potion":
							buffs[0] = true;
							buffs[31] = true;
							break;
						case "Unlimited Recall Potion":
							buffs[0] = true;
							buffs[32] = true;
							break;
						case "Unlimited Regeneration Potion":
							buffs[0] = true;
							buffs[33] = true;
							break;
						case "Unlimited Shine Potion":
							buffs[0] = true;
							buffs[34] = true;
							break;
						case "Unlimited Sonar Potion":
							buffs[0] = true;
							buffs[35] = true;
							break;
						case "Unlimited Spelunker Potion":
							buffs[0] = true;
							buffs[36] = true;
							break;
						case "Unlimited Summoning Potion":
							buffs[0] = true;
							buffs[37] = true;
							break;
						case "Unlimited Swiftness Potion":
							buffs[0] = true;
							buffs[38] = true;
							break;
						case "Unlimited Thorns Potion":
							buffs[0] = true;
							buffs[39] = true;
							break;
						case "Unlimited Tipsy Potion":
							buffs[0] = true;
							buffs[40] = true;
							break;
						case "Unlimited Titan Potion":
							buffs[0] = true;
							buffs[41] = true;
							break;
						case "Unlimited Warmth Potion":
							buffs[0] = true;
							buffs[42] = true;
							break;
						case "Unlimited Water Walking Potion":
							buffs[0] = true;
							buffs[43] = true;
							break;
						case "Unlimited Well Fed":
							buffs[0] = true;
							buffs[44] = true;
							break;
						case "Unlimited Wormhole Potion":
							buffs[0] = true;
							buffs[45] = true;
							break;
						case "Unlimited Wrath Potion":
							buffs[0] = true;
							buffs[46] = true;
							break;
						case "Unlimited Peace Candle":
							buffs[0] = true;
							buffs[47] = true;
							break;
						case "Unlimited Water Candle":
							buffs[0] = true;
							buffs[48] = true;
							break;
						case "Unlimited Campfire":
							buffs[0] = true;
							buffs[49] = true;
							break;
						case "Unlimited Heart Lantern":
							buffs[0] = true;
							buffs[50] = true;
							break;
						case "Unlimited Honey":
							buffs[0] = true;
							buffs[51] = true;
							break;
						case "Unlimited Star in a Bottle":
							buffs[0] = true;
							buffs[52] = true;
							break;
						case "Unlimited Ammo Box":
							buffs[0] = true;
							buffs[53] = true;
							break;
						case "Unlimited Bewitching Table":
							buffs[0] = true;
							buffs[54] = true;
							break;
						case "Unlimited Crystal Ball":
							buffs[0] = true;
							buffs[55] = true;
							break;
						case "Unlimited Sharpening Station":
							buffs[0] = true;
							buffs[56] = true;
							break;
						case "Unlimited Arena Buffs":
							buffs[0] = true;
							buffs[57] = true;
							break;
						case "Unlimited Basic Buffs":
							buffs[0] = true;
							buffs[58] = true;
							break;
						case "Unlimited Battler Buffs":
							buffs[0] = true;
							buffs[59] = true;
							break;
						case "Unlimited Combat Buffs":
							buffs[0] = true;
							buffs[60] = true;
							break;
						case "Unlimited Damage Buffs":
							buffs[0] = true;
							buffs[61] = true;
							break;
						case "Unlimited Danger Buffs":
							buffs[0] = true;
							buffs[62] = true;
							break;
						case "Unlimited Defense Buffs":
							buffs[0] = true;
							buffs[63] = true;
							break;
						case "Unlimited Explorer Buffs":
							buffs[0] = true;
							buffs[64] = true;
							break;
						case "Unlimited Fishing Buffs":
							buffs[0] = true;
							buffs[65] = true;
							break;
						case "Unlimited Flight Buffs":
							buffs[0] = true;
							buffs[66] = true;
							break;
						case "Unlimited Gathering Buffs":
							buffs[0] = true;
							buffs[67] = true;
							break;
						case "Unlimited Magic Buffs":
							buffs[0] = true;
							buffs[68] = true;
							break;
						case "Unlimited Melee Buffs":
							buffs[0] = true;
							buffs[69] = true;
							break;
						case "Unlimited Peaceful Buffs":
							buffs[0] = true;
							buffs[70] = true;
							break;
						case "Unlimited Ranged Buffs":
							buffs[0] = true;
							buffs[71] = true;
							break;
						case "Unlimited Station Buffs":
							buffs[0] = true;
							buffs[72] = true;
							break;
						case "Unlimited Lesser Luck Potion":
							buffs[0] = true;
							buffs[73] = true;
							break;
						case "Unlimited Luck Potion":
							buffs[0] = true;
							buffs[74] = true;
							break;
						case "Unlimited Greater Luck Potion":
							buffs[0] = true;
							buffs[75] = true;
							break;
						case "Unlimited Ladybug":
							buffs[0] = true;
							buffs[76] = true;
							break;
						case "Unlimited Gnome":
							buffs[0] = true;
							buffs[77] = true;
							break;
						case "Unlimited Lucky Buffs":
							buffs[0] = true;
							buffs[78] = true;
							break;
						case "Unlimited Bast Statue":
							buffs[0] = true;
							buffs[79] = true;
							break;
						case "Unlimited Slice of Cake":
							buffs[0] = true;
							buffs[80] = true;
							break;
						default: 
							break;
                    }
                }
            }
        }

		private void MovePacket(bool server)
		{
			ModPacket packet = base.Mod.GetPacket();
			((BinaryWriter)packet).Write(12);
			((BinaryWriter)packet).Write(base.Player.whoAmI);
			packet.WriteVector2(base.Player.position);
			((BinaryWriter)packet).Write(velocity.X);
			((BinaryWriter)packet).Write(velocity.Y);
			((BinaryWriter)packet).Write(noClip);
			((BinaryWriter)packet).Write(noDrill);
			if (!server)
			{
				packet.Send();
			}
			else
			{
				packet.Send(-1, base.Player.whoAmI);
			}
		}

		internal void HandleMovePacket(BinaryReader reader)
		{
			base.Player.position = reader.ReadVector2();
			position = base.Player.position;
			velocity.X = reader.ReadSingle();
			velocity.Y = reader.ReadSingle();
			noClip = reader.ReadBoolean();
			noDrill = reader.ReadBoolean();
			if (Main.netMode == 2)
			{
				MovePacket(server: true);
			}
		}

		private void Reset()
		{
			buffs = null;
			buffs = new bool[81];
			holdingFishingRod = false;
			unlimitedMana = false;
			moneyCollect = false;
			if (base.Player.whoAmI == Main.myPlayer)
			{
				UpdateAdjTiles = craftWithAnyTile;
				UILearning.ResetUIs();
			}
		}

		private bool Timer(int timerType)
		{
			if (currentTimer == 0)
			{
				currentTimer = timerType;
			}
			if (currentTimer == 4)
			{
				GenderDust();
			}
			switch (timer)
			{
			case 0:
				if (currentTimer == 1 || currentTimer == 2)
				{
					SoundEngine.PlaySound(in SoundID.Item6, base.Player.position);
				}
				break;
			case 14:
				if (currentTimer == 1)
				{
					RecallBackPos = base.Player.position;
				}
				break;
			case 15:
				switch (currentTimer)
				{
				case 1:
					Recall(home: true);
					return true;
				case 2:
					Recall(home: false);
					return true;
				case 3:
					Teleport();
					return true;
				default:
					GenderChange();
					return true;
				}
			}
			timer++;
			return false;
		}

		private void GenderDust()
		{
																																																															float num = (float)base.Player.inventory[base.Player.selectedItem].useTime / PlayerLoader.UseTimeMultiplier(base.Player, base.Player.inventory[base.Player.selectedItem]);
			num = (num - (float)base.Player.itemTime) / num;
			float num2 = 44f;
			float num3 = (float)Math.PI * 3f;
			Vector2 val = Utils.RotatedBy(new Vector2(15f, 0f), num3 * num);
			val.X *= base.Player.direction;
			Vector2 val2 = default(Vector2);
			for (int i = 0; i < 2; i++)
			{
				int type = 221;
				if (i == 1)
				{
					val.X *= -1f;
					type = 219;
				}
				val2.ToWorldCoordinates(val.X, num2 * (1f - num) - num2 + (float)(base.Player.height / 2));
				val2 += base.Player.Center;
				Dust obj = Main.dust[Dust.NewDust(val2, 0, 0, type, 0f, 0f, 100)];
				obj.position = val2;
				obj.noGravity = true;
				obj.velocity = Vector2.Zero;
				obj.scale = 1.3f;
				obj.customData = base.Player;
			}
		}

		private void GenderChange()
		{
			base.Player.Male = !base.Player.Male;
			if (Main.netMode == 1)
			{
				NetMessage.SendData(4, -1, -1, null, base.Player.whoAmI);
			}
		}

		private void Teleport()
		{
			if (Main.netMode == 0)
			{
				Teleported = true;
				base.Player.TeleportationPotion();
			}
			else if (Main.netMode == 1 && base.Player.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData(73);
			}
		}

		private void Recall(bool home)
		{
			for (int i = 0; i < 70; i++)
			{
				Dust obj = Main.dust[Dust.NewDust(base.Player.position, base.Player.width, base.Player.height, 15, base.Player.velocity.X * 0.2f, base.Player.velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)];
				obj.velocity *= 0.5f;
			}
			base.Player.grappling[0] = -1;
			base.Player.grapCount = 0;
			for (int j = 0; j < 1000; j++)
			{
				if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && Main.projectile[j].aiStyle == 7)
				{
					Main.projectile[j].Kill();
				}
			}
			Teleported = true;
			if (home)
			{
				RecallHome();
			}
			else
			{
				RecallBack();
			}
			for (int k = 0; k < 70; k++)
			{
				Dust obj2 = Main.dust[Dust.NewDust(base.Player.position, base.Player.width, base.Player.height, 15, 0f, 0f, 150, Color.Cyan, 1.2f)];
				obj2.velocity *= 0.5f;
			}
		}

		private void RecallHome()
		{
			bool immune = base.Player.immune;
			int immuneTime = base.Player.immuneTime;
			base.Player.Spawn(PlayerSpawnContext.RecallFromItem);
			base.Player.immune = immune;
			base.Player.immuneTime = immuneTime;
		}

		private void RecallBack()
		{
			base.Player.noFallDmg = true;
			base.Player.Teleport(RecallBackPos);
			RecallBackPos = Vector2.Zero;
		}

		public override void SaveData(TagCompound tag)
		{
			tag = new TagCompound
			{
				{ "noClip", noClip },
				{ "noDrill", noDrill },
				{ "respawnTimer", respawnTimer },
				{ "despawnNPCsOnRespawn", despawnNPCsOnRespawn },
				{
					"drillMode",
					(byte)drillMode
				},
				{ "forwardSlash", forwardSlash },
				{ "stressLock", stressLock },
				{ "stressLockNum", stressLockNum },
				{ "mouseTileCoords", mouseTileCoords },
				{ "goodMove", goodMove },
				{ "infiniteAmmoDisabled", infiniteAmmoDisabled },
				{ "craftWithAnyTile", craftWithAnyTile },
			};
			SaveUI(tag);
		}

		public override void LoadData(TagCompound tag)
		{
			noClip = tag.Get<bool>("noClip");
			noDrill = tag.Get<bool>("noDrill");
			respawnTimer = (tag.ContainsKey("respawnTimer") ? tag.Get<int>("respawnTimer") : (-1));
			despawnNPCsOnRespawn = !tag.ContainsKey("despawnNPCsOnRespawn") || tag.Get<bool>("despawnNPCsOnRespawn");
			drillMode = (DrillMode)tag.Get<byte>("drillMode");
			forwardSlash = tag.Get<bool>("forwardSlash");
			stressLock = tag.Get<bool>("stressLock");
			stressLockNum = tag.Get<int>("stressLockNum");
			mouseTileCoords = tag.Get<bool>("mouseTileCoords");
			goodMove = tag.Get<bool>("goodMove");
			infiniteAmmoDisabled = tag.Get<bool>("infiniteAmmoDisabled");
			craftWithAnyTile = tag.Get<bool>("craftWithAnyTile");
			LoadUI(tag);
		}

		public override void OnEnterWorld(Player player)
		{
			if (goodMove)
			{
				if (TileChecks.InGameWorld(player.SpawnX, player.SpawnY))
				{
					position = new Vector2((float)(player.SpawnX << 4), (float)(player.SpawnY << 4));
				}
				else
				{
					position = new Vector2((float)(Main.spawnTileX << 4), (float)(Main.spawnTileY << 4));
				}
			}
			UILearning.OnEnterWorld(player);
			uiMultiSolutionTileX = new int[3] { -1, -1, -1 };
			uiMultiSolutionTileY = new int[2] { -1, -1 };
			if (Main.netMode == 1)
			{
				LuiafkWorld.RequestTelePoints();
			}
		}

		public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
		{
			if (base.Player.anglerQuestsFinished == 35)
			{
				Item item = new Item();
				item.SetDefaults(2422);
				rewardItems.Add(item);
			}
			if (base.Player.whoAmI == Main.myPlayer && base.Player.anglerQuestsFinished % 5 == 0)
			{
				string text = (base.Player.anglerQuestsFinished / 5 + 1).ToString();
				if (Main.netMode != 2)
				{
					Main.NewText((object)"Congratulations, your fishing skill has increased!", (Color?)new Color(255, 255, 0));
					Main.NewText((object)("You can now fish with " + text + " bobbers instead of one when using unlimited rods."), (Color?)new Color(255, 255, 0));
				}
			}
		}

		/*public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			if (!Main.hardMode && attempt.rolledItemDrop == 2331)
			{
				if (Main.rand.NextBool(3))
				{
					attempt.rolledItemDrop = 2312;
				}
				else
				{
					attempt.rolledItemDrop = 2315;
				}
			}
		}*/

		public override void SetControls()
		{
			if (base.Player.whoAmI == Main.myPlayer && chests)
			{
				Main.SmartCursorShowing = false;
				Player.tileRangeX = 9999;
				Player.tileRangeY = 5000;
				if (base.Player.chest >= -1)
				{
					piggy = -1;
					safe = -1;
					defenders = -1;
					chests = false;
				}
				if (piggy != -1 && Main.projectile[piggy].type != base.Mod.Find<ModProjectile>("PiggyBankProjectile").Type)
				{
					piggy = -1;
					chests = false;
				}
				if (safe != -1 && Main.projectile[safe].type != base.Mod.Find<ModProjectile>("SafeProjectile").Type)
				{
					safe = -1;
					chests = false;
				}
				if (defenders != -1 && Main.projectile[defenders].type != base.Mod.Find<ModProjectile>("DefendersForgeProjectile").Type)
				{
					defenders = -1;
					chests = false;
				}
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			PotionHotkeys();
			if (LuiafkMod.LuiafkSettings.JustPressed)
			{
				if (UILearning.BuffInterface?.CurrentState != null)
				{
					UILearning.BuffInterface?.SetState(null);
				}
				else
				{
					UILearning.BuffInterface?.SetState(UILearning.BuffUI);
					UILearning.BuffUI.buttonUpdates();
				}
			}
			if (forwardSlash)
			{
				KeyboardState keyState = Main.keyState;
				bool flag = ((KeyboardState)(keyState)).IsKeyDown((Keys)191);
				if (flag && flag != oldSlash)
				{
					Main.drawingPlayerChat = true;
					PlayerInput.WritingText = true;
					Main.chatText = "/luiafk ";
				}
				oldSlash = flag;
			}
		}

		public override void PreUpdate()
		{
			Teleported = base.Player.teleportTime == 1f;
		}

		public override void ResetEffects()
		{
			Reset();
		}

		public override void UpdateDead()
		{
			Reset();
			if (base.Player.whoAmI != Main.myPlayer || respawnTimer < 0 || base.Player.respawnTimer <= respawnTimer * 60)
			{
				return;
			}
			base.Player.respawnTimer = respawnTimer * 60;
			if (base.Player.lostCoins > 0)
			{
				Main.NewText((object)string.Format("{0} {1}", base.Player.name, Language.GetTextValue("Game.DroppedCoins", base.Player.lostCoinString)), (Color?)new Color(255, 85, 0));
			}
			if (despawnNPCsOnRespawn)
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
		}

		public override void PostUpdateBuffs()
		{
			if (goodMove || base.Player.mount.Type == base.Mod.Find<ModMount>("DrillMountMount").Type)
			{
				if (noClip)
				{
					base.Player.buffImmune[68] = true;
				}
				Drilling.DrillStuff(base.Player, this);
			}
		}

		public override void UpdateEquips()
		{
			if (goodMove || base.Player.mount.Type == base.Mod.Find<ModMount>("DrillMountMount").Type)
			{
				base.Player.gills = true;
				base.Player.lavaImmune = true;
			}
			if ((base.Player.whoAmI != Main.myPlayer && Main.netMode != 2) || !base.Player.active || base.Player.dead || !buffs[0])
			{
				return;
			}
			//only gets here if you have one unlimited buffs active
			Item[] item = base.Player.bank.item;
			for (int i = 0; i < item.Length; i++)
			{
				int type = item[i].type;
				if (type == 3124 || type == 3123 || type == 395 || type == 17 || type == 709)
				{
					base.Player.accWatch = 3;
				}
				else
				{
					if (base.Player.accWatch < 2 && (type == 708 || type == 16))
					{
						base.Player.accWatch = 2;
						continue;
					}
					if (base.Player.accWatch < 1 && (type == 707 || type == 15))
					{
						base.Player.accWatch = 1;
						continue;
					}
				}
				if (type == 3124 || type == 3123 || type == 395 || type == 393)
				{
					base.Player.accCompass = 1;
				}
				if (type == 3124 || type == 3123 || type == 395 || type == 18)
				{
					base.Player.accDepthMeter = 1;
				}
				if (type == 3124 || type == 3123 || type == 3036 || type == 3120)
				{
					base.Player.accCalendar = true;
				}
				if (type == 3124 || type == 3123 || type == 3036 || type == 3037)
				{
					base.Player.accWeatherRadio = true;
				}
				if (type == 3124 || type == 3123 || type == 3036 || type == 3096)
				{
					base.Player.accFishFinder = true;
				}
				if (type == 3124 || type == 3123 || type == 3121 || type == 3102)
				{
					base.Player.accOreFinder = true;
				}
				if (type == 3124 || type == 3123 || type == 3121 || type == 3099)
				{
					base.Player.accStopwatch = true;
				}
				if (type == 3124 || type == 3123 || type == 3121 || type == 3119)
				{
					base.Player.accDreamCatcher = true;
				}
				if (type == 3124 || type == 3123 || type == 3122 || type == 3095)
				{
					base.Player.accJarOfSouls = true;
				}
				if (type == 3124 || type == 3123 || type == 3122 || type == 3118)
				{
					base.Player.accCritterGuide = true;
				}
				if (type == 3124 || type == 3123 || type == 3122 || type == 3084)
				{
					base.Player.accThirdEye = true;
				}
			}
		}

		internal bool checkBoulder(Item[] i)
        {
			foreach(Item item in i)
            {
				if(!item.IsAir)
                {
					if (item.type == ModContent.ItemType<FastFall>() && item.favorited) return true;
                }
            }
			return false;
        }

		public override void PostUpdateEquips()
		{
			checkPotions(Player.bank.item);
			checkPotions(Player.bank2.item);
			checkPotions(Player.bank3.item);
			checkPotions(Player.bank4.item);
			
			if (checkBoulder(Player.inventory))
			{
				base.Player.maxFallSpeed = 28f;
			}
			if (buffs[0])
			{
				UpdatePotions();
			}
		}

		public override void PostUpdateMiscEffects()
		{
			if (LuiafkMod.CalamityLoaded && stressLock)
			{
				MiscMethods.StressChange(base.Player, stressLockNum);
			}
		}

		internal int ticks = 0;

		public override void PostUpdate()
		{
			if (Main.netMode != 2)
			{
				if (battlerCountdown)
				{
					BattlerCountdown();
				}
				if (timerNeeded > 0 && Timer(timerNeeded))
				{
					timer = 0;
					timerNeeded = 0;
					currentTimer = 0;
				}
			}
			if (unlimitedMana)
			{
				base.Player.statMana = base.Player.statManaMax2;
			}
			if (goodMove || base.Player.mount.Type == base.Mod.Find<ModMount>("DrillMountMount").Type)
			{
				Movement.GoodMove(base.Player, this);
				if (Main.netMode == 1 && base.Player.whoAmI == Main.myPlayer)
				{
					MovePacket(server: false);
				}
			}
			Teleported = false;
			if (base.Player.whoAmI == Main.myPlayer)
			{
				if (moneyCollect)
				{
					MoneyCollector.UpdateCoins(base.Player);
				}
				if (Main.netMode == 1 && ++settingSync > 60)
				{
					settingSync = 0;
					TogglesPacket(server: false);
				}
			}

			if (Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On)
			{
				if ((UILearning.BuffInterface?.CurrentState != null || UILearning.RightInterface?.CurrentState != null || UILearning.ComboInterface?.CurrentState != null) && ticks >= 30)
				{
					ticks = 0;
					if (Main.netMode != 2)
					{
						Main.NewText("[LuiAFK] Please set FrameSkip to Subtle or Off for the GUIs to work!");
					}
				}
				ticks++;
			}
		}

		internal static void InitCoatings()
		{
			/*if (LuiafkMod.ThoriumLoaded)
			{
				coatings = new int[5]
				{
					LuiafkMod.ThoriumMod.Find<ModItem>("ExplosiveCoating").Type,
					LuiafkMod.ThoriumMod.Find<ModItem>("DeepFreezeCoating").Type,
					LuiafkMod.ThoriumMod.Find<ModItem>("GorganCoating").Type,
					LuiafkMod.ThoriumMod.Find<ModItem>("SporeCoating").Type,
					LuiafkMod.ThoriumMod.Find<ModItem>("ToxicCoating").Type
				};
			}*/
		}

		internal void PotionHotkeys()
		{
			if ((buffs[32] || buffs[4] || buffs[1]) && base.Player.itemAnimation == 0)
			{
				if (LuiafkMod.LuiafkRecall.JustPressed)
				{
					timerNeeded = 1;
				}
				if (LuiafkMod.LuiafkRecallBack.JustPressed && TileChecks.InGameWorld((int)RecallBackPos.X >> 4, (int)RecallBackPos.Y >> 4))
				{
					timerNeeded = 2;
				}
			}
		}

		internal void UpdatePotions()
		{
			if (buffs[49] || buffs[57] || buffs[60] || buffs[1])
			{
				if (Main.myPlayer == base.Player.whoAmI || Main.netMode == 2)
				{
					Main.SceneMetrics.HasCampfire = true;
				}
				base.Player.buffImmune[87] = true;
			}
			if (buffs[50] || buffs[57] || buffs[60] || buffs[1])
			{
				if (Main.myPlayer == base.Player.whoAmI || Main.netMode == 2)
				{
					Main.SceneMetrics.HasHeartLantern = true;
				}
				base.Player.buffImmune[89] = true;
			}
			if (buffs[51] || buffs[57] || buffs[60] || buffs[1])
			{
				base.Player.honey = true;
				base.Player.buffImmune[48] = true;
			}
			if (buffs[52] || buffs[57] || buffs[60] || buffs[1])
			{
				if (Main.myPlayer == base.Player.whoAmI || Main.netMode == 2)
				{
					Main.SceneMetrics.HasStarInBottle = false;
				}
				base.Player.manaRegenBonus += 2;
				base.Player.buffImmune[158] = true;
			}
			if (buffs[47] || buffs[70] || buffs[3] || buffs[1])
			{
				base.Player.ZonePeaceCandle = true;
				if (Main.myPlayer == base.Player.whoAmI)
				{
					Main.SceneMetrics.PeaceCandleCount = 0;
				}
				base.Player.buffImmune[157] = true;
			}
			if (buffs[48] || buffs[59] || buffs[2] || buffs[1])
			{
				base.Player.ZoneWaterCandle = true;
				if (base.Player.whoAmI == Main.myPlayer)
				{
					Main.SceneMetrics.WaterCandleCount = 0;
				}
				base.Player.buffImmune[86] = true;
			}
			if (buffs[5] || buffs[71] || buffs[60] || buffs[1])
			{
				base.Player.ammoPotion = true;
				base.Player.buffImmune[112] = true;
			}
			if (buffs[6] || buffs[71] || buffs[60] || buffs[1])
			{
				base.Player.archery = true;
				base.Player.arrowDamage.Flat *= 0.2f;
				base.Player.buffImmune[16] = true;
			}
			if (buffs[7] || buffs[59] || buffs[2] || buffs[1])
			{
				base.Player.enemySpawns = true;
				base.Player.buffImmune[13] = true;
			}
			if (buffs[8] || buffs[64] || buffs[1])
			{
				base.Player.tileSpeed += 0.25f;
				base.Player.wallSpeed += 0.25f;
				base.Player.blockRange++;
				base.Player.buffImmune[107] = true;
			}
			if (buffs[9] || buffs[70] || buffs[3] || buffs[1])
			{
				base.Player.calmed = true;
				base.Player.buffImmune[106] = true;
			}
			if ((buffs[10] || buffs[65] || buffs[1]) && (uiBuffs & PotToggles.Crate) != 0)
			{
				base.Player.cratePotion = true;
				base.Player.buffImmune[123] = true;
			}
			if ((buffs[12] || buffs[62] || buffs[64] || buffs[1]) && (uiBuffs & PotToggles.DangerHunter) != 0)
			{
				base.Player.dangerSense = true;
				base.Player.buffImmune[111] = true;
			}
			if (buffs[13] || buffs[63] || buffs[60] || buffs[1])
			{
				base.Player.endurance += 0.1f;
				base.Player.buffImmune[114] = true;
			}
			if ((buffs[14] || buffs[66] || buffs[1]) && (uiBuffs & PotToggles.Feather) != 0)
			{
				base.Player.slowFall = true;
				base.Player.buffImmune[8] = true;
			}
			if (buffs[15] || buffs[65] || buffs[1])
			{
				base.Player.fishingSkill += 15;
				base.Player.buffImmune[121] = true;
			}
			if (buffs[16] || buffs[11] || buffs[64] || buffs[1])
			{
				base.Player.ignoreWater = true;
				base.Player.accFlipper = true;
				base.Player.buffImmune[109] = true;
			}
			if (buffs[18] || buffs[11] || buffs[64] || buffs[1])
			{
				base.Player.gills = true;
				base.Player.buffImmune[4] = true;
			}
			if ((buffs[17] || buffs[66] || buffs[1]) && (uiBuffs & PotToggles.Grav) != 0)
			{
				base.Player.gravControl = true;
				base.Player.buffImmune[18] = true;
			}
			if (buffs[19] || buffs[63] || buffs[60] || buffs[1])
			{
				base.Player.lifeMagnet = true;
				base.Player.buffImmune[105] = true;
			}
			if ((buffs[20] || buffs[62] || buffs[64] || buffs[1]) && (uiBuffs & PotToggles.DangerHunter) != 0)
			{
				base.Player.detectCreature = true;
				base.Player.buffImmune[17] = true;
			}
			if (buffs[21] || buffs[69] || buffs[60] || buffs[1])
			{
				base.Player.meleeEnchant = 5;
				base.Player.buffImmune[71] = true;
				base.Player.buffImmune[73] = true;
				base.Player.buffImmune[74] = true;
				base.Player.buffImmune[75] = true;
				base.Player.buffImmune[76] = true;
				base.Player.buffImmune[77] = true;
				base.Player.buffImmune[79] = true;
			}
			if (buffs[22] || buffs[61] || buffs[60] || buffs[1])
			{
				base.Player.inferno = (uiBuffs & PotToggles.Inferno) != 0;
				Lighting.AddLight((int)base.Player.Center.X >> 4, (int)base.Player.Center.Y >> 4, 0.65f, 0.4f, 0.1f);
				float num = 40000f;
				bool flag = base.Player.infernoCounter % 60 == 0;
				int damage = 10;
				if (base.Player.whoAmI == Main.myPlayer)
				{
					for (int i = 0; i < 200; i++)
					{
						NPC nPC = Main.npc[i];
						if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[24] && Vector2.DistanceSquared(base.Player.Center, nPC.Center) <= num)
						{
							if (nPC.FindBuffIndex(24) == -1)
							{
								nPC.AddBuff(24, 120);
							}
							if (flag)
							{
								base.Player.ApplyDamageToNPC(nPC, damage, 0f, 0, crit: false);
							}
						}
					}
					if (Main.netMode != 0 && base.Player.hostile)
					{
						for (int j = 0; j < 255; j++)
						{
							Player player = Main.player[j];
							if (player != base.Player && player.active && !player.dead && player.hostile && !player.buffImmune[24] && (player.team != base.Player.team || player.team == 0) && Vector2.DistanceSquared(base.Player.Center, player.Center) <= num)
							{
								if (player.FindBuffIndex(24) == -1)
								{
									player.AddBuff(24, 120);
								}
								if (flag)
								{
									player.Hurt(PlayerDeathReason.LegacyEmpty(), damage, 0, pvp: true, quiet: false, Crit: false, 120);
									PlayerDeathReason reason = PlayerDeathReason.ByPlayer(base.Player.whoAmI);
									NetMessage.SendPlayerHurt(j, reason, damage, 0, critical: false, pvp: true, 0, 120, 120);
								}
							}
						}
					}
				}
				base.Player.buffImmune[116] = true;
			}
			if ((buffs[23] || buffs[1]) && (uiBuffs & PotToggles.Invis) != 0)
			{
				base.Player.invis = true;
				base.Player.buffImmune[10] = true;
			}
			if (buffs[24] || buffs[58] || buffs[60] || buffs[1])
			{
				base.Player.statDefense += 8;
				base.Player.buffImmune[5] = true;
			}
			if (buffs[25] || buffs[63] || buffs[60] || buffs[1])
			{
				base.Player.lifeForce = true;
				base.Player.statLifeMax2 += base.Player.statLifeMax / 5 / 20 * 20;
				base.Player.buffImmune[113] = true;
			}
			if (buffs[26] || buffs[68] || buffs[60] || buffs[1])
			{
				base.Player.GetDamage(DamageClass.Magic) += 0.2f;
				base.Player.buffImmune[7] = true;
			}
			if (buffs[27] || buffs[68] || buffs[60] || buffs[1])
			{
				base.Player.manaRegenBuff = true;
				base.Player.buffImmune[6] = true;
			}
			if (buffs[28] || buffs[67] || buffs[64] || buffs[1])
			{
				base.Player.pickSpeed -= 0.25f;
				base.Player.buffImmune[104] = true;
			}
			if (buffs[29] || buffs[67] || buffs[64] || buffs[1])
			{
				base.Player.nightVision = true;
				base.Player.buffImmune[12] = true;
			}
			if (buffs[30] || buffs[67] || buffs[64] || buffs[1])
			{
				base.Player.lavaImmune = true;
				base.Player.fireWalk = true;
				base.Player.buffImmune[24] = true;
				base.Player.buffImmune[1] = true;
			}
			if (buffs[31] || buffs[61] || buffs[60] || buffs[1])
			{
				base.Player.GetCritChance(DamageClass.Melee) += 10f;
				base.Player.GetCritChance(DamageClass.Throwing) += 10f;
				base.Player.GetCritChance(DamageClass.Magic) += 10f;
				base.Player.GetCritChance(DamageClass.Ranged) += 10f;
				base.Player.buffImmune[115] = true;
			}
			if (buffs[33] || buffs[58] || buffs[60] || buffs[1])
			{
				base.Player.lifeRegen += 4;
				base.Player.buffImmune[2] = true;
			}
			if (buffs[34] || buffs[67] || buffs[64] || buffs[1])
			{
				Lighting.AddLight((int)base.Player.Center.X >> 4, (int)base.Player.Center.Y >> 4, 0.8f, 0.95f, 1f);
				base.Player.buffImmune[11] = true;
			}
			if (buffs[35] || buffs[65] || buffs[1])
			{
				base.Player.sonarPotion = true;
				base.Player.buffImmune[122] = true;
			}
			if ((buffs[36] || buffs[67] || buffs[64] || buffs[1]) && (uiBuffs & PotToggles.Spelunker) != 0)
			{
				base.Player.findTreasure = true;
				base.Player.buffImmune[9] = true;
			}
			if (buffs[37] || buffs[61] || buffs[60] || buffs[1])
			{
				base.Player.maxMinions++;
				base.Player.buffImmune[110] = true;
			}
			if (buffs[38] || buffs[58] || buffs[60] || buffs[1])
			{
				base.Player.moveSpeed += 0.25f;
				base.Player.buffImmune[3] = true;
			}
			if (buffs[39] || buffs[61] || buffs[60] || buffs[1])
			{
				base.Player.thorns += 0.33f;
				base.Player.buffImmune[14] = true;
			}
			if (buffs[40] || buffs[69] || buffs[60] || buffs[1])
			{
				if (base.Player.inventory[base.Player.selectedItem].CountsAsClass(DamageClass.Melee))
				{
					base.Player.statDefense -= 4;
				}
				base.Player.GetDamage(DamageClass.Melee) += 0.1f;
				base.Player.GetCritChance(DamageClass.Melee) += 2f;
				base.Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
				base.Player.buffImmune[25] = true;
			}
			if (buffs[41] || buffs[61] || buffs[60] || buffs[1])
			{
				base.Player.kbBuff = true;
				base.Player.buffImmune[108] = true;
			}
			if (buffs[42] || buffs[63] || buffs[60] || buffs[1])
			{
				base.Player.resistCold = true;
				base.Player.buffImmune[124] = true;
			}
			if (buffs[43] || buffs[11] || buffs[64] || buffs[1])
			{
				base.Player.waterWalk = true;
				base.Player.buffImmune[15] = true;
			}
			if (buffs[44] || buffs[58] || buffs[60] || buffs[1])
			{
				base.Player.wellFed = true;
				base.Player.statDefense += 4;
				base.Player.GetCritChance(DamageClass.Generic) += 4f;
				base.Player.GetDamage(DamageClass.Generic) += 0.1f;
				base.Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
				base.Player.GetKnockback(DamageClass.Summon) += 1f;
				base.Player.moveSpeed += 0.4f;
				base.Player.pickSpeed -= 0.15f;
				base.Player.buffImmune[26] = true;
			}
			if (buffs[46] || buffs[61] || buffs[60] || buffs[1])
			{
				base.Player.GetDamage(DamageClass.Generic) += 0.1f;
				base.Player.buffImmune[117] = true;
			}
			if ((buffs[45] || buffs[4] || buffs[1]) && Main.mapFullscreen && Main.netMode == 1 && Main.myPlayer == base.Player.whoAmI && base.Player.team > 0 && Main.mouseLeft && Main.mouseLeftRelease)
			{
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active && !Main.player[k].dead && k != Main.myPlayer && base.Player.team == Main.player[k].team)
					{
						float mapFullscreenScale = Main.mapFullscreenScale;
						float num2 = (Main.player[k].position.X + (float)(Main.player[k].width / 2)) / 16f * mapFullscreenScale;
						float num3 = (Main.player[k].position.Y + Main.player[k].gfxOffY + (float)(Main.player[k].height / 2)) / 16f * mapFullscreenScale;
						num2 += 0f - Main.mapFullscreenPos.X * mapFullscreenScale + (float)(Main.screenWidth / 2) - 6f;
						float num4 = num3 + (0f - Main.mapFullscreenPos.Y * mapFullscreenScale + (float)(Main.screenHeight / 2) - 4f - mapFullscreenScale / 5f * 2f);
						float num5 = num2 + 4f - 14f * Main.UIScale;
						float num6 = num4 + 2f - 14f * Main.UIScale;
						float num7 = num5 + 28f * Main.UIScale;
						float num8 = num6 + 28f * Main.UIScale;
						int mouseX = PlayerInput.MouseX;
						int mouseY = PlayerInput.MouseY;
						if ((float)mouseX >= num5 && (float)mouseX <= num7 && (float)mouseY >= num6 && (float)mouseY <= num8)
						{
							SoundEngine.PlaySound(in SoundID.Item12, (Vector2?)new Vector2(-1f, 120f));
							Main.mouseLeftRelease = false;
							Main.mapFullscreen = false;
							base.Player.UnityTeleport(Main.player[k].position);
							break;
						}
					}
				}
			}
			if (buffs[53] || buffs[72] || buffs[60] || buffs[1])
			{
				base.Player.ammoBox = true;
				base.Player.buffImmune[93] = true;
			}
			if (buffs[54] || buffs[72] || buffs[60] || buffs[1])
			{
				base.Player.maxMinions++;
				base.Player.buffImmune[150] = true;
			}
			if (buffs[55] || buffs[72] || buffs[60] || buffs[1])
			{
				base.Player.GetDamage(DamageClass.Magic) += 0.05f;
				base.Player.GetCritChance(DamageClass.Magic) += 2f;
				base.Player.statManaMax2 += 20;
				base.Player.manaCost -= 0.02f;
				base.Player.buffImmune[29] = true;
			}
			if (buffs[56] || buffs[72] || buffs[60] || buffs[1])
			{
				if (base.Player.inventory[base.Player.selectedItem].DamageType.Type == DamageClass.Melee.Type)
				{
					base.Player.GetArmorPenetration(DamageClass.Melee) += 4f;
				}
				base.Player.buffImmune[159] = true;
			}
			if (buffs[75] || buffs[78] || buffs[1])
            {
				base.Player.luck += 0.3f;
				base.Player.buffImmune[257] = true;
			}
			if (buffs[76] || buffs[78] || buffs[1])
            {
				base.Player.luck += 0.3f;
			}
			if (buffs[77] || buffs[78] || buffs[1])
            {
				base.Player.luck += 0.2f;
			}
			if (buffs[78] || buffs[1])
			{
				if (base.Player.unlockedBiomeTorches)
				{
					base.Player.luck += 0.2f;
				}
			}
            if (buffs[79] || buffs[57] || buffs[1])
            {
				base.Player.statDefense += 5;
				base.Player.buffImmune[215] = true;
            }
			if (buffs[80] || buffs[72] || buffs[1])
			{
				base.Player.pickSpeed -= 0.2f;
				base.Player.moveSpeed += 0.2f;
				base.Player.buffImmune[192] = true;
			}
			if ((buffs[3] || buffs[1]) && (uiBuffs & PotToggles.UltPeaceful) != 0)
			{
				if (base.Player.whoAmI == Main.myPlayer)
				{
					Main.SceneMetrics.PeaceCandleCount = 0;
					Main.SceneMetrics.WaterCandleCount = 0;
					Main.SceneMetrics.HasSunflower = true;
				}
				base.Player.enemySpawns = false;
				base.Player.ZoneWaterCandle = false;
				base.Player.ZonePeaceCandle = true;
				base.Player.calmed = true;
				base.Player.sunflower = true;
				base.Player.moveSpeed += 0.1f;
				base.Player.moveSpeed *= 1.1f;
				base.Player.buffImmune[146] = true;
				base.Player.buffImmune[86] = true;
				base.Player.buffImmune[13] = true;
				base.Player.buffImmune[157] = true;
				base.Player.buffImmune[106] = true;
			}
			if ((buffs[2] || buffs[1]) && (uiBuffs & PotToggles.UltBattler) != 0)
			{
				if (base.Player.whoAmI == Main.myPlayer)
				{
					Main.SceneMetrics.PeaceCandleCount = 0;
					Main.SceneMetrics.WaterCandleCount = 0;
					Main.SceneMetrics.HasSunflower = false;
				}
				base.Player.enemySpawns = true;
				base.Player.ZoneWaterCandle = true;
				base.Player.ZonePeaceCandle = false;
				base.Player.calmed = false;
				base.Player.sunflower = false;
				base.Player.buffImmune[146] = true;
				base.Player.buffImmune[157] = true;
				base.Player.buffImmune[106] = true;
				base.Player.buffImmune[86] = true;
				base.Player.buffImmune[13] = true;
			}
			bool thorium = false;
			for (int l = 0; l < 50; l++)
			{
				CheckBuffItem(base.Player.inventory[l], ref thorium);
			}
			for (int m = 0; m < 40; m++)
			{
				CheckBuffItem(base.Player.bank.item[m], ref thorium);
			}
		}

		private void CheckBuffItem(Item item, ref bool thorium)
		{
			if (item.buffType > 0 && item.stack >= 30 && !base.Player.buffImmune[item.buffType])
			{
				base.Player.AddBuff(item.buffType, 5);
				Main.buffNoTimeDisplay[item.buffType] = true;
			}
			else if (LuiafkMod.ThoriumLoaded && !thorium && coatings.Contains(item.type))
			{
				item.ModItem.UseItem(base.Player);
				thorium = true;
			}
		}

		private void LoadUI(TagCompound tag)
		{
			uiMaterial = tag.Get<int>("uiMaterial");
			uiLight = tag.Get<bool>("uiLight");
			uiObsidian = tag.Get<bool>("uiObsidian");
			uiCampfire = tag.Get<bool>("uiCampfire");
			uiBiome = tag.Get<int>("uiBiome");
			uiRope = tag.Get<bool>("uiRope");
			uiPoolBuild = tag.Get<bool>("uiPoolBuild");
			uiSubOrMinecart = tag.Get<bool>("uiSubOrMinecart");
			uiComboMode = (BuildingRodModes)tag.Get<byte>("uiComboMode");
			uiComboExtras = tag.Get<int>("uiComboExtras");
			uiHoikRodActive = tag.Get<bool>("uiHoikRodActive");
			uiHoikRodReverse = tag.Get<bool>("uiHoikRodReverse");
			uiHoikRodGap = tag.Get<byte>("uiHoikRodGap");
			uiHoikRodSelected = tag.Get<int>("uiHoikRodSelected");
			uiMultiSolutionType = tag.Get<int>("uiMultiSolutionType");
			uiPaintMode = (PaintType)tag.Get<byte>("uiPaintMode");
			uiPaintType = tag.Get<int>("uiPaintType");
			uiBucketType = tag.Get<int>("uiBucketType");
			uiWireMode = (MultiToolMode)tag.Get<byte>("uiWireMode");
			uiDrawItemHitbox = tag.Get<bool>("uiDrawItemHitbox");
			uiDrawWeaponHitbox = tag.Get<bool>("uiDrawWeaponHitbox");
			uiDrawProjHitbox = tag.Get<bool>("uiDrawProjHitbox");
			uiDrawNPCHitbox = tag.Get<bool>("uiDrawNPCHitbox");
			uiDrawPlayerHitbox = tag.Get<bool>("uiDrawPlayerHitbox");
			uiDrawAllHitbox = tag.Get<bool>("uiDrawAllHitbox");
			uiDrawDummyHitbox = tag.Get<bool>("uiDrawDummyHitbox");
			uiBuffs = (PotToggles)tag.Get<ushort>("uiBuffs");
			uiBuffPosition = new Point(tag.Get<int>("uiBuffPositionX"), tag.Get<int>("uiBuffPositionY"));
		}

		private void SaveUI(TagCompound tag)
		{
			tag.Add("uiMaterial", uiMaterial);
			tag.Add("uiLight", uiLight);
			tag.Add("uiObsidian", uiObsidian);
			tag.Add("uiCampfire", uiCampfire);
			tag.Add("uiBiome", uiBiome);
			tag.Add("uiRope", uiRope);
			tag.Add("uiPoolBuild", uiPoolBuild);
			tag.Add("uiSubOrMinecart", uiSubOrMinecart);
			tag.Add("uiComboMode", (byte)uiComboMode);
			tag.Add("uiComboExtras", uiComboExtras);
			tag.Add("uiHoikRodActive", uiHoikRodActive);
			tag.Add("uiHoikRodReverse", uiHoikRodReverse);
			tag.Add("uiHoikRodGap", uiHoikRodGap);
			tag.Add("uiHoikRodSelected", uiHoikRodSelected);
			tag.Add("uiPaintMode", (byte)uiPaintMode);
			tag.Add("uiPaintType", uiPaintType);
			tag.Add("uiBucketType", uiBucketType);
			tag.Add("uiWireMode", (byte)uiWireMode);
			tag.Add("uiDrawItemHitbox", uiDrawItemHitbox);
			tag.Add("uiDrawWeaponHitbox", uiDrawWeaponHitbox);
			tag.Add("uiDrawProjHitbox", uiDrawProjHitbox);
			tag.Add("uiDrawNPCHitbox", uiDrawNPCHitbox);
			tag.Add("uiDrawPlayerHitbox", uiDrawPlayerHitbox);
			tag.Add("uiDrawAllHitbox", uiDrawAllHitbox);
			tag.Add("uiDrawDummyHitbox", uiDrawDummyHitbox);
			tag.Add("uiBuffs", (ushort)uiBuffs);
			tag.Add("uiBuffPositionX", uiBuffPosition.X);
			tag.Add("uiBuffPositionY", uiBuffPosition.Y);
		}
	}
}
