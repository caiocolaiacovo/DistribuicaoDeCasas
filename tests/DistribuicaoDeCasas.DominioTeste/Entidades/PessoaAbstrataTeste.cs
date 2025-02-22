using System;
using Bogus;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using ExpectedObjects;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PessoaAbstrataTeste : TesteBase
    {
        class PessoaAbstrata : Pessoa
        {
            public PessoaAbstrata(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento){}
        }

        public PessoaAbstrataTeste()
        {
        }

        [Fact]
        public void Deve_criar_uma_pessoa()
        {
            var pessoa = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today,
            };

            var novaPessoa = new PessoaAbstrata(pessoa.Nome, pessoa.DataDeNascimento);

            pessoa.ToExpectedObject().ShouldMatch(novaPessoa);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Deve_falhar_ao_criar_uma_pessoa_com_nome_invalido(string nomeInvalido)
        {
            var dataDeNascimento = DateTime.Today;

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaAbstrata(nomeInvalido, dataDeNascimento);
            }).ComMensagemDeErro("Nome obrigatório");
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_pessoa_com_data_de_nascimento_no_futuro()
        {
            var nome = faker.Person.FullName;
            var dataFutura = faker.Date.Future();

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaAbstrata(nome, dataFutura);
            }).ComMensagemDeErro("Data de nascimento não pode ser maior que a data atual");
        }
    }   
}