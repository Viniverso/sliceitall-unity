using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Internal.Command.impl;
using entities.player.model;

namespace behaviours
{
    public class MoveCommandBehaviour : Command
    {
        public MoveCommandBehaviour(IPlayer _player, Vector3 _moveForceDirection) : base(_player)
        {
            moveForceDirection = _moveForceDirection;
        }

        public override void Execute()
        {
            player.MoveForce(moveForceDirection);
            //player.RotateForce();
        }
    }
}
