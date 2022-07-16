using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Buckets
{
	public class UnlimitedLava : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Lava Bucket");
			base.Tooltip.SetDefault("Never run out of lava.");
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
			return Liquids.UseBucket(player, LiquidTypes.Lava);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(207, 30).AddTile(16).Register();
		}
	}
}
