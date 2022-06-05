using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName="Criando produto com parametros validos")]
        public void CreateProduct_WithValidParameters_ResultObjectValidStales()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando produto com id invalido")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Criando produto com name menor que 3 caracteres")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters!");
        }

        [Fact(DisplayName = "Criando produto com name vazio")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact(DisplayName = "Criando produto com name nulo")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando produto com description menor que 5 caracteres")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Product Name", "Pro", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters!");
        }

        [Fact(DisplayName = "Criando produto com price invalido")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1.0m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Criando produto com stock invalido")]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Fact(DisplayName = "Criando produto com image maior que 250 caracteres")]
        public void CreateProduct_LongImageValue_DomainExceptionLongImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "productproductimageim" +
                "ageproductproductimageimagproductproductimageimagproductproductimageimagproductproductimageimagproductp" +
                "roductimageimageproductproductimageimagproductproductimageimagproductproductimageimagproductproductimage" +
                "imagproductproductimageimageproductproductimageimagproductproductimageimagproductproductimageimagproduct" +
                "productimageimagproductproductimageimageproductproductimageimagproductproductimageimagproductproductimag" +
                "eimagproductproductimageimagproductproductimageimageproductproductimageimagproductproductimageimagproduc" +
                "tproductimageimagproductproductimageimagproductproductimageimageproductproductimageimagproductproductima" +
                "geimagproductproductimageimagproductproductimageimagproductproductimageimageproductproductimageimagprodu" +
                "ctproductimageimagproductproductimageimagproductproductimageimagproductproductimageimageproductproducti" +
                "mageimagproductproductimageimagproductproductimageimagproductproductimageimagproductproductimageimagepr" +
                "oductproductimageimagproductproductimageimagproductproductimageimagproductproductimageimagproductproduct" +
                "imageimageproductproductimageimagproductproductimageimagproductproductimageimagproductproductimageimag");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters!");
        }

        [Fact(DisplayName = "Criando produto com image nulo")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando produto com image nulo")]
        public void CreateProduct_WithNullImageName_NoNullDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}
