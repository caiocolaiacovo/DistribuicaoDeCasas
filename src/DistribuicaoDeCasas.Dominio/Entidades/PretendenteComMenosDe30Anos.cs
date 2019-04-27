using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteComMenosDe30Anos : Pretendente
    {
        private const int IdadeExcedente = 30;
        private const int Pontuacao = 1;

        public PretendenteComMenosDe30Anos(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
            if (dataDeNascimento < UltimaDataDeNascimentoPermitida())
                throw new ExcecaoDeDominio("O pretendente deve ter no máximo 29 anos");
        }

        private DateTime UltimaDataDeNascimentoPermitida()
        {
            return DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1);
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}