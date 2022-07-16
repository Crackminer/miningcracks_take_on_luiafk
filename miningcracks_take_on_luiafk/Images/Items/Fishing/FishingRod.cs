using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.Utility;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Fishing
{
	public abstract class FishingRod : ModItem
	{
		private readonly string name;

		private readonly string tooltip;

		private readonly int shoot;

		private readonly float speed;

		private readonly int skill;

		private readonly bool line;

		private readonly int rod;

		private readonly string bait;

		private readonly int baitAmount;

		internal int Skill => skill;

		public FishingRod(string name, string tooltip, int shoot, float speed, int skill, bool line, int rod, string bait, int baitAmount)
		{
			this.name = name;
			this.tooltip = tooltip;
			this.shoot = shoot;
			this.speed = speed;
			this.skill = skill;
			this.line = line;
			this.rod = rod;
			this.bait = bait;
			this.baitAmount = baitAmount;
		}

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited " + name);
			base.Tooltip.SetDefault("Doesn't need bait." + tooltip + "\nThrows an extra line for every 5 fishing quests completed.");
			base.SacrificeTotal = 1;
			if (skill == 110)
			{
				ItemID.Sets.CanFishInLava[base.Item.type] = true;
			}
		}

		public override void SetDefaults()
		{
			base.Item.width = 24;
			base.Item.height = 28;
			base.Item.shootSpeed = speed;
			base.Item.shoot = shoot;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useTime = 8;
			base.Item.useAnimation = 8;
			base.Item.holdStyle = 0;
			base.Item.useStyle = 1;
			base.Item.rare = 10;
			base.Item.value = 1;
		}

		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Player player = Main.player[Main.myPlayer];
			if (player.inventory[player.selectedItem].type == base.Item.type)
			{
				string text = CatchFish.GetProjSkill(myPlayer: true).ToString();
				if (text == "-1")
				{
					text = "Pig";
				}
				DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.ItemStack.Value, text, position, new Color(255, 0, 255), 0f, new Vector2(-7f, 10f), 1.1f, (SpriteEffects)0, 0f);
			}
		}

        public override void HoldItem(Player player)
		{
			if (line)
			{
				player.accFishingLine = true;
			}
			player.fishingSkill += skill;
			player.GetModPlayer<LuiafkPlayer>().holdingFishingRod = true;
			if (Main.netMode != 2)
			{
				int num = player.mount.PlayerOffsetHitbox + 4;
				player.itemLocation.X = player.position.X + (float)player.width * 0.5f + (float)TextureAssets.Item[base.Item.type].Value.Width * 0.18f * (float)player.direction;
				player.itemLocation.Y = player.position.Y + 24f + (float)num;
				if (base.Item.useStyle == 2 && player.itemAnimation > 0)
				{
					player.itemLocation.Y = player.position.Y + 24f + (float)num - 14f;
				}
			}
		}

		public override void HoldStyle(Player player, Rectangle heldItemFrame)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].bobber)
				{
					base.Item.holdStyle = 1;
					break;
				}
				if (i == 999)
				{
					base.Item.holdStyle = 0;
				}
			}
		}

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].bobber)
				{
					base.Item.useStyle = 2;
					return true;
				}
				if (i == 999)
				{
					base.Item.useStyle = 1;
				}
			}
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			if (Fishing.currentlyFishing)
			{
				Fishing.currentlyFishing = false;
			}
			else
			{
				Fishing.currentlyFishing = true;
			}
			bool flag = false;
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (!projectile.active || projectile.owner != player.whoAmI || !projectile.bobber || player.whoAmI != Main.myPlayer || projectile.ai[0] != 0f)
				{
					continue;
				}
				flag = true;
				projectile.ai[0] = 1f;
				float num = -10f;
				if (projectile.wet && projectile.velocity.Y > num)
				{
					projectile.velocity.Y = num;
				}
				projectile.netUpdate2 = true;
				if (!(projectile.ai[1] < 0f) || projectile.localAI[1] == 0f)
				{
					continue;
				}
				if (player.inventory.HasAtleastOne(2673))
				{
					if (Main.netMode == 0)
					{
						NPC nPC = Main.npc[NPC.NewNPC(null, (int)projectile.Center.X, (int)projectile.Center.Y + 100, 370)];
						Main.NewText((object)Language.GetTextValue("Announcement.HasAwoken", nPC.TypeName), (Color?)new Color(175, 75, 255));
					}
					else
					{
						Fishing.FishronPacket(i);
					}
				}
				else
				{
					if (Main.rand.NextBool(7) && !player.accFishingLine)
					{
						projectile.ai[0] = 2f;
					}
					else
					{
						projectile.ai[1] = projectile.localAI[1];
					}
					projectile.netUpdate = true;
				}
			}
			if (flag)
			{
				return false;
			}
			int num2 = player.anglerQuestsFinished / 5;
			/*if (LuiafkMod.FargoLoaded)
			{
				int type2 = LuiafkMod.FargoMod.Find<ModItem>("TrawlerSoul").Type;
				int type3 = LuiafkMod.FargoMod.Find<ModItem>("DimensionSoul").Type;
				int type4 = LuiafkMod.FargoMod.Find<ModItem>("AnglerEnchantment").Type;
				for (int j = 3; j < 8 + player.extraAccessorySlots; j++)
				{
					int type5 = player.armor[j].type;
					if (type5 == type2 || type5 == type3)
					{
						num2 += 10;
					}
					else if (type5 == type4)
					{
						num2 += 4;
					}
				}
			}*/
			for (int k = 0; k < num2; k++)
			{
				Projectile.NewProjectile(source, position, new Vector2(velocity.X + Main.rand.NextFloat(-75f, 75f) * 0.05f, velocity.Y + Main.rand.NextFloat(-75f, 75f) * 0.05f), type, damage, knockBack, player.whoAmI);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(rod).AddRecipeGroup(bait, baitAmount).AddTile(18)
				.Register();
		}
	}
}
