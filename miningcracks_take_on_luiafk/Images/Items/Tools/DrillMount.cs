using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class DrillMount : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Improved Drill Mount");
			base.Tooltip.SetDefault(":shrug:");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
			base.Item.mountType = base.Mod.Find<ModMount>("DrillMountMount").Type;
		}

		public override bool? UseItem(Player player)
		{
									player.GetModPlayer<LuiafkPlayer>().position = player.position;
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2768).AddIngredient(2798, 5).AddIngredient(751, 300)
				.AddIngredient(3467, 30)
				.AddRecipeGroup("Luiafk:LunarPick")
				.AddRecipeGroup("Luiafk:LunarHamaxe")
				.AddTile(412)
				.Register();
		}
	}
}
