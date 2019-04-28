using System;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Fabricas
{
    public class PretendenteComMenosDe30AnosFactory : PretendenteFactory
    {
        public override Pretendente ObterPretendente(string nome, DateTime dataDeNascimento)
        {
            return new PretendenteComMenosDe30Anos(nome, dataDeNascimento);
        } 
    }
}