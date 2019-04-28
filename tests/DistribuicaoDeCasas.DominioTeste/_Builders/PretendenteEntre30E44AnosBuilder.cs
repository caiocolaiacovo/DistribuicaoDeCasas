using System;
using Bogus;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.DominioTeste._Builders
{
    public class PretendenteEntre30E44AnosBuilder
    {
        private static int IdadeMinima = 30;
        private static int IdadeExcedente = 45;
        private string Nome;
        private DateTime DataDeNascimento;
        private Faker faker;

        public static PretendenteEntre30E44AnosBuilder Instancia()
        {
            return new PretendenteEntre30E44AnosBuilder();
        }

        public PretendenteEntre30E44AnosBuilder()
        {
            faker = new Faker();

            Nome = faker.Person.FullName;
            DataDeNascimento = faker.Date.Between(DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1), DateTime.Today.AddYears(IdadeMinima * -1));
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

        public PretendenteEntre30E44Anos Construir()
        {
            return new PretendenteEntre30E44Anos(Nome, DataDeNascimento);
        }
    }
}