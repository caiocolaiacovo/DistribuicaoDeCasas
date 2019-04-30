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
        public string Nome;
        public DateTime DataDeNascimento;

        public DependenteMaiorDeIdadeTeste()
        {
            Nome = faker.Person.FullName;
            DataDeNascimento = DateTime.Today.SubtrairAnos(18);
        }

        [Fact]
        public void Deve_criar_um_dependente()
        {
            var dependenteEsperado = new {
                Nome = Nome,
                DataDeNascimento = DataDeNascimento,
            };

            var novoDependente = new DependenteMaiorDeIdade(dependenteEsperado.Nome, dependenteEsperado.DataDeNascimento);

            dependenteEsperado.ToExpectedObject().ShouldMatch(novoDependente);
        }

        [Fact]
        public void Deve_falhar_ao_criar_dependente_com_menos_de_18_anos()
        {
            var dataDeNascimentoInvalida = DateTime.Today.SubtrairAnos(18).AddDays(1);

            Assert.Throws<ExcecaoDeDominio>(() => {
                new DependenteMaiorDeIdade(Nome, dataDeNascimentoInvalida);
            }).ComMensagemDeErro("O dependente precisa ter 18 anos ou mais");
        }

        [Fact]
        public void Deve_ser_uma_Pessoa()
        {
            var dependente = new DependenteMaiorDeIdade(Nome, DataDeNascimento);

            Assert.True(dependente is Pessoa);
        }

        [Fact]
        public void Deve_implementar_IDependente()
        {
            var dependente = new DependenteMaiorDeIdade(Nome, DataDeNascimento);

            Assert.True(dependente is IDependente);
        }

        [Fact]
        public void Deve_ser_um_dependente_maior_de_idade()
        {
            var dependente = new DependenteMaiorDeIdade(Nome, DataDeNascimento);

            Assert.True(dependente.EhMaiorDeIdade());
        }
    }
}