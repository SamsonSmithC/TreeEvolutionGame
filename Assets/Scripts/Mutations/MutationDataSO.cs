// Original Author - Sam Smith
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame {
    [CreateAssetMenu(fileName = "New MutationData", menuName = "Scriptables/MutationData")]
    public class MutationDataSO : ScriptableObject
    {
        [SerializeField]
        private string m_name;
        public string Name { get { return m_name; } }
        public List<EffectAffects>  m_mutationEffects = null;

    }
}