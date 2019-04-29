using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class FamiliaSemDependentes: ICriterio
    {
        private const int Pontuacao = 0;
        public readonly Pretendente Pretendente;
        public readonly Pessoa Conjuge;
        public readonly List<Pessoa> Dependentes;

        public FamiliaSemDependentes(Pretendente pretendente, Pessoa conjuge, List<Pessoa> dependentes)
        {
            ValidadorDeDominio
                .Instancia()
                .Quando(pretendente == null, "Pretendente é obrigatório")
                .Quando(conjuge == null, "Conjuge é obrigatório");

            Pretendente = pretendente;
            Conjuge = conjuge;
            Dependentes = dependentes ?? new List<Pessoa>();
        }

        public int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}