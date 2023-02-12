using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame
{
    public class PlayMusicAfterDelay : MonoBehaviour
    {
        [SerializeField] private AudioSource m_onStartSound = null;
        [SerializeField] private AudioSource m_music = null;


        private void Start()
        {
            m_onStartSound.Play();
            float t_initialClipLength = m_onStartSound.clip.length;
            Invoke(nameof(PlayMusic), t_initialClipLength);
        }


        private void PlayMusic()
        {
            m_music.Play();
        }
    }
}