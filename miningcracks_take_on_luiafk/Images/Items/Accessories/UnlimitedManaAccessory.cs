using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class UnlimitedManaAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana");
			base.Tooltip.SetDefault("Unlimited mana.\nMagic damage reduced by 30%.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 75000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost *= 0f;
			player.GetDamage(DamageClass.Magic) -= 0.3f;
			player.GetModPlayer<LuiafkPlayer>().unlimitedMana = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(110, 225).AddIngredient(982).AddTile(114)
				.Register();
		}
	}
}
