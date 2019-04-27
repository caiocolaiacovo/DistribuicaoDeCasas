using System;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteAte30Anos : Pessoa, Criterio
    {
        private readonly int Pontuacao;

        public PretendenteAte30Anos(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento) 
        {
            Pontuacao = 1;
        }

        public int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}