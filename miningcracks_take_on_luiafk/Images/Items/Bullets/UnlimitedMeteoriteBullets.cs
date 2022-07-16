using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedMeteoriteBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Meteor Shot");
			base.Tooltip.SetDefault("Never run out of Meteor Shot.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 234);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(234, 3996).AddTile(18).Register();
		}
	}
}
