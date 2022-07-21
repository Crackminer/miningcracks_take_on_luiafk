using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public abstract class ChestTiles : ModTile
	{
		public override string HighlightTexture => "Terraria/Images/Misc/TileOutlines/Tiles_21";

		internal bool loaded = false;

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void PlaceInWorld(int x, int y, Item item)
		{
			Chests.PlaceHarvester(x, y);
			loaded = true;
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
			Chests.ChestRightClick(x, y);
			return true;
		}

		public override void NearbyEffects(int i, int j, bool closer)		//doesnt work like i wanted :(
		{
			if (!Main.PlayerLoaded) return;
			if (!loaded)
			{
				Chests.PlaceHarvester(i, j);
				loaded = true;
			}
		}
	}
}
