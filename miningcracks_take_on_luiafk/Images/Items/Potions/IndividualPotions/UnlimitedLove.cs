using miningcracks_take_on_luiafk.Utility;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedLove : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Love Potion");
			base.Tooltip.SetDefault("Throw at some to make them fall in love.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.useStyle = 1;
			base.Item.shootSpeed = 9f;
			base.Item.shoot = 370;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useAnimation = 15;
			base.Item.useTime = 15;
			base.Item.noUseGraphic = true;
			base.Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2352, 30).AddTile(13).Register();
		}
	}
}
