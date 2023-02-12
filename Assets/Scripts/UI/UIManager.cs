using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FactoryLuna.Core.Singletons;
using System.Security.Cryptography;
using TMPro;
using UnityEngine.UI;

namespace TreeEvolutionGame {
    public class UIManager : SingletonMonoBehavior<UIManager>
    {
        const int numActiveChoices = 3;
        [SerializeField]
        TextMeshProUGUI text = null;

        [SerializeField]
        Button[] m_choiceButtons = new Button[numActiveChoices];
        [SerializeField]
        ChoiceDisplayManager[] m_choiceDisplays = new ChoiceDisplayManager[numActiveChoices];
        
        [SerializeField]
        List<MutationDataSO> m_choiceData = null;
        List<Mutation> m_choices = null;
        public List<Mutation> Choices { get { return m_choices; } }
        Mutation[] m_activeChoices = new Mutation[numActiveChoices];
        public Mutation[] ActiveChocies { get { return m_activeChoices; } }

        void SetRandomChoices() {
            if (m_choices.Count < 3)
            {
                Debug.LogError("Not enough choices. Game unplayable.");
                return;
            }
            Randomize<Mutation>(m_choices);
            for (int i = 0; i < numActiveChoices; ++i) {
                m_activeChoices[i] = m_choices[i];
                // m_choiceButtons[i]
                m_choiceDisplays[i].SetMutation(m_activeChoices[i].Type, m_activeChoices[i].Cost);
            }
        }

        public void SetText(string newText){
            text.text = newText;
        }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            m_choices = new List<Mutation>();
            foreach (MutationDataSO data in m_choiceData)
            {
                m_choices.Add(new Mutation(data));
            }
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            SetRandomChoices();
        }

        /// <summary>
        /// Randomize the order of elements in a list.
        /// </summary>
        static void Randomize<T>(List<T> list) {
            for(int i = 0; i < list.Count - 1; ++i) {
                Swap<T>(list, i, RandomNumberGenerator.GetInt32(list.Count - 1) + 1);
            }
        }

        static void Swap<T>(List<T> list, int indexA, int indexB)
        {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }        
    }
}
