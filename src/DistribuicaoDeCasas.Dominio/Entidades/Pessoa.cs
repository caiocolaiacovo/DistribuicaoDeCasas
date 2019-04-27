using System;
using DistribuicaoDeCasas.Dominio._Excecoes;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public abstract class Pessoa
    {
        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }

        public Pessoa(string nome, DateTime dataDeNascimento)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(nome.Trim()))
                throw new ExcecaoDeDominio("Nome obrigatório");

            var dataEstaNoFuturo = DateTime.Today.CompareTo(dataDeNascimento) == -1;

            if (dataEstaNoFuturo)
                throw new ExcecaoDeDominio("Data de nascimento não pode ser maior que a data atual");

            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }
    }
}