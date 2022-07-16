using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Misc
{
	public class LightSwitch : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Light Switch");
			base.Tooltip.SetDefault("Switches the light off on all \"House Enablers\".\n\"House Enabler (No Light)\" are unaffected.");
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
				LuiafkWorld.lightSwitch = !LuiafkWorld.lightSwitch;
				NetMessage.SendData(7);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(538).AddTile(18).Register();
		}
	}
}
