// Original Author - Sam Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FactoryLuna.Core.Singletons;
using System.Security.Cryptography;

namespace TreeEvolutionGame {
    public class EncounterManager : SingletonMonoBehavior<EncounterManager>
    {
        [SerializeField]
        List<EncounterDataSO> m_encounters = null;

        List<Encounter> m_possibleEncounters = null;

        List<Encounter> m_occuringEncounters = null;

        TreeManager treeManager = null;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            m_possibleEncounters = new List<Encounter>();
            foreach (EncounterDataSO encounterData in m_encounters)
            {
                m_possibleEncounters.Add(new Encounter(encounterData));
            }
            m_occuringEncounters = new List<Encounter>();
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            treeManager = TreeManager.Instance;
            PrepareEncounters();
            RunEncounters();
        }

        /// <summary>
        /// Prepare the queue of occuringEncounters.
        /// <summary>
        public void PrepareEncounters()
        {
            foreach (Encounter encounter in m_possibleEncounters)
            {
                if (IsRunnable(encounter) && (RandomFloatRange(0f, 1f) < encounter.CalculatedChance))
                {
                    m_occuringEncounters.Add(encounter);
                }
            }
        }

        /// <summary>
        /// Check the prereqs for an encounter and add it to occuringEncounters
        /// <summery>
        bool IsRunnable(Encounter encounter)
        {   Debug.Log("Check runnable");
            if (treeManager.GrowthStage < encounter.MinGrowthStage) { return false; }
            if (treeManager.GrowthStage > encounter.MaxGrowthStage) { return false; }
            Debug.Log("Passed");
            return true;
        }

        public void RunEncounters() {
            Encounter t_nextEncounter = NextEncounter;
            int t_infiniteSavior = 0;
            while (t_nextEncounter != null)
            {
                Debug.Log($"{t_nextEncounter.Name} had a chance of {t_nextEncounter.CalculatedChance}");
                t_nextEncounter = NextEncounter;
                if  (++t_infiniteSavior > 1000)
                {
                    Debug.LogError("There is an infinite loop in EncounterManger.RunEncounters");
                    break;
                }
            }
        }

        /// <summary>
        /// Remove and return the element at the end of m_occuringEncounters
        /// </summary>
        public Encounter NextEncounter
        {
            get
            {
                if (m_occuringEncounters.Count > 0)
                {
                    int lastIndex = m_occuringEncounters.Count - 1;
                    Encounter t_nextEncounter = m_occuringEncounters[lastIndex];
                    m_occuringEncounters.RemoveAt(lastIndex);
                    return t_nextEncounter;
                }
                return null;
            }
        }

        /// <summary>
        /// Generate a random float between min and max.
        /// </summary>
        static float RandomFloatRange(float min, float max){
            System.Random t_random = new System.Random();
            double t_val = (t_random.NextDouble() * (max - min) + min);
            return (float)t_val;
        }

        /// <summary>
        /// Randomize the order of elements in a list.
        /// </summary>
        static void Randomize<T>(List<T> list) {
            for(int i = 0; i < list.Count; ++i) {
                Swap<T>(list, i, RandomNumberGenerator.GetInt32(list.Count - 1) + 1);
            }
        }

        /// <summary>
        /// Swap two elements of a List<T>
        /// </summary>
        static void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T t_tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = t_tmp;
        }
    }
}