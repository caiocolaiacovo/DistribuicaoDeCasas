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
    public class PretendenteComMenosDe30AnosTeste : TesteBase
    {
        public readonly DateTime UltimaDataPermitida;

        public PretendenteComMenosDe30AnosTeste()
        {
            var idadeExcedente = 30;
            UltimaDataPermitida = DateTime.Today.SubtrairAnos(idadeExcedente).AddDays(1);
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = UltimaDataPermitida,
                Renda = faker.Random.Decimal(0M, 2000M),
            };

            var novoPretendente = PretendenteComMenosDe30AnosBuilder
                .Instancia()
                .ComNome(pretendenteEsperado.Nome)
                .ComDataDeNascimento(pretendenteEsperado.DataDeNascimento)
                .ComRenda(pretendenteEsperado.Renda)
                .Construir();
           
            pretendenteEsperado.ToExpectedObject().ShouldMatch(novoPretendente);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_mais_de_29_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => { 
                PretendenteComMenosDe30AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(UltimaDataPermitida.SubtrairDias(1))
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
        public void Deve_retornar_a_quantidade_esperada_de_pontos()
        {
            var pontuacaoEsperada = 1;

            var novoPretendente = PretendenteComMenosDe30AnosBuilder.Instancia().Construir();

            Assert.Equal(pontuacaoEsperada, novoPretendente.ObterPontuacao());
        }
    }
}