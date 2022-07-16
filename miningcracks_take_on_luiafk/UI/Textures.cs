using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.UI
{
	internal static class Textures
	{
		private const string location = "miningcracks_take_on_luiafk/Images/Settings/";

		internal static Asset<Texture2D> BiomeCorruption { get; private set; }

		internal static Asset<Texture2D> BiomeCrimson { get; private set; }

		internal static Asset<Texture2D> BiomeHallow { get; private set; }

		internal static Asset<Texture2D> BiomeIce { get; private set; }

		internal static Asset<Texture2D> BiomeIceCorruption { get; private set; }

		internal static Asset<Texture2D> BiomeIceCrimson { get; private set; }

		internal static Asset<Texture2D> BiomeIceHallow { get; private set; }

		internal static Asset<Texture2D> BiomeJungle { get; private set; }

		internal static Asset<Texture2D> BiomeMushroom { get; private set; }

		internal static Asset<Texture2D> BuffBattler { get; private set; }

		internal static Asset<Texture2D> BuffCrate { get; private set; }

		internal static Asset<Texture2D> BuffDangerSense { get; private set; }

		internal static Asset<Texture2D> BuffFeatherFall { get; private set; }

		internal static Asset<Texture2D> BuffGravitation { get; private set; }

		internal static Asset<Texture2D> BuffInferno { get; private set; }

		internal static Asset<Texture2D> BuffInvis { get; private set; }

		internal static Asset<Texture2D> BuffPeace { get; private set; }

		internal static Asset<Texture2D> BuffSpelunker { get; private set; }

		internal static Asset<Texture2D> ComboHoik { get; private set; }

		internal static Asset<Texture2D> ComboLiquid { get; private set; }

		internal static Asset<Texture2D> ComboPaint { get; private set; }

		internal static Asset<Texture2D> ComboWall { get; private set; }

		internal static Asset<Texture2D> ComboWire { get; private set; }

		internal static Asset<Texture2D> HoikActuated { get; private set; }

		internal static Asset<Texture2D> HoikFull { get; private set; }

		internal static Asset<Texture2D> HoikGap { get; private set; }

		internal static Asset<Texture2D> HoikHalf { get; private set; }

		internal static Asset<Texture2D> HoikReverse { get; private set; }

		internal static Asset<Texture2D> HoikSlopeDownLeft { get; private set; }

		internal static Asset<Texture2D> HoikSlopeDownRight { get; private set; }

		internal static Asset<Texture2D> HoikSlopeUpLeft { get; private set; }

		internal static Asset<Texture2D> HoikSlopeUpRight { get; private set; }

		internal static Asset<Texture2D> MiscCampFire { get; private set; }

		internal static Asset<Texture2D> MiscFishing { get; private set; }

		internal static Asset<Texture2D> MiscHoney { get; private set; }

		internal static Asset<Texture2D> MiscLava { get; private set; }

		internal static Asset<Texture2D> MiscLight { get; private set; }

		internal static Asset<Texture2D> MiscMineTrack { get; private set; }

		internal static Asset<Texture2D> MiscPlatform { get; private set; }

		internal static Asset<Texture2D> MiscRopes { get; private set; }

		internal static Asset<Texture2D> MiscSponge { get; private set; }

		internal static Asset<Texture2D> MiscWalls { get; private set; }

		internal static Asset<Texture2D> MiscWater { get; private set; }

		internal static Asset<Texture2D> MossBlue { get; private set; }

		internal static Asset<Texture2D> MossLava { get; private set; }

		internal static Asset<Texture2D> MossOlive { get; private set; }

		internal static Asset<Texture2D> MossPurple { get; private set; }

		internal static Asset<Texture2D> MossRed { get; private set; }

		internal static Asset<Texture2D> MossTeal { get; private set; }

		internal static Asset<Texture2D> ColorBlack { get; private set; }

		internal static Asset<Texture2D> ColorBlue { get; private set; }

		internal static Asset<Texture2D> ColorBrown { get; private set; }

		internal static Asset<Texture2D> ColorCyan { get; private set; }

		internal static Asset<Texture2D> ColorDeepBlue { get; private set; }

		internal static Asset<Texture2D> ColorDeepCyan { get; private set; }

		internal static Asset<Texture2D> ColorDeepGreen { get; private set; }

		internal static Asset<Texture2D> ColorDeepLime { get; private set; }

		internal static Asset<Texture2D> ColorDeepOrange { get; private set; }

		internal static Asset<Texture2D> ColorDeepPink { get; private set; }

		internal static Asset<Texture2D> ColorDeepPurple { get; private set; }

		internal static Asset<Texture2D> ColorDeepRed { get; private set; }

		internal static Asset<Texture2D> ColorDeepSkyBlue { get; private set; }

		internal static Asset<Texture2D> ColorDeepTeal { get; private set; }

		internal static Asset<Texture2D> ColorDeepViolet { get; private set; }

		internal static Asset<Texture2D> ColorDeepYellow { get; private set; }

		internal static Asset<Texture2D> ColorGray { get; private set; }

		internal static Asset<Texture2D> ColorGreen { get; private set; }

		internal static Asset<Texture2D> ColorLime { get; private set; }

		internal static Asset<Texture2D> ColorNegative { get; private set; }

		internal static Asset<Texture2D> ColorOrange { get; private set; }

		internal static Asset<Texture2D> ColorPink { get; private set; }

		internal static Asset<Texture2D> ColorPurple { get; private set; }

		internal static Asset<Texture2D> ColorRed { get; private set; }

		internal static Asset<Texture2D> ColorShadow { get; private set; }

		internal static Asset<Texture2D> ColorSkyBlue { get; private set; }

		internal static Asset<Texture2D> ColorTeal { get; private set; }

		internal static Asset<Texture2D> ColorViolet { get; private set; }

		internal static Asset<Texture2D> ColorWhite { get; private set; }

		internal static Asset<Texture2D> ColorYellow { get; private set; }

		internal static Asset<Texture2D> PaintModeNone { get; private set; }

		internal static Asset<Texture2D> PaintModeTile { get; private set; }

		internal static Asset<Texture2D> PaintModeWall { get; private set; }

		internal static Asset<Texture2D> RegrowthCorruption { get; private set; }

		internal static Asset<Texture2D> RegrowthCrimson { get; private set; }

		internal static Asset<Texture2D> RegrowthGrass { get; private set; }

		internal static Asset<Texture2D> RegrowthHallow { get; private set; }

		internal static Asset<Texture2D> RegrowthJungle { get; private set; }

		internal static Asset<Texture2D> RegrowthLeaf { get; private set; }

		internal static Asset<Texture2D> RegrowthMushroom { get; private set; }

		internal static Asset<Texture2D> RegrowthNone { get; private set; }

		internal static Asset<Texture2D> RegrowthRoots { get; private set; }

		internal static Asset<Texture2D> SolutionCorruption { get; private set; }

		internal static Asset<Texture2D> SolutionCrimson { get; private set; }

		internal static Asset<Texture2D> SolutionGrass { get; private set; }

		internal static Asset<Texture2D> SolutionHallow { get; private set; }

		internal static Asset<Texture2D> SolutionHell { get; private set; }

		internal static Asset<Texture2D> SolutionIce { get; private set; }

		internal static Asset<Texture2D> SolutionJungle { get; private set; }

		internal static Asset<Texture2D> SolutionMushroom { get; private set; }

		internal static Asset<Texture2D> SolutionSky { get; private set; }

		internal static Asset<Texture2D> SolutionUse { get; private set; }

		internal static Asset<Texture2D> WallBorealWood { get; private set; }

		internal static Asset<Texture2D> WallEbonWood { get; private set; }

		internal static Asset<Texture2D> WallGrayBrick { get; private set; }

		internal static Asset<Texture2D> WallLivingWood { get; private set; }

		internal static Asset<Texture2D> WallPalmWood { get; private set; }

		internal static Asset<Texture2D> WallPearlWood { get; private set; }

		internal static Asset<Texture2D> WallShadeWood { get; private set; }

		internal static Asset<Texture2D> WallStoneSlab { get; private set; }

		internal static Asset<Texture2D> WallWood { get; private set; }

		internal static Asset<Texture2D> WireActuator { get; private set; }

		internal static Asset<Texture2D> WireBlue { get; private set; }

		internal static Asset<Texture2D> WireCutter { get; private set; }

		internal static Asset<Texture2D> WireGreen { get; private set; }

		internal static Asset<Texture2D> WireRed { get; private set; }

		internal static Asset<Texture2D> WireYellow { get; private set; }

		internal static void Unload()
		{
			BiomeCorruption = null;
			BiomeCrimson = null;
			BiomeHallow = null;
			BiomeIce = null;
			BiomeIceCorruption = null;
			BiomeIceCrimson = null;
			BiomeIceHallow = null;
			BiomeJungle = null;
			BiomeMushroom = null;
			BuffBattler = null;
			BuffCrate = null;
			BuffDangerSense = null;
			BuffFeatherFall = null;
			BuffGravitation = null;
			BuffInferno = null;
			BuffInvis = null;
			BuffPeace = null;
			BuffSpelunker = null;
			ComboHoik = null;
			ComboLiquid = null;
			ComboPaint = null;
			ComboWall = null;
			ComboWire = null;
			HoikActuated = null;
			HoikFull = null;
			HoikGap = null;
			HoikHalf = null;
			HoikReverse = null;
			HoikSlopeDownLeft = null;
			HoikSlopeDownRight = null;
			HoikSlopeUpLeft = null;
			HoikSlopeUpRight = null;
			MiscCampFire = null;
			MiscFishing = null;
			MiscHoney = null;
			MiscLava = null;
			MiscLight = null;
			MiscMineTrack = null;
			MiscPlatform = null;
			MiscRopes = null;
			MiscSponge = null;
			MiscWalls = null;
			MiscWater = null;
			MossBlue = null;
			MossLava = null;
			MossOlive = null;
			MossPurple = null;
			MossRed = null;
			MossTeal = null;
			ColorBlack = null;
			ColorBlue = null;
			ColorBrown = null;
			ColorCyan = null;
			ColorDeepBlue = null;
			ColorDeepCyan = null;
			ColorDeepGreen = null;
			ColorDeepLime = null;
			ColorDeepOrange = null;
			ColorDeepPink = null;
			ColorDeepPurple = null;
			ColorDeepRed = null;
			ColorDeepSkyBlue = null;
			ColorDeepTeal = null;
			ColorDeepViolet = null;
			ColorDeepYellow = null;
			ColorGray = null;
			ColorGreen = null;
			ColorLime = null;
			ColorNegative = null;
			ColorOrange = null;
			ColorPink = null;
			ColorPurple = null;
			ColorRed = null;
			ColorShadow = null;
			ColorSkyBlue = null;
			ColorTeal = null;
			ColorViolet = null;
			ColorWhite = null;
			ColorYellow = null;
			PaintModeNone = null;
			PaintModeTile = null;
			PaintModeWall = null;
			RegrowthCorruption = null;
			RegrowthCrimson = null;
			RegrowthGrass = null;
			RegrowthHallow = null;
			RegrowthJungle = null;
			RegrowthLeaf = null;
			RegrowthMushroom = null;
			RegrowthNone = null;
			RegrowthRoots = null;
			SolutionCorruption = null;
			SolutionCrimson = null;
			SolutionGrass = null;
			SolutionHallow = null;
			SolutionHell = null;
			SolutionIce = null;
			SolutionJungle = null;
			SolutionMushroom = null;
			SolutionSky = null;
			SolutionUse = null;
			WallBorealWood = null;
			WallEbonWood = null;
			WallGrayBrick = null;
			WallLivingWood = null;
			WallPalmWood = null;
			WallPearlWood = null;
			WallShadeWood = null;
			WallStoneSlab = null;
			WallWood = null;
			WireActuator = null;
			WireBlue = null;
			WireCutter = null;
			WireGreen = null;
			WireRed = null;
			WireYellow = null;
		}

		internal static void Load()
		{
			BiomeCorruption = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeCorruption", (AssetRequestMode)1);
			BiomeCrimson = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeCrimson", (AssetRequestMode)1);
			BiomeHallow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeHallow", (AssetRequestMode)1);
			BiomeIce = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeIce", (AssetRequestMode)1);
			BiomeIceCorruption = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeIceCorruption", (AssetRequestMode)1);
			BiomeIceCrimson = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeIceCrimson", (AssetRequestMode)1);
			BiomeIceHallow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeIceHallow", (AssetRequestMode)1);
			BiomeJungle = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeJungle", (AssetRequestMode)1);
			BiomeMushroom = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/biome/BiomeMushroom", (AssetRequestMode)1);
			BuffBattler = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffBattler", (AssetRequestMode)1);
			BuffCrate = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffCrate", (AssetRequestMode)1);
			BuffDangerSense = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffDangerSense", (AssetRequestMode)1);
			BuffFeatherFall = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffFeatherFall", (AssetRequestMode)1);
			BuffGravitation = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffGravitation", (AssetRequestMode)1);
			BuffInferno = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffInferno", (AssetRequestMode)1);
			BuffInvis = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffInvis", (AssetRequestMode)1);
			BuffPeace = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffPeace", (AssetRequestMode)1);
			BuffSpelunker = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/buff/BuffSpelunker", (AssetRequestMode)1);
			ComboHoik = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/combo/ComboHoik", (AssetRequestMode)1);
			ComboLiquid = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/combo/ComboLiquid", (AssetRequestMode)1);
			ComboPaint = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/combo/ComboPaint", (AssetRequestMode)1);
			ComboWall = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/combo/ComboWall", (AssetRequestMode)1);
			ComboWire = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/combo/ComboWire", (AssetRequestMode)1);
			HoikActuated = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikActuated", (AssetRequestMode)1);
			HoikFull = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikFull", (AssetRequestMode)1);
			HoikGap = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikGap", (AssetRequestMode)1);
			HoikHalf = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikHalf", (AssetRequestMode)1);
			HoikReverse = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikReverse", (AssetRequestMode)1);
			HoikSlopeDownLeft = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikSlopeDownLeft", (AssetRequestMode)1);
			HoikSlopeDownRight = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikSlopeDownRight", (AssetRequestMode)1);
			HoikSlopeUpLeft = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikSlopeUpLeft", (AssetRequestMode)1);
			HoikSlopeUpRight = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/hoik/HoikSlopeUpRight", (AssetRequestMode)1);
			MiscCampFire = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscCampFire", (AssetRequestMode)1);
			MiscFishing = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscFishing", (AssetRequestMode)1);
			MiscHoney = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscHoney", (AssetRequestMode)1);
			MiscLava = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscLava", (AssetRequestMode)1);
			MiscLight = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscLight", (AssetRequestMode)1);
			MiscMineTrack = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscMineTrack", (AssetRequestMode)1);
			MiscPlatform = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscPlatform", (AssetRequestMode)1);
			MiscRopes = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscRopes", (AssetRequestMode)1);
			MiscSponge = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscSponge", (AssetRequestMode)1);
			MiscWalls = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscWalls", (AssetRequestMode)1);
			MiscWater = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/misc/MiscWater", (AssetRequestMode)1);
			MossBlue = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/moss/MossBlue", (AssetRequestMode)1);
			MossLava = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/moss/MossLava", (AssetRequestMode)1);
			MossOlive = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/moss/MossOlive", (AssetRequestMode)1);
			MossPurple = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/moss/MossPurple", (AssetRequestMode)1);
			MossRed = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/moss/MossRed", (AssetRequestMode)1);
			MossTeal = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/moss/MossTeal", (AssetRequestMode)1);
			ColorBlack = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorBlack", (AssetRequestMode)1);
			ColorBlue = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorBlue", (AssetRequestMode)1);
			ColorBrown = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorBrown", (AssetRequestMode)1);
			ColorCyan = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorCyan", (AssetRequestMode)1);
			ColorDeepBlue = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepBlue", (AssetRequestMode)1);
			ColorDeepCyan = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepCyan", (AssetRequestMode)1);
			ColorDeepGreen = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepGreen", (AssetRequestMode)1);
			ColorDeepLime = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepLime", (AssetRequestMode)1);
			ColorDeepOrange = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepOrange", (AssetRequestMode)1);
			ColorDeepPink = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepPink", (AssetRequestMode)1);
			ColorDeepPurple = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepPurple", (AssetRequestMode)1);
			ColorDeepRed = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepRed", (AssetRequestMode)1);
			ColorDeepSkyBlue = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepSkyBlue", (AssetRequestMode)1);
			ColorDeepTeal = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepTeal", (AssetRequestMode)1);
			ColorDeepViolet = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepViolet", (AssetRequestMode)1);
			ColorDeepYellow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorDeepYellow", (AssetRequestMode)1);
			ColorGray = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorGray", (AssetRequestMode)1);
			ColorGreen = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorGreen", (AssetRequestMode)1);
			ColorLime = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorLime", (AssetRequestMode)1);
			ColorNegative = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorNegative", (AssetRequestMode)1);
			ColorOrange = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorOrange", (AssetRequestMode)1);
			ColorPink = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorPink", (AssetRequestMode)1);
			ColorPurple = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorPurple", (AssetRequestMode)1);
			ColorRed = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorRed", (AssetRequestMode)1);
			ColorShadow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorShadow", (AssetRequestMode)1);
			ColorSkyBlue = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorSkyBlue", (AssetRequestMode)1);
			ColorTeal = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorTeal", (AssetRequestMode)1);
			ColorViolet = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorViolet", (AssetRequestMode)1);
			ColorWhite = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorWhite", (AssetRequestMode)1);
			ColorYellow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintcolor/ColorYellow", (AssetRequestMode)1);
			PaintModeNone = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintmode/PaintModeNone", (AssetRequestMode)1);
			PaintModeTile = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintmode/PaintModeTile", (AssetRequestMode)1);
			PaintModeWall = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/paintmode/PaintModeWall", (AssetRequestMode)1);
			RegrowthCorruption = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthCorruption", (AssetRequestMode)1);
			RegrowthCrimson = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthCrimson", (AssetRequestMode)1);
			RegrowthGrass = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthGrass", (AssetRequestMode)1);
			RegrowthHallow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthHallow", (AssetRequestMode)1);
			RegrowthJungle = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthJungle", (AssetRequestMode)1);
			RegrowthLeaf = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthLeaf", (AssetRequestMode)1);
			RegrowthMushroom = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthMushroom", (AssetRequestMode)1);
			RegrowthNone = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthNone", (AssetRequestMode)1);
			RegrowthRoots = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/regrowth/RegrowthRoots", (AssetRequestMode)1);
			SolutionCorruption = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionCorruption", (AssetRequestMode)1);
			SolutionCrimson = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionCrimson", (AssetRequestMode)1);
			SolutionGrass = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionGrass", (AssetRequestMode)1);
			SolutionHallow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionHallow", (AssetRequestMode)1);
			SolutionHell = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionHell", (AssetRequestMode)1);
			SolutionIce = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionIce", (AssetRequestMode)1);
			SolutionJungle = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionJungle", (AssetRequestMode)1);
			SolutionMushroom = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionMushroom", (AssetRequestMode)1);
			SolutionSky = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionSky", (AssetRequestMode)1);
			SolutionUse = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/solution/SolutionUse", (AssetRequestMode)1);
			WallBorealWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallBorealWood", (AssetRequestMode)1);
			WallEbonWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallEbonWood", (AssetRequestMode)1);
			WallGrayBrick = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallGrayBrick", (AssetRequestMode)1);
			WallLivingWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallLivingWood", (AssetRequestMode)1);
			WallPalmWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallPalmWood", (AssetRequestMode)1);
			WallPearlWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallPearlWood", (AssetRequestMode)1);
			WallShadeWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallShadeWood", (AssetRequestMode)1);
			WallStoneSlab = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallStoneSlab", (AssetRequestMode)1);
			WallWood = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wall/WallWood", (AssetRequestMode)1);
			WireActuator = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wire/WireActuator", (AssetRequestMode)1);
			WireBlue = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wire/WireBlue", (AssetRequestMode)1);
			WireCutter = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wire/WireCutter", (AssetRequestMode)1);
			WireGreen = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wire/WireGreen", (AssetRequestMode)1);
			WireRed = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wire/WireRed", (AssetRequestMode)1);
			WireYellow = ModContent.Request<Texture2D>("miningcracks_take_on_luiafk/Images/Settings/wire/WireYellow", (AssetRequestMode)1);
		}
	}
}
