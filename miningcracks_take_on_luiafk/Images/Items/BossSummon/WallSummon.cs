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
			return Main.hardMode;
		}

		public override bool? UseItem(Player player)
		{
			if (!player.ZoneUnderworldHeight) return false;	//something in here is faulty and i believe its this line right here
			if (Main.netMode != 1)
			{
				NPC.NewNPC(player.GetSource_ItemUse(this.Item), player.Left.X < player.Right.X ? 0 : Main.ActiveWorldFileData.WorldSizeX, player.height, 113, ai0: 28, ai1: 27);
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
