namespace DistribuicaoDeCasas.Dominio.Contratos
{
    public interface IFamilia
    {
        int ObterPontuacaoPorDependenteValido();
        int ObterPontuacaoPelaIdadeDoPretendente();
        int ObterPontuacaoPorRendaFamiliar();
    }
}