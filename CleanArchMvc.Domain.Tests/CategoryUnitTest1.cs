using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        //Fact - Marca o metodo como um teste de unidade para o xUnit
        //DisplayName - Exibe como nome do teste no Test Explorer
        //CreateCategory_WithValidParametrs_ResultObjectValidState()
        //Action - Encapsula um m�todo que n�o tem par�metros e n�o retorna valor
        //Should - Retorna um objeto que testa uma condi��o(NotThrow) como uma instru��o Assert

        [Fact(DisplayName = "Criando Categoria com parametros validos")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>(); // n�o lan�a a exce��o

        }

        [Fact(DisplayName = "Criando Categoria com Id negativo")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>() // lan�a a exce��o
                .WithMessage("Invalid Id value."); // valida a mensagem que espera de retorno
        }

        [Fact(DisplayName = "Criando Categoria com nome menor que 3 caracteres")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters!");
        }

        [Fact(DisplayName = "Criando Categoria com nome vazio")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact(DisplayName = "Criando Categoria com nome nulo")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
