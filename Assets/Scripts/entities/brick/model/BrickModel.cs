using UnityEngine;

namespace entities.brick.model
{
    public class BrickModel : MonoBehaviour
    {
        [SerializeField] private float hitForce = 1f;
        [SerializeField] private Color hitColor = Color.gray;

        public float GetHitForce => hitForce;

        public Color GetHitColor => hitColor;

        internal BrickState currentBrickState;
        public BrickState CurrentBrickState
        {
            get { return currentBrickState; }
            set
            {
                if (currentBrickState != value)
                    currentBrickState = value;
            }
        }
    }
}