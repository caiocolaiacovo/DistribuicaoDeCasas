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
    public class FamiliaCom1Ou2DependentesTeste : TesteBase
    {
        // [Fact]
        // public void Deve_criar_uma_familia()
        // {
        //     var dependenteMenorDeIdade = new Mock<Pessoa>(
        //         MockBehavior.Default, 
        //         faker.Person.FullName, 
        //         DateTime.Today
        //     );
        //     dependenteMenorDeIdade.Setup(d => d.EhMenorDeIdade()).Returns(true);

        //     var familiaEsperada = new {
        //         Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
        //         Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
        //         Dependentes = new List<Pessoa> { dependenteMenorDeIdade.Object },
        //     };

        //     var novaFamilia = new FamiliaCom1Ou2Dependentes(
        //         familiaEsperada.Pretendente.Object, 
        //         familiaEsperada.Conjuge.Object, 
        //         familiaEsperada.Dependentes
        //     );

        //     Assert.Equal(familiaEsperada.Pretendente.Object, novaFamilia.Pretendente);
        //     Assert.Equal(familiaEsperada.Conjuge.Object, novaFamilia.Conjuge);
        //     Assert.Equal(familiaEsperada.Dependentes, novaFamilia.Dependentes);
        // }

        // [Fact]
        // public void Deve_falhar_ao_criar_uma_familia_sem_dependentes_menores_de_idade()
        // {
        //     var dependenteMaiorDeIdade = new Mock<Pessoa>(
        //         MockBehavior.Default, 
        //         faker.Person.FullName, 
        //         DateTime.Today.SubtrairAnos(18)
        //     );
        //     var familiaEsperada = new {
        //         Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
        //         Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
        //         Dependentes = new List<Pessoa> { dependenteMaiorDeIdade.Object },
        //     };

        //     Assert.Throws<ExcecaoDeDominio>(() => { 
        //         new FamiliaCom1Ou2Dependentes(
        //             familiaEsperada.Pretendente.Object, 
        //             familiaEsperada.Conjuge.Object, 
        //             familiaEsperada.Dependentes
        //         );
        //     }).ComMensagemDeErro("A família deve ter pelo menos 1 (um) pretendente menor de idade");
        // }
        
        // [Fact]
        // public void Deve_falhar_ao_criar_uma_familia_sem_pretendente()
        // {
        //     Assert.Throws<ExcecaoDeDominio>(() => { 
        //         new FamiliaCom1Ou2Dependentes(null, null, null); 
        //     }).ComMensagemDeErro("Pretendente é obrigatório");
        // }

        // [Fact]
        // public void Deve_falhar_ao_criar_uma_familia_sem_conjuge()
        // {
        //     var pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M);

        //     Assert.Throws<ExcecaoDeDominio>(() => { 
        //         new FamiliaCom1Ou2Dependentes(pretendente.Object, null, null); 
        //     }).ComMensagemDeErro("Conjuge é obrigatório");
        // }

        // [Fact]
        // public void Deve_falhar_ao_criar_uma_familia_sem_dependentes()
        // {
        //     var familia = new {
        //         Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
        //         Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
        //     };

        //     Assert.Throws<ExcecaoDeDominio>(() => { 
        //         new FamiliaCom1Ou2Dependentes(
        //             familia.Pretendente.Object, 
        //             familia.Conjuge.Object, 
        //             null
        //         );
        //     }).ComMensagemDeErro("A família deve ter pelo menos 1 (um) dependente");
        // }

        // [Fact]
        // public void Deve_criar_uma_instancia_de_ICriterio()
        // {
        //     var dependente = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today);
        //     var familiaEsperada = new {
        //         Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
        //         Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
        //         Dependentes = new List<Pessoa> { dependente.Object },
        //     };

        //     var novaFamilia = new FamiliaCom1Ou2Dependentes(
        //         familiaEsperada.Pretendente.Object, 
        //         familiaEsperada.Conjuge.Object, 
        //         familiaEsperada.Dependentes
        //     );

        //     Assert.True(novaFamilia is ICriterio);
        // }

        //  [Fact]
        // public void Deve_retornar_a_pontuacao()
        // {
        //     var pontuacaoEsperada = 2;
        //     var dependente = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today);
        //     var familiaEsperada = new {
        //         Pretendente = new Mock<Pretendente>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, 0M),
        //         Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
        //         Dependentes = new List<Pessoa> { dependente.Object },
        //     };

        //     var novaFamilia = new FamiliaCom1Ou2Dependentes(
        //         familiaEsperada.Pretendente.Object, 
        //         familiaEsperada.Conjuge.Object, 
        //         familiaEsperada.Dependentes
        //     );

        //     Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacao());
        // }
    }
}