using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables
{
	public class HouseTile : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited House Enabler");
			base.Tooltip.SetDefault("Invisible tile.\nCounts as a door, chair, table, and light source.\nRight-click to choose whether it will be lit up (will counts as a house either way).");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 94);
			base.Item.createTile = base.Mod.Find<ModTile>("HouseEnabler").Type;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<HouseUI>().holding = true;
			}
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<HouseUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<HouseUI>());
					UILearning.RightClickUIs<HouseUI>().buttonUpdates();
					if (Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On) Main.FrameSkipMode = Terraria.Enums.FrameSkipMode.Subtle;
				}
				return false;
			}
			if (player.GetModPlayer<LuiafkPlayer>().uiLight)
			{
				base.Item.createTile = base.Mod.Find<ModTile>("HouseEnabler").Type;
			}
			else
			{
				base.Item.createTile = base.Mod.Find<ModTile>("HouseEnablerDark").Type;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:LightSource", 10).AddRecipeGroup("Luiafk:Tables", 10).AddRecipeGroup("Luiafk:Chairs", 10)
				.AddRecipeGroup("Luiafk:Doors", 10)
				.AddTile(18)
				.Register();
		}
	}
}
