using System;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Fabricas
{
    public class PretendenteComMenosDe30AnosFactory : PretendenteFactory
    {
        public override IPretendente ObterPretendente(string nome, DateTime dataDeNascimento, decimal renda)
        {
            return new PretendenteComMenosDe30Anos(nome, dataDeNascimento, renda);
        }
    }
}