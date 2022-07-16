using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ContentSamples.CreativeHelper;

namespace miningcracks_take_on_luiafk.Images.Items.Glowsticks
{
	public abstract class Glowstick : ModItem
	{
		private readonly string name;

		private readonly int shoot;

		private readonly Vector3 rgb;

		private readonly int type;

		public Glowstick(string name, int shoot, Vector3 rgb, int type)
		{
			this.name = name;
			this.shoot = shoot;
			this.rgb = rgb;
			this.type = type;
		}

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited " + name + "Glowsticks");
			base.Tooltip.SetDefault("Never run out of " + name + "Glowsticks.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.consumable = false;
			base.Item.useStyle = 1;
			base.Item.shootSpeed = 6f;
			base.Item.shoot = shoot;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useAnimation = 15;
			base.Item.useTime = 15;
			base.Item.noMelee = true;
			base.Item.holdStyle = 1;
			Defaults.Base(base.Item);
		}

		public override void ModifyResearchSorting(ref ItemGroup itemGroup)
		{
			itemGroup = ItemGroup.Glowsticks;
		}

		public override void HoldItem(Player player)
		{
			if (!player.pulley)
			{
				HoldingItem(player);
			}
		}

		protected virtual void HoldingItem(Player player)
		{
			if (player.direction == -1)
			{
				Lighting.AddLight(player.RotatedRelativePoint(new Vector2(player.itemLocation.X - 16f + player.velocity.X, player.itemLocation.Y - 14f), reverseRotation: true), rgb);
			}
			else
			{
				Lighting.AddLight(player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 6f + player.velocity.X, player.itemLocation.Y - 14f), reverseRotation: true), rgb);
			}
		}

		public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
		{
			glowstick = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(type, 396).AddTile(18).Register();
		}
	}
}
