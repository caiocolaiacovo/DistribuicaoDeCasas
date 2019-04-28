using System;
using Bogus;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Builders;
using DistribuicaoDeCasas.DominioTeste._Util;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PretendenteCom45AnosOuMaisTeste : TesteBase
    {
        public readonly int IdadeMinima;

        public PretendenteCom45AnosOuMaisTeste()
        {
            faker = new Faker();
            IdadeMinima = 45;
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendente = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.AddYears(IdadeMinima * -1),
            };

            var novoPretendente = PretendenteCom45AnosOuMaisBuilder
                    .Instancia()
                    .ComNome(pretendente.Nome)
                    .ComDataDeNascimento(pretendente.DataDeNascimento)
                    .Construir();
           
            Assert.Equal(pretendente.Nome, novoPretendente.Nome);
            Assert.Equal(pretendente.DataDeNascimento, novoPretendente.DataDeNascimento);
        }

        [Fact]
        public void Deve_criar_um_pretendente_com_mais_de_45_anos()
        {
            var pretendente = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.AddYears(IdadeMinima * -1).AddDays(-1),
            };

            var novoPretendente = PretendenteCom45AnosOuMaisBuilder
                    .Instancia()
                    .ComNome(pretendente.Nome)
                    .ComDataDeNascimento(pretendente.DataDeNascimento)
                    .Construir();
           
            Assert.Equal(pretendente.Nome, novoPretendente.Nome);
            Assert.Equal(pretendente.DataDeNascimento, novoPretendente.DataDeNascimento);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_menos_de_45_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteCom45AnosOuMaisBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.AddYears(IdadeMinima * -1).AddDays(1))
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
        public void Deve_ser_uma_Criterio()
        {
            var novoPretendente = PretendenteCom45AnosOuMaisBuilder.Instancia().Construir();

            Assert.True(novoPretendente is Criterio);
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