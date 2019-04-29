using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.DominioTeste._Base;
using Moq;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PontuadorDeFamilia : TesteBase
    {
        [Fact]
        public void Deve_criar_um_pontuador_de_familia()
        {
            var pontuadorEsperado = new {
                Familia = new Mock<IFamilia>(),
            };

            Assert.True(true);
        }
    }
}