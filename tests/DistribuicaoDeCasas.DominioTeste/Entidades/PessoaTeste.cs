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
    public class PessoaTeste : TesteBase
    {
        class PessoaTestavel : Pessoa
        {
            public PessoaTestavel(string nome, DateTime dataDeNascimento, decimal renda) 
                : base(nome, dataDeNascimento, renda){}
        }

        public PessoaTeste()
        {
        }

        [Fact]
        public void Deve_criar_uma_pessoa()
        {
            var pessoa = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today,
                Renda = faker.Random.Decimal(0M, 2000M),
            };

            var novaPessoa = new PessoaTestavel(pessoa.Nome, pessoa.DataDeNascimento, pessoa.Renda);

            pessoa.ToExpectedObject().ShouldMatch(novaPessoa);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Deve_falhar_ao_criar_uma_pessoa_com_nome_invalido(string nomeInvalido)
        {
            var dataDeNascimento = DateTime.Today;
            var renda = faker.Random.Decimal(0M, 2000M);

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaTestavel(nomeInvalido, dataDeNascimento, renda);
            }).ComMensagemDeErro("Nome obrigatório");
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_pessoa_com_data_de_nascimento_no_futuro()
        {
            var nome = faker.Person.FullName;
            var dataFutura = faker.Date.Future();
            var renda = faker.Random.Decimal(0M, 2000M);

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaTestavel(nome, dataFutura, renda);
            }).ComMensagemDeErro("Data de nascimento não pode ser maior que a data atual");
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_pessoa_com_renda_negativa()
        {
            var nome = faker.Person.FullName;
            var dataFutura = DateTime.Today;
            var rendaInvalida = -1M;

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaTestavel(nome, dataFutura, rendaInvalida);
            }).ComMensagemDeErro("A renda não pode ser negativa");
        }
    }   
}