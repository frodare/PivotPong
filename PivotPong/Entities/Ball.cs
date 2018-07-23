using System;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using PivotPong.Desktop.Components;
using Microsoft.Xna.Framework;

namespace PivotPong.Desktop.Entities
{
    public class Ball
    {
		public static Entity New(Scene scene)
        {
            var e = scene.createEntity("ball");
            e.addComponent(new Sprite(BallTexture(scene)));
            e.addComponent<CircleCollider>();

            BallBody body = new BallBody(scene);
            body.velocity = new Vector2(0, 0);
            e.addComponent(body);

			e.addComponent(new CircularBounds(Vector2.Zero, 300));

			return e;
        }

		private static Texture2D BallTexture(Scene scene)
        {
            Texture2D originalTexture = scene.content.Load<Texture2D>("balls");
            var sourceRectangle = new Rectangle(0, 0, 32, 32);

            
			var texture = new Texture2D(Core.graphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
            Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
            originalTexture.GetData(0, sourceRectangle, data, 0, data.Length);
            texture.SetData(data);
            return texture;
        }

    }
}
