#define DEBUG
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using PivotPong.Desktop.Components;
using PivotPong.Desktop.Entities;
using PivotPong.Desktop.Scenes;

// sprites from https://ccrgeek.wordpress.com/rpg-maker-ace/graphics/character-sprites/


namespace PivotPong.Desktop
{



	public class Game1 : Core
	{
      
		public Game1() : base()
		{
            
		}

		protected override void Initialize()
		{
			base.Initialize();
			base.Initialize();
			Window.AllowUserResizing = true;

			//Core.debugRenderEnabled = true;
			IsFixedTimeStep = true;
            
            
			Core.defaultSamplerState = SamplerState.LinearClamp;
         
			scene = SetupMainScene();
		}

		private Scene SetupMainScene()
		{
			//var scene = Scene.createWithDefaultRenderer(Color.Black);

			var scene = new GameScene();
			scene.clearColor = Color.Black;
            scene.addRenderer(new DefaultRenderer());


			CreateBall(scene);
			Paddle.New(scene, 0);
			Paddle.New(scene, 1);

			//scene.on

			return scene;
		}
      

		private void CreateBall(Scene scene)
		{
			var e = Ball.New(scene);
			e.getComponent<BallBody>().velocity = new Vector2(100, 100);
			e.transform.position = new Vector2(0, 0);
		}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}
	}
}
