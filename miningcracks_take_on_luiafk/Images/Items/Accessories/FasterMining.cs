using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class FasterMining : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dig Faster");
			base.Tooltip.SetDefault("Mining speed increased by 35%.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 50000;
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (equippedItem.type == ModContent.ItemType<ToolTime>() || equippedItem.type == ModContent.ItemType<SuperToolTime>())
			{
				return false;
			}
			return true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed -= 0.35f;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3, 100).AddRecipeGroup("Wood", 100).AddRecipeGroup("IronBar", 5)
				.AddTile(16)
				.Register();
		}
	}
}
