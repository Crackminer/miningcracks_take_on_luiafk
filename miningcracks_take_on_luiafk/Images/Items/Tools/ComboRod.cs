using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class ComboRod : ModItem
	{
		public override string Texture => "Terraria/Images/Item_" + (short)495;

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Combo Rod");
			base.Tooltip.SetDefault("Has the features of the:\nAll-in-One Paint Tool\nHoiktuation Rod\nWall Rod\nUnlimited Grand Design\nUltimate Liquid Manipulator\nAll now have unlimited range.\nBucket mode now uses box placement when smart-cursor is disabled\nTile mode can place grass (on dirt/mud), moss (on stone),\nhive (need hive), bone blocks (need bones/unlimited bones),\nliving wood/leaf (need wood), living mahogany wood/leaf (need rich mahogany).");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
			base.Item.tileBoost += 10;
			base.Item.mech = true;
		}

		public override void UpdateInventory(Player player)
		{
			player.InfoAccMechShowWires = true;
			player.rulerLine = true;
		}

		public override void HoldItem(Player player)
		{
			player.InfoAccMechShowWires = true;
			player.rulerLine = true;
			if (player.whoAmI != Main.myPlayer || player.noBuilding)
			{
				return;
			}
			UILearning.RightClickUIs<ComboRodUI>().holding = true;
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (modPlayer.uiComboMode == BuildingRodModes.Paint)
			{
				MiscMethods.PaintHoldItem(player, UILearning.RightClickUIs<PaintToolUI>());
			}
			else if (modPlayer.uiComboMode == BuildingRodModes.Walls)
			{
				MiscMethods.WallRodHoldItem(player);
			}
			else if (modPlayer.uiComboMode == BuildingRodModes.Liquid)
			{
				Liquids.HoldBucket(player);
				if (!Main.SmartCursorIsUsed)
				{
					UILearning.BoxPlaceUI.Update(BoxType.Liquid);
				}
			}
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (Main.SmartCursorIsUsed)
			{
				Main.NewText("Please disable Smart Cursor to use this rod, It will be nearly unusable otherwise.");
				return false;
			}
			if (player.altFunctionUse == 2)
			{
				base.Item.shoot = 0;
				if (UILearning.ComboInterface?.CurrentState != null && UILearning.ComboInterface?.CurrentState == UILearning.RightClickUIs<ComboRodUI>())
				{
					UILearning.ComboInterface?.SetState(null);
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.ComboInterface?.SetState(UILearning.RightClickUIs<ComboRodUI>());
					UILearning.RightClickUIs<ComboRodUI>().buttonUpdate();
					if (Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On) Main.FrameSkipMode = Terraria.Enums.FrameSkipMode.Subtle;
				}
				return false;
			}
			if (player.noBuilding)
			{
				return false;
			}
			if (player.whoAmI != Main.myPlayer)
			{
				return true;
			}
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (modPlayer.uiComboMode == BuildingRodModes.Walls || (!Main.SmartCursorIsUsed && (modPlayer.uiComboMode == BuildingRodModes.Paint || modPlayer.uiComboMode == BuildingRodModes.Liquid)))
			{
				return false;
			}
			if (modPlayer.uiComboMode == BuildingRodModes.Tiles || modPlayer.uiComboMode == BuildingRodModes.Wire)
			{
				Defaults.UnlUse(base.Item);
				base.Item.channel = true;
				base.Item.shootSpeed = 10f;
				if (modPlayer.uiComboMode == BuildingRodModes.Tiles)
				{
					base.Item.shoot = base.Mod.Find<ModProjectile>("ActuatorProjectile").Type;
				}
				else
				{
					base.Item.shoot = base.Mod.Find<ModProjectile>("UnlimitedGrandDesignProjectile").Type;
				}
			}
			else
			{
				base.Item.autoReuse = true;
				base.Item.useStyle = 1;
				base.Item.useTurn = true;
				base.Item.channel = false;
				base.Item.shoot = -1;
				if (modPlayer.uiComboMode == BuildingRodModes.Liquid)
				{
					base.Item.useAnimation = 12;
					base.Item.useTime = 5;
				}
				else
				{
					base.Item.useAnimation = 15;
					base.Item.useTime = 1;
				}
			}
			return true;
		}

		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			if (player.whoAmI != Main.myPlayer || player.noBuilding)
			{
				return true;
			}
			if (player.GetModPlayer<LuiafkPlayer>().uiComboMode == BuildingRodModes.Liquid)
			{
				return Liquids.UseUltBucket(player);
			}
			return SmartCursor.PaintUseItem(player);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "BuildingRod").AddIngredient(null, "WallRod").AddIngredient(null, "PaintTool")
				.AddIngredient(null, "UnlimitedGrandDesign")
				.AddRecipeGroup("Luiafk:Buckets")
				.AddRecipeGroup("Luiafk:Regrowth")
				.AddTile(134)
				.Register();
		}
	}
}
