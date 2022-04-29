using System;
using UnityEngine;

namespace entities.api
{
    public interface IDestructibleObject
    {
        int ID { get; }

        void MoveForce(float _force);
    }
}
