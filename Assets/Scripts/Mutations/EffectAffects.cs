// Original Author - Sam Smith
using UnityEngine;

namespace TreeEvolutionGame{
    [System.Serializable]
    public struct EffectAffects {
        [SerializeField]
        private Encounters m_affectedTag;
        public readonly Encounters AffectedTag { get { return m_affectedTag; } }

        [SerializeField]
        private Effect m_effectType;
        public readonly Effect EffectType { get { return m_effectType; } }
    }
}