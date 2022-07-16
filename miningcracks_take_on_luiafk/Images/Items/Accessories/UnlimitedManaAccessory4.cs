using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class UnlimitedManaAccessory4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana 4");
			base.Tooltip.SetDefault("Unlimited mana.\nMagic damage increased by 5%.\nMagic crit increased by 5%.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 550000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost *= 0f;
			player.GetCritChance(DamageClass.Magic) += 5f;
			player.GetDamage(DamageClass.Magic) += 0.05f;
			player.GetModPlayer<LuiafkPlayer>().unlimitedMana = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedManaAccessory3").Type).AddIngredient(2218, 15).AddTile(114)
				.Register();
		}
	}
}
