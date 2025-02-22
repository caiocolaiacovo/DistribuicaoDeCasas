using System;
using System.Collections.Generic;
using DistribuicaoDeCasas.Dominio._Excecoes;
using DistribuicaoDeCasas.Dominio._Util;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public abstract class Pessoa
    {
        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public decimal Renda { get; protected set; }

        public Pessoa(string nome, DateTime dataDeNascimento)
        {
            var dataEstaNoFuturo = DateTime.Today.CompareTo(dataDeNascimento) == -1;

            ValidadorDeDominio
                .Instancia()
                .Quando(string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(nome.Trim()), "Nome obrigatório")
                .Quando(dataEstaNoFuturo, "Data de nascimento não pode ser maior que a data atual");

            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }
    }
}