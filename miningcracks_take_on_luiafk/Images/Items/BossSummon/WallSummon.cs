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
			return Main.hardMode && player.ZoneUnderworldHeight;
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				NPC.SpawnWOF(player.position);//new(player.Left.X < player.Right.X ? 0 + 400 : Main.ActiveWorldFileData.WorldSizeX - 400, player.height));
				MiscMethods.WriteText("Wall of Flesh has been summoned!", new Color(175, 75, 255));
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
