using System;
using Nez;
using Microsoft.Xna.Framework;

namespace PivotPong.Desktop.Components
{
    public class FaceOrigin : Component, IUpdatable
    {
        void IUpdatable.update()
        {
            entity.transform.rotation = VectorToAngle(entity.transform.position) + (float)Math.PI/2;
        }

        float VectorToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
    }
}
