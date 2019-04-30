using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DistribuicaoDeCasas.Dominio.Contratos;
using DistribuicaoDeCasas.Dominio.Entidades;
using DistribuicaoDeCasas.DominioTeste._Base;
using Moq;

namespace DistribuicaoDeCasas.DominioTeste._Builders
{
    public class FamiliaBuilder : BuilderBase
    {
        private Mock<IPretendente> Pretendente;
        private Mock<IConjuge> Conjuge;
        private List<IDependente> Dependentes;

        public static FamiliaBuilder Instancia()
        {
            return new FamiliaBuilder();
        }

        public FamiliaBuilder()
        {
            Pretendente = new Mock<IPretendente>();
            Conjuge = new Mock<IConjuge>();
            Dependentes = new List<IDependente>();
        }

        public FamiliaBuilder ComPretendente(Mock<IPretendente> pretendente)
        {
            Pretendente = pretendente;
            return this;
        }

        public FamiliaBuilder ComConjuge(Mock<IConjuge> conjuge)
        {
            Conjuge = conjuge;
            return this;
        }

        public FamiliaBuilder ComDependentes(List<IDependente> dependentes)
        {
            Dependentes = dependentes;
            return this;
        }

        public Familia Construir()
        {
            return new Familia(Pretendente.Object, Conjuge.Object, Dependentes);
        }
    }
}