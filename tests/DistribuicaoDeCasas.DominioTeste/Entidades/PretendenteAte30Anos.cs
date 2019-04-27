using System;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PretendenteAte30AnosTeste
    {
        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendente = new {
                Nome = "José",
                DataDeNascimento = DateTime.Today,
            };

            var novoPretendente = new PretendenteAte30Anos(pretendente.Nome, pretendente.DataDeNascimento);

            Assert.Equal(pretendente.Nome, novoPretendente.Nome);
            Assert.Equal(pretendente.DataDeNascimento, novoPretendente.DataDeNascimento);
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pessoa()
        {
            var pretendente = new {
                Nome = "José",
                DataDeNascimento = DateTime.Today,
            };

            var novoPretendente = new PretendenteAte30Anos(pretendente.Nome, pretendente.DataDeNascimento);

            Assert.True(novoPretendente is Pessoa);
        }

        [Fact]
        public void Deve_ser_um_criterio()
        {
            var pretendente = new {
                Nome = "José",
                DataDeNascimento = DateTime.Today,
            };

            var novoPretendente = new PretendenteAte30Anos(pretendente.Nome, pretendente.DataDeNascimento);

            Assert.True(novoPretendente is Criterio);
        }

        [Fact]
        public void Deve_retornar_a_quantidade_esperada_de_pontos()
        {
            var pretendente = new {
                Nome = "José",
                DataDeNascimento = DateTime.Today,
            };
            var pontuacaoEsperada = 1;

            var novoPretendente = new PretendenteAte30Anos(pretendente.Nome, pretendente.DataDeNascimento);

            Assert.Equal(pontuacaoEsperada, novoPretendente.ObterPontuacao());
        }
    }
}