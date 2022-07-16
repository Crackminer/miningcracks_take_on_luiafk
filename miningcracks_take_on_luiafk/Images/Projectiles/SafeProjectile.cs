using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Projectiles
{
	public class SafeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Flying Safe");
		}

		public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 32;
			base.Projectile.aiStyle = 97;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 10800;
		}

		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverPlayers, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsOverWiresUI.Add(base.Projectile.whoAmI);
		}

		public override void PostAI()
		{
			if (Main.netMode != 2)
			{
				Player player = Main.player[Main.myPlayer];
				LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
				ProjAIs.BankAI(base.Projectile, base.Mod.Find<ModItem>("Safe").Type, -3, ref modPlayer.safe, player, modPlayer);
			}
		}
	}
}
