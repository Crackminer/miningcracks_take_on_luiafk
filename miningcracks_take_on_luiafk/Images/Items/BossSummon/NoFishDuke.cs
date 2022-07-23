using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.BossSummon
{
	public class NoFishDuke : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fishron Summon");
			base.Tooltip.SetDefault("Summons Fishron with out having to fish.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
			base.Item.maxStack = 9999;
			base.Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ZoneBeach;
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				NPC.NewNPC(null, (int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y - Main.rand.Next(650), 370);
				MiscMethods.WriteText("Duke Fishron has awoken!", new Color(175, 75, 255));
			}
			return true;
		}

		public override void AddRecipes()
		{
			if (!LuiafkMod.FargoLoaded)
			{
				CreateRecipe().AddIngredient(2673).Register();
			}
		}
	}
}
