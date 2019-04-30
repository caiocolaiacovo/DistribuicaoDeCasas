using System.Collections.Generic;

namespace DistribuicaoDeCasas.Dominio.Contratos
{
    public interface IFamilia
    {
        IPretendente Pretendente { get; }
        IConjuge Conjuge { get; }
        List<IDependente> Dependentes { get; }
        int ObterPontuacaoPorQuantidadeDeDependentesValidos();
        int ObterPontuacaoPorRendaFamiliar();
    }
}