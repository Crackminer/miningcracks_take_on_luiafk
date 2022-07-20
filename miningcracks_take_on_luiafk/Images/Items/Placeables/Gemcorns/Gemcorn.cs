using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Tiles.Gemcorns;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ContentSamples.CreativeHelper;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Gemcorns
{
    public class Gemcorn : ModItem
    {
        private readonly string name;

        private readonly int type;

        public Gemcorn(string name, int type)
        {
            this.name = name;
            this.type = type;
        }

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Modded " + name + "Gemcorn");
			base.Tooltip.SetDefault("'Cause vanilla's cant be placed :/\nOnly for placing down for the Gem Harvester.");
			base.SacrificeTotal = 15;
		}

		public override void SetDefaults()
		{
			base.Item.consumable = true;
			base.Item.useStyle = 1;
			base.Item.useTurn = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 20;
			base.Item.holdStyle = 1;
			base.Item.autoReuse = true;
			int tt = 0;
			switch(type)
            {
				case 1: tt = ModContent.TileType<TopazCorn>(); break;
				case 2: tt = ModContent.TileType<AmethystCorn>(); break;
				case 3: tt = ModContent.TileType<SapphireCorn>(); break;
				case 4: tt = ModContent.TileType<EmeraldCorn>(); break;
				case 5: tt = ModContent.TileType<RubyCorn>(); break;
				case 6: tt = ModContent.TileType<DiamondCorn>(); break;
				case 7: tt = ModContent.TileType<AmberCorn>(); break;
            }
			base.Item.createTile = tt;
			base.Item.placeStyle = 1;
			Defaults.Base(base.Item);
			base.Item.maxStack = 9999;
		}
	}
}
