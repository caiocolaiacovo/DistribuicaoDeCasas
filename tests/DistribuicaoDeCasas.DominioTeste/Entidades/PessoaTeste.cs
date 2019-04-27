using System;
using Bogus;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Util;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PessoaTeste
    {
        class PessoaTestavel : Pessoa
        {
            public PessoaTestavel(string nome, DateTime dataDeNascimento) 
                : base(nome, dataDeNascimento){}
        }

        public readonly Faker faker;

        public PessoaTeste()
        {
            faker = new Faker();
        }

        [Fact]
        public void Deve_criar_uma_pessoa()
        {
            var pessoa = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today
            };

            var novaPessoa = new PessoaTestavel(pessoa.Nome, pessoa.DataDeNascimento);

            Assert.Equal(pessoa.Nome, novaPessoa.Nome);
            Assert.Equal(pessoa.DataDeNascimento, novaPessoa.DataDeNascimento);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Deve_falhar_ao_criar_uma_pessoa_com_nome_invalido(string nomeInvalido)
        {
            var dataDeNascimento = DateTime.Today;

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaTestavel(nomeInvalido, dataDeNascimento);
            }).ComMensagemDeErro("Nome obrigatório");
        }
        [Fact]
        public void Deve_falhar_ao_criar_uma_pessoa_com_data_de_nascimento_no_futuro()
        {
            var nome = faker.Person.FullName;
            var dataFutura = faker.Date.Future();

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PessoaTestavel(nome, dataFutura);
            }).ComMensagemDeErro("Data de nascimento não pode ser maior que a data atual");
        }
    }   
}