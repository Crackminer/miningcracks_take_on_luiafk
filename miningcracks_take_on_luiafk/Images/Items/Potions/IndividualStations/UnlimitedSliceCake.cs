using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualStations
{
    public class UnlimitedSliceCake : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Unlimited Slice of Cake");
            base.Tooltip.SetDefault("'Stuff your face. Stuff someone else's face. Whatever.'");
            base.SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Defaults.Base(base.Item);
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<LuiafkPlayer>().buffs[80] = true;
            player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(3750, 5).AddTile(13).Register();
        }
    }
}