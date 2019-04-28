using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste._Util
{
    public static class MetodosDeExtensao {
        public static void ComMensagemDeErro(this ExcecaoDeDominio excecao, string mensagemEsperada) 
        {
            Assert.Equal(mensagemEsperada, excecao.Message);
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