using System;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.Dominio.Fabricas;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Fabricas
{
    public class PretendenteCom45AnosOuMaisFactoryTeste : TesteBase
    {
        public readonly int IdadeMinima;

        public PretendenteCom45AnosOuMaisFactoryTeste()
        {
            IdadeMinima = 45;
        }

        [Fact]
        public void Deve_criar_um_instancia_de_pretendente_com_45_anos_ou_mais()
        {
            var fabrica = new PretendenteCom45AnosOuMaisFactory();
            var pretendente = fabrica.ObterPretendente(
                faker.Person.FullName, 
                DateTime.Today.SubtrairAnos(IdadeMinima), 
                faker.Random.Decimal(0M, 2000M)
            );

            Assert.True(pretendente is PretendenteCom45AnosOuMais);
        }
    }
}