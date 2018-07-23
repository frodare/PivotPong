using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using PivotPong.Desktop.Scenes;

namespace PivotPong.Desktop.Components
{
	public class SpinWithLevel : Component, IUpdatable
	{
		private float lastRot = 0;

		void IUpdatable.update()
		{

			entity.transform.rotation = -GameScene.rotation;
			entity.transform.position = RotateAboutOrigin(entity.transform.position, -(GameScene.rotation - lastRot));
			lastRot = GameScene.rotation;

		}

		public Vector2 RotateAboutOrigin(Vector2 point, float rotation)
		{
			return Vector2.Transform(point, Matrix.CreateRotationZ(rotation));
		}

	}
}
