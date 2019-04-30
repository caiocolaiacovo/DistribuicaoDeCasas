using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using ExpectedObjects;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class ConjugeTeste : TesteBase
    {
        public string Nome;
        public DateTime DataDeNascimento;
        public decimal Renda;

        public ConjugeTeste()
        {
            Nome = faker.Person.FullName;
            DataDeNascimento = DateTime.Today;
            Renda = faker.Random.Decimal(0M, 2000M);
        }

        [Fact]
        public void Deve_criar_um_conjuge()
        {
            var conjugeEsperado = new {
                Nome = Nome,
                DataDeNascimento = DataDeNascimento,
                Renda = Renda,
            };

            var novoConjuge = new Conjuge(
                conjugeEsperado.Nome, 
                conjugeEsperado.DataDeNascimento, 
                conjugeEsperado.Renda
            );

            conjugeEsperado.ToExpectedObject().ShouldMatch(novoConjuge);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_conjuge_com_renda_negativa()
        {
            var rendaInvalida = -1M;

            Assert.Throws<ExcecaoDeDominio>(() => {
                new Conjuge(Nome, DataDeNascimento, rendaInvalida);
            }).ComMensagemDeErro("A renda não pode ser negativa");
        }

        [Fact]
        public void Deve_implementar_IConjuge()
        {
            var conjuge = new Conjuge(
                Nome, 
                DataDeNascimento, 
                Renda
            );

            Assert.True(conjuge is IConjuge);
        }
    }
}