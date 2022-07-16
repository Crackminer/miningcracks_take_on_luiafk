using System.Collections.Generic;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkGlobalItem : GlobalItem
	{
		internal static List<Rectangle> useItem = new List<Rectangle>();

		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && !Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(new EntitySource_DropAsItem(player), base.Mod.Find<ModItem>("HarvesterParts").Type);
			}
		}

		public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
		{
			if (Main.netMode != 2 && Main.player[Main.myPlayer].GetModPlayer<LuiafkPlayer>().uiDrawWeaponHitbox)
			{
				useItem.Add(hitbox);
			}
		}

		public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
		{
			if (weapon.type == 1946)
			{
				if (ammo.type == base.Mod.Find<ModItem>("UnlimitedRocketIs").Type)
				{
					type = 338;
				}
				else if (ammo.type == base.Mod.Find<ModItem>("UnlimitedRocketIIs").Type)
				{
					type = 339;
				}
				else if (ammo.type == base.Mod.Find<ModItem>("UnlimitedRocketIIIs").Type)
				{
					type = 340;
				}
				else if (ammo.type == base.Mod.Find<ModItem>("UnlimitedRocketIVs").Type)
				{
					type = 341;
				}
			}
			else if (weapon.type == 779 && ammo.type == base.Mod.Find<ModItem>("UnlimitedMultiSolution").Type)
			{
				int num;
				switch (player.GetModPlayer<LuiafkPlayer>().uiMultiSolutionType)
				{
				case 1:
					num = 147;
					break;
				case 2:
					num = 149;
					break;
				case 3:
					num = 148;
					break;
				case 4:
					num = 146;
					break;
				case 5:
					num = base.Mod.Find<ModProjectile>("DarkGreenSolutionProjectile").Type;
					break;
				default:
					num = 145;
					break;
				}
				type = num;
			}
		}

		public override void OnConsumeAmmo(Item weapon, Item ammo, Player player)
		{
			if (!player.GetModPlayer<LuiafkPlayer>().infiniteAmmoDisabled)
			{
				if (ammo.stack < 3996)
				{
					if (weapon.ammo == AmmoID.Solution)
					{
						if (ammo.stack < 999) return;
						ammo.stack++;
					}
					return;
				}
				ammo.stack++;
			}
		}

		public override bool ConsumeItem(Item item, Player player)
		{
			if (!player.GetModPlayer<LuiafkPlayer>().infiniteAmmoDisabled)
			{
				if (item.damage > 0 && (item.DamageType == DamageClass.Throwing || LuiafkMod.throwingtypes.Contains(item.type)) && item.stack >= 999)
				{
					return false;
				}
				/*if(LuiafkMod.CalamityLoaded)	//need implementations
                {
					if(item.damage > 0 && (item.DamageType == DamageClass.Rogue) && item.stack >= 999)
                    {
						return false;
                    }
                }*/
				if (item.damage > 0 && item.stack >= 3996)
				{
					return false;
				}
			}
			//only works if player already has an instance of a unlimited potion
			if (player.GetModPlayer<LuiafkPlayer>().buffs.Count != 0)
			{
				if (item.healLife > 0 && item.stack >= 90)
				{
					return false;
				}
				if (item.healMana > 0 && item.stack >= 225)
				{
					return false;
				}
				if (item.buffType > 0 && item.stack >= 30)
				{
					return false;
				}
			}
			return true;
		}
	}
}
