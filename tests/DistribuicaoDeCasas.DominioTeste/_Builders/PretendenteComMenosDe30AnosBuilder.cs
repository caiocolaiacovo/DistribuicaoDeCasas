using System;
using Bogus;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.DominioTeste._Builders
{
    public class PretendenteComMenosDe30AnosBuilder
    {
        private static int IdadeExcedente = 30;
        private string Nome { get; set; }
        private DateTime DataDeNascimento { get; set; }

        private PretendenteComMenosDe30AnosBuilder()
        {
            var faker = new Faker();

            Nome = faker.Person.FullName;
            DataDeNascimento = faker.Date.Between(DateTime.Today.AddYears(IdadeExcedente * -1).AddDays(1), DateTime.Today);
        }

        public static PretendenteComMenosDe30AnosBuilder Instancia() {
            return new PretendenteComMenosDe30AnosBuilder();
        }

        public PretendenteComMenosDe30AnosBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PretendenteComMenosDe30AnosBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
            return this;
        }

        public PretendenteComMenosDe30Anos Construir()
        {
            return new PretendenteComMenosDe30Anos(Nome, DataDeNascimento);
        }
    }
}