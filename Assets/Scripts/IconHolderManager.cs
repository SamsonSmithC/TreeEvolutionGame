using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame
{
    public class IconHolderManager : MonoBehaviour
    {
        [SerializeField] private Animator m_rootAnimator = null;

        private int m_selectedIndex = 0;


        public void SetSelected(int index)
        {
            m_selectedIndex = index;

            m_rootAnimator.SetInteger("selectionIndex", m_selectedIndex);
        }
    }
}