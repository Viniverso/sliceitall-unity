using UnityEngine;

namespace entities.player.model
{
    public interface IPlayer
    {
        void MoveForce(Vector3 _force);

        void RotateForce(Quaternion _rotationForce);
    }
}