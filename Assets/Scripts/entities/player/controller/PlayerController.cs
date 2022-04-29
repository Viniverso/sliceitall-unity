using UnityEngine;

using Internal.Command;

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

        private void LateUpdate() 
        {
            bool _receivedInput = false;
            if (isOnEditor) _receivedInput = inputReceiver.GetKeyPressed();
            else _receivedInput = inputReceiver.GetTouch();


            if (_receivedInput)
            {

                moveCommand = new MoveCommandBehaviour(this, (Vector3.up + this.transform.position));
                moveCommand.Execute();
            }
        }

        public void MoveForce(Vector3 _force)
        {
            playerModel.CurrentPlayerState = PlayerState.FLYING;

            this.playerRigidbody.MovePosition(_force);
        }

        public void RotateForce(Quaternion _rotationForce)
        {
            this.playerRigidbody.MoveRotation(_rotationForce);
        }


        private void OnCollisionEnter(Collision collision)
        {
            GameObject _collidedObject = collision.gameObject;

            Debug.Log("Collision " + _collidedObject.name);

            if (_collidedObject.name == "ground")
            {
                playerModel.CurrentPlayerState = PlayerState.IDLE;
            }
        }
    }
}