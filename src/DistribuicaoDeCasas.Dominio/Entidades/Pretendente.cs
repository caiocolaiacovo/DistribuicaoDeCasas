using System;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public abstract class Pretendente : Pessoa, Criterio
    {
        public Pretendente(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento) { }

        public abstract int ObterPontuacao();
    }
}