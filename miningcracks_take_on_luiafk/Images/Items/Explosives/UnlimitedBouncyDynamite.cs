using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedBouncyDynamite : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bouncy Dynamite");
			base.Tooltip.SetDefault("Never run out of Bouncy Dynamite.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3547, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3547, 198).AddTile(16).Register();
		}
	}
}
