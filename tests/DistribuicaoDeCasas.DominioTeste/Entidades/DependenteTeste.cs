using System;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using ExpectedObjects;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class DependenteTeste : TesteBase
    {
        [Fact]
        public void Deve_criar_um_dependente()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today,
            };

            var novoDependente = new Dependente(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            dependenteEsperado.ToExpectedObject().ShouldMatch(novoDependente);
        }

        [Fact]
        public void Deve_considerar_dependente_como_maior_de_idade()
        {
            var dataDeNascimentoDe18Anos = DateTime.Today.SubtrairAnos(18);

            var novoDependente = new Dependente(faker.Person.FullName, dataDeNascimentoDe18Anos);

            Assert.False(novoDependente.EhMenorDeIdade());
        }

        [Fact]
        public void Deve_considerar_dependente_como_menor_de_idade()
        {
            var dataDeNascimentoDe17Anos = DateTime.Today.SubtrairAnos(18).AddDays(1);

            var novoDependente = new Dependente(faker.Person.FullName, dataDeNascimentoDe17Anos);

            Assert.True(novoDependente.EhMenorDeIdade());
        }
    }
}