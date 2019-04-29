using System;
using Bogus;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Builders;
using DistribuicaoDeCasas.DominioTeste._Util;
using ExpectedObjects;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PretendenteCom45AnosOuMaisTeste : TesteBase
    {
        public readonly int IdadeMinima;

        public PretendenteCom45AnosOuMaisTeste()
        {
            IdadeMinima = 45;
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(IdadeMinima),
                Renda = faker.Random.Decimal(0M, 2000M),
            };

            var novoPretendente = PretendenteCom45AnosOuMaisBuilder
                    .Instancia()
                    .ComNome(pretendenteEsperado.Nome)
                    .ComDataDeNascimento(pretendenteEsperado.DataDeNascimento)
                    .ComRenda(pretendenteEsperado.Renda)
                    .Construir();
           
            pretendenteEsperado.ToExpectedObject().ShouldMatch(novoPretendente);
        }

        [Fact]
        public void Deve_criar_um_pretendente_com_mais_de_45_anos()
        {
            var dataDeNascimentoEsperada = DateTime.Today.SubtrairAnos(IdadeMinima).SubtrairDias(1);

            var novoPretendente = PretendenteCom45AnosOuMaisBuilder
                    .Instancia()
                    .ComDataDeNascimento(dataDeNascimentoEsperada)
                    .Construir();
           
            Assert.Equal(dataDeNascimentoEsperada, novoPretendente.DataDeNascimento);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_menos_de_45_anos()
        {
            var dataDeNascimentoIncorreta = DateTime.Today.SubtrairAnos(IdadeMinima).AddDays(1);

            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteCom45AnosOuMaisBuilder
                    .Instancia()
                    .ComDataDeNascimento(dataDeNascimentoIncorreta)
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no mínimo 45 anos");
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pretendente()
        {
            var novoPretendente = PretendenteCom45AnosOuMaisBuilder.Instancia().Construir();

            Assert.True(novoPretendente is Pretendente);
        }

        [Fact]
        public void Deve_implementar_IPretendente()
        {
            var novoPretendente = PretendenteCom45AnosOuMaisBuilder.Instancia().Construir();

            Assert.True(novoPretendente is IPretendente);
        }

        [Fact]
        public void Deve_obter_a_pontuacao_esperada()
        {
            var pontuacaoEsperada = 3;

            var novoPretendente = PretendenteCom45AnosOuMaisBuilder.Instancia().Construir();

            Assert.Equal(pontuacaoEsperada, novoPretendente.ObterPontuacao());
        }
    }   
}