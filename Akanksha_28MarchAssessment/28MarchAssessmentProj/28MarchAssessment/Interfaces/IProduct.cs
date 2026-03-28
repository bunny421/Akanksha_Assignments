using _28MarchAssessment.Models;

namespace _28MarchAssessment.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product?> UpdateAsync(Product product);
        Task<Product?> DeleteAsync(int id);

    }
}
