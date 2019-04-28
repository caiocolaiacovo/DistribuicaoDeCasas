using System;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Contratos
{
    public interface IPretendenteFactory
    {
         Pretendente ObterPretendente(string nome, DateTime dataDeNascimento);
    }
}