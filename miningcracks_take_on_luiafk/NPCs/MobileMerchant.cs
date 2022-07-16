using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.NPCs
{
	public class MobileMerchant : ModNPC
	{
		private int timer;

		private LuiafkPlayer luiP;

		public override string Texture => "miningcracks_take_on_luiafk/Images/NPCs/MobileMerchant/MobileMerchantAll";

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fairy Merchant");
			Main.npcFrameCount[base.NPC.type] = 16;
		}

		public override void SetDefaults()
		{
			base.NPC.townNPC = true;
			base.NPC.homeless = false;
			base.NPC.friendly = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.aiStyle = -1;
			base.NPC.damage = 0;
			base.NPC.width = 54;
			base.NPC.height = 34;
			base.NPC.immortal = true;
			base.NPC.trapImmune = true;
			base.NPC.dontTakeDamage = true;
			base.NPC.dontTakeDamageFromHostiles = true;
			base.NPC.lavaImmune = true;
			base.NPC.defense = 30;
			base.NPC.lifeMax = 250;
			base.NPC.homeTileX = 5;
			base.NPC.homeTileY = 5;
			/*if (LuiafkMod.CalamityLoaded)
			{
				base.NPC.buffImmune[LuiafkMod.CalamityMod.Find<ModBuff>("ExoFreeze").Type] = true;
				base.NPC.buffImmune[LuiafkMod.CalamityMod.Find<ModBuff>("GlacialState").Type] = true;
			}*/
		}

		public override void FindFrame(int frameHeight)
		{
			if (Main.netMode != 2)
			{
				Lighting.AddLight(base.NPC.Center, 1.3f, 1.3f, 1.3f);
				base.NPC.frame.Y = (int)(base.NPC.frameCounter * (double)frameHeight);
				if (timer % 7 == 0)
				{
					base.NPC.frameCounter += 1.0;
				}
				if (base.NPC.frameCounter > 15.0)
				{
					base.NPC.frameCounter = 0.0;
				}
				if (Main.netMode == 1)
				{
					timer++;
				}
			}
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool PreAI()
		{
			if (Main.netMode != 1)
			{
				if (base.NPC.breath < 200)
				{
					base.NPC.breath = 200;
				}
				if (timer == 0)
				{
					for (int i = 0; i < 30; i++)
					{
						Dust.NewDust(base.NPC.position, base.NPC.width / 2, base.NPC.height / 2, Main.rand.Next(139, 143), Main.rand.Next(-3, 4), Main.rand.Next(-3, 4), 0, default(Color), 1.2f);
					}
					luiP = Main.player[(int)base.NPC.ai[2]].GetModPlayer<LuiafkPlayer>();
					if (luiP.Player.active && luiP.mobileMerchantDelete == base.NPC.whoAmI)
					{
						timer++;
						return false;
					}
					MiscMethods.Despawn(base.NPC.whoAmI);
					return false;
				}
				if (luiP == null)
				{
					MiscMethods.Despawn(base.NPC.whoAmI);
					return false;
				}
				if (!luiP.Player.active || luiP.mobileMerchantDelete != base.NPC.whoAmI || ++timer > 10800)
				{
					if (luiP.deepsDelete == base.NPC.whoAmI)
					{
						luiP.deepsDelete = -1;
					}
					MiscMethods.Despawn(base.NPC.whoAmI);
					return false;
				}
			}
			if (base.NPC.ai[0] == 0f)
			{
				if (base.NPC.velocity.LengthSquared() < 0.01f)
				{
					base.NPC.velocity.X = 0f;
					base.NPC.velocity.Y = 0f;
					base.NPC.ai[0] = 1f;
					base.NPC.ai[1] = 45f;
					return false;
				}
				NPC nPC = base.NPC;
				nPC.velocity *= 0.94f;
				if (base.NPC.velocity.X < 0f)
				{
					base.NPC.direction = -1;
				}
				else
				{
					base.NPC.direction = 1;
				}
				base.NPC.spriteDirection = base.NPC.direction;
			}
			else
			{
				if (Main.player[Main.myPlayer].Center.X < base.NPC.Center.X)
				{
					base.NPC.direction = -1;
				}
				else
				{
					base.NPC.direction = 1;
				}
				base.NPC.spriteDirection = base.NPC.direction;
				base.NPC.ai[1] += 1f;
				float num = 0.005f;
				if (base.NPC.ai[1] > 0f)
				{
					base.NPC.velocity.Y = base.NPC.velocity.Y - num;
				}
				else
				{
					base.NPC.velocity.Y = base.NPC.velocity.Y + num;
				}
				if (base.NPC.ai[1] >= 90f)
				{
					base.NPC.ai[1] *= -1f;
				}
			}
			return false;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return false;
		}

		public override string GetChat()
		{
			return "Hurry up, I can't stay for long...";
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(8);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(282);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(40);
			nextSlot++;
			if (NPC.AnyNPCs(19))
			{
				shop.item[nextSlot].SetDefaults(97);
				nextSlot++;
			}
			shop.item[nextSlot].SetDefaults(42);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(965);
			nextSlot++;
			if (NPC.savedMech)
			{
				shop.item[nextSlot].SetDefaults(530);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(849);
				nextSlot++;
			}
			shop.item[nextSlot].SetDefaults(35);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(28);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(110);
			nextSlot++;
			if (NPC.savedWizard)
			{
				shop.item[nextSlot].SetDefaults(500);
				nextSlot++;
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
			//button2 = Lang.inter[64].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
			if (firstButton)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			shop = false;
			Main.npcChatCornerItem = 0;
			/*SoundEngine.PlaySound(in SoundID.Item12, (Vector2?)new Vector2(-1f, -1f));
			bool flag = false;
			if (!Main.anglerQuestFinished && !Main.anglerWhoFinishedToday.Contains(player.name))
			{
				int num = player.FindItem(Main.anglerQuestItemNetIDs[Main.anglerQuest]);
				if (num != -1)
				{
					player.inventory[num].stack--;
					if (player.inventory[num].stack <= 0)
					{
						player.inventory[num] = new Item();
					}
					flag = true;
					SoundEngine.PlaySound(in SoundID.Item24, (Vector2?)new Vector2(-1f, -1f));
					player.anglerQuestsFinished++;
					player.GetAnglerReward(NPCLoader.GetNPC(NPCID.Angler).NPC);
				}
			}
			Main.npcChatText = Lang.AnglerQuestChat(flag);
			if (flag)
			{
				Main.anglerQuestFinished = true;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(75);
				}
				else
				{
					Main.anglerWhoFinishedToday.Add(player.name);
				}
				AchievementsHelper.HandleAnglerService();
			}*/
		}
	}
}
