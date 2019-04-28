using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteComMenosDe30Anos : Pretendente
    {
        private const int IdadeExcedente = 30;
        private const int Pontuacao = 1;

        public PretendenteComMenosDe30Anos(string nome, DateTime dataDeNascimento, decimal renda) 
            : base(nome, dataDeNascimento, renda)
        {
            ValidadorDeDominio
                .Instancia()
                .Quando(dataDeNascimento < UltimaDataDeNascimentoPermitida(), "O pretendente deve ter no máximo 29 anos");
        }

        private DateTime UltimaDataDeNascimentoPermitida()
        {
            return DateTime.Today.SubtrairAnos(IdadeExcedente).AddDays(1);
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}