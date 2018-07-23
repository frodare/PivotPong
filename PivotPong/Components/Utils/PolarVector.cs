using System;
using Microsoft.Xna.Framework;

namespace PivotPong.Desktop.Components.Utils
{
    public class PolarVector
    {

		public float Angle;
		public float Radius;
        
		public PolarVector()
        {
        }
        
		public PolarVector(float Angle, float Radius)
        {
			this.Angle = Angle;
			this.Radius = Radius;
        }

		public Vector2 toVector2() {         
			return new Vector2((float)(Radius * Math.Cos(Angle)), (float)(Radius * Math.Sin(Angle)));
		}

    }
}
