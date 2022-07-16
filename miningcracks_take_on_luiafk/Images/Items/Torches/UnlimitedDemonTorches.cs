using Microsoft.Xna.Framework;
using Terraria;

namespace miningcracks_take_on_luiafk.Images.Items.Torches
{
	public class UnlimitedDemonTorches : Torch
	{
		public UnlimitedDemonTorches()
			: base("Demon ", 7, 433, Vector3.Zero)
		{
		}

		protected override void AddLight(Vector2 pos)
		{
						Lighting.AddLight(pos, 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch), 0.3f, 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch));
		}
	}
}
