using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.Utility;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedLucky : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Lucky Buffs");
			base.Tooltip.SetDefault("You lucky being.\nThe torches don't pay attention to your presence");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			foreach(TooltipLine line in tooltips)
            {
				if(line.Text == "The torches don't pay attention to your presence" && UILearning.LuiP.Player.unlockedBiomeTorches)
                {
					line.Text = "The torches grant you their blessing";
				}
            }
        }

        public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[78] = true;
			player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "UnlimitedLuck")
				.AddIngredient(null, "UnlimitedGnome")
				.AddIngredient(null, "UnlimitedLadybug")
				.AddIngredient(null, "UnlimitedTorches")
				.AddTile(13)
				.Register();
		}
	}
}
