using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedArena : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Arena Buffs");
			base.Tooltip.SetDefault("Life and mana regen increased.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Arena");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedHoneyBuff").AddIngredient(null, "UnlimitedStarinaBottle").AddIngredient(null, "UnlimitedCampfire")
				.AddIngredient(null, "UnlimitedHeartLantern")
				.AddTile(13)
				.Register();
		}
	}
}
