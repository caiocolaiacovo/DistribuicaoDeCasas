using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteAte29Anos : Pretendente, Criterio
    {
        private const int IdadeMaxima = 29;
        private const int Pontuacao = 1;

        public PretendenteAte29Anos(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
            var idade = dataDeNascimento.AddYears(IdadeMaxima);
            
            if (idade.Date < DateTime.Today.Date)
                throw new ExcecaoDeDominio("");
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}