using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
    public class UnlimitedGnome : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Unlimited Gnome");
            base.Tooltip.SetDefault("Increase the luck");
            base.SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Defaults.Base(base.Item);
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<LuiafkPlayer>().buffs[257] = true;
            player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(4609, 10).AddTile(13).Register();
        }
    }
}