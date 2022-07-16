using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class UnlimitedManaAccessory2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana 2");
			base.Tooltip.SetDefault("Unlimited mana.\nMagic damage reduced by 10%.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 125000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost *= 0f;
			player.GetDamage(DamageClass.Magic) -= 0.1f;
			player.GetModPlayer<LuiafkPlayer>().unlimitedMana = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedManaAccessory1").Type).AddIngredient(489).AddIngredient(500, 225)
				.AddTile(114)
				.Register();
		}
	}
}
