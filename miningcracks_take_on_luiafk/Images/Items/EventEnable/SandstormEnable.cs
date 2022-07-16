using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.EventEnable
{
	public class SandstormEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Sand Charm");
			base.Tooltip.SetDefault("Enables or disables sandstorms.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				if (Sandstorm.Happening)
				{
					SandstormOff();
					return true;
				}
				SandstormOn();
			}
			return true;
		}

		private static void SandstormOff()
		{
						MiscMethods.WriteText("Sandstorm disabled.", new Color(255, 255, 0));
			Sandstorm.StopSandstorm();
			SandstormStuff();
		}

		private static void SandstormOn()
		{
						MiscMethods.WriteText("Sandstorm disabled.", new Color(255, 255, 0));
			Sandstorm.StartSandstorm();
			SandstormStuff();
		}

		private static void SandstormStuff()
		{
			NetMessage.SendData(7);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(857).AddIngredient(323, 10).AddIngredient(528)
				.AddIngredient(527)
				.AddTile(18)
				.Register();
		}
	}
}
