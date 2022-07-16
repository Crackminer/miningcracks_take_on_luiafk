using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedJavelin : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Javelins");
			base.Tooltip.SetDefault("Never run out of Javelins.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3094, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3094, 999).AddTile(16).Register();
		}
	}
}
