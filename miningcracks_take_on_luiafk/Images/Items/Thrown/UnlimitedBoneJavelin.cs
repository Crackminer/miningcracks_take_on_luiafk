using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedBoneJavelin : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bone Javelin");
			base.Tooltip.SetDefault("Never run out of Bone Javelins.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3378, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3378, 999).AddTile(16).Register();
		}
	}
}
