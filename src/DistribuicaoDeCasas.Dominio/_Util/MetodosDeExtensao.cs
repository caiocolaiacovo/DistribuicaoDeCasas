using System;

namespace DistribuicaoDeCasas.Dominio._Util
{
    public static class MetodosDeExtensao
    {
        public static int ObterIdadeEmAnos(this DateTime data)
        {
            var intervalo = DateTime.Today - data;
            
            return new DateTime(intervalo.Ticks).Year - 1;
        }

        public static DateTime SubtrairAnos(this DateTime data, int anos)
        {
            return data.AddYears(anos * -1);
        }

        public static DateTime SubtrairDias(this DateTime data, int dias)
        {
            return data.AddDays(dias * -1);
        }
    }
}