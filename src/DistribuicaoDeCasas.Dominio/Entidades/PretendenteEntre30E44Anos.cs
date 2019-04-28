using System;
using DistribuicaoDeCasas.Dominio._Excecoes;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteEntre30E44Anos : Pretendente
    {
        private const int IdadeMinima = 30;
        private const int IdadeExcedente = 45;
        private const int Pontuacao = 2;

        public PretendenteEntre30E44Anos(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
            var idadeMinima = dataDeNascimento.AddYears(IdadeMinima);
            
            if (idadeMinima.Date > DateTime.Today.Date)
                throw new ExcecaoDeDominio("O pretendente deve ter no mínimo 30 anos");

            if (dataDeNascimento < UltimaDataDeNascimentoPermitida())
                throw new ExcecaoDeDominio("O pretendente deve ter no máximo 44 anos");
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }

        private DateTime UltimaDataDeNascimentoPermitida()
        {
            return DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1);
        }
    }
}