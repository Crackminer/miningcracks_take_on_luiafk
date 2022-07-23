using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Buckets
{
    public class UnlimitedChumBucket : ModItem
    {
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Chum Bucket");
			base.Tooltip.SetDefault("Plankton dreams of this Luxury.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 820, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(4608, 10).AddTile(18)
				.Register();
		}
	}
}
