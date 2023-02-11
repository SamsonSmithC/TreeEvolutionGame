// Original Author - Wyatt Senalik
// Modified by - Sam Smith
using UnityEngine;

namespace FactoryLuna.Core.Singletons
{
    // Basic Singleton class which inherits MonoBehavior and creates an instance if none exist when referenced.
    public class SingletonMonoBehavior<T> : MonoBehaviour where T : SingletonMonoBehavior<T>
    {
        // Reference this Singleton.
        static T m_instance = null;
        public static T Instance {
            get
            {
                // If no instance exists, create a GameObject and attach a new instance of this singleton.
                if (m_instance == null)
                {
                    GameObject gameObject = new GameObject(typeof(T).Name);
                    m_instance = gameObject.AddComponent<T>();
                }
                return m_instance;
            }
        }

        /// <summary>
        /// Awake is called when the object is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
            // If an instance already exists destroy this one.
            if (m_instance != null)
            {
                Debug.LogWarning($"A {GetType().Name} already exist, destroying this one.");
                Destroy(gameObject);
                return;
            }

            // Set the static m_instance to reference this object.
            m_instance = this as T;
        }

        /// <summary>
        /// This function is called when the MonoBehaviour will be destroyed.
        /// </summary>
        protected virtual void OnDestroy()
        {
            // Remove this object from the static instance reference.
            if (m_instance == this)
            {
                m_instance = null;
            }
        }
    }
}
