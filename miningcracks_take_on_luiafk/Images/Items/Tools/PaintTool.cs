using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class PaintTool : ModItem
	{
		public override string Texture => "Terraria/Images/Item_1544";

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("All-in-One Paint Tool");
			base.Tooltip.SetDefault("Right-click to choose paint color and mode.\nWith smart cursor disabled you'll be able to paint by selecting a box.\nDoesn't consume paint.\nInsanely fast speed.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 1;
			base.Item.useAnimation = 15;
			base.Item.useTime = 1;
			base.Item.width = 40;
			base.Item.height = 40;
			base.Item.autoReuse = true;
			base.Item.rare = 10;
			base.Item.value = 1;
			base.Item.tileBoost += 6;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer && !player.noBuilding)
			{
				PaintToolUI paintToolUI = UILearning.RightClickUIs<PaintToolUI>();
				paintToolUI.holding = true;
				if (Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On) MiscMethods.PaintHoldItem(player, paintToolUI);
			}
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<PaintToolUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<PaintToolUI>());
					UILearning.RightClickUIs<PaintToolUI>().buttonUpdates();
					Main.FrameSkipMode = Terraria.Enums.FrameSkipMode.Subtle;
				}
				return false;
			}
			return Main.SmartCursorIsUsed;
		}

		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			return SmartCursor.PaintUseItem(player);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1071).AddIngredient(1100).AddIngredient(1072)
				.AddTile(16)
				.Register();
		}
	}
}
