using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.NPCs
{
	[AutoloadHead]
	public class TravellingMerchant : ModNPC
	{
		public override string HeadTexture
		{
			get
			{
				if (!Main.dedServ)
				{
					return "Terraria/Images/NPC_Head_21";
				}
				return "miningcracks_take_on_luiafk/Images/NPCs/TravellingMerchant/TravellingMerchant_Head";
			}
		}

		public override string Texture => "Terraria/Images/NPC_368";

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Travelling Merchant");
			Main.npcFrameCount[base.NPC.type] = 26;
			NPCID.Sets.ExtraFramesCount[base.NPC.type] = 10;
			NPCID.Sets.AttackFrameCount[base.NPC.type] = 5;
			NPCID.Sets.DangerDetectRange[base.NPC.type] = 900;
			NPCID.Sets.AttackType[base.NPC.type] = 0;
			NPCID.Sets.AttackTime[base.NPC.type] = 60;
			NPCID.Sets.AttackAverageChance[base.NPC.type] = 40;
			NPCID.Sets.HatOffsetY[base.NPC.type] = 0;
			NPCID.Sets.PrettySafe[base.NPC.type] = 200;
			NPCID.Sets.FaceEmote[base.NPC.type] = 122;
		}

		public override void SetDefaults()
		{
			base.NPC.townNPC = true;
			base.NPC.friendly = true;
			base.NPC.width = 18;
			base.NPC.height = 40;
			base.NPC.aiStyle = 7;
			base.NPC.damage = 10;
			base.NPC.defense = 15;
			base.NPC.lifeMax = 250;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.knockBackResist = 0.5f;
			base.AnimationType = 368;
		}

		public override string GetChat()
		{
			if (BirthdayParty.PartyIsUp && Main.rand.NextBool(3))
			{
				return Language.SelectRandom(Lang.CreateDialogFilter("TravellingMerchantSpecialText.Party")).Value;
			}
			if (NPC.AnyNPCs(22) && Main.rand.NextBool(5))
			{
				return Lang.dialog(319);
			}
			if (NPC.AnyNPCs(17) && Main.rand.NextBool(5))
			{
				return Lang.dialog(320);
			}
			if (NPC.AnyNPCs(54) && Main.rand.NextBool(5))
			{
				return Lang.dialog(321);
			}
			return Lang.dialog(Main.rand.Next(322, 331));
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.SetupShop(19);
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (numTownNPCs > 2)
			{
				return money >= 500000;
			}
			return false;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			knockback = 2f;
			damage = (Main.hardMode ? 30 : 24);
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 12;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			attackDelay = 1;
			projType = (Main.hardMode ? 357 : 14);
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 13f;
			randomOffset = 0.2f;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
		{
			item = (Main.hardMode ? 2223 : 2269);
		}
	}
}
