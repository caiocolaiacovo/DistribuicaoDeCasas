using System;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.Dominio.Fabricas;
using DistribuicaoDeCasas.DominioTeste.Entidades;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Fabricas
{
    public class PretendenteComMenosDe30AnosTeste : TesteBase
    {
        public readonly int IdadeExcedente;

        public PretendenteComMenosDe30AnosTeste()
        {
            IdadeExcedente = 30;
        }

        [Fact]
        public void Deve_criar_um_instancia_de_pretendente_com_menos_de_30_anos()
        {
            var fabrica = new PretendenteComMenosDe30AnosFactory();
            var dataDeNascimento = faker.Date.Between(DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1), DateTime.Today);

            var pretendente = fabrica.ObterPretendente(faker.Person.FullName, dataDeNascimento);

            Assert.True(pretendente is PretendenteComMenosDe30Anos);
        }
    }
}