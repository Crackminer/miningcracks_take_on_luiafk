using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class BloodMoonEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Bloody Voodoo Doll");
			base.Tooltip.SetDefault("Starts the Blood Moon.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
			if (!Main.dayTime && !Main.snowMoon && !Main.pumpkinMoon && !Main.bloodMoon && Main.netMode != 1)
			{
				Main.bloodMoon = true;
				if (Main.bloodMoon)
				{
					AchievementsHelper.NotifyProgressionEvent(4);
					MiscMethods.WriteText(Lang.misc[8].Value, new Color(50, 255, 130));
					NetMessage.SendData(7);
				}
				return true;
			}
			if (!Main.dayTime && !Main.snowMoon && !Main.pumpkinMoon && Main.bloodMoon && Main.netMode != 1)
            {
				Main.bloodMoon = false;
				if (!Main.bloodMoon)
				{
					MiscMethods.WriteText("BloodMoon disabled", new Color(50, 255, 130));
					NetMessage.SendData(7);
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:EvilOreMat", 15).AddIngredient(1727, 50).AddIngredient(225, 5)
				.AddIngredient(216)
				.AddIngredient(216).AddIngredient<UnlimitedBloodyTear>()
				.AddTile(18)
				.Register();
		}
	}
}
