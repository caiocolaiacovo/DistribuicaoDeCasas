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
    public class PretendenteComMenosDe30AnosTeste
    {
        public readonly DateTime UltimaDataPermitida;
        public readonly Faker faker;

        public PretendenteComMenosDe30AnosTeste()
        {
            faker = new Faker();
            var idadeExcedente = 30 * -1;
            UltimaDataPermitida = DateTime.Today.AddYears(idadeExcedente).AddDays(1);
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendente = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = UltimaDataPermitida,
            };

            var novoPretendente = PretendenteComMenosDe30AnosBuilder
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
                PretendenteComMenosDe30AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(UltimaDataPermitida.AddDays(-1))
                    .Construir(); 
            }).ComMensagemDeErro("O pretendente deve ter no máximo 29 anos");
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pretendente()
        {
            var novoPretendente = PretendenteComMenosDe30AnosBuilder.Instancia().Construir();

            Assert.True(novoPretendente is Pretendente);
        }

        [Fact]
        public void Deve_ser_um_Criterio()
        {
            var novoPretendente = PretendenteComMenosDe30AnosBuilder.Instancia().Construir();

            Assert.True(novoPretendente is Criterio);
        }

        

        [Fact]
        public void Deve_retornar_a_quantidade_esperada_de_pontos()
        {
            var pontuacaoEsperada = 1;

            var novoPretendente = PretendenteComMenosDe30AnosBuilder.Instancia().Construir();

            Assert.Equal(pontuacaoEsperada, novoPretendente.ObterPontuacao());
        }
    }
}