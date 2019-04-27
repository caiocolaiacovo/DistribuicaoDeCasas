using DistribuicaoDeCasas.Dominio._Excecoes;
using Xunit;

namespace DistribuicaoDeCasas.DominioTeste._Util
{
    public static class MetodosDeExtensao {
        public static void ComMensagemDeErro(this ExcecaoDeDominio excecao, string mensagemEsperada) {
            Assert.Equal(mensagemEsperada, excecao.Message);
        }
    }
}