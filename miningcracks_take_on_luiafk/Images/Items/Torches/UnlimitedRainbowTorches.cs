using Microsoft.Xna.Framework;
using Terraria;

namespace miningcracks_take_on_luiafk.Images.Items.Torches
{
	public class UnlimitedRainbowTorches : Torch
	{
		public UnlimitedRainbowTorches()
			: base("Rainbow ", 14, 3045, Vector3.Zero)
		{
		}

		protected override void AddLight(Vector2 pos)
		{
						Lighting.AddLight(pos, (float)Main.DiscoR / 255f, (float)Main.DiscoG / 255f, (float)Main.DiscoB / 255f);
		}
	}
}
