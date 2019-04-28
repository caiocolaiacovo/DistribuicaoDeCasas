using System;
using DistribuicaoDeCasas.Dominio._Excecoes;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteCom45AnosOuMais : Pretendente
    {
        private const int IdadeMinima = 45;
        private const int Pontuacao = 3;

        public PretendenteCom45AnosOuMais(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
            var idadeMinima = dataDeNascimento.AddYears(IdadeMinima);
            
            if (idadeMinima.Date > DateTime.Today.Date)
                throw new ExcecaoDeDominio("O pretendente deve ter no mínimo 45 anos");
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }
    } 
}