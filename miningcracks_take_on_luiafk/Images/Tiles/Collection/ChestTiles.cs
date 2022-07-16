using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public abstract class ChestTiles : ModTile
	{
		public override string HighlightTexture => "Terraria/Images/Misc/TileOutlines/Tiles_21";

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void PlaceInWorld(int x, int y, Item item)
		{
			Chests.PlaceHarvester(x, y);
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			Chests.Kill(x, y, base.ChestDrop);
		}

		public override void MouseOver(int x, int y)
		{
			Chests.MouseOver(base.ContainerName.ToString(), base.ChestDrop, x, y);
		}

		public override void MouseOverFar(int x, int y)
		{
			Chests.MouseOverFar(base.ContainerName.ToString(), base.ChestDrop, x, y);
		}

		public override bool RightClick(int x, int y)
		{
			if (base.RightClick(x, y))
			{
				Chests.ChestRightClick(x, y);
				return true;
			}
			return false;
		}
	}
}
