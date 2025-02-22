using System;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Contratos
{
    public interface IPretendenteFactory
    {
         IPretendente ObterPretendente(string nome, DateTime dataDeNascimento, decimal renda);
    }
}