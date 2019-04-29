using System;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public abstract class Pretendente : Pessoa
    {
        public Pretendente(string nome, DateTime dataDeNascimento, decimal renda) 
            : base(nome, dataDeNascimento) 
        { 
            ValidadorDeDominio
                .Instancia()
                .Quando(renda < 0M, "A renda não pode ser negativa");

            Renda = renda;
        }
    }
}