// Original Author - Wyatt Senalik
// Modified by - Sam Smith
namespace FactoryLuna.Core.Singletons {

    // Basic Singleton class which creates an instance if none exist when referenced.
    public class Singleton<T> where T : Singleton<T>, new()
    {
        // Reference this Singleton.
        static T m_instance = null;
        public static T Instance {
            get
            {
                // If no instance exists, create one.
                if (m_instance == null)
                {
                    m_instance = new T();
                }
                return m_instance;
            }
        }
    }
}
