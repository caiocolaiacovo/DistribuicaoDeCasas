using System;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Fabricas
{
    public class PretendenteEntre30E44AnosFactory : PretendenteFactory
    {
        public override Pretendente ObterPretendente(string nome, DateTime dataDeNascimento, decimal renda)
        {
            return new PretendenteEntre30E44Anos(nome, dataDeNascimento, renda);
        }
    }
}