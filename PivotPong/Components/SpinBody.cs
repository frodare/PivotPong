using System;
using Microsoft.Xna.Framework;
using Nez;
using PivotPong.Desktop.Components.Utils;
using PivotPong.Desktop.Scenes;

namespace PivotPong.Desktop.Components
{
	public class SpinBody : Component, IUpdatable
    {

		public PolarVector position = new PolarVector();
        



		public Vector2 getWorldPosition () {
			// add scene rot
			// convert to vector2d

			PolarVector offseted = new PolarVector(position.Angle - GameScene.rotation, position.Radius);
                
				return offseted.toVector2();
		}


		void IUpdatable.update()
        {
			entity.transform.rotation = -GameScene.rotation;
			entity.transform.position = getWorldPosition();

        }


    }
}
