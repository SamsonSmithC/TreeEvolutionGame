using FactoryLuna.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame
{
    public class SoundManager : SingletonMonoBehavior<SoundManager>
    {
        [SerializeField] private AudioSource m_mouseOverSound = null;

        public void PlayMouseOverSound()
        {
            m_mouseOverSound.Play();
        }
    }
}