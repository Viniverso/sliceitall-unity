using System.Collections;
using UnityEngine;

namespace Internal.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        private static bool isQuitting = false;

        public static T Instance
        {
            get
            {
                if(isQuitting)
                    return null;
                
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                        instance = new GameObject(typeof(T) + " Singleton Instance").AddComponent<T>();
                }
                return instance;
            }
        }

        private void OnDestroy() 
        {
            isQuitting = true;
        }
    }
}