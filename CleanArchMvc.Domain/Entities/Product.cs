using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product // garantindo que a classe Product nao seja herdada
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), // verifica se a name é nulo ou vazio
                "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, // verifica se nome é menos que 3 caracters
                "Invalid name, too short, minimum 3 characters!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), // verifica se a description é nulo ou vazio
                "Invalid name. Name is required!");
        }

        // relacionando o produto com uma categoria
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
