using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Buckets
{
	public class MultiPurposeSponge : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Multipurpose Sponge");
			base.Tooltip.SetDefault("Get rid of all that liquid.\nWorks on water, lava, and honey.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 1;
			base.Item.useTurn = true;
			base.Item.useAnimation = 12;
			base.Item.useTime = 5;
			base.Item.autoReuse = true;
			Defaults.Base(base.Item);
		}

		public override void HoldItem(Player player)
		{
			MiscMethods.ThisItemIcon(player, base.Item);
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer && !player.noBuilding && Liquids.Sponge(Player.tileTargetX, Player.tileTargetY))
			{
				SoundEngine.PlaySound(in SoundID.Item19, (Vector2?)new Vector2((float)(int)player.position.X, (float)(int)player.position.Y));
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(225, 30).AddIngredient(275, 30).AddIngredient(1124, 30)
				.AddIngredient(173, 30)
				.AddTile(16)
				.Register();
		}
	}
}
