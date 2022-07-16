using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class PirateEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Pirate Map");
			base.Tooltip.SetDefault("Starts the Pirate invasion.\nThe pirates arrive instantly.\nWill instantly start any normal Pirate invasion.");
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
			if (Main.CanStartInvasion(3))
			{
				Main.StartInvasion(3);
			}
			if (Main.invasionType == 3 && Main.invasionX != (double)Main.spawnTileX)
			{
				Main.invasionX = Main.spawnTileX;
				MiscMethods.WriteText(Lang.misc[27].Value, new Color(175, 75, 255));
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1315, 15).AddTile(18).Register();
		}
	}
}
