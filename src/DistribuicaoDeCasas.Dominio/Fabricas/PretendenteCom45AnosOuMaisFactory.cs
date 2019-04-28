using System;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Fabricas
{
    public class PretendenteCom45AnosOuMaisFactory : PretendenteFactory
    {
        public override Pretendente ObterPretendente(string nome, DateTime dataDeNascimento)
        {
            return new PretendenteCom45AnosOuMais(nome, dataDeNascimento);
        }
    }
}