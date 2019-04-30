using System;
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
        private const int PontuacaoParaRendaDeAte900Reais = 5;
        private const int PontuacaoParaRendaEntre901E1500Reais = 3;
        private const int PontuacaoParaRendaEntre1501E2000Reais = 1;
        private const int PontuacaoParaRendaSuperiorA2000Reais = 0;

        private readonly IPretendente _Pretendente;
        private readonly IConjuge _Conjuge;
        private readonly List<IDependente> _Dependentes;

        public IPretendente Pretendente => _Pretendente;
        public IConjuge Conjuge => _Conjuge;
        public List<IDependente> Dependentes => _Dependentes;

        public Familia(IPretendente pretendente, IConjuge conjuge, List<IDependente> dependentes)
        {
            ValidadorDeDominio
                .Instancia()
                .Quando(pretendente == null, "Pretendente é obrigatório")
                .Quando(conjuge == null, "Conjuge é obrigatório");
            
            _Pretendente = pretendente;
            _Conjuge = conjuge;
            _Dependentes = dependentes ?? new List<IDependente>();
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

        public int ObterPontuacaoPorQuantidadeDeDependentesValidos()
        {
            var quantidade = NumeroDeDependentesValidos();

            if (quantidade >= 3)
                return PontuacaoPara3OuMaisDependentesValidos;
            
            if (quantidade >= 1)
                return PontuacaoPara1Ou2DependentesValidos;

            return PontuacaoSemDependentesValidos;
        }

        public int ObterPontuacaoPorRendaFamiliar()
        {
            var totalDaRenda = ObterRendas();

            if (totalDaRenda <= 900M)
                return PontuacaoParaRendaDeAte900Reais;

            if (totalDaRenda >= 901M && totalDaRenda <= 1500)
                return PontuacaoParaRendaEntre901E1500Reais;

            if (totalDaRenda >= 1501M && totalDaRenda <= 2000)
                return PontuacaoParaRendaEntre1501E2000Reais;

            return PontuacaoParaRendaSuperiorA2000Reais;
        }

        private decimal ObterRendas()
        {
            var rendaPretendente = Pretendente.Renda;
            var rendaConjuge = Conjuge.Renda;

            return rendaPretendente + rendaConjuge;
        }
    }
}