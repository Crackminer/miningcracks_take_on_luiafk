using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class SolarEclipseEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Solar Tablet");
			base.Tooltip.SetDefault("Starts the Solar Eclipse.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
						if (Main.hardMode && NPC.downedMechBossAny && Main.dayTime && Main.netMode != 1)
			{
				Main.eclipse = true;
				if (Main.eclipse)
				{
					AchievementsHelper.NotifyProgressionEvent(2);
					MiscMethods.WriteText(Lang.misc[20].Value, new Color(50, 255, 130));
					NetMessage.SendData(7);
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2767, 10).AddTile(18).Register();
		}
	}
}
