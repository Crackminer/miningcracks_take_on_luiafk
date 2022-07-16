using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualArena
{
	public class UnlimitedHoneyBuff : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Honey");
			base.Tooltip.SetDefault("Life regen increased.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Honey");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1134, 30).AddIngredient(313, 30).AddIngredient(314, 30)
				.AddIngredient(1125, 30)
				.AddTile(13)
				.Register();
		}
	}
}
