using System;
using DistribuicaoDeCasas.Dominio.Fabricas;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Fabricas
{
    public class PretendenteFactoryTeste : TesteBase
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
            var dataDeNascimento = DateTime.Today.SubtrairAnos(IdadeMinima).AddDays(1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteComMenosDe30AnosFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_30_anos()
        {
            var dataDeNascimento = DateTime.Today.SubtrairAnos(IdadeMinima);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteEntre30E44AnosFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_44_anos_ou_menos()
        {
            var dataDeNascimento = DateTime.Today.SubtrairAnos(IdadeExcedente).AddDays(1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteEntre30E44AnosFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_45_anos()
        {
            var dataDeNascimento = DateTime.Today.SubtrairAnos(IdadeExcedente);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteCom45AnosOuMaisFactory);
        }

        [Fact]
        public void Deve_criar_uma_fabrica_de_pretendentes_com_mais_de_45_anos()
        {
            var dataDeNascimento = DateTime.Today.SubtrairAnos(IdadeExcedente).SubtrairDias(1);
            var fabrica = PretendenteFactory.ObterFabrica(dataDeNascimento);

            Assert.True(fabrica is PretendenteCom45AnosOuMaisFactory);
        }
    }
}