using Bogus;

namespace DistribuicaoDeCasas.DominioTeste._Base
{
    public class TesteBase
    {
        protected Faker faker;

        public TesteBase()
        {
            faker = new Faker();
        }
    }
}