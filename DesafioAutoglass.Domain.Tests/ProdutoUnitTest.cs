using DesafioAutoglass.Domain.Entidades;
using FluentAssertions;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace DesafioAutoglass.Domain.Tests
{
    public class ProdutoUnitTest
    {
        [Fact]
        public void CreateProduto_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                Produto produto = new(1, "Farinha de Trigo", true, new DateTime(2023, 01, 10), new DateTime(2023, 04, 30), 1, "Farinha do Chefe", "09.284.153/0001-82");
            };
            action.Should()
                .NotThrow<DesafioAutoglass.Domain.Validacao.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduto_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            {
                Produto produto = new (-1, "Farinha de Trigo", true, new DateTime(2023, 01, 10), new DateTime(2023, 04, 30), 1, "Farinha do Chefe", "09.284.153 / 0001 - 82");
            };
            action.Should()
                .Throw<DesafioAutoglass.Domain.Validacao.DomainExceptionValidation>()
                 .WithMessage("Campo obrigatório 'Id' inválido.");
        }

        [Fact]
        public void CreateProduto_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () =>
            {
                Produto produto = new(1, "", true, new DateTime(2023, 01, 10), new DateTime(2023, 04, 30), 1, "Farinha do Chefe", "09.284.153/0001-82");
            };
            action.Should()
                .Throw<DesafioAutoglass.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("Campo obrigatório 'Descricao' inválido.");
        }
    }
}
