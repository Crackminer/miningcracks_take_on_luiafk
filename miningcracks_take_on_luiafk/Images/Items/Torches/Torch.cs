using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Torches
{
	public abstract class Torch : ModItem
	{
		private readonly string name;

		private readonly int style;

		private readonly bool noWet;

		private readonly int type;

		private readonly Vector3 light;

		public Torch(string name, int style, int type, Vector3 light, bool noWet = true)
		{
			this.name = name;
			this.style = style;
			this.type = type;
			this.light = light;
			this.noWet = noWet;
		}

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited " + name + "Torches");
			base.Tooltip.SetDefault("Never run out of " + name + "Torches.");
			base.SacrificeTotal = 1;
		}

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Torches;
        }

        public override void SetDefaults()
		{
			base.Item.consumable = false;
			base.Item.flame = true;
			base.Item.noWet = noWet;
			base.Item.useStyle = 1;
			base.Item.useTurn = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.holdStyle = 1;
			base.Item.autoReuse = true;
			base.Item.createTile = 4;
			base.Item.placeStyle = style;
			Defaults.Base(base.Item);
		}

        public override void HoldItem(Player player)
		{
			if ((!player.wet && noWet) || !noWet)
			{
				Vector2 pos = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * (float)player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), reverseRotation: true);
				AddLight(pos);
			}
		}

		protected virtual void AddLight(Vector2 pos)
		{
			Lighting.AddLight(pos, light);
		}

		public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
		{
			dryTorch = true;
			wetTorch = !noWet;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(type, 396).AddTile(18).Register();
		}
	}
}
