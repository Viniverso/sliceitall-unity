using UnityEngine;
using entities.player.model;

namespace Internal.Command.impl
{
    public abstract class Command : ICommand
    {
        protected IPlayer player;

        public Vector3 moveForceDirection;

        public Command(IPlayer _player)
        {
            player = _player;
        }

        public virtual void Execute(){}
    }
}