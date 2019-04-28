using System;
using Bogus;
using DistribuicaoDeCasas.Dominio.Entidades;

namespace DistribuicaoDeCasas.DominioTeste._Builders
{
    public class PretendenteCom45AnosOuMaisBuilder : BuilderBase
    {
        private static int IdadeMinima = 45;
        private string Nome;
        private DateTime DataDeNascimento;

        public static PretendenteCom45AnosOuMaisBuilder Instancia()
        {
            return new PretendenteCom45AnosOuMaisBuilder();
        }

        public PretendenteCom45AnosOuMaisBuilder()
        {
            Nome = faker.Person.FullName;
            DataDeNascimento = DateTime.Today.AddYears(IdadeMinima * -1);
        }

        public PretendenteCom45AnosOuMaisBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PretendenteCom45AnosOuMaisBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
            return this;
        }

        public PretendenteCom45AnosOuMais Construir()
        {
            return new PretendenteCom45AnosOuMais(Nome, DataDeNascimento);
        }
    }
}