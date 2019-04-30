using System;
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
    public class PretendenteEntre30E44AnosTeste : TesteBase
    {
        public readonly int IdadeMinima;
        public readonly int IdadeExcedente;

        public PretendenteEntre30E44AnosTeste()
        {
            IdadeMinima = 30;
            IdadeExcedente = 45;
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var dataEntre30E44AnosAtras = faker.Date.Between(
                DateTime.Today.SubtrairAnos(IdadeExcedente).AddDays(1), 
                DateTime.Today.SubtrairAnos(IdadeMinima)
            );
            var pretendenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = dataEntre30E44AnosAtras,
                Renda = faker.Random.Decimal(0M, 2000M),
            };
            var novoPretendente = PretendenteEntre30E44AnosBuilder
                .Instancia()
                .ComNome(pretendenteEsperado.Nome)
                .ComDataDeNascimento(pretendenteEsperado.DataDeNascimento)
                .ComRenda(pretendenteEsperado.Renda)
                .Construir();
           
            pretendenteEsperado.ToExpectedObject().ShouldMatch(novoPretendente);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_menos_de_30_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteEntre30E44AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.SubtrairAnos(IdadeMinima).AddDays(1))
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no mínimo 30 anos");
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_45_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteEntre30E44AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.SubtrairAnos(IdadeExcedente))
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no máximo 44 anos");
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_mais_de_45_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteEntre30E44AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.SubtrairAnos(IdadeExcedente).SubtrairDias(1))
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no máximo 44 anos");
        }

        [Fact]
        public void Deve_implementar_IPretendente()
        {
            var novoPretendente = PretendenteEntre30E44AnosBuilder.Instancia().Construir(); 

            Assert.True(novoPretendente is IPretendente);
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pretendente()
        {
            var novoPretendente = PretendenteEntre30E44AnosBuilder.Instancia().Construir(); 

            Assert.True(novoPretendente is Pretendente);
        }

        [Fact]
        public void Deve_obter_a_pontuacao_esperada()
        {
            var pontuacaoEsperada = 2;
            var novoPretendente = PretendenteEntre30E44AnosBuilder.Instancia().Construir(); 

            var pontuacaoEncontrada = novoPretendente.ObterPontuacaoPorIdade();

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }

    
}