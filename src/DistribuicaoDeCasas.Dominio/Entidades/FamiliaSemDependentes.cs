// using DistribuicaoDeCasas.Dominio._Util;
// using DistribuicaoDeCasas.Dominio.Contratos;

// namespace DistribuicaoDeCasas.Dominio.Entidades
// {
//     public class FamiliaSemDependentes: IFamilia
//     {
//         private const int Pontuacao = 0;
//         public readonly IPretendente Pretendente;
//         public readonly Pessoa Conjuge;

//         public FamiliaSemDependentes(IPretendente pretendente, Pessoa conjuge)
//         {
//             ValidadorDeDominio
//                 .Instancia()
//                 .Quando(pretendente == null, "Pretendente é obrigatório")
//                 .Quando(conjuge == null, "Conjuge é obrigatório");

//             Pretendente = pretendente;
//             Conjuge = conjuge;
//         }

//         public int ObterPontuacaoPorDependente()
//         {
//             return Pontuacao;
//         }
//     }
// }