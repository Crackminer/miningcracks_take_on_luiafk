using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class UnlimitedGrandDesign : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Infinite Grand Design");
			base.Tooltip.SetDefault("Never run out of Wire or Actuators again.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
			base.Item.channel = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("UnlimitedGrandDesignProjectile").Type;
			base.Item.shootSpeed = 10f;
			base.Item.UseSound = SoundID.Item64;
			base.Item.mech = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				base.Item.shoot = 0;
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<WiringUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<WiringUI>());
					UILearning.RightClickUIs<WiringUI>().buttonUpdates();
				}
				return false;
			}
			else
			{
				base.Item.shoot = base.Mod.Find<ModProjectile>("UnlimitedGrandDesignProjectile").Type;
			}
			return true;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<WiringUI>().holding = true;
			}
			player.InfoAccMechShowWires = true;
			player.rulerLine = true;
		}

		public override void UpdateInventory(Player player)
		{
			player.InfoAccMechShowWires = true;
			player.rulerLine = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(530, 2997).AddIngredient(849, 500).AddIngredient(3611)
				.AddTile(16)
				.Register();
		}
	}
}
