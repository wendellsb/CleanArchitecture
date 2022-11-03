using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity // garantindo que a classe Product nao seja herdada com o "sealed"
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //construtor sem o id de category
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }


        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            // verifica se a name é nulo ou vazio
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required!");

            // verifica se nome é menor que 3 caracters
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters!");

            // verifica se a description é nulo ou vazio
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), 
                "Invalid name. Name is required!");


            // verifica se description menos que 5 caracteres
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters!");

            // verifica se o price é menor que zero
            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            // verifica se o stock é menor que zero
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            // verifica se image maior que 250 caracteres
            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters!");


            // criando objeto caso os valores passados sejam validos
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        // relacionando o produto com uma categoria
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
