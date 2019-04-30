using System;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.Dominio.Fabricas;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Fabricas
{
    public class PretendenteComMenosDe30AnosFactoryTeste : TesteBase
    {
        public readonly int IdadeExcedente;

        public PretendenteComMenosDe30AnosFactoryTeste()
        {
            IdadeExcedente = 30;
        }

        [Fact]
        public void Deve_criar_um_instancia_de_pretendente_com_menos_de_30_anos()
        {
            var fabrica = new PretendenteComMenosDe30AnosFactory();
            var dataDeNascimento = faker.Date.Between(
                DateTime.Today.SubtrairAnos(IdadeExcedente).AddDays(1), 
                DateTime.Today
            );
            var pretendente = fabrica.ObterPretendente(
                faker.Person.FullName, 
                dataDeNascimento, 
                faker.Random.Decimal(0M, 2000M)
            );

            Assert.True(pretendente is PretendenteComMenosDe30Anos);
        }
    }
}