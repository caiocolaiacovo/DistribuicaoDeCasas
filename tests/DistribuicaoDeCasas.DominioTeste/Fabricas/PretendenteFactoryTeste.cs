using System;
using DistribuicaoDeCasas.Dominio.Fabricas;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Fabricas
{
    public class PretendenteFactoryTeste
    {
        public readonly int IdadeMinima;
        public readonly int IdadeExcedente;
        
        public PretendenteFactoryTeste()
        {
            IdadeMinima = 30;
            IdadeExcedente = 45;
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_menos_de_30_anos()
        {
            var dataDeNascimento = DateTime.Today.AddYears(IdadeMinima * -1).AddDays(1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteComMenosDe30AnosFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_30_anos()
        {
            var dataDeNascimento = DateTime.Today.AddYears(IdadeMinima * -1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteEntre30E44AnosFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_44_anos_ou_menos()
        {
            var dataDeNascimento = DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteEntre30E44AnosFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_45_anos()
        {
            var dataDeNascimento = DateTime.Today.AddYears(IdadeExcedente * -1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteCom45AnosOuMaisFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_mais_de_45_anos()
        {
            var dataDeNascimento = DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(-1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteCom45AnosOuMaisFactory);
        }
    }
}