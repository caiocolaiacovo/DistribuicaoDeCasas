using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class CalculadoraDePontos
    {
        public int QuantidadeDeCriteriosAtendidos { get; private set; }
        public CalculadoraDePontos() { }

        public int Calcular(IFamilia familia)
        {
            var pretendente = familia.Pretendente;
            
            var total = 0;

            total += RetornaPontosCasoOCriterioSejaAtendido(pretendente.ObterPontuacaoPorIdade());
            total += RetornaPontosCasoOCriterioSejaAtendido(familia.ObterPontuacaoPorRendaFamiliar());
            total += RetornaPontosCasoOCriterioSejaAtendido(familia.ObterPontuacaoPorQuantidadeDeDependentesValidos());

            return total;
        }

        private int RetornaPontosCasoOCriterioSejaAtendido(int pontuacao)
        {
            var foiPontuadoPeloCriterio = pontuacao > 0;
            
            if (foiPontuadoPeloCriterio)
                QuantidadeDeCriteriosAtendidos++;

            return pontuacao;
        }
    }
}