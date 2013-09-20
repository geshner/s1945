#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace s1945
{
	public class Ocean : Microsoft.Xna.Framework.DrawableGameComponent
	{
		SpriteBatch spriteBatch;
		Texture2D waterTexture;
		RenderTarget2D oceanTexture;
		Vector2 position;

		public Ocean (Game game) : base(game)
		{
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (Game.GraphicsDevice);

			waterTexture = Game.Content.Load<Texture2D> ("water");

			int oceanWidth = Game.GraphicsDevice.Viewport.Width + (waterTexture.Width * 2);
			int oceanHeight = GraphicsDevice.Viewport.Height + (waterTexture.Height * 2);

			oceanTexture = new RenderTarget2D (GraphicsDevice, oceanWidth, oceanHeight);

			GraphicsDevice.SetRenderTarget (oceanTexture);

			GraphicsDevice.Clear (Color.Transparent);

			spriteBatch.Begin ();

			oceanWidth = oceanWidth / waterTexture.Width;
			oceanHeight = oceanHeight / waterTexture.Height;


			for (int posX = 0; posX < oceanWidth; posX++) {
				for (int posY = 0; posY < oceanHeight; posY++) {

					spriteBatch.Draw (waterTexture, new Vector2 (posX * waterTexture.Width, posY * waterTexture.Height), Color.White);
				}
			}

			spriteBatch.End ();

			GraphicsDevice.SetRenderTarget (null);

			position.X = - waterTexture.Width;
			position.Y = - waterTexture.Height;

			base.LoadContent ();
		}

		public override void Update (GameTime gameTime)
		{
			position.Y++;

			if (position.Y == 0) {
				position.Y = - waterTexture.Height;
			}

			base.Update (gameTime);
		}

		public override void Draw (GameTime gameTime)
		{
			spriteBatch.Begin ();
			spriteBatch.Draw (oceanTexture, position, Color.White);
			spriteBatch.End ();
		}


	}
}