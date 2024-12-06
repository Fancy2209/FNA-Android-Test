/* SpriteBatch Stress Test
 * Written by Ethan "flibitijibibo" Lee
 * http://www.flibitijibibo.com/
 *
 * Released under public domain.
 * No warranty implied; use at your own risk.
 */

using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
class SpriteBatchTest : Game
{
	private const int SPRITECOUNT = 2048;
	private const int TEXTURECOUNT = 2;

	private const int TEXTURESIZE = 128;
	private static readonly Color TEXTURECOLOR = Color.White;

	private SpriteSortMode mode = SpriteSortMode.Deferred;

	private Stopwatch timer;
	private Random random;
	private Vector2[] positions;
	private Color[] colors;
	private Texture2D[] boxRefs;
	private Texture2D[] boxes;
	private SpriteBatch batch;

	public SpriteBatchTest() : base()
	{
		(new GraphicsDeviceManager(this)).IsFullScreen = true;
		timer = new Stopwatch();
		random = new Random();
		positions = new Vector2[SPRITECOUNT];
		colors = new Color[SPRITECOUNT];
		boxRefs = new Texture2D[SPRITECOUNT];
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Black);
		timer.Start();
		batch.Begin(mode, BlendState.AlphaBlend);
		for (int i = 0; i < SPRITECOUNT; i += 1)
		{
			batch.Draw(boxRefs[i], positions[i], colors[i]);
		}
		batch.End();
		timer.Stop();
		Console.WriteLine(
			"Batch took " +
			timer.ElapsedMilliseconds.ToString() +
			"ms with " +
			mode.ToString()
		);
		timer.Reset();
	}

	protected override void Update(GameTime gameTime)
	{
		if (Keyboard.GetState().IsKeyDown(Keys.D1))
		{
			mode = SpriteSortMode.Deferred;
		}
		else if (Keyboard.GetState().IsKeyDown(Keys.D2))
		{
			mode = SpriteSortMode.Immediate;
		}
		else if (Keyboard.GetState().IsKeyDown(Keys.D3))
		{
			mode = SpriteSortMode.Texture;
		}
		else if (Keyboard.GetState().IsKeyDown(Keys.D4))
		{
			mode = SpriteSortMode.BackToFront;
		}
		else if (Keyboard.GetState().IsKeyDown(Keys.D5))
		{
			mode = SpriteSortMode.FrontToBack;
		}
		for (int i = 0; i < SPRITECOUNT; i += 1)
		{
			positions[i].X = (float) (random.NextDouble() * GraphicsDeviceManager.DefaultBackBufferWidth) - (boxes[0].Width / 2);
			positions[i].Y = (float) (random.NextDouble() * GraphicsDeviceManager.DefaultBackBufferHeight) - (boxes[0].Height / 2);
			colors[i].R = (byte) (random.NextDouble() * 255);
			colors[i].G = (byte) (random.NextDouble() * 255);
			colors[i].B = (byte) (random.NextDouble() * 255);
			colors[i].A = (byte) (random.NextDouble() * 255);
			boxRefs[i] = boxes[(int) (random.NextDouble() * TEXTURECOUNT)];
		}
	}

	protected override void LoadContent()
	{
		Color[] color = new Color[TEXTURESIZE * TEXTURESIZE];
		for (int i = 0; i < color.Length; i += 1)
		{
			color[i] = TEXTURECOLOR;
		}
		boxes = new Texture2D[TEXTURECOUNT];
		for (int i = 0; i < TEXTURECOUNT; i += 1)
		{
			boxes[i] = new Texture2D(GraphicsDevice, 128, 128);
			boxes[i].SetData(color);
		}
		batch = new SpriteBatch(GraphicsDevice);
	}

	protected override void UnloadContent()
	{
		batch.Dispose();
		batch = null;
		for (int i = 0; i < TEXTURECOUNT; i += 1)
		{
			boxes[i].Dispose();
			boxes[i] = null;
		}
		boxes = null;
	}

	public static void Main(string[] args)
	{
		using (SpriteBatchTest game = new SpriteBatchTest())
		{
			game.Run();
		}
	}
}