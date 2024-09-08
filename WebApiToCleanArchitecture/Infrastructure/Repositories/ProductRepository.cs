using Microsoft.EntityFrameworkCore;
using WebApiToCleanArchitecture.Domain.Entities;
using WebApiToCleanArchitecture.Domain.Interfaces;
using WebApiToCleanArchitecture.Infrastructure.Data;

namespace WebApiToCleanArchitecture.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product));
                }
                product.Id = Guid.NewGuid();
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync(); 
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Có lỗi xảy ra khi thêm sản phẩm.", ex);
            }
        }


        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(id);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa sản phẩm.", ex);
            }
        }
    }
}
