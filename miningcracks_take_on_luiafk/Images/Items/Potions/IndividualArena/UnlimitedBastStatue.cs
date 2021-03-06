using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualArena
{
    public class UnlimitedBastStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Unlimited Bast Statue");
            base.Tooltip.SetDefault("Defense is increased by 5");
            base.SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Defaults.Base(base.Item);
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<LuiafkPlayer>().buffs[79] = true;
            player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(4276, 5).AddTile(13).Register();
        }
    }
}