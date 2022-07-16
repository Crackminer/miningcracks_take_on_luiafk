using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.Utility;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.NPCs
{
	public class Deeps : ModNPC
	{
		private int frameCount;

		private bool forward = true;

		private bool firstFrame = true;

		private int currentBoss;

		private LuiafkPlayer luiP;

		internal static int defense;

		internal List<int> types = new List<int>();

		public override string Texture => "miningcracks_take_on_luiafk/Images/NPCs/Deeps/Deeps";

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Patchwerk");
			Main.npcFrameCount[base.NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			base.NPC.friendly = false;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.aiStyle = -1;
			base.NPC.damage = 0;
			base.NPC.width = 150;
			base.NPC.height = 150;
			base.NPC.trapImmune = false;
			base.NPC.lavaImmune = false;
			base.NPC.defense = 0;
			base.NPC.lifeMax = int.MaxValue;
			base.NPC.knockBackResist = 0f;
			base.NPC.chaseable = true;
			base.NPC.netAlways = true;
			/*if (LuiafkMod.CalamityLoaded)
			{
				base.NPC.buffImmune[LuiafkMod.CalamityMod.Find<ModBuff>("ExoFreeze").Type] = true;
				base.NPC.buffImmune[LuiafkMod.CalamityMod.Find<ModBuff>("GlacialState").Type] = true;
			}*/
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool CheckDead()
		{
			return false;
		}

		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
		{
			base.NPC.life = int.MaxValue;
			if (base.NPC.ai[3] == 1f)
			{
				base.NPC.immune[player.whoAmI] = 0;
			}
		}

		public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
		{
			base.NPC.life = int.MaxValue;
			if (base.NPC.ai[3] == 1f)
			{
				base.NPC.immune[projectile.owner] = 0;
			}
		}

		public override void UpdateLifeRegen(ref int damage)
		{
			base.NPC.life = int.MaxValue;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
												Lighting.AddLight(base.NPC.Center, 1.3f, 1.3f, 1.3f);
			if (Main.player[Main.myPlayer].GetModPlayer<LuiafkPlayer>().uiDrawDummyHitbox)
			{
				MiscMethods.DrawRectangleOutline(spriteBatch, base.NPC.Hitbox, new Color(255, 0, 0, 0));
			}
			return true;
		}

		private void WhichFrame()
		{
			frameCount++;
			if (firstFrame)
			{
				firstFrame = false;
				NewBoss();
			}
			else if (frameCount == 192)
			{
				NewBoss();
				frameCount = 0;
			}
			else if (frameCount % 8 == 0)
			{
				FindNextFrame();
			}
		}

		private void FindNextFrame()
		{
			int num = TextureAssets.Npc[currentBoss].Value.Height / Main.npcFrameCount[currentBoss];
			if (forward)
			{
				base.NPC.frame.Y += num;
			}
			else
			{
				base.NPC.frame.Y -= num;
			}
			if (base.NPC.frame.Y + num > TextureAssets.Npc[currentBoss].Value.Height)
			{
				base.NPC.frame.Y -= num;
				forward = false;
			}
			else if (base.NPC.frame.Y < 0)
			{
				base.NPC.frame.Y += num;
				forward = true;
			}
		}

		private void NewBoss()
		{
									do
			{
				currentBoss = LuiafkMod.AllBosses[Main.rand.Next(LuiafkMod.AllBosses.Length)];
			}
			while (Main.npcFrameCount[currentBoss] < 2);
			if (!types.Contains(currentBoss) && currentBoss < 580)
			{
				Asset<Texture2D>[] npc = TextureAssets.Npc;
				int num = currentBoss;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Terraria/Images/NPC_");
				defaultInterpolatedStringHandler.AppendFormatted(currentBoss);
				npc[num] = ModContent.Request<Texture2D>(defaultInterpolatedStringHandler.ToStringAndClear(), (AssetRequestMode)1);
				types.Add(currentBoss);
			}
			base.NPC.frame = new Rectangle(0, 0, TextureAssets.Npc[currentBoss].Value.Width, TextureAssets.Npc[currentBoss].Value.Height / Main.npcFrameCount[currentBoss]);
			forward = true;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

		public override bool PreAI()
		{
									base.NPC.defense = defense;
			base.NPC.velocity = Vector2.Zero;
			LuiafkWorld.checkForBoss = true;
			base.NPC.lifeMax = int.MaxValue;
			base.NPC.life = int.MaxValue;
			if (Main.netMode != 1)
			{
				if (base.NPC.breath < 200)
				{
					base.NPC.breath = 200;
				}
				if (base.NPC.ai[1] == 1f)
				{
					luiP = Main.player[(int)base.NPC.ai[2]].GetModPlayer<LuiafkPlayer>();
					if (luiP.Player.active && luiP.deepsDelete == base.NPC.whoAmI)
					{
						base.NPC.ai[1] = 0f;
						return false;
					}
					MiscMethods.Despawn(base.NPC.whoAmI);
				}
				else
				{
					if (luiP == null)
					{
						MiscMethods.Despawn(base.NPC.whoAmI);
						return false;
					}
					if (!luiP.Player.active || luiP.deepsDelete != base.NPC.whoAmI || LuiafkWorld.AnyBoss)
					{
						if (luiP.deepsDelete == base.NPC.whoAmI)
						{
							luiP.deepsDelete = -1;
						}
						MiscMethods.Despawn(base.NPC.whoAmI);
					}
				}
			}
			return false;
		}
	}
}
