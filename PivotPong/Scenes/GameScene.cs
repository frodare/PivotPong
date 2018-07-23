using System;
using Microsoft.Xna.Framework;
using Nez;

namespace PivotPong.Desktop.Scenes
{
	public class GameScene : Scene
	{
		public static float rotation = 0;
		public static float speed = 1.25f;

		public override void initialize()
		{
			base.initialize();
                       

		}

		public override void onStart()
		{
			base.onStart();
            
		}

		public override void update()
		{
			base.update();
			camera.position = Vector2.Zero;
			rotation += speed * Time.deltaTime;
			camera.rotation = rotation;
		}
	}
}
