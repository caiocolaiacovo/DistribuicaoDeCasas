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
    public class DependenteMaiorDeIdadeTeste : TesteBase
    {
        [Fact]
        public void Deve_criar_um_dependente()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(18),
            };

            var novoDependente = new DependenteMaiorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            dependenteEsperado.ToExpectedObject().ShouldMatch(novoDependente);
        }

        [Fact]
        public void Deve_falhar_ao_criar_dependente_com_menos_de_18_anos()
        {
            var dataDeNascimentoDe17Anos = DateTime.Today.SubtrairAnos(18).AddDays(1);

            Assert.Throws<ExcecaoDeDominio>(() => {
                new DependenteMaiorDeIdade(faker.Person.FullName, dataDeNascimentoDe17Anos);
            }).ComMensagemDeErro("O dependente precisa ter 18 anos ou mais");
        }

        [Fact]
        public void Deve_ser_uma_Pessoa()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(18),
            };

            var novoDependente = new DependenteMaiorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            Assert.True(novoDependente is Pessoa);
        }

        [Fact]
        public void Deve_implementar_IDependente()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(18),
            };

            var novoDependente = new DependenteMaiorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            Assert.True(novoDependente is IDependente);
        }
    }
}