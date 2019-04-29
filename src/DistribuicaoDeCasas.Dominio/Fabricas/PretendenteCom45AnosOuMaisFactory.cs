using System;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Fabricas
{
    public class PretendenteCom45AnosOuMaisFactory : PretendenteFactory
    {
        public override IPretendente ObterPretendente(string nome, DateTime dataDeNascimento, decimal renda)
        {
            return new PretendenteCom45AnosOuMais(nome, dataDeNascimento, renda);
        }
    }
}