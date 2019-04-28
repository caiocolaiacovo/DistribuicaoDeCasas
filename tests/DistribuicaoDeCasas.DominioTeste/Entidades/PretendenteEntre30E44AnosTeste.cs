using System;
using Bogus;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Builders;
using DistribuicaoDeCasas.DominioTeste._Util;
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
            var dataEntre30E44AnosAtras = faker.Date.Between(DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1), DateTime.Today.AddYears(IdadeMinima * -1));
        
            var pretendente = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = dataEntre30E44AnosAtras,
            };

            var novoPretendente = PretendenteEntre30E44AnosBuilder
                .Instancia()
                .ComNome(pretendente.Nome)
                .ComDataDeNascimento(pretendente.DataDeNascimento)
                .Construir();
           
            Assert.Equal(pretendente.Nome, novoPretendente.Nome);
            Assert.Equal(pretendente.DataDeNascimento, novoPretendente.DataDeNascimento);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_menos_de_30_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteEntre30E44AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.AddYears(IdadeMinima * -1).AddDays(1))
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no mínimo 30 anos");
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_45_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteEntre30E44AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.AddYears(IdadeExcedente * -1))
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no máximo 44 anos");
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_pretendente_com_mais_de_45_anos()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                PretendenteEntre30E44AnosBuilder
                    .Instancia()
                    .ComDataDeNascimento(DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(-1))
                    .Construir();
            }).ComMensagemDeErro("O pretendente deve ter no máximo 44 anos");
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pretendente()
        {
            var novoPretendente = PretendenteEntre30E44AnosBuilder.Instancia().Construir(); 

            Assert.True(novoPretendente is Pretendente);
        }

        [Fact]
        public void Deve_ser_uma_Criterio()
        {
            var novoPretendente = PretendenteEntre30E44AnosBuilder.Instancia().Construir(); 

            Assert.True(novoPretendente is Criterio);
        }

        [Fact]
        public void Deve_obter_a_pontuacao_esperada()
        {
            var pontuacaoEsperada = 2;

            var novoPretendente = PretendenteEntre30E44AnosBuilder.Instancia().Construir(); 

            Assert.Equal(pontuacaoEsperada, novoPretendente.ObterPontuacao());
        }
    }

    
}