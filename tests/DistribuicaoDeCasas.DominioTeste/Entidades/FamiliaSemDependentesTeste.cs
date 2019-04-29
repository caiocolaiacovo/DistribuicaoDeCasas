using System;
using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Util;
using Moq;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class FamiliaSemDependentesTeste : TesteBase
    {
        [Fact]
        public void Deve_criar_uma_familia()
        {
            var familiaEsperada = new {
                Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
                Dependentes = new List<Pessoa>(),
            };

            var novaFamilia = new FamiliaSemDependentes(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                familiaEsperada.Dependentes
            );

            Assert.Equal(familiaEsperada.Pretendente.Object, novaFamilia.Pretendente);
            Assert.Equal(familiaEsperada.Conjuge.Object, novaFamilia.Conjuge);
            Assert.Equal(familiaEsperada.Dependentes, novaFamilia.Dependentes);
        }

        [Fact]
        public void Deve_criar_uma_familia_sem_dependentes()
        {
            var quantidadeDeDependentesEsperada = 0;
            var familiaEsperada = new {
                Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
            };

            var novaFamilia = new FamiliaSemDependentes(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null
            );

            Assert.Equal(familiaEsperada.Pretendente.Object, novaFamilia.Pretendente);
            Assert.Equal(familiaEsperada.Conjuge.Object, novaFamilia.Conjuge);
            Assert.Equal(quantidadeDeDependentesEsperada, novaFamilia.Dependentes.Count);
        }

        [Fact]
        public void Deve_criar_uma_instancia_de_ICriterio()
        {
            var familiaEsperada = new {
                Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
            };

            var novaFamilia = new FamiliaSemDependentes(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null
            );

            Assert.True(novaFamilia is ICriterio);
        }

        [Fact]
        public void Deve_retornar_a_pontuacao()
        {
            var pontuacaoEsperada = 0;
            var familiaEsperada = new {
                Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
            };

            var novaFamilia = new FamiliaSemDependentes(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacao());
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_familia_sem_pretendente()
        {
            Assert.Throws<ExcecaoDeDominio>(() => { 
                new FamiliaSemDependentes(null, null, null); 
            }).ComMensagemDeErro("Pretendente é obrigatório");
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_familia_sem_conjuge()
        {
            var pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M);

            Assert.Throws<ExcecaoDeDominio>(() => { 
                new FamiliaSemDependentes(pretendente.Object, null, null); 
            }).ComMensagemDeErro("Conjuge é obrigatório");
        }
    }
}