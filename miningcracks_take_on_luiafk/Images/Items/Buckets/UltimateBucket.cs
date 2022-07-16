using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Buckets
{
	public class UltimateBucket : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Ultimate Liquid Manipulator");
			base.Tooltip.SetDefault("Never run out of liquid.\nUnless you want to.\nRight-click to change modes.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 1;
			base.Item.useTurn = true;
			base.Item.useAnimation = 12;
			base.Item.useTime = 5;
			base.Item.autoReuse = true;
			Defaults.Base(base.Item);
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<UltimateBucketUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<UltimateBucketUI>());
				}
				return false;
			}
			return true;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<UltimateBucketUI>().holding = true;
				Liquids.HoldBucket(player);
			}
		}

		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			return Liquids.UseUltBucket(player);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedWater").Type).AddIngredient(base.Mod.Find<ModItem>("UnlimitedLava").Type).AddIngredient(base.Mod.Find<ModItem>("UnlimitedHoney").Type)
				.AddIngredient(base.Mod.Find<ModItem>("MultiPurposeSponge").Type)
				.AddTile(16)
				.Register();
		}
	}
}
