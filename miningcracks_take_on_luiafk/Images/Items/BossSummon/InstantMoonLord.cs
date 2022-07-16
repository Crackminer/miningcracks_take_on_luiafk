using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.BossSummon
{
	public class InstantMoonLord : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Instant Moon Lord Summon");
			base.Tooltip.SetDefault("Skips Impending Doom.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
			base.Item.maxStack = 9999;
			base.Item.consumable = true;
		}

		public override bool? UseItem(Player player)
		{
						if (Main.netMode != 1)
			{
				NPC.NewNPC(null, (int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y - Main.rand.Next(650), 398);
				MiscMethods.WriteText("Moon Lord has awoken!", new Color(175, 75, 255));
			}
			return true;
		}

		public override void AddRecipes()
		{
			if (!LuiafkMod.FargoLoaded)
			{
				CreateRecipe().AddIngredient(3601).Register();
			}
		}
	}
}
