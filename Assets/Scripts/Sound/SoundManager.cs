using FactoryLuna.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame
{
    public class SoundManager : SingletonMonoBehavior<SoundManager>
    {
        [SerializeField] private AudioSource m_mouseOverSound = null;
        [SerializeField] private AudioSource m_selectSound = null;

        public void PlayMouseOverSound()
        {
            m_mouseOverSound.Play();
        }
        public void PlaySelectSound()
        {
            m_selectSound.Play();
        }
    }
}