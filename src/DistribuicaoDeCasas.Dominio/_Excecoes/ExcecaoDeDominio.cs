using System;

namespace DistribuicaoDeCasas.Dominio._Excecoes
{
    public class ExcecaoDeDominio : Exception
    {
        public ExcecaoDeDominio(string message) : base(message) { }
    }
}