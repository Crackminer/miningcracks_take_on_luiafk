using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedBoneThrowingKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bone Throwing Knives");
			base.Tooltip.SetDefault("Never run out of Bone Throwing Knives.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3379, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3379, 999).AddTile(16).Register();
		}
	}
}
