using miningcracks_take_on_luiafk.Utility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
    public class UnlimitedBloodyTear : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Unlimited Bloody Tear");
            base.Tooltip.SetDefault("Summons the Blood Moon 'What a horrible night to have a curse.'");
            base.SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Defaults.Base(base.Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(4271, 15).AddTile(13).Register();
        }
    }
}