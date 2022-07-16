using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedManaRegeneration : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana Regeneration Potion");
			base.Tooltip.SetDefault("Increased mana regen.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("ManaRegen");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(293, 30).AddTile(13).Register();
		}
	}
}
