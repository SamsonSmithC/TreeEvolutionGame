// Original Author - Sam Smith
using UnityEngine;

namespace TreeEvolutionGame
{
    [CreateAssetMenu(fileName = "New EncounterData", menuName = "Scriptables/EncounterData")]
    public class EncounterDataSO : ScriptableObject
    {
        // Encounter Tag.
        [SerializeField]
        private Encounters m_tag = Encounters.Undefined;
        public Encounters Tag { get { return m_tag; } }

        // Name the encounter.
        [SerializeField]
        private string m_name = string.Empty;
        public string Name { get { return m_name; } }

        // Only do the event on a tree of at least this growth stage.
        [SerializeField]
        private int m_minGrowthStage = 0;
        public int MinGrowthStage { get { return m_minGrowthStage; } }

        // Only do the event on a tree below this growth stage.
        [SerializeField]
        private int m_maxGrowthStage = int.MaxValue;
        public int MaxGrowthStage { get { return m_maxGrowthStage; } }

        // Do this event at this frequncy
        [SerializeField][Range(0f,1f)]
        private float m_chance = 0f;
        public float Chance { get { return m_chance; } }

        // Describe the encounter (flavortext).
        [SerializeField][TextArea(5,1)]
        private string m_description = string.Empty;
        public string Description { get { return m_description; } }

        // Show this message when the NPCS consider the encounter successful and will temporarily have an increased chance.
        [SerializeField][TextArea(3,3)]
        private string m_increaseChanceMessage = string.Empty;
        public string IncreasedChanceMessage { get { return m_increaseChanceMessage; } }

        // Show this message when the NPCS feel neutral about the encounter and their chance is unaffected.
        [SerializeField][TextArea(3,3)]
        private string m_unchangedChanceMessage = string.Empty;
        public string UnchangedChanceMessage { get { return m_unchangedChanceMessage; } }

        // Show this message when the NPCS consider the encounter a failure and will temporarily have an reduced chance.
        [SerializeField][TextArea(3,3)]
        private string m_decreaseChanceMessage = string.Empty;
        public string DecreasedChanceMessage { get { return m_decreaseChanceMessage; } }

        // Is this an ongoing type encounter?
        [SerializeField]
        bool m_isTypeOngoing = false;
        public bool IsTypeOngoing => m_isTypeOngoing;

        // Do this event at this frequncy
        [SerializeField][Range(0f,1f)]
        private float m_endChance = 0f;
        public float EndChance { get { return m_endChance; } }

        // Show this message instead of the description the first time the Encounter is triggered.
        [SerializeField][TextArea(3,3)]
        private string m_firstDescription = string.Empty;
        public string FirstDescription { get { return m_firstDescription; } }

        // Show this message when the NPCS consider the encounter successful and will temporarily have an increased chance.
        [SerializeField][TextArea(3,3)]
        private string m_increaseEndChanceMessage = string.Empty;
        public string IncreasedEndChanceMessage { get { return m_increaseEndChanceMessage; } }

        // Show this message when the NPCS feel neutral about the encounter and their chance is unaffected.
        [SerializeField][TextArea(3,3)]
        private string m_unchangedEndChanceMessage = string.Empty;
        public string UnchangedEndChanceMessage { get { return m_unchangedEndChanceMessage; } }

        // Show this message when the NPCS consider the encounter a failure and will temporarily have an reduced chance.
        [SerializeField][TextArea(3,3)]
        private string m_decreaseEndChanceMessage = string.Empty;
        public string DecreasedEndChanceMessage { get { return m_decreaseEndChanceMessage; } }
    }
}
