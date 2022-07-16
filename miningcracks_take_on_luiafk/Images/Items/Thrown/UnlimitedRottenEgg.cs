using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedRottenEgg : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Rotten Eggs");
			base.Tooltip.SetDefault("Never run out of Rotten Eggs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1809, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1809, 999).AddTile(18).Register();
		}
	}
}
