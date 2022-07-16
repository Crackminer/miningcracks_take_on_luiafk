using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class UnlimitedManaAccessory3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana 3");
			base.Tooltip.SetDefault("Unlimited mana.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 175000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost *= 0f;
			player.GetModPlayer<LuiafkPlayer>().unlimitedMana = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedManaAccessory2").Type).AddIngredient(526, 10).AddIngredient(75, 10)
				.AddIngredient(502, 5)
				.AddIngredient(548, 5)
				.AddIngredient(549, 5)
				.AddIngredient(547, 5)
				.AddTile(114)
				.Register();
		}
	}
}
