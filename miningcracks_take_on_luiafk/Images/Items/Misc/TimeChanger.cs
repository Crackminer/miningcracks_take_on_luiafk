using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Misc
{
	public class TimeChanger : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Time Changer");
			base.Tooltip.SetDefault("Never wait again.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				Main.time = 54000.0;
				CultistRitual.delay = 0.0;
				CultistRitual.recheck = 0.0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:GoldWatch").AddIngredient(530, 30).AddIngredient(501, 20)
				.AddIngredient(521, 5)
				.AddIngredient(520, 5)
				.AddTile(134)
				.Register();
		}
	}
}
