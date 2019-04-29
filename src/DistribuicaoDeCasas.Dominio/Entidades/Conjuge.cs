using System;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class Conjuge : Pessoa
    {
        public Conjuge(string nome, DateTime dataDeNascimento, decimal renda) : base(nome, dataDeNascimento)
        {
            ValidadorDeDominio.Instancia().Quando(renda < 0, "A renda não pode ser negativa");
            
            Renda = renda;
        }
    }
}