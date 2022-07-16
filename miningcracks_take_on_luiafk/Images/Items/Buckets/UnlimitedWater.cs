using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Buckets
{
	public class UnlimitedWater : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Water Bucket");
			base.Tooltip.SetDefault("Never run out of water.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 1;
			base.Item.useTurn = true;
			base.Item.useAnimation = 12;
			base.Item.useTime = 5;
			base.Item.autoReuse = true;
			Defaults.Base(base.Item);
		}

		public override void HoldItem(Player player)
		{
			MiscMethods.ThisItemIcon(player, base.Item);
		}

		public override bool? UseItem(Player player)
		{
			return Liquids.UseBucket(player, LiquidTypes.Water);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(206, 30).AddTile(16).Register();
		}
	}
}
