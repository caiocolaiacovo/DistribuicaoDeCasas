using Bogus;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
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