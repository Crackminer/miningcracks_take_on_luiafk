using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal class MyUIPanel : UIPanel
	{
		private Vector2 offset;

		private bool dragging;

		public override void OnActivate()
		{
			base.OnActivate();
			Left.Set((float)Main.mouseX / 1.6f, 0f);
			Top.Set((float)Main.mouseY / 1.6f, 0f);
		}

		public override void MouseDown(UIMouseEvent evt)
		{
			base.MouseDown(evt);
			DragStart(evt);
		}

		public override void MouseUp(UIMouseEvent evt)
		{
			base.MouseUp(evt);
			DragEnd(evt);
		}

		private void DragStart(UIMouseEvent evt)
		{
			offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt)
		{
			Vector2 mousePosition = evt.MousePosition;
			dragging = false;
			Left.Set(mousePosition.X - offset.X, 0f);
			Top.Set(mousePosition.Y - offset.Y, 0f);
			Recalculate();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			if (ContainsPoint(Main.MouseScreen))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				Left.Set((float)Main.mouseX - offset.X, 0f);
				Top.Set((float)Main.mouseY - offset.Y, 0f);
				Recalculate();
			}
			Rectangle val = base.Parent.GetDimensions().ToRectangle();
			Rectangle val2 = GetDimensions().ToRectangle();
			if (!((Rectangle)(val2)).Intersects(val))
			{
				Left.Pixels = Utils.Clamp(Left.Pixels, 0f, (float)((Rectangle)(val)).Right - Width.Pixels);
				Top.Pixels = Utils.Clamp(Top.Pixels, 0f, (float)((Rectangle)(val)).Bottom - Height.Pixels);
				Recalculate();
			}
		}
	}
}
