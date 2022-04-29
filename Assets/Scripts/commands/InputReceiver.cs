using UnityEngine;

namespace commands
{
    public class InputReceiver
    {
        public InputReceiver(){}

        public bool GetTouch()
        {
            if (Input.touchCount > 0)
                return true;
            return false;
        }

        public bool GetKeyPressed()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                return true;

            return false;
        }
    }
}