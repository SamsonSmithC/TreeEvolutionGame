// Original Author - Sam Smith
using System;
using UnityEngine;

namespace TreeEvolutionGame
{
    [Serializable]
    public class Mutation
    {
        public Mutation(MutationDataSO mutationData)
        {
            m_data = mutationData;
            myName = m_data.Name;
        }

        [SerializeField]
        string myName;

        public Tier Tier {get; private set;} = Tier.Insignificant;

        MutationDataSO m_data;

        public string Name => m_data.Name;
        public int Cost => m_data.Cost;
        public MutationType Type => m_data.Type;
    }
}