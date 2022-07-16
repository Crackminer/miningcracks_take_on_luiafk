using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualArena
{
	public class UnlimitedHeartLantern : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Heart Lantern");
			base.Tooltip.SetDefault("Life regen increased.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("HeartLantern");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:LifeCrystal", 10).AddIngredient(5, 30).AddIngredient(313, 30)
				.AddIngredient(126, 30)
				.AddTile(13)
				.Register();
		}
	}
}
