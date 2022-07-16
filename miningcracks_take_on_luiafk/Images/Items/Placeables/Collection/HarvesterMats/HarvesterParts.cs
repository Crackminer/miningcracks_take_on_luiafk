using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection.HarvesterMats
{
	public class HarvesterParts : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.Tooltip.SetDefault("Expert");
			base.SacrificeTotal = 15;
		}

		public override void SetDefaults()
		{
			Defaults.ChestMaterials(base.Item);
		}
	}
}
