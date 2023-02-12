// Original Author - Sam Smith
namespace TreeEvolutionGame
{
    public class Encounter
    {
        public Encounter(EncounterDataSO encounterData)
        {
            m_data = encounterData;
        }

        public Tier Tier {get; private set;} = Tier.Insignificant;

        EncounterDataSO m_data;

        public bool IsOngoing => false;

        public string Name => m_data.Name;

        public string Description => m_data.Description;

        public string IncreasedChanceMessage => m_data.IncreasedChanceMessage;

        public string UnchangedChanceMessage => m_data.UnchangedChanceMessage;

        public string DecreasedChanceMessage => m_data.DecreasedChanceMessage;

        public int MinGrowthStage => m_data.MinGrowthStage;

        public int MaxGrowthStage => m_data.MaxGrowthStage;

        public float BaseChance => m_data.Chance;

        public float CalculatedChance { get { return m_data.Chance; } }
    }
}
