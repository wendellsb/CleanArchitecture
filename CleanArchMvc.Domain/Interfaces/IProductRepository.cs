using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        // assinatura de metodo para retornar todos os produtos criando uma lista de Product
        Task<IEnumerable<Product>> GetProductsAsync();

        // assinatura de metodo para buscar pelo id de Product
        Task<Product> GetByIdAsync(int? id);

        // retornando os produtos por um id de uma categoria
        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product); // Criar um Product
        Task<Product> UpdateAsync(Product product); // Atualizar um Product
        Task<Product> RemoveAsync(Product product); // Deletar um Product
    }
}
