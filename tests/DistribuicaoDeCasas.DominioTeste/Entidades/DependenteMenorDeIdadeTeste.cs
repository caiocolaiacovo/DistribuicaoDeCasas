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
    public class DependenteMenorDeIdadeTeste : TesteBase
    {
        [Fact]
        public void Deve_criar_um_dependente()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(18).AddDays(1),
            };

            var novoDependente = new DependenteMenorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            dependenteEsperado.ToExpectedObject().ShouldMatch(novoDependente);
        }

        [Fact]
        public void Deve_falhar_ao_criar_um_dependente_com_18_anos_ou_mais()
        {
            Assert.Throws<ExcecaoDeDominio>(() => {
                new DependenteMenorDeIdade(faker.Person.FullName, DateTime.Today.SubtrairAnos(18));
            }).ComMensagemDeErro("O dependente precisa ter menos de 18 anos");
        }

        [Fact]
        public void Deve_ser_uma_Pessoa()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(18).AddDays(1),
            };

            var novoDependente = new DependenteMenorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            Assert.True(novoDependente is Pessoa);
        }

        [Fact]
        public void Deve_implementar_IDependente()
        {
            var dependenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today.SubtrairAnos(18).AddDays(1),
            };

            var novoDependente = new DependenteMenorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            Assert.True(novoDependente is IDependente);
        }
    }
}