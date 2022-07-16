using System.Linq;
using Terraria;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class Extensions
	{
		internal static bool HasAtleastOne(this Item[] itemArray, params int[] itemTypes)
		{
			foreach (Item item in itemArray)
			{
				if (!item.IsAir && itemTypes.Contains(item.type))
				{
					return true;
				}
			}
			return false;
		}

		internal static bool HasAtleastAmount(this Item[] itemArray, int amount, params int[] itemTypes)
		{
			if (amount < 1)
			{
				return true;
			}
			foreach (Item item in itemArray)
			{
				if (!item.IsAir && itemTypes.Contains(item.type))
				{
					amount -= item.stack;
					if (amount <= 0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
