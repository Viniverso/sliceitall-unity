using UnityEngine;

namespace entities.player.model
{
    public class PlayerModel : MonoBehaviour
    {

        [SerializeField] private Vector3 moveForce = new Vector3(0, 100, 20f);

        [SerializeField] private Vector3 rotationForce = new Vector3(180,0,0);

        internal PlayerState currentPlayerState;
        public PlayerState CurrentPlayerState
        {
            get { return currentPlayerState; }
            set
            {
                if (currentPlayerState != value)
                    currentPlayerState = value;
            }
        }

        public Vector3 GetMoveForce => moveForce;

        public Vector3 GetRotationForce => rotationForce;
    }
}