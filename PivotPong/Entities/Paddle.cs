using System;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using PivotPong.Desktop.Components;
using Microsoft.Xna.Framework;

namespace PivotPong.Desktop.Entities
{
    public class Paddle
    {
		public static void New(Scene scene, int player)
        {
            var e = scene.createEntity("paddle" + player);
            Texture2D texture = scene.content.Load<Texture2D>("paddle");
            e.addComponent(new Sprite(texture));

            BoxCollider boxCollider = new BoxCollider();
            e.addComponent(boxCollider);

			SpinBody body = new SpinBody();
			e.addComponent(body);

            e.addComponent(new PaddleMover(player));

			e.addComponent<FaceOrigin>();


			if (player == 0) {
				body.position.Angle = 0;
			} else {
				body.position.Angle = 1;
			}

			body.position.Radius = 300;


            //e.transform.position = new Vector2(0, -400f + (player * 800));
        }

    }
}
