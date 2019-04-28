using DistribuicaoDeCasas.Dominio._Excecoes;

namespace DistribuicaoDeCasas.Dominio._Util
{
    public class ValidadorDeDominio
    {
        public static ValidadorDeDominio Instancia()
        {
            return new ValidadorDeDominio();
        }

        public ValidadorDeDominio Quando(bool condicao, string mensagem)
        {
            if (condicao)
                throw new ExcecaoDeDominio(mensagem);

            return this;
        }
    }
}