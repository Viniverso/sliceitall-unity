using UnityEngine;

using entities.impl;
using entities.brick.model;

namespace entities.brick.controller
{
    [RequireComponent(typeof(BrickModel))]
    public class BrickController : DestructibleObject
    {
        [SerializeField] private Rigidbody leftCollider;
        [SerializeField] private Rigidbody rightCollider;

        private BrickModel brickModel;

        private MeshRenderer leftMeshRenderer, rightMeshRenderer;


        private void Awake()
        {
            brickModel = this.GetComponent<BrickModel>();
            brickModel.CurrentBrickState = BrickState.IDLE;

            leftMeshRenderer = leftCollider.gameObject.GetComponent<MeshRenderer>();
            rightMeshRenderer = rightCollider.gameObject.GetComponent<MeshRenderer>();
        }

        public override void MoveForce(float _force)
        {
            leftCollider.isKinematic = false;
            rightCollider.isKinematic = false;

            leftCollider.AddRelativeForce(-leftCollider.transform.right * _force);
            leftCollider.AddRelativeForce(rightCollider.transform.right * _force);
        }

        private void Update()
        {
            HitMaterialEffect();
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if(brickModel.CurrentBrickState == BrickState.IDLE)
                {
                    MoveForce(brickModel.GetHitForce);
                    brickModel.CurrentBrickState = BrickState.UNQUALIFIED;
                }
            }
        }

        public void HitMaterialEffect()
        {
            if (brickModel.CurrentBrickState == BrickState.UNQUALIFIED)
            {
                leftMeshRenderer.material.color = brickModel.GetHitColor;
                rightMeshRenderer.material.color = brickModel.GetHitColor;
            }
        }

        private void OnDestroy()
        {
            if (OnNotifyDestruct != null)
                OnNotifyDestruct = null;
        }
    }
}