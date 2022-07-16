using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.EventEnable
{
	public class RainEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Rain Charm");
			base.Tooltip.SetDefault("Enables or disables rain.");
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
				if (Main.raining)
				{
					RainOff();
				}
				else if (!Main.raining && !Main.slimeRain)
				{
					RainOn();
				}
			}
			return true;
		}

		private static void RainOff()
		{
						MiscMethods.WriteText("Rain disabled.", new Color(0, 128, 255));
			Main.StopRain();
			NetMessage.SendData(7);
		}

		private static void RainOn()
		{
						MiscMethods.WriteText("Rain enabled.", new Color(0, 128, 255));
			Main.StartRain();
			NetMessage.SendData(7);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(987).AddIngredient(751, 30).AddIngredient(765, 15)
				.AddIngredient(2002, 5)
				.AddTile(18)
				.Register();
		}
	}
}
