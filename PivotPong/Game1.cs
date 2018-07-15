#define DEBUG
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using PivotPong.Desktop.Components;

// sprites from https://ccrgeek.wordpress.com/rpg-maker-ace/graphics/character-sprites/


namespace PivotPong.Desktop {



	public class Game1 : Core {
    // GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

		public Game1() : base() {
     
    }

    protected override void Initialize() {
      base.Initialize();
			base.Initialize();
      Window.AllowUserResizing = true;   

			Core.debugRenderEnabled = true;

			scene = SetupMainScene();
    }

		private Scene SetupMainScene() {
			var scene = Scene.createWithDefaultRenderer(Color.Black);
			CreateBall(scene);
			CreatePaddle(scene, 0);
			CreatePaddle(scene, 1);
			return scene;
		}

		private void CreatePaddle(Scene scene, int player) {
      var e = scene.createEntity("paddle" + player);
			Texture2D texture = scene.content.Load<Texture2D>("paddle");
			e.addComponent(new Sprite(texture));

			BoxCollider boxCollider = new BoxCollider();
			e.addComponent(boxCollider);
      /*
      ArcadeRigidbody arcadeRigidbody = new ArcadeRigidbody();
      arcadeRigidbody.shouldUseGravity = false;
      e.addComponent(arcadeRigidbody);
			arcadeRigidbody.elasticity = 0;
			*/

			e.addComponent(new PaddleMover(player));
      
			e.transform.position = new Vector2(500f, 600f - (player * 300));
    }

		  
		private void CreateBall(Scene scene) {
			var e = scene.createEntity("ball");
			e.addComponent(new Sprite(BallTexture(scene)));
			e.addComponent<CircleCollider>();
         
			BallBody body = new BallBody();
			body.velocity = new Vector2(20f, 150f);
			e.addComponent(body);


			e.addComponent(new CircularBounds(new Vector2(500, 500), 400));

			e.transform.position = new Vector2(500f, 500f);
		}

		private Texture2D BallTexture(Scene scene) {
			Texture2D originalTexture = scene.content.Load<Texture2D>("balls");
      var sourceRectangle = new Rectangle(0, 0, 32, 32);
      var texture = new Texture2D(GraphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
      Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
      originalTexture.GetData(0, sourceRectangle, data, 0, data.Length);
      texture.SetData(data);
      return texture;
    }


    protected override void LoadContent() {
      spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void UnloadContent() {
    }

    protected override void Update(GameTime gameTime) {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();


      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      base.Draw(gameTime);
    }
  }
}
