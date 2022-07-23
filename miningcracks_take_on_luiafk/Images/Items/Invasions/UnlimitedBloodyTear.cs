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
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(4271, 15).AddTile(13).Register();
        }
    }
}