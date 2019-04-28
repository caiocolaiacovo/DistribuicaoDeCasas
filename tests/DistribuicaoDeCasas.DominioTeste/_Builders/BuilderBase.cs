using Bogus;

namespace DistribuicaoDeCasas.DominioTeste._Builders
{
    public class BuilderBase
    {
        protected Faker faker;

        public BuilderBase()
        {
            faker = new Faker();
        }
    }
}