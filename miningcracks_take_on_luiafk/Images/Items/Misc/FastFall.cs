using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Misc
{
	public class FastFall : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Really Heavy Boulder");
			base.Tooltip.SetDefault("It's so heavy it makes you fall faster than normal.\nFavorite for it to work.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(540, 10).AddRecipeGroup("Luiafk:AdamTitanBar", 10).AddTile(134)
				.Register();
		}
	}
}
