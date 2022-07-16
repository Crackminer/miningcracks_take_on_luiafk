using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedTeleportation : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Teleportation");
			base.Tooltip.SetDefault("Teleports you to a random location.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.UseSound = SoundID.Item6;
			base.Item.useStyle = 2;
			base.Item.useTurn = true;
			base.Item.useAnimation = 17;
			base.Item.useTime = 17;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				player.GetModPlayer<LuiafkPlayer>().timerNeeded = 3;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2351, 30).AddTile(13).Register();
		}
	}
}
