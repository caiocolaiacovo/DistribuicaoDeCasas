using System;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class DependenteMaiorDeIdade : Pessoa, IDependente
    {
        public DependenteMaiorDeIdade(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
            var idade = dataDeNascimento.ObterIdadeEmAnos();

            ValidadorDeDominio.Instancia().Quando(idade < 18, "O dependente precisa ter 18 anos ou mais");
        }

        public bool EhMaiorDeIdade()
        {
            return true;
        }
    }
}