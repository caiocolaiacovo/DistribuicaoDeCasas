// using System;
// using System.Collections.Generic;
// using DistribuicaoDeCasas.Dominio._Excecoes;
// using DistribuicaoDeCasas.Dominio.Contratos;
// using DistribuicaoDeCasas.Dominio.Entidades;
// using DistribuicaoDeCasas.DominioTeste._Base;
// using DistribuicaoDeCasas.DominioTeste._Util;
// using Moq;
// using Xunit;

// namespace DistribuicaoDeCasas.DominioTeste.Entidades
// {
//     public class FamiliaSemDependentesTeste : TesteBase
//     {
//         [Fact]
//         public void Deve_criar_uma_familia()
//         {
//             var familiaEsperada = new {
//                 Pretendente = new Mock<IPretendente>(),
//                 Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
//             };

//             var novaFamilia = new FamiliaSemDependentes(
//                 familiaEsperada.Pretendente.Object, 
//                 familiaEsperada.Conjuge.Object
//             );

//             Assert.Equal(familiaEsperada.Pretendente.Object, novaFamilia.Pretendente);
//             Assert.Equal(familiaEsperada.Conjuge.Object, novaFamilia.Conjuge);
//         }

//         [Fact]
//         public void Deve_falhar_ao_criar_uma_familia_sem_pretendente()
//         {
//             Assert.Throws<ExcecaoDeDominio>(() => { 
//                 new FamiliaSemDependentes(null, null); 
//             }).ComMensagemDeErro("Pretendente é obrigatório");
//         }

//         [Fact]
//         public void Deve_falhar_ao_criar_uma_familia_sem_conjuge()
//         {
//             var pretendente = new Mock<IPretendente>();

//             Assert.Throws<ExcecaoDeDominio>(() => { 
//                 new FamiliaSemDependentes(pretendente.Object, null); 
//             }).ComMensagemDeErro("Conjuge é obrigatório");
//         }

//         [Fact]
//         public void Deve_implementar_IFamilia()
//         {
//             var familiaEsperada = new {
//                 Pretendente = new Mock<IPretendente>(),
//                 Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
//             };

//             var novaFamilia = new FamiliaSemDependentes(
//                 familiaEsperada.Pretendente.Object, 
//                 familiaEsperada.Conjuge.Object
//             );

//             Assert.True(novaFamilia is IFamilia);
//         }

//         [Fact]
//         public void Deve_retornar_a_pontuacao()
//         {
//             var pontuacaoEsperada = 0;
//             var familiaEsperada = new {
//                 Pretendente = new Mock<IPretendente>(),
//                 Conjuge = new Mock<Pessoa>(MockBehavior.Default, faker.Person.FullName, DateTime.Today),
//             };

//             var novaFamilia = new FamiliaSemDependentes(
//                 familiaEsperada.Pretendente.Object, 
//                 familiaEsperada.Conjuge.Object
//             );

//             Assert.Equal(pontuacaoEsperada, novaFamilia.ObterPontuacao());
//         }
//     }
// }