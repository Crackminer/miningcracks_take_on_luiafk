using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class GoblinArmyEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Goblin Battle Standard");
			base.Tooltip.SetDefault("Starts the Goblin Army invasion.\nThe Goblin Army arrive instantly.\nWill instantly start any normal Goblin Army invasion.");
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
			if (Main.CanStartInvasion())
			{
				Main.StartInvasion();
			}
			if (Main.invasionType == 1 && Main.invasionX != (double)Main.spawnTileX)
			{
				Main.invasionX = Main.spawnTileX;
				MiscMethods.WriteText(Lang.misc[3].Value, new Color(175, 75, 255));
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(361, 5).AddTile(18).Register();
		}
	}
}
