using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using webapiefcore.Data;
using webapiefcore.Models;
using webapiefcore.ViewModels.ProductViewModels;

namespace webapiefcore.Repositories
{
    public class ProductRepository
    {
        private readonly VidottiDataContext _context;

        public ProductRepository(VidottiDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context
                .Products
                .Include(x => x.Category)
                .Select(x => new ListProductViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Category = x.Category.Title,
                    CategoryId = x.Category.Id
                })
                .AsNoTracking()
                .ToList();
        }
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}