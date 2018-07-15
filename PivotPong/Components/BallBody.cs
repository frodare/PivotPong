using System;
using Microsoft.Xna.Framework;
using Nez;

namespace PivotPong.Desktop.Components {
	public class BallBody : Component, IUpdatable {

    public Vector2 velocity;
    Collider _collider;
  
    public override void onAddedToEntity() {
      _collider = entity.getComponent<Collider>();
    }

    void IUpdatable.update() {

      entity.transform.position += velocity * Time.deltaTime;

      CollisionResult collisionResult;

      var neighbors = Physics.boxcastBroadphaseExcludingSelf(_collider, _collider.collidesWithLayers);

			foreach (var neighbor in neighbors) {
        if (neighbor.entity == entity) continue;
        

        if (_collider.collidesWith(neighbor, out collisionResult)) {
					//entity.transform.position -= collisionResult.minimumTranslationVector;
					//var relativeVelocity = velocity;
					//calculateResponseVelocity(ref relativeVelocity, ref collisionResult.minimumTranslationVector, out relativeVelocity);
					//velocity += relativeVelocity;

					velocity.Y *= -1;
          

        }
      }
    }

  

  }
}
