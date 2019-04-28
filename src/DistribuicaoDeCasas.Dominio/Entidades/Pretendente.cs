using System;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public abstract class Pretendente : Pessoa, ICriterio
    {
        public Pretendente(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento, 0) { } //Remover!!
        public Pretendente(string nome, DateTime dataDeNascimento, decimal renda) 
            : base(nome, dataDeNascimento, renda) { }

        public abstract int ObterPontuacao();
    }
}