namespace DistribuicaoDeCasas.Dominio.Contratos
{
    public interface IPretendente
    {
        decimal Renda { get; }
        int ObterPontuacaoPorIdade();
    }
}