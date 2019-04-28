using System;
using Bogus;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Util;

namespace DistribuicaoDeCasas.DominioTeste._Builders
{
    public class PretendenteEntre30E44AnosBuilder : BuilderBase
    {
        private static int IdadeMinima = 30;
        private static int IdadeExcedente = 45;
        private string Nome;
        private DateTime DataDeNascimento;
        private Decimal Renda;

        public static PretendenteEntre30E44AnosBuilder Instancia()
        {
            return new PretendenteEntre30E44AnosBuilder();
        }

        public PretendenteEntre30E44AnosBuilder()
        {
            Nome = faker.Person.FullName;
            DataDeNascimento = faker.Date.Between(
                DateTime.Today.SubtrairAnos(IdadeExcedente).AddDays(1), 
                DateTime.Today.SubtrairAnos(IdadeMinima)
            );
            Renda = faker.Random.Decimal(0M, 2000M);
        }

        public PretendenteEntre30E44AnosBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PretendenteEntre30E44AnosBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
            return this;
        }

        public PretendenteEntre30E44AnosBuilder ComRenda(decimal renda)
        {
            Renda = renda;
            return this;
        }

        public PretendenteEntre30E44Anos Construir()
        {
            return new PretendenteEntre30E44Anos(Nome, DataDeNascimento, Renda);
        }
    }
}