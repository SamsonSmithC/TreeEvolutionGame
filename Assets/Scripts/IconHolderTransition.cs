// Original Author - Sam Smith
using System.Collections;
using System.Collections.Generic;
using FactoryLuna.Core.Singletons;
using UnityEngine;

namespace TreeEvolutionGame {
    public class IconHolderTransition : SingletonMonoBehavior<IconHolderTransition>
    {
        [SerializeField]
        private bool m_isAnimating = false;
        public bool IsAnimating { get { return m_isAnimating; } }
        public bool teleported { get; private set; } = false;

        public void Play() {
            m_isAnimating = true;
        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void FixedUpdate()
        {
            if (IsAnimating) {
                transform.Translate(new Vector3(0,0.1f,0));
                if (transform.position.y >= 6)
                {
                    teleported = true;
                    transform.position = new Vector3(0, -8, 0);
                }
                if (teleported && transform.position.y >= 0)
                {
                    transform.position = new Vector3 (0,0,0);
                    teleported = false;
                    m_isAnimating = false;
                }
            }
        }
    }
}
