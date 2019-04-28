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
            var idade = dataDeNascimento.ObterIdadeEmAnos();

            ValidadorDeDominio
                .Instancia()
                .Quando(idade >= IdadeExcedente, "O pretendente deve ter no máximo 29 anos");
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }
    }
}