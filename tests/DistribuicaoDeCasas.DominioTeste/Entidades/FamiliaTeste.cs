using System;
using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using DistribuicaoDeCasas.DominioTeste._Builders;
using DistribuicaoDeCasas.DominioTeste._Util;
using Moq;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class FamiliaTeste : TesteBase
    {
        private Mock<IDependente> DependenteValido;
        private Mock<IDependente> DependenteInvalido;
        private Mock<IPretendente> Pretendente;
        private Mock<IConjuge> Conjuge;

        public FamiliaTeste()
        {
            DependenteValido = new Mock<IDependente>();
            DependenteValido.Setup(d => d.EhMaiorDeIdade()).Returns(false);

            DependenteInvalido = new Mock<IDependente>();
            DependenteInvalido.Setup(d => d.EhMaiorDeIdade()).Returns(true);

            Pretendente = new Mock<IPretendente>();
            Conjuge = new Mock<IConjuge>();
        }

        [Fact]
        public void Deve_criar_uma_familia()
        {
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<IConjuge>(),
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null
            );

            Assert.Equal(familiaEsperada.Pretendente.Object, novaFamilia.Pretendente);
            Assert.Equal(familiaEsperada.Conjuge.Object, novaFamilia.Conjuge);
            Assert.True(novaFamilia.Dependentes.Count == 0);
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_familia_sem_pretendente()
        {
            Assert.Throws<ExcecaoDeDominio>(() => { 
                new Familia(null, null, null); 
            }).ComMensagemDeErro("Pretendente é obrigatório");
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_familia_sem_conjuge()
        {
            Assert.Throws<ExcecaoDeDominio>(() => { 
                new Familia(Pretendente.Object, null, null); 
            }).ComMensagemDeErro("Conjuge é obrigatório");
        }

        [Fact]
        public void Deve_implementar_IFamilia()
        {
            var familia = new Familia(
                new Mock<IPretendente>().Object,
                new Mock<IConjuge>().Object, 
                null
            );

            Assert.True(familia is IFamilia);
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_nao_existam_dependentes()
        {
            var pontuacaoEsperada = 0;

            var familia = new Familia(
                new Mock<IPretendente>().Object, 
                new Mock<IConjuge>().Object, 
                null
            );

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_nao_existam_dependentes_validos()
        {
            var pontuacaoEsperada = 0;

            var dependente = new Mock<IDependente>();
            dependente.Setup(d => d.EhMaiorDeIdade()).Returns(true);

            var dependentes = new List<IDependente> { dependente.Object };

            var familia = FamiliaBuilder.Instancia().ComDependentes(dependentes).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_exista_1_dependente_valido()
        {
            var pontuacaoEsperada = 2;   

            var dependentes = new List<IDependente> { DependenteValido.Object };

            var familia = FamiliaBuilder.Instancia().ComDependentes(dependentes).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_existam_2_dependentes_validos()
        {
            var pontuacaoEsperada = 2;
            
            var dependentes = new List<IDependente> { DependenteValido.Object, DependenteValido.Object };

            var familia = FamiliaBuilder.Instancia().ComDependentes(dependentes).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_existam_3_dependentes_validos()
        {
            var pontuacaoEsperada = 3;
           
            var dependentes = new List<IDependente> { DependenteValido.Object, DependenteValido.Object, DependenteValido.Object };

            var familia = FamiliaBuilder.Instancia().ComDependentes(dependentes).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_existam_mais_de_3_dependentes_validos()
        {
            var pontuacaoEsperada = 3;
          
            var dependentes = new List<IDependente> { 
                    DependenteValido.Object, 
                    DependenteValido.Object, 
                    DependenteValido.Object, 
                    DependenteValido.Object 
                };

            var familia = FamiliaBuilder.Instancia().ComDependentes(dependentes).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());
        }

        public static IEnumerable<object[]> RendaDosConjugesAte900Reais =>
            new List<object[]>
            {
                new object[] { 0M, 0M },
                new object[] { 200M, 200M },
                new object[] { 450M, 450M },
            };

        [Theory]
        [MemberData(nameof(RendaDosConjugesAte900Reais))]
        public void Deve_retornar_a_pontuacao_esperada_para_renda_familiar_de_ate_900_reais(decimal rendaPretendente, decimal rendaConjuge)
        {
            var pontuacaoEsperada = 5;

            Pretendente.Setup(p => p.Renda).Returns(rendaPretendente);
            Conjuge.Setup(p => p.Renda).Returns(rendaConjuge);

            var familia = new Familia(
                Pretendente.Object, 
                Conjuge.Object, 
                null
            );

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorRendaFamiliar());
        }

        public static IEnumerable<object[]> RendaDosConjugesEntre901E1500Reais =>
            new List<object[]>
            {
                new object[] { 900M, 1M },
                new object[] { 750M, 750M },
                new object[] { 1100M, 400M },
            };

        [Theory]
        [MemberData(nameof(RendaDosConjugesEntre901E1500Reais))]
        public void Deve_retornar_a_pontuacao_esperada_para_renda_familiar_de_901_a_1500_reais(decimal rendaPretendente, decimal rendaConjuge)
        {
            var pontuacaoEsperada = 3;

            Pretendente.Setup(p => p.Renda).Returns(rendaPretendente);
            Conjuge.Setup(p => p.Renda).Returns(rendaConjuge);

            var familia = FamiliaBuilder.Instancia().ComPretendente(Pretendente).ComConjuge(Conjuge).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorRendaFamiliar());
        }

        public static IEnumerable<object[]> RendaDosConjugesEntre1501E2000Reais =>
            new List<object[]>
            {
                new object[] { 1M, 1500M },
                new object[] { 750.5M, 750.5M },
                new object[] { 1000M, 1000M },
            };

        [Theory]
        [MemberData(nameof(RendaDosConjugesEntre1501E2000Reais))]
        public void Deve_retornar_a_pontuacao_esperada_para_renda_familiar_de_1501_e_2000_reais(decimal rendaPretendente, decimal rendaConjuge)
        {
            var pontuacaoEsperada = 1;

            Pretendente.Setup(p => p.Renda).Returns(rendaPretendente);
            Conjuge.Setup(p => p.Renda).Returns(rendaConjuge);

            var familia = FamiliaBuilder.Instancia().ComPretendente(Pretendente).ComConjuge(Conjuge).Construir();

            Assert.Equal(pontuacaoEsperada, familia.ObterPontuacaoPorRendaFamiliar());
        }
    }
}