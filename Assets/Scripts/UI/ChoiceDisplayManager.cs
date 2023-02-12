using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame {
    public class ChoiceDisplayManager : MonoBehaviour
    {
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
        }

        /// <summary>
        /// Called when the mouse is not any longer over the GUIElement or Collider.
        /// </summary>
        void OnMouseExit()
        {
            m_selctionIndicator.enabled = false;
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
