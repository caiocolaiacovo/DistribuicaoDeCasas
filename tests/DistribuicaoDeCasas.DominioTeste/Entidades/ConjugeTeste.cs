using System;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using ExpectedObjects;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class ConjugeTeste : TesteBase
    {
        public ConjugeTeste()
        {
        }

        [Fact]
        public void Deve_criar_um_conjuge()
        {
            var conjugeEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today,
            };

            var novoConjuge = new Conjuge(conjugeEsperado.Nome, conjugeEsperado.DataDeNascimento);

            conjugeEsperado.ToExpectedObject().ShouldMatch(novoConjuge);
        }
    }
}