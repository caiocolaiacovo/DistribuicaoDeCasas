using System;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio._Util;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class PretendenteCom45AnosOuMais : Pretendente
    {
        private const int IdadeMinima = 45;
        private const int Pontuacao = 3;

        public PretendenteCom45AnosOuMais(string nome, DateTime dataDeNascimento, decimal renda) 
            : base(nome, dataDeNascimento,renda)
        {
            var idade = dataDeNascimento.ObterIdadeEmAnos();
            
            ValidadorDeDominio
                .Instancia()
                .Quando(idade < IdadeMinima, "O pretendente deve ter no mínimo 45 anos");
        }

        public override int ObterPontuacao()
        {
            return Pontuacao;
        }
    } 
}