using System;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MobileBanks
{
	public class MoneyCollector : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Money Collector");
			base.Tooltip.SetDefault("Automatically places any coins picked up into your Piggy Bank.\nIf you don't have enough space in your Piggy Bank it does nothing.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.width = 24;
			base.Item.height = 28;
			base.Item.rare = 10;
			base.Item.value = 150000;
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().moneyCollect = true;
		}

		internal static void UpdateCoins(Player p)
		{
			if (p.whoAmI != Main.myPlayer)
			{
				return;
			}
			long copper = 0L;
			long silver = 0L;
			long gold = 0L;
			long platinum = 0L;
			int slots = 0;
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num2 = 0;
			int num3 = 0;
			num3 = CalculateSlots(p, ref copper, ref silver, ref gold, ref platinum, ref slots);
			if (num3 == -1)
			{
				return;
			}
			for (int i = 0; i < 40; i++)
			{
				Item item = p.bank.item[i];
				if (item.IsAir || (item.type >= 71 && item.type <= 74))
				{
					num++;
					if (num >= slots)
					{
						break;
					}
				}
			}
			if (num < slots)
			{
				return;
			}
			for (int j = 50; j < 54; j++)
			{
				Item item2 = p.inventory[j];
				if (item2.type >= 71 && item2.type <= 74)
				{
					p.inventory[j].TurnToAir();
				}
			}
			for (int k = 0; k < 40; k++)
			{
				Item item3 = p.bank.item[k];
				if (item3.type >= 71 && item3.type <= 74)
				{
					p.bank.item[k].TurnToAir();
				}
			}
			for (int num4 = 39; num4 >= 0; num4--)
			{
				if (p.bank.item[num4].IsAir)
				{
					if (num2 + 1 < num3)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(74);
						p.bank.item[num4].stack = 999;
						platinum -= 999;
						num2++;
					}
					else if (num2 + 1 == num3)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(74);
						p.bank.item[num4].stack = (int)platinum;
						num2++;
					}
					else if (!flag3 && gold > 0)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(73);
						p.bank.item[num4].stack = (int)gold;
						flag3 = true;
					}
					else if (!flag2 && silver > 0)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(72);
						p.bank.item[num4].stack = (int)silver;
						flag2 = true;
					}
					else if (!flag && copper > 0)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(71);
						p.bank.item[num4].stack = (int)copper;
						flag = true;
						break;
					}
				}
			}
			if (Main.playerInventory)
			{
				Recipe.FindRecipes();
			}
		}

		private static int CalculateSlots(Player player, ref long copper, ref long silver, ref long gold, ref long platinum, ref int slots)
		{
			int num = 0;
			for (int i = 50; i < 54; i++)
			{
				Item item = player.inventory[i];
				if (item.type >= 71 && item.type <= 74)
				{
					copper += (long)((double)item.stack * Math.Pow(100.0, item.type - 71));
				}
			}
			if (copper > 0)
			{
				for (int j = 0; j < 40; j++)
				{
					Item item2 = player.bank.item[j];
					if (item2.type >= 71 && item2.type <= 74)
					{
						copper += (long)((double)item2.stack * Math.Pow(100.0, item2.type - 71));
					}
				}
				ValueCalc(ref copper, ref silver, ref gold, ref platinum);
				if (platinum > 0)
				{
					num = (int)((platinum % 999 == 0L) ? (platinum / 999) : (platinum / 999 + 1));
				}
				slots = ((gold > 0) ? 1 : 0) + ((silver > 0) ? 1 : 0) + ((copper > 0) ? 1 : 0) + num;
				return num;
			}
			return -1;
		}

		private static void ValueCalc(ref long copper, ref long silver, ref long gold, ref long platinum)
		{
			platinum = copper / 1000000;
			copper -= platinum * 1000000;
			gold = copper / 10000;
			copper -= gold * 10000;
			silver = copper / 100;
			copper -= silver * 100;
		}
	}
}
