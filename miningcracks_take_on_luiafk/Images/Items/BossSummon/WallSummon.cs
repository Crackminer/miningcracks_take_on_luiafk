using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.BossSummon
{
    public class WallSummon : ModItem
    {
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Bloody Guide Voodoo Doll");
			base.Tooltip.SetDefault("Summons Wall of Flesh with out needing the Guide.\nOnly usable after Wall of Flesh has been killed.");
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
			return Main.hardMode && player.ZoneUnderworldHeight && !NPC.AnyNPCs(113) && !NPC.AnyNPCs(114);
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				NPC.SpawnWOF(player.position);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GuideVoodooDoll, 8)
				.Register();
		}
	}
}
