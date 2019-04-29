using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class FamiliaCom1Ou2Dependentes: ICriterio
    {
        private const int Pontuacao = 2;
        public readonly Pretendente Pretendente;
        public readonly Pessoa Conjuge;
        public readonly List<Pessoa> Dependentes;

        public FamiliaCom1Ou2Dependentes(Pretendente pretendente, Pessoa conjuge, List<Pessoa> dependentes)
        {
            var numeroDeDependentesMenoresDeIdade = NumeroDeDependentesMenoresDeIdade(dependentes);

            ValidadorDeDominio
                .Instancia()
                .Quando(pretendente == null, "Pretendente é obrigatório")
                .Quando(conjuge == null, "Conjuge é obrigatório")
                .Quando(dependentes == null, "A família deve ter pelo menos 1 (um) dependente")
                .Quando(numeroDeDependentesMenoresDeIdade == 0, "A família deve ter pelo menos 1 (um) pretendente menor de idade");

            Pretendente = pretendente;
            Conjuge = conjuge;
            Dependentes = dependentes;
            
        }

        private int NumeroDeDependentesMenoresDeIdade(List<Pessoa> dependentes)
        {
            var quantidade = 0;

            foreach (var dependente in dependentes ?? new List<Pessoa>())
            {
                // if ((dependente as DependenteMenorDeIdade).EhMenorDeIdade())
                //     quantidade++;
            }
            return quantidade;
        }

        public int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}