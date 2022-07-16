using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class UnlimitedManaAccessory1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Mana 1");
			base.Tooltip.SetDefault("Unlimited mana.\nMagic damage reduced by 20%.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 100000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost *= 0f;
			player.GetDamage(DamageClass.Magic) -= 0.2f;
			player.GetModPlayer<LuiafkPlayer>().unlimitedMana = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedManaAccessory").Type).AddIngredient(183, 200).AddIngredient(154, 30)
				.AddTile(114)
				.Register();
		}
	}
}
