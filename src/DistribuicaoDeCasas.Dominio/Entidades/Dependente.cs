using System;
using DistribuicaoDeCasas.Dominio._Util;
using DistribuicaoDeCasas.Dominio.Contratos;

namespace DistribuicaoDeCasas.Dominio.Entidades
{
    public class Dependente : Pessoa
    {
        public Dependente(string nome, DateTime dataDeNascimento) : base(nome, dataDeNascimento)
        {
        }

        public bool EhMenorDeIdade()
        {
            var idade = DataDeNascimento.ObterIdadeEmAnos();

            if (idade < 18)
                return true;

            return false;
        }
    }
}