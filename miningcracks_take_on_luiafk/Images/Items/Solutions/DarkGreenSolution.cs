using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class DarkGreenSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dark Green Solution");
			base.Tooltip.SetDefault("Used by the Clentaminator.\nSpreads the Jungle.\nConverts pretty much everything.");
			base.SacrificeTotal = 100;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, base.Mod.Find<ModProjectile>("DarkGreenSolutionProjectile").Type - 145, consumable: true);
			base.Item.value = 2500;
			base.Item.maxStack = 9999;
		}
	}
}
