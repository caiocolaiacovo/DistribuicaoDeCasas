using System;
using Bogus;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Bulders;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PretendenteAte29AnosTeste
    {
        public readonly int IdadeMaxima;
        public readonly DateTime DataDe29AnosAtras;
        public readonly Faker faker;

        public PretendenteAte29AnosTeste()
        {
            faker = new Faker();
            IdadeMaxima = 29;
            DataDe29AnosAtras = DateTime.Today.AddYears(IdadeMaxima * -1);
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendente = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DataDe29AnosAtras,
            };

            var novoPretendente = PretendenteAte29AnosBuilder
                .Instancia()
                .ComNome(pretendente.Nome)
                .ComDataDeNascimento(pretendente.DataDeNascimento)
                .Construir();
           
            Assert.Equal(pretendente.Nome, novoPretendente.Nome);
            Assert.Equal(pretendente.DataDeNascimento, novoPretendente.DataDeNascimento);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_mais_de_29_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => { 
                PretendenteAte29AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DataDe29AnosAtras.AddDays(-1))
                    .Construir(); 
            });
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pretendente()
        {
            var novoPretendente = PretendenteAte29AnosBuilder.Instancia().Construir();

            Assert.True(novoPretendente is Pretendente);
        }

        [Fact]
        public void Deve_ser_um_Criterio()
        {
            var novoPretendente = PretendenteAte29AnosBuilder.Instancia().Construir();

            Assert.True(novoPretendente is Criterio);
        }

        

        [Fact]
        public void Deve_retornar_a_quantidade_esperada_de_pontos()
        {
            var pontuacaoEsperada = 1;

            var novoPretendente = PretendenteAte29AnosBuilder.Instancia().Construir();

            Assert.Equal(pontuacaoEsperada, novoPretendente.ObterPontuacao());
        }
    }
}