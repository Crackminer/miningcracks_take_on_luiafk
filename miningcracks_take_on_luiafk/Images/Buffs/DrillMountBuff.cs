using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Buffs
{
	public class DrillMountBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Laser Drill Mount");
			base.Description.SetDefault("Careful you don't destroy everything.");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(base.Mod.Find<ModMount>("DrillMountMount").Type, player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
