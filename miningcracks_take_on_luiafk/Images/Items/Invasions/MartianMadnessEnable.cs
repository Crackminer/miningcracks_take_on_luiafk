using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class MartianMadnessEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Martian Probe");
			base.Tooltip.SetDefault("Starts the Martian Madness invasion.\nRequires Golem to be dead.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
			if (Main.CanStartInvasion(4) && Main.netMode != 1 && NPC.downedGolemBoss)
			{
				Main.StartInvasion(4);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(530, 150).AddIngredient(1225, 20).AddIngredient(2860, 150)
				.AddTile(18)
				.Register();
		}
	}
}
