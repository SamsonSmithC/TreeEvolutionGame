using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame {
    public class ChoiceDisplayManager : MonoBehaviour
    {
        [SerializeField] private IconHolderManager m_holderMan = null;
        [SerializeField] private int m_selIndex = 0;

        [SerializeField]
        IntSpriteDictionary m_numberSprites = null;

        [SerializeField]
        SpriteRenderer m_selctionIndicator = null;

        [SerializeField]
        private SpriteRenderer m_labelRenderer = null;
        [SerializeField]
        private SpriteRenderer m_costRenderer = null;
        [SerializeField]
        private SpriteRenderer m_iconRenderer = null;
        public SpriteRenderer LabelRenderer { get { return m_labelRenderer; } }
        public SpriteRenderer CostRenderer { get { return m_costRenderer; } }
        public SpriteRenderer IconRenderer { get { return m_iconRenderer; } }

        [SerializeField]
        private List<Sprite> m_labels = null;
        
        [SerializeField]
        private List<Sprite> m_icons = null;

        private SoundManager m_soundMan = null;

        private void Start()
        {
            m_soundMan = SoundManager.Instance;
        }

        public void SetCost (int cost) {
            m_costRenderer.sprite = m_numberSprites.numbers[cost];
        }

        public void SetLabel (MutationType type) {
            m_labelRenderer.sprite = GetLabel(type);
        }

        public void SetIcon (MutationType type) {
            m_iconRenderer.sprite = GetIcon(type);
        }

        public void SetMutation(MutationType type, int cost)
        {
            SetCost(cost);
            SetLabel(type);
            SetIcon(type);
        }

        /// <summary>
        /// Called when the mouse enters the GUIElement or Collider.
        /// </summary>
        void OnMouseEnter()
        {
            m_selctionIndicator.enabled = true;

            m_soundMan.PlayMouseOverSound();

            m_holderMan.SetSelected(m_selIndex);
        }

        /// <summary>
        /// Called when the mouse is not any longer over the GUIElement or Collider.
        /// </summary>
        void OnMouseExit()
        {
            m_selctionIndicator.enabled = false;

            m_holderMan.SetSelected(-1);
        }
        private void OnMouseDown()
        {
            m_soundMan.PlaySelectSound();
        }

        Sprite GetLabel(MutationType type) {
            switch (type)
            {
                case MutationType.Bones:
                    return m_labels[0];
                case MutationType.Water:
                    return m_labels[1];
                case MutationType.Iron:
                    return m_labels[2];
                case MutationType.Flower:
                    return m_labels[3];
                case MutationType.Tide:
                    return m_labels[4];
                default:
                Debug.Log(type);
                    return null;
            }
        }

        Sprite GetIcon (MutationType type) {
            switch (type)
            {
                case MutationType.Bones:
                    return m_icons[0];
                case MutationType.Water:
                    return m_icons[1];
                case MutationType.Iron:
                    return m_icons[2];
                case MutationType.Flower:
                    return m_icons[3];
                case MutationType.Tide:
                    return m_icons[4];
                default:
                    return null;
            }
        }
    }
}
