using System;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.Dominio.Fabricas;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Fabricas
{
    public class PretendenteEntre30E44AnosFactoryTeste : TesteBase
    {
        public readonly int IdadeMinima;
        public readonly int IdadeExcedente;

        public PretendenteEntre30E44AnosFactoryTeste()
        {
            IdadeMinima = 30;
            IdadeExcedente = 45;
        }

        [Fact]
        public void Deve_criar_um_instancia_de_pretendente_entre_30_e_44_anos()
        {
            var fabrica = new PretendenteEntre30E44AnosFactory();
            var dataDeNascimento = faker.Date.Between(
                DateTime.Today.SubtrairAnos(IdadeExcedente).AddDays(1), 
                DateTime.Today.SubtrairAnos(IdadeMinima)
            );
            var pretendente = fabrica.ObterPretendente(
                faker.Person.FullName, 
                dataDeNascimento, 
                faker.Random.Decimal(0M, 2000M)
            );

            Assert.True(pretendente is PretendenteEntre30E44Anos);
        }
    }
}