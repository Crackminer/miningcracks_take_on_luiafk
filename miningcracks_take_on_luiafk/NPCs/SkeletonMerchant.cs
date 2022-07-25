using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.NPCs
{
    [AutoloadHead]
    public class SkeletonMerchant : ModNPC
    {
        public override string HeadTexture => "miningcracks_take_on_luiafk/Images/NPCs/SkeletonMerchant/SkeletonMerchant_Head";

        public override string Texture => "Terraria/Images/NPC_453";

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Skeleton Merchant");
            Main.npcFrameCount[base.NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[base.NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[base.NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[base.NPC.type] = 300;
            NPCID.Sets.AttackType[base.NPC.type] = 0;
            NPCID.Sets.AttackTime[base.NPC.type] = 34;
            NPCID.Sets.AttackAverageChance[base.NPC.type] = 30;
            NPCID.Sets.HatOffsetY[base.NPC.type] = 2;
            NPCID.Sets.FaceEmote[base.NPC.type] = 124;

            NPC.Happiness
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love) //Because both love the blow up stuff
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like) //Because both live to work with their hands
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Hate) //Because, you know, it's a skeleton... And the drayd wants to purify him
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love) //Because underground is life
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) //Because Forest is easy to sells things
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate) //Because like bro... A skeleton in snow? How could you think that would work...
            ;
        }

        public override void SetDefaults()
        {
            base.NPC.townNPC = true;
            base.NPC.friendly = true;
            base.NPC.width = 18;
            base.NPC.height = 40;
            base.NPC.aiStyle = 7;
            base.NPC.damage = 10;
            base.NPC.defense = 30;
            base.NPC.lifeMax = 250;
            base.NPC.HitSound = SoundID.NPCHit2;
            base.NPC.DeathSound = SoundID.NPCDeath2;
            base.NPC.knockBackResist = 0.5f;
            base.AnimationType = 453;
        }

        public override string GetChat()
        {
            return Lang.dialog(Main.rand.Next(356, 364));
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.SetupShop(20);
            // I think this isnt implemented yet by TML, but it would be cool if we could sell the pylon. 
            // Maybe there's nothing to do, or maybe there's something to do.
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            /*int count = 0;
            count += NPC.killCount[21];
            count += NPC.killCount[201];
            count += NPC.killCount[202];
            count += NPC.killCount[203];
            count += NPC.killCount[322];
            count += NPC.killCount[323];
            count += NPC.killCount[324];

            return count >= 50;*/
            return NPC.killCount[Item.NPCtoBanner(NPCID.Skeleton)] >= 50; //Counts the kill of every skeleton type in the game
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 14;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 0;
            randExtraCooldown = 1;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 21;
            attackDelay = 10;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 14f;
            gravityCorrection = 16f;
        }
    }
}
