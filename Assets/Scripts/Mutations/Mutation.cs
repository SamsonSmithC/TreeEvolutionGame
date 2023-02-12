// Original Author - Sam Smith
namespace TreeEvolutionGame
{
    public class Mutation
    {
        public Mutation(MutationDataSO mutationData)
        {
            m_data = mutationData;
        }

        public Tier Tier {get; private set;} = Tier.Insignificant;

        MutationDataSO m_data;
    }
}