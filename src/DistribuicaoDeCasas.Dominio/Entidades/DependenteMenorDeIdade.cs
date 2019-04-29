using System;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class DependenteMenorDeIdade : Pessoa, IDependente
    {
        public DependenteMenorDeIdade(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
            var idade = dataDeNascimento.ObterIdadeEmAnos();

            ValidadorDeDominio.Instancia().Quando(idade >= 18, "O dependente precisa ter menos de 18 anos");
        }

        public bool EhMaiorDeIdade()
        {
            return false;
        }
    }
}