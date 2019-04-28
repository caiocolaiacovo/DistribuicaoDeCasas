using System;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class Conjuge : Pessoa
    {
        public Conjuge(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
        }
    }
}