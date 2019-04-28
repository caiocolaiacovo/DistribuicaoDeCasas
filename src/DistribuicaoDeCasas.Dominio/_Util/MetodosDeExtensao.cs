using System;

namespace DistribuicaoDeCasas.Dominio._Util
{
    public static class MetodosDeExtensao
    {
        public static int ObterIdade(this DateTime data)
        {
            var intervalo = DateTime.Today - data;
            
            return new DateTime(intervalo.Ticks).Year - 1;
        }
    }
}