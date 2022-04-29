using System;
using UnityEngine;

using entities.api;

namespace entities.impl
{
    public abstract class DestructibleObject : MonoBehaviour, IDestructibleObject
    {
        public static Action<DestructibleObject> OnNotifyDestruct;

        [SerializeField] private int id = 0;

        public int ID { get => id; }

        public virtual void MoveForce(float _force) { }

        public virtual void OnTriggerEnter(Collider other)
        {
            if (OnNotifyDestruct != null)
                OnNotifyDestruct(this);
        }
    }
}
