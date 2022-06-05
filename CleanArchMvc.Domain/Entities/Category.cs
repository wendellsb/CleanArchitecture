using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity // garantindo que a classe Category nao seja herdada
    {
        public string Name { get; private set; }

        // construtores parametrizados
        public Category(string name)
        {
            ValidadeDomain(name); //  testa condições de possiveis erros
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value."); // testa se o Id é negativo 
            Id = id;
            ValidadeDomain(name);
        }

        public void Update(string name) // metodo para permitir atualização de nome
        {
            ValidadeDomain(name);
        }

        public ICollection<Product> Products { get; set; } // criando uma coleção de produtos

        private void ValidadeDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters!");

            Name = name;
        }
    }
}
