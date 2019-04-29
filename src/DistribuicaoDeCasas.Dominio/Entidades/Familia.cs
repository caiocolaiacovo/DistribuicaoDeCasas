using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class Familia: IFamilia
    {
        private const int PontuacaoSemDependentesValidos = 0;
        private const int PontuacaoPara1Ou2DependentesValidos = 2;
        private const int PontuacaoPara3OuMaisDependentesValidos = 3;
        public readonly IPretendente Pretendente;
        public readonly Pessoa Conjuge;
        public readonly List<IDependente> Dependentes;

        public Familia(IPretendente pretendente, Pessoa conjuge, List<IDependente> dependentes)
        {
            ValidadorDeDominio
                .Instancia()
                .Quando(pretendente == null, "Pretendente é obrigatório")
                .Quando(conjuge == null, "Conjuge é obrigatório");
            
            Pretendente = pretendente;
            Conjuge = conjuge;
            Dependentes = dependentes ?? new List<IDependente>();
        }

        private int NumeroDeDependentesValidos()
        {
            var quantidade = 0;

            foreach (var dependente in Dependentes)
            {
                if (!dependente.EhMaiorDeIdade())
                    quantidade++;
            }
            return quantidade;
        }

        public int ObterPontuacaoPorDependenteValido()
        {
            var quantidade = NumeroDeDependentesValidos();

            if (quantidade >= 3)
                return PontuacaoPara3OuMaisDependentesValidos;
            
            if (quantidade >= 1)
                return PontuacaoPara1Ou2DependentesValidos;

            return PontuacaoSemDependentesValidos;
        }

        public int ObterPontuacaoPelaIdadeDoPretendente()
        {
            return Pretendente.ObterPontuacao();
        }

        public int ObterPontuacaoPorRendaFamiliar()
        {
            throw new System.NotImplementedException();
        }
    }
}