using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedBoneArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bone Arrows");
			base.Tooltip.SetDefault("Never run out of Bone Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3003);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3003, 3996).AddTile(18).Register();
		}
	}
}
