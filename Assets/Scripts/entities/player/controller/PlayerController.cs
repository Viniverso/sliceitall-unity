using UnityEngine;

using behaviours;

using commands;

using entities.player.model;

namespace entities.player.controller
{
    [RequireComponent(typeof(PlayerModel))]
    public class PlayerController : MonoBehaviour, IPlayer
    {
        [SerializeField] private GameObject launchableObject;

        private Rigidbody playerRigidbody;

        private PlayerModel playerModel;
        
        private InputReceiver inputReceiver;
        private MoveCommandBehaviour moveCommand;


        private bool isOnEditor = true;

        private void Awake() 
        {
#if !UNITY_EDITOR
            isOnEditor = false;
#endif
            playerModel = this.GetComponent<PlayerModel>();

            inputReceiver = new InputReceiver();

            playerModel.CurrentPlayerState = PlayerState.IDLE;
        }

        // Start is called before the first frame update
        void Start()
        {   
            playerRigidbody = this.GetComponent<Rigidbody>();
            
        }

        private void FixedUpdate()
        {
            bool _receivedInput = false;
            if (isOnEditor) _receivedInput = inputReceiver.GetKeyPressed();
            else _receivedInput = inputReceiver.GetTouch();


            if (_receivedInput)
            {

                moveCommand = new MoveCommandBehaviour(this, playerModel.GetMoveForce);
                moveCommand.Execute();
            }


            if(playerModel.CurrentPlayerState == PlayerState.FLYING)
            {
                RotateForce(Quaternion.Euler(playerModel.GetRotationForce * Time.fixedDeltaTime));
            }
        }

        public void MoveForce(Vector3 _force)
        {
            playerModel.CurrentPlayerState = PlayerState.FLYING;

            Vector3 _moveForce = _force;

            playerRigidbody.AddForce(_moveForce);
        }

        public void RotateForce(Quaternion _rotationForce)
        {

            playerRigidbody.MoveRotation(playerRigidbody.rotation * _rotationForce);
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject _collidedObject = collision.gameObject;

            if (_collidedObject.name == "ground")
            {
                playerModel.CurrentPlayerState = PlayerState.IDLE;
            }
        }
    }
}