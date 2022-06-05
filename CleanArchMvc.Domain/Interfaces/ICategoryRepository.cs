using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        // assinatura de metodo para obter todas as categorias criando uma lista de Category
        Task<IEnumerable<Category>> GetCategories();

        // assinatura de metodo para buscar pelo id 
        Task<Category> GetById(int? id);

        Task<Category> Create(Category category); // Criar uma categoria
        Task<Category> Update(Category category); // Atualizar uma categopria
        Task<Category> Remove(Category category); // Deletar uma categoria
    }
}
