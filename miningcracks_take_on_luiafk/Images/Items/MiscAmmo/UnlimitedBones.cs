using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedBones : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bones");
			base.Tooltip.SetDefault("Never run out of Bones.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 154, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(154, 999).AddTile(18).Register();
		}
	}
}
