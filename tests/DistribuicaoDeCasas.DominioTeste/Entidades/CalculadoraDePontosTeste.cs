using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using Moq;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste.Entidades
{
    public class CalculadoraDePontosTeste : TesteBase
    {
        [Fact]
        public void Deve_calcular_a_pontuacao_da_familia_pela_idade_do_pretendente()
        {
            var pontuacaoEsperada = faker.Random.Int(0, 100);

            var pretendente = new Mock<IPretendente>();
            pretendente.Setup(p => p.ObterPontuacaoPorIdade()).Returns(pontuacaoEsperada);
            
            var familia = new Mock<IFamilia>();
            familia.Setup(f => f.Pretendente).Returns(pretendente.Object);

            var pontuador = new CalculadoraDePontos();

            Assert.Equal(pontuacaoEsperada, pontuador.Calcular(familia.Object));
        }

        [Fact]
        public void Deve_calcular_a_pontuacao_da_familia_pela_renda_total()
        {
            var pontuacaoEsperada = faker.Random.Int(0, 100);

            var pretendente = new Mock<IPretendente>();
            pretendente.Setup(p => p.ObterPontuacaoPorIdade()).Returns(0);

            var familia = new Mock<IFamilia>();
            familia.Setup(f => f.Pretendente).Returns(pretendente.Object);
            familia.Setup(f => f.ObterPontuacaoPorRendaFamiliar()).Returns(pontuacaoEsperada);

            var pontuador = new CalculadoraDePontos();

            Assert.Equal(pontuacaoEsperada, pontuador.Calcular(familia.Object));
        }

        [Fact]
        public void Deve_calcular_a_pontuacao_da_familia_pelo_numero_de_dependentes()
        {
            var pontuacaoEsperada = faker.Random.Int(0, 100);

            var pretendente = new Mock<IPretendente>();
            pretendente.Setup(p => p.ObterPontuacaoPorIdade()).Returns(0);

            var familia = new Mock<IFamilia>();
            familia.Setup(f => f.Pretendente).Returns(pretendente.Object);
            familia.Setup(f => f.ObterPontuacaoPorRendaFamiliar()).Returns(0);
            familia.Setup(f => f.ObterPontuacaoPorQuantidadeDeDependentesValidos()).Returns(pontuacaoEsperada);

            var pontuador = new CalculadoraDePontos();

            Assert.Equal(pontuacaoEsperada, pontuador.Calcular(familia.Object));
        }

        [Fact]
        public void Deve_calcular_a_pontuacao_da_familia_por_todos_os_criterios()
        {
            var pontuacaoDoPretendentePorIdade = faker.Random.Int(0, 100);
            var pontuacaoPorRendaFamiliar = faker.Random.Int(0, 100);
            var pontuacaoPelaQuantidadeDeDependentes = faker.Random.Int(0, 100);

            var pontuacaoEsperada = 
                pontuacaoDoPretendentePorIdade + 
                pontuacaoPorRendaFamiliar + 
                pontuacaoPelaQuantidadeDeDependentes;

            var pretendente = new Mock<IPretendente>();
            pretendente.Setup(p => p.ObterPontuacaoPorIdade()).Returns(pontuacaoDoPretendentePorIdade);

            var familia = new Mock<IFamilia>();
            familia.Setup(f => f.Pretendente).Returns(pretendente.Object);
            familia.Setup(f => f.ObterPontuacaoPorRendaFamiliar()).Returns(pontuacaoPorRendaFamiliar);
            familia.Setup(f => f.ObterPontuacaoPorQuantidadeDeDependentesValidos()).Returns(pontuacaoPelaQuantidadeDeDependentes);

            var pontuador = new CalculadoraDePontos();

            Assert.Equal(pontuacaoEsperada, pontuador.Calcular(familia.Object));
        }

        public static IEnumerable<object[]> CriteriosAtendidos =>
            new List<object[]>
            {
                new object[] { 0, 0, 0, 0 },
                new object[] { 1, 0, 0, 1 },
                new object[] { 1, 1, 0, 2 },
                new object[] { 1, 1, 1, 3 },
            };

        [Theory]
        [MemberData(nameof(CriteriosAtendidos))]
        public void Deve_atender_a_quantidade_correta_de_criterios(
            int pontuacaoCriterioPretendente,
            int pontuacaoCriterioRendaFamiliar,
            int pontuacaoCriterioQuantidadeDeDependentes,
            int quantidadeEsperadaDeCriteriosAtendidos
        )
        {
            var pretendente = new Mock<IPretendente>();
            pretendente.Setup(p => p.ObterPontuacaoPorIdade()).Returns(pontuacaoCriterioPretendente);

            var familia = new Mock<IFamilia>();
            familia.Setup(f => f.Pretendente).Returns(pretendente.Object);
            familia.Setup(f => f.ObterPontuacaoPorRendaFamiliar()).Returns(pontuacaoCriterioRendaFamiliar);
            familia.Setup(f => f.ObterPontuacaoPorQuantidadeDeDependentesValidos()).Returns(pontuacaoCriterioQuantidadeDeDependentes);

            var pontuador = new CalculadoraDePontos();
            pontuador.Calcular(familia.Object);

            Assert.Equal(quantidadeEsperadaDeCriteriosAtendidos, pontuador.QuantidadeDeCriteriosAtendidos);
        }
    }
}