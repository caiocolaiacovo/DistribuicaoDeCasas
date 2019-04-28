using System;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.Dominio.Fabricas
{
    public abstract class PretendenteFactory : IPretendenteFactory
    {
        public static PretendenteFactory ObterFabrica(DateTime dataDeNascimento)
        {
            var idade = dataDeNascimento.ObterIdadeEmAnos();

            if (idade < 30)
                return new PretendenteComMenosDe30AnosFactory();

            if (idade <= 44)
                return new PretendenteEntre30E44AnosFactory();

            return new PretendenteCom45AnosOuMaisFactory();
        }

        public abstract Pretendente ObterPretendente(string nome, DateTime dataDeNascimento, decimal renda);
    }
}