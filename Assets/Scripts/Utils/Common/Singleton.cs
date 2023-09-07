using UnityEngine;

namespace Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static bool HasInstance => _instance != null;

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = (T) FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    Debug.LogError("[Singleton] Something went wrong " +
                                   " - there should never be more than 1 singleton!");
                    return _instance;
                }

                if (_instance == null)
                {
                    if (applicationIsQuitting)
                    {
                        return null;
                    }

                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();
                    singleton.name = "(singleton) " + typeof(T);
                }

                return _instance;
            
            }
        }

        protected static bool applicationIsQuitting = false;

        public virtual void OnDestroy()
        {
            applicationIsQuitting = true;
        }

        [InvokeOnResetProgress]
        public static void ClearInstance()
        {
            _instance = null;
        }
    }
}