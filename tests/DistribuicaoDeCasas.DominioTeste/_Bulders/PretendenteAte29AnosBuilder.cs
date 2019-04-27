using System;
using Bogus;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.DominioTeste._Bulders
{
    public class PretendenteAte29AnosBuilder
    {
        private static int IdadeMaxima = 29;
        private string Nome { get; set; }
        private DateTime DataDeNascimento { get; set; }

        private PretendenteAte29AnosBuilder()
        {
            var faker = new Faker();

            Nome = faker.Person.FullName;
            DataDeNascimento = faker.Date.Between(DateTime.Today.AddYears(IdadeMaxima * -1), DateTime.Today);
        }

        public static PretendenteAte29AnosBuilder Instancia() {
            return new PretendenteAte29AnosBuilder();
        }

        public PretendenteAte29AnosBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PretendenteAte29AnosBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
            return this;
        }

        public PretendenteAte29Anos Construir()
        {
            return new PretendenteAte29Anos(Nome, DataDeNascimento);
        }
    }
}