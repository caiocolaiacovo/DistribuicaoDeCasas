using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio._Util;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteEntre30E44Anos : Pretendente
    {
        private const int IdadeMinima = 30;
        private const int IdadeExcedente = 45;
        private const int Pontuacao = 2;

        public PretendenteEntre30E44Anos(string nome, DateTime dataDeNascimento, decimal renda) 
            : base(nome, dataDeNascimento, renda)
        {
            var idade = dataDeNascimento.ObterIdadeEmAnos();
            
            ValidadorDeDominio
                .Instancia()
                .Quando(idade < IdadeMinima, "O pretendente deve ter no mínimo 30 anos")
                .Quando(idade >= IdadeExcedente, "O pretendente deve ter no máximo 44 anos");
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