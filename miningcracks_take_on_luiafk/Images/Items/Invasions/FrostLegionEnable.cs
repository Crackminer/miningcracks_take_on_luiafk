using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class FrostLegionEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Snow Globe");
			base.Tooltip.SetDefault("Starts the Frost Legion invasion.\nThe Frost Legion arrive instantly.\nWill instantly start any normal Frost Legion invasion.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
						if (Main.netMode == 1)
			{
				return true;
			}
			if (Main.CanStartInvasion(2))
			{
				Main.StartInvasion(2);
			}
			if (Main.invasionType == 2 && Main.invasionX != (double)Main.spawnTileX)
			{
				Main.invasionX = Main.spawnTileX;
				MiscMethods.WriteText(Lang.misc[7].Value, new Color(175, 75, 255));
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(602, 5).AddTile(18).Register();
		}
	}
}
