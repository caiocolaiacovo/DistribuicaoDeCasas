using Bogus;

namespace DistribuicaoDeCasas.DominioTeste._Base
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