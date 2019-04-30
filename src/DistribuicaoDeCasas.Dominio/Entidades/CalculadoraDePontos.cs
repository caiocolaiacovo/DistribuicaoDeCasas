using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class CalculadoraDePontos
    {
        public CalculadoraDePontos() { }

        public int Calcular(IFamilia familia)
        {
            var pretendente = familia.Pretendente;
            
            var total = 0;

            total += pretendente.ObterPontuacaoPorIdade();
            total += familia.ObterPontuacaoPorRendaFamiliar();
            total += familia.ObterPontuacaoPorQuantidadeDeDependentesValidos();

            return total;
        }
    }
}