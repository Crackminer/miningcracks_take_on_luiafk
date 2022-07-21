using System;
using System.IO;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Misc
{
    public class DeepsSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Improved Dummy");
            base.Tooltip.SetDefault("Summons a Target Dummy to test your DPS.\nUsing it again will despawn any active dummy.\nCan be homed in on and minions will target it.\nDespawns when a boss is alive.\nRight-click to toggle normal invincibility frames.\nHitbox is a constant size.\nUse /luiafk dummy to toggle hitbox drawing.\nUse /luiafk dummy then a number to change the dummy's defense.");
            base.SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            base.Item.useStyle = 2;
            base.Item.useAnimation = 20;
            base.Item.useTime = 20;
            base.Item.width = 40;
            base.Item.height = 40;
            base.Item.autoReuse = false;
            base.Item.rare = 10;
            base.Item.value = 50000;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return !MiscMethods.AnyBoss(despawn: false);
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
                if (player.altFunctionUse == 2)
                {
                    modPlayer.stupidDeeps = !modPlayer.stupidDeeps;
                    Main.NewText((object)("Patchwerk set to " + (modPlayer.stupidDeeps ? "[C/00FF00:Stupid] " : "[C/008888:Normal] ") + " mode."), (Color?)new Color(255, 0, 0));
                }
                else
                {
                    if (Main.netMode == 1)
                    {
                        DeepsPacket(player, Main.MouseWorld, modPlayer.stupidDeeps);
                        return true;
                    }
                    SummonDeeps(player, Main.MouseWorld, modPlayer.stupidDeeps);
                }
            }
            return true;
        }

        private static void DeepsPacket(Player player, Vector2 mousePos, bool stupid)
        {
            ModPacket packet = LuiafkMod.Instance.GetPacket();
            ((BinaryWriter)packet).Write(15);
            ((BinaryWriter)packet).Write(player.whoAmI);
            packet.WriteVector2(mousePos);
            ((BinaryWriter)packet).Write(stupid);
            packet.Send();
        }

        internal static void SummonDeeps(Player player, Vector2 mousePos, bool stupid)
        {
            LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
            if (modPlayer.deepsDelete == -1)
            {
                modPlayer.deepsDelete = NPC.NewNPC(null, (int)mousePos.X, (int)mousePos.Y, LuiafkMod.Instance.Find<ModNPC>("Deeps").Type, 0, 1f, 1f, player.whoAmI, stupid ? 1f : 0f);
                Main.npc[modPlayer.deepsDelete].Center = mousePos;
            }
            else
            {
                modPlayer.deepsDelete = -1;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = base.CreateRecipe(1);
            recipe.AddIngredient(3202, 1);
            recipe.Register();

            Recipe recipeBack = Recipe.Create(3202, 1);
            recipeBack.AddIngredient<DeepsSummon>(1);
            recipeBack.Register();
            
            Recipe recipeForth = base.CreateRecipe(1);
            recipeForth.AddIngredient(3302, 1);
            recipeForth.Register();
        }
    }
}
