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
    public class PretendenteTeste : TesteBase
    {
        public PretendenteTeste() { }

        class PretendenteTestavel : Pretendente
        {
            public PretendenteTestavel(string nome, DateTime dataDeNascimento, decimal renda) 
                : base(nome, dataDeNascimento, renda){}

            public override int ObterPontuacao()
            {
                throw new System.NotImplementedException();
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

            var novoPretendente = new PretendenteTestavel(
                pretendenteEsperado.Nome, 
                pretendenteEsperado.DataDeNascimento, 
                pretendenteEsperado.Renda
            );

            pretendenteEsperado.ToExpectedObject().ShouldMatch(novoPretendente);
        }

        [Fact]
        public void Deve_ser_uma_instancia_de_Pessoa()
        {
            var novoPretendente = new PretendenteTestavel(
                faker.Person.FullName, 
                DateTime.Today, 
                faker.Random.Decimal(0M, 2000M)
            );

            Assert.True(novoPretendente is Pessoa);
        }

        [Fact]
        public void Deve_ser_um_ICriterio()
        {
            var novoPretendente = new PretendenteTestavel(
                faker.Person.FullName, 
                DateTime.Today, 
                faker.Random.Decimal(0M, 2000M)
            );

            Assert.True(novoPretendente is ICriterio);
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_pessoa_com_renda_negativa()
        {
            var rendaInvalida = -1M;

            Assert.Throws<ExcecaoDeDominio>(() => {
                new PretendenteTestavel(faker.Person.FullName, DateTime.Today, rendaInvalida);
            }).ComMensagemDeErro("A renda não pode ser negativa");
        }
    }
}