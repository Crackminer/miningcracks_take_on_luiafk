using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class UnlimitedManaAccessory5 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana 5");
			base.Tooltip.SetDefault("Unlimited mana.\nMagic damage increased by 10%.\nMagic crit increased by 10%.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 850000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost *= 0f;
			player.GetCritChance(DamageClass.Magic) += 10f;
			player.GetDamage(DamageClass.Magic) += 0.1f;
			player.GetModPlayer<LuiafkPlayer>().unlimitedMana = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedManaAccessory4").Type).AddIngredient(3457, 15).AddIngredient(base.Mod.Find<ModItem>("ManaEssence").Type)
				.AddIngredient(base.Mod.Find<ModItem>("MagicEssence").Type)
				.AddTile(114)
				.Register();
		}
	}
}
