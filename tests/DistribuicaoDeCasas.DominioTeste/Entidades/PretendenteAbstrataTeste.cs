using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using ExpectedObjects;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class PretendenteAbstrataTeste : TesteBase
    {
        public PretendenteAbstrataTeste() { }

        class PretendenteAbstrata : Pretendente
        {
            public PretendenteAbstrata(string nome, DateTime dataDeNascimento, decimal renda) 
                : base(nome, dataDeNascimento, renda){}

            public override int ObterPontuacaoPorIdade()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Deve_criar_um_pretendente()
        {
            var pretendenteEsperado = new {
                Nome = faker.Person.FullName,
                DataDeNascimento = DateTime.Today,
                Renda = faker.Random.Decimal(0M, 2000M),
            };

            var novoPretendente = new PretendenteAbstrata(
                pretendenteEsperado.Nome, 
                pretendenteEsperado.DataDeNascimento, 
                pretendenteEsperado.Renda
            );

            pretendenteEsperado.ToExpectedObject().ShouldMatch(novoPretendente);
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pessoa()
        {
            var novoPretendente = new PretendenteAbstrata(
                faker.Person.FullName, 
                DateTime.Today, 
                faker.Random.Decimal(0M, 2000M)
            );

            Assert.True(novoPretendente is Pessoa);
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_pessoa_com_renda_negativa()
        {
            var rendaInvalida = -1M;

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PretendenteAbstrata(faker.Person.FullName, DateTime.Today, rendaInvalida);
            }).ComMensagemDeErro("A renda não pode ser negativa");
        }
    }
}