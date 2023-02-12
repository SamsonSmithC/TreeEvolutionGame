// Original Author - Sam Smith
using System.Collections.Generic;
using UnityEngine;

namespace TreeEvolutionGame {
    [CreateAssetMenu(fileName = "New MutationData", menuName = "Scriptables/MutationData")]
    public class MutationDataSO : ScriptableObject
    {   
        [SerializeField]
        private MutationType m_type = MutationType.Undefined;
        public MutationType Type { get { return m_type; } }
        
        [SerializeField]
        private string m_name = string.Empty;
        public string Name { get { return m_name; } }
        [SerializeField]
        private int m_cost = 1;
        public int Cost { get { return m_cost; } }
        public List<EffectAffects>  m_mutationEffects = null;

    }
}