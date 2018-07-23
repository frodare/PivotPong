using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace PivotPong.Desktop.Components
{
	public class PaddleMover : Component, IUpdatable
	{

		private float speed = 1f;

		private int player;

		public PaddleMover(int player)
		{
			this.player = player;
		}

		public void update()
		{
			float motion = 0f;

			if (Input.isKeyDown(player == 0 ? Keys.Left : Keys.A))
			{
				motion = -speed;
			}
			else if (Input.isKeyDown(player == 0 ? Keys.Right : Keys.D))
			{
				motion = speed;
			}

			entity.getComponents<SpinBody>()[0].position.Angle += motion * Time.deltaTime;
		}

	}
}
