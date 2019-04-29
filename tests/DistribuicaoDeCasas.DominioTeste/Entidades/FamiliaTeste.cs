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
    public class FamiliaTeste : TesteBase
    {
        private Mock<IDependente> dependenteValido;
        private Mock<IDependente> dependenteInvalido;

        public FamiliaTeste()
        {
            dependenteValido = new Mock<IDependente>();
            dependenteValido.Setup(d => d.EhMaiorDeIdade()).Returns(false);

            dependenteInvalido = new Mock<IDependente>();
            dependenteInvalido.Setup(d => d.EhMaiorDeIdade()).Returns(true);
        }

        [Fact]
        public void Deve_criar_uma_familia()
        {
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
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
            var pretendente = new Mock<IPretendente>();

            Assert.Throws<ExcecaoDeDominio>(() => { 
                new Familia(pretendente.Object, null, null); 
            }).ComMensagemDeErro("Conjuge é obrigatório");
        }

        [Fact]
        public void Deve_implementar_IFamilia()
        {
             var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null
            );

            Assert.True(novaFamilia is IFamilia);
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_nao_existam_dependentes()
        {
            var pontuacaoEsperada = 0;
            
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPorDependenteValido());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_nao_existam_dependentes_validos()
        {
            var pontuacaoEsperada = 0;
            var dependente = new Mock<IDependente>();
            dependente.Setup(d => d.EhMaiorDeIdade()).Returns(true);

            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
                Dependentes = new List<IDependente> { dependente.Object },
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                familiaEsperada.Dependentes
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPorDependenteValido());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_exista_1_dependente_valido()
        {
            var pontuacaoEsperada = 2;
            
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
                Dependentes = new List<IDependente> { dependenteValido.Object },
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                familiaEsperada.Dependentes
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPorDependenteValido());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_existam_2_dependentes_validos()
        {
            var pontuacaoEsperada = 2;
            
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
                Dependentes = new List<IDependente> { dependenteValido.Object, dependenteValido.Object },
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                familiaEsperada.Dependentes
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPorDependenteValido());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_existam_3_dependentes_validos()
        {
            var pontuacaoEsperada = 3;
           
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
                Dependentes = new List<IDependente> { dependenteValido.Object, dependenteValido.Object, dependenteValido.Object },
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                familiaEsperada.Dependentes
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPorDependenteValido());
        }

        [Fact]
        public void Deve_retornar_a_pontuacao_esperada_caso_existam_mais_de_3_dependentes_validos()
        {
            var pontuacaoEsperada = 3;
          
            var familiaEsperada = new {
                Pretendente = new Mock<IPretendente>(),
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
                Dependentes = new List<IDependente> { 
                    dependenteValido.Object, 
                    dependenteValido.Object, 
                    dependenteValido.Object, 
                    dependenteValido.Object 
                },
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                familiaEsperada.Dependentes
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPorDependenteValido());
        }

        [Fact]
        public void Deve_obter_pontuacao_pela_idade_do_pretendente()
        {
            var pontuacaoEsperada = faker.Random.Int(0, 100);

            var pretendente = new Mock<IPretendente>();
            pretendente.Setup(p => p.ObterPontuacao()).Returns(pontuacaoEsperada);

            var familiaEsperada = new {
                Pretendente = pretendente,
                Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
            };

            var novaFamilia = new Familia(
                familiaEsperada.Pretendente.Object, 
                familiaEsperada.Conjuge.Object, 
                null    
            );

            Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacaoPelaIdadeDoPretendente());
        }

        // [Fact]
        // public void Deve_obter_a_pontuacao_pela_renda_familiar()
        // {
        //     var rendaDoPretendente = 450M;
        //     var rendaDoConjuge = 450M;

        //     var familiaEsperada = new {
        //         Pretendente = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, rendaDoPretendente),
        //         Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today, rendaDoConjuge),
        //     };

        //     var novaFamilia = new Familia(
        //         familiaEsperada.Pretendente.Object, 
        //         familiaEsperada.Conjuge.Object, 
        //         null    
        //     );
        // }
    }
}